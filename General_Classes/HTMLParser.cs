using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    /// <summary>
    /// Using MSHTML as a UI-less HTML parser
    /// Able to assign cookies to the document object
    /// Handles username and password via InternetSetOption
    /// Username and Password can also be supplied within the URL to process
    /// Please note that this parser does not handle redirects
    /// Usage: refer to frmHTMLParser.cs
    public class HTMLParser :
        IPropertyNotifySink,
        IOleClientSite
    {
        public HTMLParser()
        {
        }

        #region Local Variables and event
        private string m_Url = string.Empty;
        private object m_ID = null;
        private IHTMLDocument2 m_pMSHTML = null;
        //Password and username are set using InternetSetOption
        private string m_Username = string.Empty;
        private string m_Password = string.Empty;
        private bool m_Done = false;
        private int m_dwCookie = 0;
        private IOleObject m_WBOleObject = null;
        private IOleControl m_WBOleControl = null;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_Flags = (int)(DOCDOWNLOADCTLFLAG.DOWNLOADONLY | DOCDOWNLOADCTLFLAG.NO_BEHAVIORS
            | DOCDOWNLOADCTLFLAG.NO_CLIENTPULL | DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS
            | DOCDOWNLOADCTLFLAG.NO_JAVA | DOCDOWNLOADCTLFLAG.NO_METACHARSET
            | DOCDOWNLOADCTLFLAG.NO_RUNACTIVEXCTLS | DOCDOWNLOADCTLFLAG.NO_SCRIPTS
            | DOCDOWNLOADCTLFLAG.SILENT);
        private const string COMPLETE = "complete";
        /// <summary>
        /// The only event fired by this class upon completion of parsing
        /// </summary>
        public event HtmlParsingDoneEventHandler HtmlParsingDoneEvent = null;
        #endregion

        #region Properties
        /// <summary>
        /// Unique ID for this instance, set by client
        /// </summary>
        public object U_ID
        {
            get
            {
                return this.m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        /// <summary>
        /// Original URL used for parsing
        /// </summary>
        public string OriginalURL
        {
            get
            {
                return m_Url;
            }
            set
            {
                this.m_Url = value;
            }
        }

        /// <summary>
        /// Accessor for our document
        /// </summary>
        public IHTMLDocument2 ParserDocument
        {
            get
            {
                return this.m_pMSHTML;
            }
        }

        public bool DoneParsing
        {
            get
            {
                return this.m_Done;
            }
        }

        public string UserName
        {
            get { return m_Username; }
            set { m_Username = value; }
        }

        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Only public method which starts the parsing process
        /// When parsing is done, we receive a DISPID_READYSTATE dispid
        /// in IPropertyNotifySink.OnChanged implementation
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="cookie"></param>
        public void StartParsing(string Url, string cookie)
        {
            IntPtr pUsername = IntPtr.Zero;
            IntPtr pPassword = IntPtr.Zero;
            try
            {
                if (string.IsNullOrEmpty(Url))
                    throw new ApplicationException("Url must have a valid value!");

                //Create a new MSHTML, throws exception if fails
                Type htmldoctype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_HTMLDocument, true);
                //Using Activator inplace of CoCreateInstance, returns IUnknown
                //which we cast to a IHtmlDocument2 interface
                m_pMSHTML = (IHTMLDocument2)System.Activator.CreateInstance(htmldoctype);

                //Get the IOleObject
                m_WBOleObject = (IOleObject)m_pMSHTML;
                //Set client site
                int iret = m_WBOleObject.SetClientSite(this);

                //Connect for IPropertyNotifySink
                m_WBOleControl = (IOleControl)m_pMSHTML;
                m_WBOleControl.OnAmbientPropertyChange(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL);

                //Get connectionpointcontainer
                IConnectionPointContainer cpCont = (IConnectionPointContainer)m_pMSHTML;
                cpCont.FindConnectionPoint(ref Iid_Clsids.IID_IPropertyNotifySink, out m_WBConnectionPoint);
                //Advice
                m_WBConnectionPoint.Advise(this, out m_dwCookie);

                m_Done = false;
                m_Url = Url;

                if (!string.IsNullOrEmpty(cookie))
                    m_pMSHTML.cookie = cookie;

                //Set up username and password if provided
                pUsername = Marshal.StringToCoTaskMemAnsi(m_Username);
                if (pUsername != IntPtr.Zero)
                    WinApis.InternetSetOption(IntPtr.Zero,
                        InternetSetOptionFlags.INTERNET_OPTION_USERNAME,
                        pUsername, m_Username.Length);
                pPassword = Marshal.StringToCoTaskMemAnsi(m_Password);
                if (pPassword != IntPtr.Zero)
                    WinApis.InternetSetOption(IntPtr.Zero,
                        InternetSetOptionFlags.INTERNET_OPTION_PASSWORD,
                        pPassword, m_Password.Length);

                //Load
                IPersistMoniker persistMoniker = (IPersistMoniker)m_pMSHTML;
                IMoniker moniker = null;
                WinApis.CreateURLMoniker(null, m_Url, out moniker);
                if (moniker == null)
                    return;
                IBindCtx bindContext = null;
                WinApis.CreateBindCtx((uint)0, out bindContext);
                if (bindContext == null)
                    return;
                persistMoniker.Load(1, moniker, bindContext, 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (pUsername != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pUsername);
                if (pPassword != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pPassword);
            }
        }

        public void StopParsing()
        {
            try
            {
                //UnAdvice and clean up
                if ((m_WBConnectionPoint != null) && (m_dwCookie > 0))
                    m_WBConnectionPoint.Unadvise(m_dwCookie);
                if (m_WBOleObject != null)
                {
                    m_WBOleObject.Close((uint)OLEDOVERB.OLECLOSE_NOSAVE);
                    m_WBOleObject.SetClientSite(null);
                }
                if (m_pMSHTML != null)
                {
                    Marshal.ReleaseComObject(m_pMSHTML);
                    m_pMSHTML = null;
                }
                if (m_WBConnectionPoint != null)
                {
                    Marshal.ReleaseComObject(m_WBConnectionPoint);
                    m_WBConnectionPoint = null;
                }
                if (m_WBOleControl != null)
                {
                    Marshal.ReleaseComObject(m_WBOleControl);
                    m_WBOleControl = null;
                }
                if (m_WBOleObject != null)
                {
                    Marshal.ReleaseComObject(m_WBOleObject);
                    m_WBOleObject = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [DispId(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL)]
        public int Idispatch_AmbiantDlControl_Invoke_Handler()
        {
            return m_Flags;
        } 
        #endregion

        #region IPropertyNotifySink Members

        int IPropertyNotifySink.OnChanged(int dispID)
        {
            if ((dispID == HTMLDispIDs.DISPID_READYSTATE) &&
                (m_pMSHTML != null) &&
                (m_pMSHTML.readyState.ToLower().Equals(COMPLETE)) &&
                (HtmlParsingDoneEvent != null))
            {
                m_Done = true;
                //Firing event to indicate the parsing is done
                HtmlParsingDoneEventArg arg = new HtmlParsingDoneEventArg(this.m_Url, this.m_ID, this.m_pMSHTML);
                HtmlParsingDoneEvent(this, arg);
            }
            return Hresults.NOERROR;
        }

        int IPropertyNotifySink.OnRequestEdit(int dispID)
        {
            // Property changes are OK any time as far as this parser is concerned!
            return Hresults.NOERROR;
        }

        #endregion

        #region IOleClientSite Members

        int IOleClientSite.SaveObject()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.GetMoniker(uint dwAssign, uint dwWhichMoniker, out System.Runtime.InteropServices.ComTypes.IMoniker ppmk)
        {
            ppmk = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.GetContainer(out IOleContainer ppContainer)
        {
            ppContainer = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.ShowObject()
        {
            return Hresults.S_OK;
        }

        int IOleClientSite.OnShowWindow(bool fShow)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.RequestNewObjectLayout()
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion
    }

    #region HtmlParsingDoneEvent
    public delegate void HtmlParsingDoneEventHandler(object sender, HtmlParsingDoneEventArg e);
    public class HtmlParsingDoneEventArg : System.EventArgs
    {
        public HtmlParsingDoneEventArg(string originalURL, object UniqueID, IHTMLDocument2 DocumentObject)
        {
            this.oriURL = originalURL;
            this.ID = UniqueID;
            this.MSHTMDocument = DocumentObject;

        }
        public IHTMLDocument2 MSHTMDocument = null;
        public string oriURL = string.Empty;
        public object ID = null;
    }
    #endregion

}
