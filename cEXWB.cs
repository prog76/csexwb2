//************************************************************************************
// csEXWB control - The most complete C# Webbrowser control.
//
// Auther: MH
// Email: mehr13@hotmail.com
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so.
//
// Although reasonable care has been taken to ensure the correctness of this
// implementation, this code should never be used in
// any application without proper verification and testing.
//************************************************************************************


using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using IfacesEnumsStructsClasses;
using System.Diagnostics;
using System.Threading;

namespace csExWB
{
    public class cEXWB : 
        Control,
        IOleClientSite,
        IOleInPlaceSite,
        IDocHostShowUI,
        IDocHostUIHandler,
        DWebBrowserEvents2,
        IfacesEnumsStructsClasses.IDropTarget,
        IfacesEnumsStructsClasses.IServiceProvider,
        IHttpSecurity,
        IWindowForBindingUI,
        INewWindowManager, //WinXP sp2 and up
        IAuthenticate,
        IOleCommandTarget,
        IInternetSecurityManager,
        IHTMLEventCallBack,
        IProtectFocus, //IE7 + Vista
        IHTMLOMWindowServices, //WinXP sp2 and up
        IHTMLEditHost //Please refer to IHTMLEditHost.cs for description
    {

#region Events and EventArgs Memebrs

        public event csExWB.DocumentCompleteEventHandler DocumentComplete = null;
        public event csExWB.BeforeNavigate2EventHandler BeforeNavigate2 = null;
        public event csExWB.ClientToHostWindowEventHandler ClientToHostWindow = null;
        public event csExWB.CommandStateChangeEventHandler CommandStateChange = null;
        public event csExWB.DownloadBeginEventHandler DownloadBegin = null;
        public event csExWB.DownloadCompleteEventHandler DownloadComplete = null;
        public event csExWB.FileDownloadEventHandler FileDownload = null;
        public event csExWB.NavigateComplete2EventHandler NavigateComplete2 = null;
        public event csExWB.NavigateErrorEventHandler NavigateError = null;
        public event csExWB.NewWindow2EventHandler NewWindow2 = null;
        public event csExWB.NewWindow3EventHandler NewWindow3 = null;
        public event csExWB.PrintTemplateInstantiationEventHandler PrintTemplateInstantiation = null;
        public event csExWB.PrintTemplateTeardownEventHandler PrintTemplateTeardown = null;
        public event csExWB.PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange = null;
        public event csExWB.ProgressChangeEventHandler ProgressChange = null;
        public event csExWB.PropertyChangeEventHandler PropertyChange = null;
        public event csExWB.SetSecureLockIconEventHandler SetSecureLockIcon = null;
        public event csExWB.StatusTextChangeEventHandler StatusTextChange = null;
        public event csExWB.TitleChangeEventHandler TitleChange = null;
        public event csExWB.WindowClosingEventHandler WindowClosing = null;
        public event csExWB.WindowSetHeightEventHandler WindowSetHeight = null;
        public event csExWB.WindowSetLeftEventHandler WindowSetLeft = null;
        public event csExWB.WindowSetResizableEventHandler WindowSetResizable = null;
        public event csExWB.WindowSetTopEventHandler WindowSetTop = null;
        public event csExWB.WindowSetWidthEventHandler WindowSetWidth = null;
        public event csExWB.WBDragEnterEventHandler WBDragEnter = null;
        public event csExWB.WBDragLeaveEventHandler WBDragLeave = null;
        public event csExWB.WBDragOverEventHandler WBDragOver = null;
        public event csExWB.WBDropEventHandler WBDragDrop = null;
        public event csExWB.WBKeyDownEventHandler WBKeyDown = null;
        public event csExWB.WBKeyUpEventHandler WBKeyUp = null;
        public event csExWB.ContextMenuEventHandler WBContextMenu = null;
        public event csExWB.GetOptionKeyPathEventHandler WBGetOptionKeyPath = null;
        public event csExWB.DocHostShowUIShowMessageEventHandler WBDocHostShowUIShowMessage = null;
        public event csExWB.DocumentCompleteExEventHandler DocumentCompleteEX = null;
        public event csExWB.AuthenticateEventHandler WBAuthenticate = null;
        public event csExWB.SecurityProblemEventHandler WBSecurityProblem = null;
        public event csExWB.EvaluateNewWindowEventHandler WBEvaluteNewWindow = null;
        public event csExWB.ScriptErrorEventHandler ScriptError = null;
        public event csExWB.UpdatePageStatusEventHandler UpdatePageStatus = null;
        public event csExWB.RefreshBeginEventHandler RefreshBegin = null;
        public event csExWB.RefreshEndEventHandler RefreshEnd = null;
        public event csExWB.ProcessUrlActionEventHandler ProcessUrlAction = null;
        public event csExWB.AllowFocusChangeEventHandler AllowFocusChange = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_moveTo = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_moveBy = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_resizeTo = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_resizeBy = null;

        public event csExWB.HTMLEventHandler HTMLEvent = null;
        private HTMLEventArgs HtmlEventArg = new HTMLEventArgs();

        private TitleChangeEventArgs TitleChangeEvent = new TitleChangeEventArgs();
        private DocumentCompleteEventArgs DocumentCompleteEvent = new DocumentCompleteEventArgs();
        private DocumentCompleteExEventArgs DocumentCompleteExEvent = new DocumentCompleteExEventArgs();
        private StatusTextChangeEventArgs StatusTextChangeEvent = new StatusTextChangeEventArgs();
        private ProgressChangeEventArgs ProgressChangeEvent = new ProgressChangeEventArgs();
        private CommandStateChangeEventArgs CommandStateChangeEvent = new CommandStateChangeEventArgs();
        private PropertyChangeEventArgs PropertyChangeEvent = new PropertyChangeEventArgs();
        private BeforeNavigate2EventArgs BeforeNavigate2Event = new BeforeNavigate2EventArgs();
        private NavigateComplete2EventArgs NavigateComplete2Event = new NavigateComplete2EventArgs();
        private NewWindow2EventArgs NewWindow2Event = new NewWindow2EventArgs();
        private NewWindow3EventArgs NewWindow3Event = new NewWindow3EventArgs();
        private WindowSetResizableEventArgs WindowSetResizableEvent = new WindowSetResizableEventArgs();
        private WindowSetLeftEventArgs WindowSetLeftEvent = new WindowSetLeftEventArgs();
        private WindowSetTopEventArgs WindowSetTopEvent = new WindowSetTopEventArgs();
        private WindowSetWidthEventArgs WindowSetWidthEvent = new WindowSetWidthEventArgs();
        private WindowSetHeightEventArgs WindowSetHeightEvent = new WindowSetHeightEventArgs();
        private WindowClosingEventArgs WindowClosingEvent = new WindowClosingEventArgs();
        private ClientToHostWindowEventArgs ClientToHostWindowEvent = new ClientToHostWindowEventArgs();
        private SetSecureLockIconEventArgs SetSecureLockIconEvent = new SetSecureLockIconEventArgs();
        private FileDownloadEventArgs FileDownloadEvent = new FileDownloadEventArgs();
        private NavigateErrorEventArgs NavigateErrorEvent = new NavigateErrorEventArgs();
        private PrintTemplateInstantiationEventArgs PrintTemplateInstantiationEvent = new PrintTemplateInstantiationEventArgs();
        private PrintTemplateTeardownEventArgs PrintTemplateTeardownEvent = new PrintTemplateTeardownEventArgs();
        private PrivacyImpactedStateChangeEventArgs PrivacyImpactedStateChangeEvent = new PrivacyImpactedStateChangeEventArgs();
        private UpdatePageStatusEventArgs UpdatePageStatusEvent = new UpdatePageStatusEventArgs();

        private DocHostShowUIShowMessageEventArgs DocHostShowUIShowMessageEvent = new DocHostShowUIShowMessageEventArgs();
        private ContextMenuEventArgs ContextMenuEvent = new ContextMenuEventArgs();
        private GetOptionKeyPathEventArgs GetOptionKeyPathEvent = new GetOptionKeyPathEventArgs();
        private WBKeyDownEventArgs WBKeyDownEvent = new WBKeyDownEventArgs();
        private WBKeyUpEventArgs WBKeyUpEvent = new WBKeyUpEventArgs();
        private EvaluateNewWindowEventArgs EvaluateNewWindowEvent = new EvaluateNewWindowEventArgs();
        private SecurityProblemEventArgs SecurityProblemEvent = new SecurityProblemEventArgs();
        private AuthenticateEventArgs AuthenticateEvent = new AuthenticateEventArgs();
        private WBDragEnterEventArgs WBDragEnterEvent = new WBDragEnterEventArgs();
        private WBDragOverEventArgs WBDragOverEvent = new WBDragOverEventArgs();
        private WBDropEventArgs WBDropEvent = new WBDropEventArgs();
        private ScriptErrorEventArgs ScriptErrorEvent = new ScriptErrorEventArgs();
        private ProcessUrlActionEventArgs ProcessUrlActionEvent = new ProcessUrlActionEventArgs();
        private AllowFocusChangeEventArgs AllowFocusChangeEvent = new AllowFocusChangeEventArgs();
        private HTMLOMWindowServicesEventArgs HTMLOMWindowServicesEvent = new HTMLOMWindowServicesEventArgs();

#endregion //Events and EventArgs Memebrs

#region Local members

        //Required by designer
        private System.ComponentModel.IContainer components = null;

        //Use the internal dragdrop in combination with WBDrag/Drop events
        private bool m_bUseInternalDragDrop = true;
        //Fires DocumentCompleteEx, with an additional parameter "docsource"
        //containning the source of the incoming document before any scripts
        //are executed.
        private bool m_bSendSourceOnDocumentCompleteWBEx = false;
        //this.Control->ShellEmbedding->ShellDocObj->IEServer
        private IntPtr m_hWBServerHandle = (IntPtr)0;
        private IntPtr m_hWBShellDocObjHandle = (IntPtr)0;
        private IntPtr m_hWBShellEmbeddingHandle = (IntPtr)0;
        //Startup URL + LocationUrl
        private const string m_AboutBlank = "about:blank";
        private string m_sUrl = "about:blank";
        private bool m_bCanGoBack = false;
        private bool m_bCanGoForward = false;
        private TextSizeWB m_enumTextSize = TextSizeWB.Medium; //default
        //Default, selecttext+no3dborder+flatscrollbars+themes(xp look)
        private DOCHOSTUIFLAG m_DocHostUiFlags = DOCHOSTUIFLAG.NO3DBORDER | 
            DOCHOSTUIFLAG.FLAT_SCROLLBAR | DOCHOSTUIFLAG.THEME;
        private DOCHOSTUIDBLCLK m_DocHostUiDbClkFlag = DOCHOSTUIDBLCLK.DEFAULT;
        //DLCTL_DLIMAGES
        private DOCDOWNLOADCTLFLAG m_DLCtlFlags = DOCDOWNLOADCTLFLAG.DLIMAGES |
            DOCDOWNLOADCTLFLAG.BGSOUNDS | DOCDOWNLOADCTLFLAG.VIDEOS;

        //Used in find
        private IHTMLTxtRange m_txtrange = null;
        private string m_sLastSearch = string.Empty;
        //Pointer to our browser interface
        private IWebBrowser2 m_WBWebBrowser2 = null;
        //IntPtr.Zero
        private IntPtr m_NullPointer = IntPtr.Zero;
        private tagMSG m_NullMsg = new tagMSG();
        private object m_NullObject = null;
        //ConnectionPoint Cookie
        private int m_dwCookie = 0;
        //Keep track of our location + size
        private tagRECT m_WBRect = new tagRECT(0, 0, 0, 0);
        //WB IUnknown and other ifaces
        private object m_WBUnknown = null;
        private IOleObject m_WBOleObject = null;
        private IOleInPlaceObject m_WBOleInPlaceObject = null;
        private IOleCommandTarget m_WBOleCommandTarget = null;
///Taken from article:
///Invoke Hidden Commands in Your Web Browser
///http://www.codeguru.com/cpp/i-n/ieprogram/openfaq/article.php/c8163/
///As I stated above, the IDocHostUIHandler::ShowContextMenu demo of
///"WebBrowser Customization" in the MSDN shows a way to manually build
///IE's context menu from correlative resource file "SHDOCLC.DLL".
///So, open the file "SHDOCLC.DLL" by using some resource explorer software
///such as "eXeScope", we can find all the Command IDs (also menu item IDs)
///used by the WebBrowser Control under menu resources, and all of them are
///the same in IE 4.x/5.x/6.x according to my tesing.

        //command send to IE server hwnd
        private const int ID_IE_CONTEXTMENU_ADDFAV = 2261;
        //comands send to shelldocobject hwnd
        private const int ID_IE_FIND                     = 67;
        private const int ID_IE_PAGESETUP                = 259;
        private const int ID_IE_PRINT                    = 260;
        private const int ID_IE_PRINTPREVIEW             = 277;
        private const int ID_IE_FILE_NEWMAIL             = 279;
        private const int ID_IE_FILE_SENDPAGE            = 282;
        private const int ID_IE_FILE_SENDLINK            = 283;
        private const int ID_IE_FILE_SENDDESKTOPSHORTCUT = 284;
        private const int ID_IE_FILE_IMPORTEXPORT        = 374;
        private const int ID_IE_FILE_ADDTRUST            = 376;
        private const int ID_IE_FILE_ADDLOCAL            = 377;
        private const int ID_IE_FILE_NEWCALL             = 395; //Internet call
        //To catch Refresh event!
        // counter to monitor number of requests to BeforeNavigate2 vs number of requests to DownloadBegin.
        private int m_nPageCounter = 0;
        // counter to monitor number of DownloadBegin and DownloadEnd calls.
        private int m_nObjCounter = 0;
        // variable to tell us whether a refresh request has started.	
        private bool m_bIsRefresh = false;
        //browser thumb image cache
        private Image m_WBThumbImg = null;

        //Used to handle HtmlDocument and HtmlWindow events
        private bool m_WantHTMLEvents = false;
        private bool m_WantHtmlDocumentEvents = false;
        private bool m_WantHtmlWindowEvents = false;
        //These instances take care of the toplevel document and window
        //For frameset sites, we use a collection of below classes
        private cHTMLDocumentEvents m_TopLevelHtmlDocumentevents = new cHTMLDocumentEvents();
        private cHTMLWindowEvents m_TopLevelHtmlWindowEvents = new cHTMLWindowEvents();
        //Template based lists
        private List<cHTMLDocumentEvents> m_HtmlDocumentEventsList = new List<cHTMLDocumentEvents>();
        private List<cHTMLWindowEvents> m_HtmlWindowEventsList = new List<cHTMLWindowEvents>();

        private int m_SecureLockIcon = (int)SecureLockIconConstants.secureLockIconUnsecure;

        private object m_WinExternal = null;

        //allow or disallow HTML dialogs launched using showModelessDialog() + showModalDialog() methods!
        //Using CBT window hook
        private WindowsHookUtil.HookInfo m_CBT = new WindowsHookUtil.HookInfo(CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT);
        private const string m_HTMLDlgClassName = "Internet Explorer_TridentDlgFrame";
        private IntPtr m_HookHandled = IntPtr.Zero;
        private string m_strTemp = string.Empty;
        private int m_NCode = 0;

        //To subclass Internet Explorer_Server handle in order to catch back and forward buttons
        private IEServerWindow m_ieServerWindow = null;
        private bool m_DocDone = false;

#endregion //Local members

#region Properties list

        [Category("ExWB")]
        public bool MainDocumentFullyLoaded
        {
            get { return m_DocDone; }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public int WBDOCDOWNLOADCTLFLAG
        {
            get { return (int)m_DLCtlFlags; }
            set
            {
                m_DLCtlFlags = (DOCDOWNLOADCTLFLAG)value;
                if( ( m_WBUnknown != null ) && (m_WBWebBrowser2 != null) )
                {
                    //Signal change of DL property
                    //so MSHTML call our Invoke method through Dispatch
                    //Otherwise refreshing the page will have no effect
                    //MSHTML does not know of new flags set by us
                    //QI for IOleControl
                    IOleControl pOC = m_WBUnknown as IOleControl;
                    if(pOC != null)
                        pOC.OnAmbientPropertyChange(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL);
                }
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadImages
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.DLIMAGES) != 0); }
            set { SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.DLIMAGES, value); }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadSounds
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.BGSOUNDS) != 0); }
            set { SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.BGSOUNDS, value); }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadVideo
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.VIDEOS) != 0); }
            set { SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.VIDEOS, value); }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadActiveX
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS, true);
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadJava
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_JAVA) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_JAVA, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_JAVA, true);
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadFrames
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD, true);
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadScripts
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_SCRIPTS) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_SCRIPTS, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_SCRIPTS, true);
            }
        }

        [Category("DOCHOSTUIFLAG")]
        public int WBDOCHOSTUIFLAG
        {
            get { return (int)m_DocHostUiFlags; }
            set { m_DocHostUiFlags = (DOCHOSTUIFLAG)value; }
        }

        [Category("DOCHOSTUIFLAG")]
        public bool Border3DEnabled
        {
            get { return ((m_DocHostUiFlags & DOCHOSTUIFLAG.NO3DBORDER) == 0); }
            set 
            {
                if(value)
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.NO3DBORDER, false);
                else
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.NO3DBORDER, true);
            }
        }

        [Category("DOCHOSTUIFLAG")]
        public bool ScrollBarsEnabled
        {
            get { return ((m_DocHostUiFlags & DOCHOSTUIFLAG.SCROLL_NO) == 0); }
            set
            {
                if (value)
                {
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.SCROLL_NO, false);
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.FLAT_SCROLLBAR, value);
                }
                else
                {
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.FLAT_SCROLLBAR, false);
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.SCROLL_NO, true);                    
                }
            }
        }

        [Category("DOCHOSTUIDBLCLK")]
        public DOCHOSTUIDBLCLK WBDOCHOSTUIDBLCLK
        {
            get { return m_DocHostUiDbClkFlag; }
            set { m_DocHostUiDbClkFlag = value; }
        }

        [Category("ExWB")]
        public SecureLockIconConstants SecureLockIcon
        {
            get
            {
                return (SecureLockIconConstants)m_SecureLockIcon;
            }
        }

        [Category("ExWB")]
        public TextSizeWB TextSize
        {
            get
            {
                if (m_WBOleCommandTarget != null)
                {
                    object retVal = new object(); //VT_NULL
                    IntPtr pRet = m_NullPointer;
                    int iZoom = (int)5;
                    try
                    {
                        pRet = Marshal.AllocCoTaskMem((int)1024);
                        Marshal.GetNativeVariantForObject(retVal, pRet);

                        //NULL to specify the standard group
                        int hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                            (uint)OLECMDID.OLECMDID_ZOOM,
                            (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                            m_NullPointer, pRet);

                        retVal = Marshal.GetObjectForNativeVariant(pRet);
                        Marshal.FreeCoTaskMem(pRet);
                        pRet = m_NullPointer;
                        if (Type.GetTypeCode(retVal.GetType()) == TypeCode.Int32)
                            iZoom = int.Parse(retVal.ToString());
                        //else
                        //    Debug.Write("Incorrect TypeCode!", "Get_TextSizeWB");
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        if (pRet != m_NullPointer)
                            Marshal.FreeCoTaskMem(pRet);
                    }
                    if((iZoom > -1) && (iZoom < 5) )
                        m_enumTextSize = (TextSizeWB)iZoom;
                }
                return m_enumTextSize;
            }

            set
            {
                if (m_WBOleCommandTarget != null)
                {
                    if (((int)value > (int)-1) && ((int)value < (int)5))
                    {
                        IntPtr pRet = m_NullPointer;
                        try
                        {
                            pRet = Marshal.AllocCoTaskMem((int)1024);
                            Marshal.GetNativeVariantForObject((int)value, pRet);

                            int hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                                (uint)OLECMDID.OLECMDID_ZOOM,
                                (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                                pRet, m_NullPointer);
                            Marshal.FreeCoTaskMem(pRet);
                            pRet = m_NullPointer;
                            if (hr == Hresults.S_OK)
                                m_enumTextSize = (TextSizeWB)value;
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            if (pRet != m_NullPointer)
                                Marshal.FreeCoTaskMem(pRet);
                        }
                    }
                }
            }
        }

        [Category("ExWB")]
        public bool CanGoBack
        {
            get { return m_bCanGoBack; }
        }

        [Category("ExWB")]
        public bool CanGoForward
        {
            get { return m_bCanGoForward; }
        }

        [Category("ExWB")]
        public IWebBrowser2 WebbrowserObject
        {
            get { return m_WBWebBrowser2; }
        }

        [Category("ExWB"), Description("true, fires DocumentCompleteEX instead of DocumentComplete passing source of the pDisp Document.")]
        public bool SendSourceOnDocumentCompleteWBEx
        {
            get { return m_bSendSourceOnDocumentCompleteWBEx; }
            set { m_bSendSourceOnDocumentCompleteWBEx = value; }
        }

        [Category("ExWB"), Description("Internet Explorer_Server HWND")]
        public IntPtr IEServerHwnd
        {
            get {return WBIEServerHandle();}
        }

        [Category("ExWB"), Description("ShellEmbedding HWND")]
        public IntPtr ShellEmbedingHwnd
        {
            get { return WBShellEmbedingHandle(); }
        }

        [Category("ExWB"), Description("ShellDocObject HWND")]
        public IntPtr ShellDocObjectHwnd
        {
            get { return WBShellDocObjHandle(); }
        }

        [Category("ExWB"),
        Description("Allows default drag drop operations. Default false. To use internal drag drop, set RegisterForInternalDragDrop to true. Setting this property to true will deactivate internal drag drop.")]
        public bool RegisterAsDropTarget
        {
            get 
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.RegisterAsDropTarget;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.RegisterAsDropTarget = value;
                if (value)
                    this.RegisterForInternalDragDrop = false;
            }
        }

        [Category("ExWB"),
        Description("Uses internal drag drop events to notify the client. Default true.")]
        public bool RegisterForInternalDragDrop
        {
            get
            {
                return m_bUseInternalDragDrop;
            }
            set
            {
                m_bUseInternalDragDrop = value;
                //Make sure we set RegisterAsDropTarget to false
                if( (m_bUseInternalDragDrop) && (m_WBWebBrowser2 != null) )
                    this.RegisterAsDropTarget = false;
            }
        }

        [ Category("ExWB") ]
        public bool RegisterAsBrowser
        {
            //MessageBox(IntPtr.Zero, "", "", 0);
            get 
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.RegisterAsBrowser;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.RegisterAsBrowser = value;
            }
        }

        [Category("ExWB")]
        public bool Silent
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.Silent;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.Silent = value;
            }
        }

        [Category("ExWB")]
        public string LocationName
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.LocationName;
                else
                    return "Unavailable";
            }
        }

        [Category("ExWB"), Description("Set or get current LocationURL. Works in design mode as well.")]
        public string LocationUrl
        {
            //Treat it as URL
            get
            {
                if( (!DesignMode) && (m_WBWebBrowser2 != null) )
                    m_sUrl = m_WBWebBrowser2.LocationURL;

                if (m_sUrl.Length == 0)
                    m_sUrl = "about:blank";
                return m_sUrl;
            }
            set
            {
                m_sUrl = value;
                if( (m_WBWebBrowser2 != null) && (m_sLastSearch.Length > 0) )
                   this.Navigate(m_sUrl);
            }
        }

        [Category("ExWB")]
        public bool Busy
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.Busy;
                else
                    return false;
            }
        }

        [Category("ExWB")]
        public bool OffLine
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.Offline;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.Offline = value;
            }
        }

        [Category("ExWB")]
        public tagREADYSTATE ReadyState
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.ReadyState;
                else
                    return tagREADYSTATE.READYSTATE_UNINITIALIZED;
            }
        }
        
        [Category("ExWB")]
        public Image ThumbImage
        {
            get
            {
                if (m_WBThumbImg != null)
                    return m_WBThumbImg;
                else
                    return new Bitmap(16, 16);
            }
        }

        [Category("ExWB"), Description("Offers same functionality as ObjectForScripting of C# webbrowser wrapper control.")]
        public object ObjectForScripting
        {
            get
            {
                return m_WinExternal;
            }
            set
            {
                m_WinExternal = value;
            }
        }

        [Category("ExWB"), Description("Sets or retrieves the title of the document")]
        public string DocumentTitle
        {
            get { return this.GetTitle(true); }
            set
            {
                if( (this.m_WBWebBrowser2 != null) &&
                    (m_WBWebBrowser2.Document != null) )
                {
                    IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                    if (doc2 != null)
                        doc2.title = value;
                }
            }
        }

        [Category("ExWB"), Description("Sets or retrives the HTML source of the document")]
        public string DocumentSource
        {
            get { return this.GetSource(true); }
            set { this.LoadHtmlIntoBrowser(value); }
        }

        #endregion

#region Overriden members

        public cEXWB()
        {
            ////Set some styles in regard to painting. We don't
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.Selectable, true);
            //this.SetStyle(ControlStyles.StandardClick, true);
            //this.SetStyle(ControlStyles.Opaque, true);
            //this.SetStyle(ControlStyles.ContainerControl, true);


            //components = new System.ComponentModel.Container();
            //this.SuspendLayout();
            // 
            // csEXWB
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Name = "csEXWB";
            //this.Size = new System.Drawing.Size(287, 239);
            //this.ResumeLayout(false);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!this.DesignMode)
                SetFocus();
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    e.Graphics.Clear(this.BackColor);
        //    //base.OnPaint(e);
        //}

        protected override void Dispose(bool disposing)
        {
            if( (disposing) && (!this.DesignMode) )
            {
                if (m_HookHandled != IntPtr.Zero)
                    Marshal.FreeHGlobal(m_HookHandled);
                if (m_WBThumbImg != null)
                    m_WBThumbImg.Dispose();
                InternalFreeWB();
                if((components != null))
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.SetLocation();
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            bool handled = false;
            if ((msg.Msg >= WindowsMessages.WM_KEYFIRST) && (msg.Msg <= WindowsMessages.WM_KEYLAST_NT501))
            {
                // If it's a key down, first see if the key combo is a command key
                if (msg.Msg == WindowsMessages.WM_KEYDOWN)
                {
                    handled = ProcessCmdKey(ref msg, (Keys)(int)msg.WParam | ModifierKeys);
                }

                if (!handled)
                {
                    int keyCode = (int)msg.WParam;
                    // Don't let Trident eat Ctrl-PgUp/PgDn
                    if (((keyCode != (int)Keys.PageUp) && 
                        (keyCode != (int)Keys.PageDown)) || 
                        ((ModifierKeys & Keys.Control) == 0))
                    {
                        tagMSG cm = new tagMSG();

                        cm.hwnd = msg.HWnd;
                        cm.message = msg.Msg;
                        cm.wParam = msg.WParam;
                        cm.lParam = msg.LParam;

                        IOleInPlaceActiveObject accele = m_WBUnknown as IOleInPlaceActiveObject;
                        if( (accele != null) && 
                            (accele.TranslateAccelerator(ref cm) == Hresults.S_OK) )
                            handled = true;
                    }
                    else
                    {
                        // WndProc for Ctrl-PgUp/PgDn is never called so call it directly here
                        WndProc(ref msg);
                        handled = true;
                    }
                }
            }
            if (!handled)
            {
                handled = base.PreProcessMessage(ref msg);
            }
            return handled;
        }

        //private int m_wparam = 0;
        //private KBDLLHOOKSTRUCT m_KBLL = new KBDLLHOOKSTRUCT();
        //How to handle LLKeyboardHook
        /*
            if (m.Msg == m_KEYBOARD_LL.UniqueMsgID)
            {
                //To stop, set to handled
                //m.Result = m_HookHandled;
                m_wparam = (int)m.WParam;

                //Get the structure
                m_KBLL.Reset();
                Marshal.PtrToStructure(m.LParam, m_KBLL);

                //bCtlPressed = (Control.ModifierKeys & Keys.Control) != 0);
                if (m_wparam == WindowsMessages.WM_KEYDOWN)
                    AppendText("KEYBOARD_LL_KEYDOWN=" + m_KBLL.vkCode.ToString() + "\r\n");
                else if (m_wparam == WindowsMessages.WM_KEYUP)
                    AppendText("KEYBOARD_LL_KEYUP=" + m_KBLL.vkCode.ToString() + "\r\n");
                else if (m_wparam == WindowsMessages.WM_SYSKEYDOWN)
                    AppendText("KEYBOARD_LL_SYSKEYDOWN=" + m_KBLL.vkCode.ToString() + "\r\n");
                else if (m_wparam == WindowsMessages.WM_SYSKEYUP)
                    AppendText("KEYBOARD_LL_SYSKEYUP=" + m_KBLL.vkCode.ToString() + "\r\n");
            }
        */

        //private WindowsHookUtil.CBT_CREATEWND m_CBT_CREATEWND = new CBT_CREATEWND();
        //private WindowsHookUtil.CREATESTRUCT m_CREATESTRUCT = new CREATESTRUCT();
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == m_CBT.UniqueMsgID)
            {
                m_csexwbCOMLib.HookProcNCode(CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT, 
                    ref m_NCode);
                if (m_NCode == WindowsHookUtil.HCBT_CREATEWND)
                {
                    //m.WParam contains handle to the new window

                    //One method of getting new window information
                    //Marshal.PtrToStructure(m.LParam, m_CBT_CREATEWND);
                    //Marshal.PtrToStructure(m_CBT_CREATEWND.lpcs, m_CREATESTRUCT);
                    //if (m_CREATESTRUCT.lpszClass != IntPtr.Zero)
                    //{
                    m_strTemp = WinApis.GetWindowClass(m.WParam); //Marshal.PtrToStringAnsi(m_CREATESTRUCT.lpszClass);
                    if (!string.IsNullOrEmpty(m_strTemp))
                    {
                        if (m_strTemp.Equals(m_HTMLDlgClassName, StringComparison.CurrentCultureIgnoreCase))
                            m.Result = m_HookHandled; //dismiss it
                    }
                    //}
                }
            }
            else
                base.WndProc(ref m);
        }

        //public override string ToString()
        //{
        //    return "csEXWB 1.0.0.4";
        //    //return base.ToString();
        //}

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if(m_WBOleObject == null)
                return;
            if(this.Visible)
                m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_SHOW, ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);
            else
                m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_HIDE, ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.IsHandleCreated)
            {
                if (!this.DesignMode)
                {
                    //CBT hook return value to stop an HTMLDialog
                    m_HookHandled = Marshal.AllocHGlobal(Marshal.SizeOf((Int32)1) + 1);
                    Marshal.WriteInt32(m_HookHandled, 1);
                    InitCOMLibrary();
                }
                InternalCreateWB();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            if( (m_WBWebBrowser2 != null) && (!this.DesignMode) )
                m_WBWebBrowser2.Refresh();
        }

        #endregion

#region Private Method Members

        //Called from resize event to adjust the size of browser
        private void SetLocation()
        {
            if (m_WBOleInPlaceObject == null)
                return;
            bool brect = WinApis.GetClientRect(this.Handle, out m_WBRect);
            //Setup H+W
            m_WBRect.Right = m_WBRect.Right - m_WBRect.Left; //W
            m_WBRect.Bottom = m_WBRect.Bottom - m_WBRect.Top; //H
            m_WBRect.Left = 0;
            m_WBRect.Top = 0;

            m_WBOleInPlaceObject.SetObjectRects(ref m_WBRect, ref m_WBRect);
        }

        //Returns corresponding string for an HRESULT
        private string HresultAsString(int iHRESULT)
        {
            string sRet = "S_OK";
            if (iHRESULT == Hresults.S_OK)
            {
                return sRet;
            }
            else if (iHRESULT == Hresults.S_FALSE)
            {
                sRet = "S_FALSE";
            }
            else if (iHRESULT == Hresults.E_INVALIDARG)
            {
                sRet = "E_INVALIDARG";
            }
            else if (iHRESULT == Hresults.E_NOTIMPL)
            {
                sRet = "E_NOTIMPL";
            }
            else if (iHRESULT == Hresults.E_ABORT)
            {
                sRet = "E_ABORT";
            }
            else if (iHRESULT == Hresults.E_ACCESSDENIED)
            {
                sRet = "E_ACCESSDENIED";
            }
            else if (iHRESULT == Hresults.E_FAIL)
            {
                sRet = "E_FAIL";
            }
            else if (iHRESULT == Hresults.E_FLAGS)
            {
                sRet = "E_FLAGS";
            }
            else if (iHRESULT == Hresults.E_HANDLE)
            {
                sRet = "E_HANDLE";
            }
            else if (iHRESULT == Hresults.E_NOINTERFACE)
            {
                sRet = "E_NOINTERFACE";
            }
            else if (iHRESULT == Hresults.E_OUTOFMEMORY)
            {
                sRet = "E_OUTOFMEMORY";
            }
            else if (iHRESULT == Hresults.E_PENDING)
            {
                sRet = "E_PENDING";
            }
            else if (iHRESULT == Hresults.E_POINTER)
            {
                sRet = "E_POINTER";
            }
            else if (iHRESULT == Hresults.E_UNEXPECTED)
            {
                sRet = "E_UNEXPECTED";
            }
            else if (iHRESULT == Hresults.DV_E_LINDEX)
            {
                sRet = "DV_E_LINDEX";
            }
            else if (iHRESULT == Hresults.OLEOBJ_S_CANNOT_DOVERB_NOW)
            {
                sRet = "OLEOBJ_S_CANNOT_DOVERB_NOW";
            }
            else if (iHRESULT == Hresults.OLEOBJ_S_INVALIDHWND)
            {
                sRet = "OLEOBJ_S_INVALIDHWND";
            }
            else if (iHRESULT == Hresults.OLEOBJ_S_INVALIDVERB)
            {
                sRet = "OLEOBJ_S_INVALIDVERB";
            }
            else if (iHRESULT == Hresults.OLEOBJ_E_NOVERBS)
            {
                sRet = "OLEOBJ_E_NOVERBS";
            }
            else if (iHRESULT == Hresults.OLE_E_NOT_INPLACEACTIVE)
            {
                sRet = "OLE_E_NOT_INPLACEACTIVE";
            }
            else if (iHRESULT == Hresults.OLE_E_CANT_BINDTOSOURCE)
            {
                sRet = "OLE_E_CANT_BINDTOSOURCE";
            }
            else if (iHRESULT == Hresults.OLE_E_CLASSDIFF)
            {
                sRet = "OLE_E_CLASSDIFF";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_UNKNOWNGROUP)
            {
                sRet = "OLECMDERR_E_UNKNOWNGROUP";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_NOTSUPPORTED)
            {
                sRet = "OLECMDERR_E_NOTSUPPORTED";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_DISABLED)
            {
                sRet = "OLECMDERR_E_DISABLED";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_CANCELED)
            {
                sRet = "OLECMDERR_E_CANCELED";
            }
            else
            {
                sRet = "UNKNOWN-VALUE: " + iHRESULT.ToString();
            }
            return sRet;
        }

        //To retreive ShellEmbeding + ShellDocObj + IEServer HWNDs
        private IntPtr WBShellEmbedingHandle()
        {
            if (m_WBUnknown == null)
                return m_NullPointer;

            if( (!m_hWBShellEmbeddingHandle.Equals(m_NullPointer)) &&
                (WinApis.IsWindow(m_hWBShellEmbeddingHandle)))
                return m_hWBShellEmbeddingHandle;

            m_hWBShellEmbeddingHandle = m_NullPointer;
        
            IOleWindow pWin = m_WBUnknown as IOleWindow;
            if(pWin != null)
                pWin.GetWindow(ref m_hWBShellEmbeddingHandle);

            return m_hWBShellEmbeddingHandle;
        }
        private IntPtr WBShellDocObjHandle()
        {
            if ((!m_hWBShellDocObjHandle.Equals(m_NullPointer)) &&
                (WinApis.IsWindow(m_hWBShellDocObjHandle)))
                return m_hWBShellDocObjHandle;
            m_hWBShellDocObjHandle = m_NullPointer;
            if (!WBShellEmbedingHandle().Equals(m_NullPointer))
            {
                m_hWBShellDocObjHandle = WinApis.GetWindow(m_hWBShellEmbeddingHandle, (uint)GetWindow_Cmd.GW_CHILD);
            }
            return m_hWBShellDocObjHandle;
        }
        private IntPtr WBIEServerHandle()
        {
            if ((!m_hWBServerHandle.Equals(m_NullPointer)) &&
                (WinApis.IsWindow(m_hWBServerHandle)))
                return m_hWBServerHandle;
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                m_hWBServerHandle = WinApis.GetWindow(m_hWBShellDocObjHandle, (uint)GetWindow_Cmd.GW_CHILD);
            }
            return m_hWBServerHandle;
        }

        //Registers clipboard formats that we can handle
        //Registered Dragdrop formats
        //private short m_CFHTML = 0;
        //private short m_CFRTF = 0;
        //private short m_CFURL = 0;
        //private short m_CFNETRESOURCE = 0;
        //private short m_CFUNTRUSTEDDRAGDROP = 0;
        //private short m_CFFILEGROUPDESCRIPTOR = 0;
        //private short m_CFFILECONTENTS = 0;
        //private void RegisterClipboardFormatsForDragDrop()
        //{
        //    m_CFHTML = (short)WinApis.RegisterClipboardFormat("HTML Format");
        //    m_CFRTF = (short)WinApis.RegisterClipboardFormat("Rich Text Format");
        //    m_CFFILEGROUPDESCRIPTOR = (short)WinApis.RegisterClipboardFormat("FileGroupDescriptor");
        //    m_CFFILECONTENTS = (short)WinApis.RegisterClipboardFormat("FileContents");
        //    m_CFUNTRUSTEDDRAGDROP = (short)WinApis.RegisterClipboardFormat("UntrustedDragDrop");
        //    m_CFURL = (short)WinApis.RegisterClipboardFormat("UniformResourceLocator");
        //    m_CFNETRESOURCE = (short)WinApis.RegisterClipboardFormat("Net Resource");
        //}

        private void InternalFreeWB()
        {
            if( (!DesignMode) && (m_WBUnknown != null) )
            {
                //Get connectionpointcontainer
                IConnectionPointContainer cpCont = m_WBUnknown as IConnectionPointContainer;

                //Find connection point
                if (cpCont != null)
                {
                    Guid guid = typeof(DWebBrowserEvents2).GUID;
                    IConnectionPoint m_WBConnectionPoint = null;
                    cpCont.FindConnectionPoint(ref guid, out m_WBConnectionPoint);
                    //UnAdvice
                    if ((m_WBConnectionPoint != null) && (m_dwCookie > 0))
                        m_WBConnectionPoint.Unadvise(m_dwCookie);
                }

                //UI and Inplace deactivate
                if (m_WBOleInPlaceObject != null)
                {
                    m_WBOleInPlaceObject.UIDeactivate();
                    m_WBOleInPlaceObject.InPlaceDeactivate();
                }

                //Disconnect from ole
                if (m_WBOleObject != null)
                {
                    m_WBOleObject.Close((uint)OLEDOVERB.OLECLOSE_NOSAVE);
                    m_WBOleObject.SetClientSite(null);
                }
            }
            if (m_TravelLogStg != null)
            {
                Marshal.ReleaseComObject(m_TravelLogStg);
                m_TravelLogStg = null;
            }
            if (m_txtrange != null)
            {
                Marshal.ReleaseComObject(m_txtrange);
                m_txtrange = null;
            }
            if (m_WBOleCommandTarget != null)
            {
                Marshal.ReleaseComObject(m_WBOleCommandTarget);
                m_WBOleCommandTarget = null;
            }
            if (m_WBWebBrowser2 != null)
            {
                Marshal.ReleaseComObject(m_WBWebBrowser2);
                m_WBWebBrowser2 = null;
            }
            if (m_WBOleInPlaceObject != null)
            {
                Marshal.ReleaseComObject(m_WBOleInPlaceObject);
                m_WBOleCommandTarget = null;
            }
            if (m_WBOleObject != null)
            {
                Marshal.ReleaseComObject(m_WBOleObject);
                m_WBOleObject = null;
            }
            if (m_WBUnknown != null)
            {
                Marshal.ReleaseComObject(m_WBUnknown);
                m_WBUnknown = null;
            }

            if (m_WantHtmlDocumentEvents)
            {
                m_TopLevelHtmlDocumentevents.DisconnectHtmlEvents();
                DisconnectHtmlDocumentEvents();
            }
            if (m_WantHtmlWindowEvents)
            {
                m_TopLevelHtmlWindowEvents.DisconnectHtmlEvents();
                DisconnectHtmlWindowEvnets();
            }
        }

        /// <summary>
        /// Create Webbrowser control and set up it's events
        /// called from OnHandleCreated
        /// Webbrowser control hosting requires an HWND
        /// </summary>
        /// <returns></returns>
        private void InternalCreateWB()
        {
            //Create a new WB, throws exception if fails
            Type webbrowsertype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_WebBrowser, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            m_WBUnknown = System.Activator.CreateInstance(webbrowsertype);

            //Get the IOleObject
            m_WBOleObject = (IOleObject)m_WBUnknown;
            //Set client site
            int iret = m_WBOleObject.SetClientSite(this);
            //Set hostnames
            iret = m_WBOleObject.SetHostNames("csEXWB", string.Empty);

            //Get client rect
            bool brect = WinApis.GetClientRect(this.Handle, out m_WBRect);
            //Setup H+W
            m_WBRect.Right = m_WBRect.Right - m_WBRect.Left; //W
            m_WBRect.Bottom = m_WBRect.Bottom - m_WBRect.Top; //H
            m_WBRect.Left = 0;
            m_WBRect.Top = 0;

            //Get the IOleInPlaceObject
            m_WBOleInPlaceObject = (IOleInPlaceObject)m_WBUnknown;
            tagRECT trect = new tagRECT();
            WinApis.CopyRect(ref trect, ref m_WBRect);
            //Set WB rects
            iret = m_WBOleInPlaceObject.SetObjectRects(ref m_WBRect, ref trect);

            //INPLACEACTIVATE the WB
            iret = m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_INPLACEACTIVATE, ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);

            //Get the IWebBrowser2
            m_WBWebBrowser2 = (IWebBrowser2)m_WBUnknown;

            //By default, we handle dragdrops
            m_WBWebBrowser2.RegisterAsDropTarget = false;
            if (!DesignMode)
            {
                //Get connectionpointcontainer
                IConnectionPointContainer cpCont = (IConnectionPointContainer)m_WBUnknown;
                //Find connection point
                Guid guid = typeof(DWebBrowserEvents2).GUID;
                IConnectionPoint m_WBConnectionPoint = null;
                cpCont.FindConnectionPoint(ref guid, out m_WBConnectionPoint);
                //Advice
                m_WBConnectionPoint.Advise(this, out m_dwCookie);

                //Get the IOleComandTarget
                m_WBOleCommandTarget = (IOleCommandTarget)m_WBUnknown;

                //Reguster clipborad format for internal drag drop
                //RegisterClipboardFormatsForDragDrop();
            }

            if (!string.IsNullOrEmpty(m_sUrl))
                this.Navigate(m_sUrl);
            else
                this.Navigate(m_AboutBlank);

            //Get the shell embedding, ...
            WBIEServerHandle();
        }

        //Wrappers for Webbrowser.ExecWB and IOleCommand.Exec methods
        private void ExecWB(OLECMDID command)
        {
            if (m_WBWebBrowser2 != null)
            {
                m_WBWebBrowser2.ExecWB(command,
                    OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    ref m_NullObject, ref m_NullObject);
            }
        }
        private int WBOleCommandExec(OLECMDID command)
        {
            //Execute the command using default group NULL
            int hr = Hresults.S_FALSE; //1
            if(m_WBOleCommandTarget != null) 
            {
                //should return S_OK 0
                hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)command, (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    m_NullPointer, m_NullPointer);
                
            }
            return hr;
        }
        private int WBOleCommandExec(OLECMDID command, OLECMDEXECOPT cmdopt)
        {
            //Execute the command using default group NULL
            int hr = Hresults.S_FALSE;
            if (m_WBOleCommandTarget != null)
            {
                hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)command, (uint)cmdopt,
                    m_NullPointer, m_NullPointer);
            }
            return hr;
        }

        //Utility, used in Findxxx methods
        //MakeRGB(Color.FromName(Color));
        private int MakeRGB(Color cColor)
        {
            try
            {
                //Taken from RGB macro in wingdi.h
                return (int)((cColor.R | (((short)cColor.G) << 8)) | (((int)cColor.B) << 16));

            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG flag, bool add)
        {
            if (add)
            {
                if ((m_DLCtlFlags & flag) == 0)
                    m_DLCtlFlags |= flag;
            }
            else
            {
                if ((m_DLCtlFlags & flag) != 0)
                    m_DLCtlFlags -= flag;
            }

            if ((m_WBUnknown != null) && (m_WBWebBrowser2 != null))
            {
                try
                {
                    //Signal change of DL property
                    //so MSHTML call our Invoke method through Dispatch
                    //Otherwise refreshing the page will have no effect
                    //MSHTML does not know of new flags set by us
                    //QI for IOleControl
                    IOleControl pOC = (IOleControl)m_WBUnknown;
                    pOC.OnAmbientPropertyChange(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL);
                }
                finally
                {
                }
            }
        }

        private void SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG flag, bool add)
        {
            if (add)
            {
                if ((m_DocHostUiFlags & flag) == 0)
                    m_DocHostUiFlags |= flag;
            }
            else
            {
                if ((m_DocHostUiFlags & flag) != 0)
                    m_DocHostUiFlags -= flag;
            }
        }

#endregion

#region Public Method Members

        //Using IWebBrowser2 interface
        public void Navigate(string URL)
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.Navigate(URL, ref m_NullObject, ref m_NullObject, ref m_NullObject, ref m_NullObject);
        }
        //http://msdn2.microsoft.com/en-us/library/2x07fbw8.aspx
        public void Navigate(string URL, BrowserNavConstants Flags)
        {
            if (m_WBWebBrowser2 != null)
            {
                //At runtime, outobj data type is determined and passed as
                //variant of that type. Used for simple data types
                object outobj = (int)Flags;
                object outtarget = null;
                if(Flags == BrowserNavConstants.navOpenInNewWindow)
                    outtarget = "_BLANK";
                m_WBWebBrowser2.Navigate(URL, ref outobj, ref outtarget , ref m_NullObject, ref m_NullObject);
            }
        }
        public void Navigate(string URL, BrowserNavConstants Flags, string TargetFrameName, string PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vFlags = (int)Flags;
                object vTargetFrameName = TargetFrameName;
                object vPostData = ASCIIEncoding.ASCII.GetBytes(PostData);
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref vFlags, ref vTargetFrameName, ref vPostData, ref vHeaders);
            }
         }
        public void Navigate(string URL, BrowserNavConstants Flags, string PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vFlags = (int)Flags;
                object vPostData = ASCIIEncoding.ASCII.GetBytes(PostData);
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref vFlags, ref m_NullObject, ref vPostData, ref vHeaders);
            }
        }
        //PostData: Flav=red&taste=good
        public void Navigate(string URL, string PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vPostData = ASCIIEncoding.ASCII.GetBytes(PostData);
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref m_NullObject, ref m_NullObject, ref vPostData, ref vHeaders);
            }
        }
        public void Navigate(string URL, byte[] PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vPostData = PostData;
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref m_NullObject, ref m_NullObject, ref vPostData, ref vHeaders);
            }
        }
        public void Navigate2(string URL)
        {
            if (m_WBWebBrowser2 != null)
            {
                object outobj = URL;
                m_WBWebBrowser2.Navigate2(ref outobj, ref m_NullObject, ref m_NullObject, ref m_NullObject, ref m_NullObject);
            }
        }
        public void NavToBlank()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.Navigate(m_AboutBlank, ref m_NullObject, ref m_NullObject, ref m_NullObject, ref m_NullObject);

        }

        public void Stop()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.Stop();
        }
        public bool GoBack()
        {
            if ((m_WBWebBrowser2 != null) && (m_bCanGoBack))
            {
                m_WBWebBrowser2.GoBack();
                return true;
            }
            return false;
        }
        public bool GoForward()
        {
            if ((m_WBWebBrowser2 != null) && (m_bCanGoForward))
            {
                m_WBWebBrowser2.GoForward();
                return true;
            }
            return false;
        }
        public void GoHome()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.GoHome();
        }
        public void GoSearch()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.GoSearch();
        }
        public void Refresh2(RefreshConstants Level)
        { 
            if (m_WBWebBrowser2 != null)
            {
                object outobj = (Int32)Level;
                m_WBWebBrowser2.Refresh2(ref outobj);
            }
        }

        //Using IOleCommandTarget interface
        public bool SelectAll()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_SELECTALL) == Hresults.S_OK) ? true : false;
        }
        public bool Clear()
        {
            if (m_WBWebBrowser2 == null)
                return false;
            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return false;
            if (doc2.body == null)
                return false;
            doc2.body.innerHTML = "";
            return true;
        }
        public bool ClearSelection()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_CLEARSELECTION) == Hresults.S_OK) ? true : false;
        }
        public bool Copy()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_COPY) == Hresults.S_OK) ? true : false;
        }
        public bool Paste()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PASTE) == Hresults.S_OK) ? true : false;
        }
        public bool Cut()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_CUT) == Hresults.S_OK) ? true : false;
        }
        public bool Undo()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_UNDO) == Hresults.S_OK) ? true : false;
        }
        public bool Redo()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_REDO) == Hresults.S_OK) ? true : false;
        }
        public bool Delete()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_DELETE) == Hresults.S_OK) ? true : false;
        }
        public bool PasteSpecial()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PASTESPECIAL) == Hresults.S_OK) ? true : false;
        }
        public bool Spell()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_SPELL) == Hresults.S_OK) ? true : false;
        }
        public bool NewWindow()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_NEW) == Hresults.S_OK) ? true : false;
        }
        public bool Print()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINT) == Hresults.S_OK) ? true : false;
        }
        public bool Print2()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINT2) == Hresults.S_OK) ? true : false;
        }
        public bool Properties()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PROPERTIES) == Hresults.S_OK) ? true : false;
        }
        public bool PrintPreview()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINTPREVIEW) == Hresults.S_OK) ? true : false;
        }
        public bool PrintPreview2()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINTPREVIEW2) == Hresults.S_OK) ? true : false;
        }
        public bool PageSetup()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PAGESETUP) == Hresults.S_OK) ? true : false;
        }
        public void SaveAs()
        {
            //displays the old style saveas
            //returns notsupported if user clicks cancel
            //m_iTmpRet = this.WBOleCommandExec(OLECMDID.OLECMDID_SAVEAS);
            
            //if (m_iTmpRet != Hresults.S_OK)
            this.ExecWB(OLECMDID.OLECMDID_SAVEAS); //displays modern style
        }

        //using CGI_IWebBrowser group
        private int ShowMiscCommands(WB_MiscCommandTarget command)
        {
            int hr = Hresults.S_FALSE;
            uint uicommand = (uint)command;
            if (m_WBOleCommandTarget != null)
            {
                IntPtr pPt = m_NullPointer;
                try
                {
                    byte[] guidbytes = Iid_Clsids.CLSID_CGI_IWebBrowser.ToByteArray();
                    pPt = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                    Marshal.Copy(guidbytes, 0, pPt, guidbytes.Length);
                    
                    hr = m_WBOleCommandTarget.Exec(pPt,
                        uicommand,
                        (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                        m_NullPointer, m_NullPointer);

                    Marshal.FreeCoTaskMem(pPt);
                    pPt = m_NullPointer;
                    //if (hr != Hresults.S_OK)
                    //    MessageBox(m_NullPointer, HresultAsString(hr),"ShowFindWB",0);
                }
                finally
                {
                    if (pPt != m_NullPointer)
                        Marshal.FreeCoTaskMem(pPt);
                }
            }
            return hr;
        }
        public bool Find()
        {
            return (this.ShowMiscCommands(WB_MiscCommandTarget.Find) == Hresults.S_OK) ? true : false;
        }
        public bool IEOptions()
        {
            return (this.ShowMiscCommands(WB_MiscCommandTarget.Options) == Hresults.S_OK) ? true : false;
        }
        public bool ViewSource()
        {
            return (this.ShowMiscCommands(WB_MiscCommandTarget.ViewSource) == Hresults.S_OK) ? true : false;
        }

        //Using IShellUIHelper
        //If not working use API:
        //DoOrganizeFavDlg
        //AddUrlToFavorites
        private int ShellUIHelperMiscCommands(string scommand)
        {

            #region C++ version
            //    HRESULT hr;
            //    IShellUIHelper* pShellUI = NULL;
            //    hr = CoCreateInstance(CLSID_ShellUIHelper, NULL, CLSCTX_INPROC_SERVER, IID_IShellUIHelper, (void **)&pShellUI);
            //    if(FAILED(hr) || !pShellUI) return Hresults.S_FALSE;
            //
            //LanguageDialog
            //    Opens the Language Preference dialog box.
            //OrganizeFavorites
            //    Opens the Organize Favorites dialog box.
            //PrivacySettings
            //    Microsoft® Internet Explorer 6 and later. Opens the Privacy Preferences dialog box.
            //ProgramAccessAndDefaults
            //    Microsoft Windows® XP Service Pack 1 (SP1) and later. Opens the Set Program Access and Defaults dialog box.
            //
            //    pShellUI->ShowBrowserUI(CComBSTR(L"OrganizeFavorites"), NULL, NULL);
            //    pShellUI->Release(); 
            #endregion

            int hr = Hresults.S_FALSE;
            //Create a new ShellUiHelper
            Type shelluitype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_ShellUIHelper, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            IShellUIHelper uihelper = System.Activator.CreateInstance(shelluitype) as IShellUIHelper;
            if (uihelper == null)
                return hr;
            uihelper.ShowBrowserUI(scommand,ref m_NullObject);
            return hr;
        }
        public void OrganizeFavorites()
        {
            ShellUIHelperMiscCommands("OrganizeFavorites");
        }
        public void PrivacySettings()
        {
            ShellUIHelperMiscCommands("PrivacySettings");
        }
        public void LanguageDialog()
        {
            ShellUIHelperMiscCommands("LanguageDialog");
        }
        public void ProgramAccessAndDefaults()
        {
            ShellUIHelperMiscCommands("ProgramAccessAndDefaults");
        }

        //Using IE Server hwnd and shelldocobject hwnd directly
        //Do not work in Vista IE7, COMMANDID values have changed
        public void AddToFavorites()
        {
            if (!WBIEServerHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBServerHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND, 
                    (IntPtr)ID_IE_CONTEXTMENU_ADDFAV, m_NullPointer);
            }
        }
        public void ImportExport()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND, 
                    (IntPtr)ID_IE_FILE_IMPORTEXPORT, m_NullPointer);
            }
        }
        public void SendLinkByEmail()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND, 
                    (IntPtr)ID_IE_FILE_SENDLINK, m_NullPointer);
            }
        }
        public void SendPageByEmail()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND, 
                    (IntPtr)ID_IE_FILE_SENDPAGE, m_NullPointer);
            }
        }
        public void SendShortcutToDesktop()
        {

            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND, 
                    (IntPtr)ID_IE_FILE_SENDDESKTOPSHORTCUT, m_NullPointer);
            }
        }

        //Using IWebbrowser2
        //Loads a URL into browser using IPersistMoniker interface
        public bool LoadUrlIntoBrowser(String url) 
        {
            bool ret = false;
            if( (m_WBWebBrowser2 == null) || (url.Length == 0) )
               return ret;

            IPersistMoniker persistMoniker = m_WBWebBrowser2.Document as IPersistMoniker;
            if (persistMoniker == null) 
               return ret;
            IMoniker moniker = null;
            IBindCtx bindContext = null;
            WinApis.CreateBindCtx((uint)0, out bindContext);
            if (bindContext == null)
               return ret;
            //need our own implementation of moniker
            //moniker.BindToStorage(bindContext, null,ref IID_IStream,out new object(stream));            
            WinApis.CreateURLMoniker(null, url, out moniker);
            if (moniker == null)
               return ret;
            persistMoniker.Load(1, moniker, bindContext, 0);
            return true;
        }
        public bool LoadHtmlIntoBrowser(string html, string sBaseUrl) 
        {
            bool ret = false;
            if ((m_WBWebBrowser2 == null) || (html.Length == 0))
                return ret;

            IStream stream = null;
            //Use Marshal.StringToHGlobalAnsi to get ANSI
            int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(html), true, out stream);
            if ((hr != Hresults.S_OK) || (stream == null))
                return ret;

            IPersistMoniker pPM = m_WBWebBrowser2.Document as IPersistMoniker;

            if (pPM == null)
                return ret;
            IBindCtx bindctx = null;
            WinApis.CreateBindCtx((uint)0, out bindctx);
            if (bindctx == null)
                return ret;
            LoadHTMLMoniker loader = new LoadHTMLMoniker();
            if (string.IsNullOrEmpty(sBaseUrl))
                sBaseUrl = m_WBWebBrowser2.LocationURL;
            loader.InitLoader(html, sBaseUrl);
            pPM.Load(1, loader, bindctx, WinApis.STGM_READ);
            stream = null;
            return true;
        }
        public bool LoadHtmlIntoBrowser(string html)
        {
            bool ret = false;
            if ((m_WBWebBrowser2 == null) || 
                (m_WBWebBrowser2.Document == null) ||
                (html.Length == 0)
               )
                return ret;
            //pWebBrowser->get_Document( &pHTMLDocDisp );
            //pHTMLDocDisp->QueryInterface( IID_IPersistStreamInit,  (void**)&pPersistStreamInit );
            IStream stream = null;
            //Use Marshal.StringToHGlobalAnsi to get ANSI
            //or Marshal.StringToHGlobalUni to get UNICODE
            //or Marshal.StringToHGlobalAuto to default to ANSI
            //define UNICODE in build config to get UNICODE HGlobal
            int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(html), true, out stream);
            if ((hr != Hresults.S_OK) || (stream == null))
                return ret;
            
            IPersistStreamInit persistentStreamInit = m_WBWebBrowser2.Document as IPersistStreamInit;
            if (persistentStreamInit != null)
            {
                persistentStreamInit.InitNew();
                persistentStreamInit.Load(stream);
                persistentStreamInit = null;
                ret = true;
            }
            stream = null; 
            return ret;
        }

        private bool ThumbnailCallback() { return false; }

        /// <summary>
        /// Faster than DrawThumb, but
        /// does not work if a window is hidden
        /// or is not on top of the zorder
        /// </summary>
        /// <param name="W"></param>
        /// <param name="H"></param>
        /// <param name="pixFormat"></param>
        /// <returns></returns>
        public Image DrawThumb2(int W, int H, System.Drawing.Imaging.PixelFormat pixFormat)
        {
            if (WBIEServerHandle().Equals(IntPtr.Zero))
                return m_WBThumbImg;
            Bitmap bmp1 = null;
            try
            {
                if (m_WBThumbImg != null)
                {
                    m_WBThumbImg.Dispose();
                    m_WBThumbImg = null;
                }

                IntPtr wbhdc = WinApis.GetWindowDC(m_hWBServerHandle);
                if (wbhdc == IntPtr.Zero)
                    return m_WBThumbImg;

                bmp1 = new Bitmap(m_WBRect.Right, m_WBRect.Bottom, pixFormat);
                using (Graphics grl = Graphics.FromImage(bmp1))
                {
                    IntPtr ghdc = grl.GetHdc();
                    //blt it to the hdc
                    WinApis.BitBlt(ghdc, 0, 0, bmp1.Width, bmp1.Height,
                        wbhdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                    grl.ReleaseHdc();
                }
                m_WBThumbImg = bmp1.GetThumbnailImage(W, H, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                bmp1.Dispose();
                bmp1 = null;
            }
            finally
            {
                if (bmp1 != null)
                    bmp1.Dispose();
            }
            return m_WBThumbImg;
        }
        public Image DrawThumb(int W, int H, System.Drawing.Imaging.PixelFormat pixFormat)
        {
            Bitmap bmp = null;
            try
            {
                if (m_WBThumbImg != null)
                {
                    m_WBThumbImg.Dispose();
                    m_WBThumbImg = null;
                }
                if (m_WBWebBrowser2 == null)
                    return m_WBThumbImg;

                //Frameset
                //http://msdn.microsoft.com/archive/default.asp?url=/archive/en-us/samples/internet/libraries/ie6_lib/default.asp
                if (IsWBFrameset(this.m_WBWebBrowser2))
                {
                    //Not the best but works as long as the browser
                    //is in front of Zorder
                    //an alternative approach would be to get
                    //the frames collection using GetFrames() method
                    //Make a bitmap size of the webbrowser,
                    //draw each frame on a seperate bitmap and then
                    //transfer it to the main bitmap according to their
                    //left and top offsets. A bit lenghty and messy.
                    //If you are looking for a challange then go no further than
                    //MSDN homepage, http://msdn.microsoft.com/library/default.asp
                    //This page has a total of six frames, but some of the frames
                    //are contained within other frames and so on. Getting the
                    //width and height is easy, but finding where to start drawing
                    //frames is not.
                    return DrawThumb2(W, H, pixFormat);
                }

                //Get doc2, and viewobject
                IHTMLDocument2 pDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                if (pDoc2 == null)
                    return m_WBThumbImg;

                IViewObject pViewObject = pDoc2 as IViewObject;
                if (pViewObject == null)
                    return m_WBThumbImg;

                IHTMLBodyElement pBody = null;
                IHTMLElement pElem = null;
                IHTMLStyle pStyle = null;
                string strStyle = string.Empty;

                //get the IHtmlelement
                pElem = pDoc2.body;
                if (pElem != null)
                {
                    //Get the IHTMLStyle
                    pStyle = pElem.style;
                    //Get the borderstyle so we can reset it
                    strStyle = pStyle.borderStyle;
                    //Hide 3D border
                    pStyle.borderStyle = "none";

                    pBody = pElem as IHTMLBodyElement;
                    //No scrollbars
                    if(pBody != null)
                        pBody.scroll = "no";
                }
                //Create bmp
                bmp = new Bitmap(m_WBRect.Right, m_WBRect.Bottom, pixFormat);

                //draw
                int hr = Hresults.S_FALSE;

                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    //get hdc
                    IntPtr hdc = gr.GetHdc();
                    hr = pViewObject.Draw(
                        (uint)DVASPECT.DVASPECT_CONTENT,
                        (int)-1, m_NullPointer, m_NullPointer,
                        m_NullPointer, hdc, ref m_WBRect, ref m_WBRect,
                        m_NullPointer, (uint)0);
                    //if (hr == Hresults.S_OK)
                    //{
                    //    //Transfer to target hdc - TargetHdc = picturebox.image hdc
                    //    StretchBlt(TargetHdc, X, Y, W, H,
                    //        hdc, 0, 0, bmp.Width, bmp.Height,
                    //        TernaryRasterOperations.SRCCOPY);
                    //}
                    gr.ReleaseHdc();
                    //gr.Dispose();
                }

                if (!string.IsNullOrEmpty(strStyle))
                    pStyle.borderStyle = strStyle;
                if (pBody != null)
                    pBody.scroll = "auto";

                m_WBThumbImg = bmp.GetThumbnailImage(W, H, 
                    new Image.GetThumbnailImageAbort(ThumbnailCallback), 
                    IntPtr.Zero);

                bmp.Dispose();
                bmp = null;
            }
            finally
            {
                if (bmp != null)
                    bmp.Dispose();
            }
            return m_WBThumbImg;
        }
        public void SaveBrowserImage(string sFileName, 
            System.Drawing.Imaging.PixelFormat pixFormat,
            System.Drawing.Imaging.ImageFormat format)
        {
            if (m_WBWebBrowser2 == null)
                return;
            Bitmap bmp = null;
            try
            {
                //Get doc2, doc3, and viewobject
                IHTMLDocument2 pDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                if (pDoc2 == null) return;
                IHTMLDocument3 pDoc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
                if (pDoc3 == null) return;
                IViewObject pViewObject = pDoc2 as IViewObject;
                if (pViewObject == null) return;

                IHTMLBodyElement pBody = null;
                IHTMLElement pElem = null;
                IHTMLElement2 pBodyElem = null;
                IHTMLStyle pStyle = null;
                string strStyle;
                int bodyHeight = 0;
                int bodyWidth = 0;
                int rootHeight = 0;
                int rootWidth = 0;
                int height = 0;
                int width = 0;

                //get the IHtmlelement
                pElem = pDoc2.body;

                //Get the IHTMLStyle
                if(pElem != null)
                    pStyle = pElem.style;

                //Get the borderstyle so we can reset it
                strStyle = pStyle.borderStyle;
                //Hide 3D border
                pStyle.borderStyle = "none";
                pBody = pElem as IHTMLBodyElement;
                //No scrollbars
                if(pBody != null)
                    pBody.scroll = "no";

                //Get root scroll h + w
                //QI for IHTMLElement2
                pBodyElem = pElem as IHTMLElement2;
                if (pBodyElem != null)
                {
                    bodyWidth = pBodyElem.scrollWidth;
                    bodyHeight = pBodyElem.scrollHeight;
                }

                //release
                pElem = null;
                pBodyElem = null;
                //Get docelem
                pElem = pDoc3.documentElement;
                //QI for IHTMLElement2
                if (pElem != null)
                {
                    pBodyElem = pElem as IHTMLElement2;
                    //Get scroll H + W
                    if (pBodyElem != null)
                    {
                        rootWidth = pBodyElem.scrollWidth;
                        rootHeight = pBodyElem.scrollHeight;
                    }
                    //calc actual W + H
                    width = rootWidth > bodyWidth ? rootWidth : bodyWidth;
                    height = rootHeight > bodyHeight ? rootHeight : bodyHeight;
                }
                //Set up a rect
                tagRECT rWPos = new tagRECT(0, 0, width, height);

                //Size browser
                if (m_WBOleInPlaceObject != null)
                    m_WBOleInPlaceObject.SetObjectRects(ref rWPos, ref rWPos);

                //Create bmp
                bmp = new Bitmap(width, height, pixFormat);

                //draw
                int hr = Hresults.S_FALSE;
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    //get hdc
                    IntPtr hdc = gr.GetHdc();
                    hr = pViewObject.Draw(
                        (uint)DVASPECT.DVASPECT_CONTENT,
                        (int)-1, m_NullPointer, m_NullPointer,
                        m_NullPointer, hdc, ref rWPos, ref rWPos,
                        m_NullPointer, (uint)0);
                    gr.ReleaseHdc(hdc);
                }

                //reset
                this.SetLocation();
                if (!string.IsNullOrEmpty(strStyle))
                    pStyle.borderStyle = strStyle;
                if(pBody != null)
                    pBody.scroll = "auto";

                if (hr == Hresults.S_OK)
                {
                    //save
                    bmp.Save(sFileName, format);
                }
                bmp.Dispose();
                bmp = null;
            }
            finally
            {
                if (bmp != null)
                    bmp.Dispose();
            }
        }

        //Using CGID_ShellDocView
        public void ShowCertificateDialog()
        {
            if (m_WBOleCommandTarget == null)
                return;
            IntPtr pPt = m_NullPointer;
            int hr = Hresults.S_OK;
            try
            {
                byte[] guidbytes = Iid_Clsids.CGID_ShellDocView.ToByteArray();
                pPt = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                Marshal.Copy(guidbytes, 0, pPt, guidbytes.Length);

                hr = m_WBOleCommandTarget.Exec(pPt,
                    WinApis.SHDVID_SSLSTATUS,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    m_NullPointer, m_NullPointer);

                Marshal.FreeCoTaskMem(pPt);
                pPt = m_NullPointer;
            }
            finally
            {
                if (pPt != m_NullPointer)
                    Marshal.FreeCoTaskMem(pPt);
            }
        }
        
        public bool HasFocus()
        {
            if (m_WBWebBrowser2 != null)
            {
                IHTMLDocument4 doc4 = m_WBWebBrowser2.Document as IHTMLDocument4;
                if (doc4 != null)
                    return doc4.hasFocus();
            }
            return false;
        }
        public void SetFocus()
        {
            if (m_WBWebBrowser2 == null)
                return;

            //UI activate first
            if (m_WBOleObject != null)
                m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_UIACTIVATE, 
                    ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);

            //Check to see if frameset
//            if (IsWBFrameset(this.m_WBWebBrowser2))
//            {
                IHTMLDocument4 doc4 = m_WBWebBrowser2.Document as IHTMLDocument4;
                if (doc4 != null)
                    doc4.focus();
//            }
//            else //Use body elem to set focus
//                SetFocusBody();

            //    if (!WBIEServerHandle().Equals(m_NullPointer))
            //        SetFocus(m_hWBServerHandle);
        }
        private void SetFocusBody()
        {
            if (m_WBWebBrowser2 == null)
                return;

            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return;
            IHTMLElement2 elem2 = doc2.body as IHTMLElement2;
            if (elem2 == null)
                return;
            elem2.focus();
        }

        //We don't have access to IDispatch::Invoke
        //Fired when IOleControl::OnAmbientPropertyChange is called
        //from WBDOCDOWNLOADCTLFLAG property in response to DLCtl flag changing
        [DispId(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL)]
        public int Idispatch_AmbiantDlControl_Invoke_Handler()
        {
            return (int)m_DLCtlFlags;
        }

        //Find + Find and highlight
        public bool FindInPage(string sFind, bool DownWard, bool MatchWholeWord, bool MatchCase, bool ScrollIntoView)
        {
            bool success = false;
            if (m_WBWebBrowser2 == null)
                return success;

            if (sFind.Length == 0)
            {
                m_sLastSearch = "";
                m_txtrange = null;
                return success;
            }
            else
                m_sLastSearch = sFind;

            int searchdir = (DownWard) ? 1000000 : -1000000;
            int searchcase = 0; //default

            //Set up search case
            if ((MatchWholeWord) && (MatchCase))
                searchcase = 6;
            else if (MatchWholeWord)
                searchcase = 2;
            else if (MatchCase)
                searchcase = 4;

            if (m_txtrange != null)
            {
                if (sFind == m_sLastSearch)
                {
                    if (DownWard)
                        m_txtrange.collapse(false);
                    else
                        m_txtrange.collapse(true);
                }
                else
                    m_txtrange = null;
            }

            IHTMLDocument2 pDoc2 = GetActiveDocument();
            if (pDoc2 == null)
                return success;

            IHTMLElement pElem = pDoc2.body;
            IHTMLBodyElement pBodyelem = pElem as IHTMLBodyElement;
            if (pBodyelem == null)
                return success;

            if (m_txtrange == null)
                m_txtrange = pBodyelem.createTextRange();
            if (m_txtrange == null)
                return success;

            success = m_txtrange.findText(sFind, searchdir, searchcase);
            if (success)
            {
                m_txtrange.select();
                if (ScrollIntoView)
                    m_txtrange.scrollIntoView(true);
            }
            return success;
        }
        public int FindAndHightAllInPage(string sFind, bool MatchWholeWord, bool MatchCase, int cbackColor, int cForeColor)
        {
            int iMatches = 0;
            if ((sFind.Length == 0) || (m_WBWebBrowser2 == null))
                return iMatches;

            int searchdir = 0;
            int searchcase = 0; //default
            const string strbg = "BackColor";
            const string strf = "ForeColor";
            const string sword = "Character";
            const string stextedit = "Textedit";

            //Set up search case
            if ((MatchWholeWord) && (MatchCase))
                searchcase = 6;
            else if (MatchWholeWord)
                searchcase = 2;
            else if (MatchCase)
                searchcase = 4;

            IHTMLDocument2 pDoc2 = GetActiveDocument();
            if (pDoc2 == null)
                return iMatches;

            IHTMLElement pElem = pDoc2.body;
            IHTMLBodyElement pBodyelem = pElem as IHTMLBodyElement;
            if (pBodyelem == null)
                return iMatches;

            IHTMLTxtRange pTxtRange = pBodyelem.createTextRange();
            if (pTxtRange == null)
                return iMatches;

            //Can also QI pTxtRange for IOleCommand and use Exec method
            //is recommanded by MSDN.
            while (pTxtRange.findText(sFind, searchdir, searchcase))
            {
                if(cbackColor != 0)
                    pTxtRange.execCommand(strbg, false, cbackColor);
                if(cForeColor != 0)
                    pTxtRange.execCommand(strf, false, cForeColor);
                pTxtRange.moveStart(sword, 1);
                pTxtRange.moveEnd(stextedit, 1);
                iMatches = iMatches + 1;
            }
            return iMatches;
        }
        public int FindAndHightAllInPage(string sFind, bool MatchWholeWord, bool MatchCase, string cbackColor, string cForeColor)
        {
            int b = 0;
            int f = 0;
            //You may be tempted to use Color.Yellow.ToArgb(). But,
            //the value returned includes the A value which
            //causes confusion for MSHTML. i.e. Color.Cyan is interpreted as yellow
            if (cbackColor.Length > 0)
                b = MakeRGB(Color.FromName(cbackColor));
            if (cForeColor.Length > 0)
                f = MakeRGB(Color.FromName(cForeColor));
            return this.FindAndHightAllInPage(sFind, MatchWholeWord, MatchCase, b, f);
        }
        public int FindAndHightAllInPage(string sFind, bool MatchWholeWord, bool MatchCase, Color cbackColor, Color cForeColor)
        {
            int b = 0;
            int f = 0;
            if (cbackColor != Color.Empty)
                b = MakeRGB(cbackColor);
            if (cForeColor != Color.Empty)
                f = MakeRGB(cForeColor);
            return this.FindAndHightAllInPage(sFind, MatchWholeWord, MatchCase,b, f);
        }

        //"Cut", "Copy", "Paste", ...
        public bool IsCommandEnabled(string sCmdId)
        {
            if (m_WBWebBrowser2 == null)
                return false;
            IHTMLDocument2 doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.queryCommandEnabled(sCmdId);
            return false;
        }
        public bool SetDesignMode(string sMode)
        {
            if (m_WBWebBrowser2 == null)
                return false;

            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
            {
                doc2.designMode = sMode;
                return true;
            }
            return false;
        }
        public string GetDesignMode()
        {
            if (m_WBWebBrowser2 == null)
                return string.Empty;
            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.designMode;
            return string.Empty;
        }

        //Frames Proof methods
        public IHTMLDocument2 GetActiveDocument()
        {
            IHTMLDocument2 doc2 = null;
            IHTMLElement elem = null;
            IWebBrowser2 wb = null;
            if (this.m_WBWebBrowser2 == null)
                return doc2;

            //Get document
            doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null) return doc2;

            if (!IsWBFrameset(doc2))
                return doc2;

            //Get active element
            elem = doc2.activeElement;

            IntPtr pelem = Marshal.GetIUnknownForObject(elem);
            if (pelem != IntPtr.Zero)
            {
                IntPtr pWB = IntPtr.Zero;
                int iRet = Marshal.QueryInterface(pelem, 
                    ref Iid_Clsids.IID_IWebBrowser2, out pWB);
                //GetIUnknownForObject AddRefs so Release                        
                Marshal.Release(pelem);

                while (pWB != IntPtr.Zero)
                {
                    wb = Marshal.GetObjectForIUnknown(pWB) as IWebBrowser2;

                    //QueryInterface AddRefs so Release
                    Marshal.Release(pWB);
                    pWB = IntPtr.Zero;

                    if (wb == null) break;

                    doc2 = wb.Document as IHTMLDocument2;
                    if (doc2 == null) break;

                    elem = doc2.activeElement;
                    if (elem == null) break;

                    pelem = Marshal.GetIUnknownForObject(elem);
                    if (pelem != IntPtr.Zero)
                        iRet = Marshal.QueryInterface(pelem, 
                            ref Iid_Clsids.IID_IWebBrowser2, out pWB);
                    Marshal.Release(pelem);
                }
            }

            //Here is the C# version. Raises exception

            ////QI for IWebbrowser2 iface
            //wb = (IWebBrowser2)elem;
            ////Continue till no more frames to traverse
            //while (wb != null)
            //{
            //    doc2 = (IHTMLDocument2)wb.Document;
            //    elem = doc2.activeElement;
            //    wb = (IWebBrowser2)elem;
            //}

            return doc2;
        }
        public IHTMLElement GetActiveElement()
        {
            IHTMLElement elem = null;
            IHTMLDocument2 doc2 = GetActiveDocument();
            if (doc2 != null)
                elem = doc2.activeElement;
            return elem;
        }

        //if(bTopLevel == true) we use the toplevel document (Not frameset)
        //if(bTopLevel == false) we find the activedocument and use it's document
        //Use IsFrameset method in conjunction with these methods
        public string GetTitle(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;
            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.title;
            else
                return string.Empty;
        }
        public string GetTitle(IWebBrowser2 thisBrowser)
        {
            if (thisBrowser == null)
                return string.Empty;
            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.title;
            else
                return string.Empty;
        }
        public string GetText(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
            {
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
                if (doc3 != null)
                    return doc3.documentElement.outerText;
            }
            else
            {
                doc3 = this.GetActiveDocument() as IHTMLDocument3;
                if (doc3 != null)
                    return doc3.documentElement.outerText;
            }
            return string.Empty;
        }
        public string GetText(IWebBrowser2 thisBrowser)
        {
            if (thisBrowser == null)
                return string.Empty;
            IHTMLDocument3 doc3 = thisBrowser.Document as IHTMLDocument3;
            if (doc3 != null)
                return doc3.documentElement.outerText;
            else
                return string.Empty;
        }
        public string GetSource(bool bTopLevel)
        {
            if(this.m_WBWebBrowser2 == null)
                return string.Empty;
            
            IHTMLDocument3 doc3 = null;
            if( bTopLevel )
                doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                //return GetSource(this.m_WBWebBrowser2);
            else
                doc3 = this.GetActiveDocument() as IHTMLDocument3;
            if ((doc3 != null) && (doc3.documentElement != null))
                return doc3.documentElement.outerHTML; //innerHTML;
            return string.Empty;
        }
        public string GetSource(IWebBrowser2 thisBrowser)
        {
            if ((thisBrowser == null) || (thisBrowser.Document == null))
                return string.Empty;

            //Declare vars
            int hr = Hresults.S_OK;
            IStream pStream = null;
            IPersistStreamInit pPersistStreamInit = null;

            // Query for IPersistStreamInit.
            pPersistStreamInit = thisBrowser.Document as IPersistStreamInit;
            if (pPersistStreamInit == null)
                return string.Empty;

            //Create stream, delete on release
            hr = WinApis.CreateStreamOnHGlobal(m_NullPointer, true, out pStream);
            if ((pStream == null) || (hr != Hresults.S_OK))
                return string.Empty;

            //Save
            hr = pPersistStreamInit.Save(pStream, false);
            if (hr != Hresults.S_OK)
                return string.Empty;

            //Now read from stream....

            //First get the size
            long ulSizeRequired = (long)0;
            //LARGE_INTEGER
            long liBeggining = (long)0;
            System.Runtime.InteropServices.ComTypes.STATSTG statstg = new System.Runtime.InteropServices.ComTypes.STATSTG();
            pStream.Seek(liBeggining, (int)tagSTREAM_SEEK.STREAM_SEEK_SET, m_NullPointer);
            pStream.Stat(out statstg, (int)tagSTATFLAG.STATFLAG_NONAME);

            //Size
            ulSizeRequired = statstg.cbSize;
            if (ulSizeRequired == (long)0)
                return string.Empty;

            //Allocate buffer + read
            byte[] pSource = new byte[ulSizeRequired];
            pStream.Read(pSource, (int)ulSizeRequired, m_NullPointer);

            //Added by schlaup to handle UTF8 and UNICODE pages
            //Convert
            //ASCIIEncoding asce = new ASCIIEncoding();
            //return asce.GetString(pSource);
            Encoding enc = null;

            if (pSource.Length > 8)
            {
                // Check byte order mark
                if ((pSource[0] == 0xFF) && (pSource[1] == 0xFE)) // UTF16LE
                    enc = Encoding.Unicode;

                if ((pSource[0] == 0xFE) && (pSource[1] == 0xFF)) // UTF16BE
                    enc = Encoding.BigEndianUnicode;

                if ((pSource[0] == 0xEF) && (pSource[1] == 0xBB) && (pSource[2] == 0xBF)) //UTF8
                    enc = Encoding.UTF8;

                if (enc == null)
                {
                    // Check for alternating zero bytes which might indicate Unicode
                    if ((pSource[1] == 0) && (pSource[3] == 0) && (pSource[5] == 0) && (pSource[7] == 0))
                        enc = Encoding.Unicode;
                }
            }

            if (enc == null)
                enc = Encoding.Default;

            int bomLength = enc.GetPreamble().Length;

            return enc.GetString(pSource, bomLength, pSource.Length - bomLength);
        }
        public IHTMLElementCollection GetImages(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument() as IHTMLDocument2;
            if (doc2 == null)
                return null;
            return doc2.images as IHTMLElementCollection;
        }
        public IHTMLElementCollection GetAnchors(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument() as IHTMLDocument2;
            if (doc2 == null)
                return null;
            return doc2.anchors as IHTMLElementCollection;
        }
        public string GetSelectedText(bool bTopLevel, bool ReturnAsHTML)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;

            IHTMLDocument2 doc2 = null;
            IHTMLSelectionObject selobj = null;
            IHTMLTxtRange range = null;

            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if( (doc2 == null) || (doc2.selection == null) )
                return string.Empty;

            selobj = doc2.selection as IHTMLSelectionObject;
            if (selobj == null)
                return string.Empty;

            if( (selobj.EventType == "none") || (selobj.EventType == "control") )
                return string.Empty;

            range = selobj.createRange() as IHTMLTxtRange;
            if (range == null)
                return string.Empty;

            if (ReturnAsHTML)
                return range.htmlText;
            else
                return range.text;

        }
        public IHTMLElement ElementFromPoint(bool bTopLevel, int X, int Y)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;

            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.elementFromPoint(X, Y);
            else
                return null;
        }
        //execCommand(true, "insertimage", false, null)
        public bool ExecCommand(bool bTopLevel, string CmdId, bool showUI, object CmdValue)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;

            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.execCommand(CmdId, showUI, CmdValue);
            else
                return false;
        }
        //OleCommandExec(true, MSHTML_COMMAND_IDS.IDM_HTMLEDITMODE, true);
        //OleCommandExec(true, MSHTML_COMMAND_IDS.IDM_COMPOSESETTINGS, "0,0,0,2,0.0.0,255.255.255,Arial");
        public bool OleCommandExec(bool bTopLevel, MSHTML_COMMAND_IDS CmdID, object pvaIn)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;
            IOleCommandTarget m_Doc2OleCommandTraget = null;
            IntPtr m_Guid_MSHTML = m_NullPointer;
            bool bret = false;
            IntPtr pIn = IntPtr.Zero;
            try
            {
                byte[] guidbytes = Iid_Clsids.Guid_MSHTML.ToByteArray();
                m_Guid_MSHTML = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                Marshal.Copy(guidbytes, 0, m_Guid_MSHTML, guidbytes.Length);

                IHTMLDocument2 doc2 = null;
                if (bTopLevel)
                    doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                else
                    doc2 = this.GetActiveDocument();
                if (doc2 == null)
                    return false;
                m_Doc2OleCommandTraget = doc2 as IOleCommandTarget;
                if (m_Doc2OleCommandTraget == null)
                    return false;
                    
                pIn = Marshal.AllocCoTaskMem((int)1024);
                Marshal.GetNativeVariantForObject(pvaIn, pIn);

                bret = (m_Doc2OleCommandTraget.Exec(m_Guid_MSHTML, (uint)CmdID,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    pIn, m_NullPointer) == Hresults.S_OK) ? true : false;

                Marshal.FreeCoTaskMem(m_Guid_MSHTML);
                m_Guid_MSHTML = m_NullPointer;
                Marshal.FreeCoTaskMem(pIn);
                pIn = IntPtr.Zero;
            }
            finally
            {
                if (m_Guid_MSHTML != m_NullPointer)
                    Marshal.FreeCoTaskMem(m_Guid_MSHTML);
                if(pIn != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pIn);
            }
            return bret;
        }
        public bool OleCommandExec(bool bTopLevel, MSHTML_COMMAND_IDS CmdID)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;
            IOleCommandTarget m_Doc2OleCommandTraget = null;
            IntPtr m_Guid_MSHTML = m_NullPointer;
            bool bret = false;
            try
            {
                byte[] guidbytes = Iid_Clsids.Guid_MSHTML.ToByteArray();
                m_Guid_MSHTML = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                Marshal.Copy(guidbytes, 0, m_Guid_MSHTML, guidbytes.Length);

                IHTMLDocument2 doc2 = null;
                if (bTopLevel)
                    doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                else
                    doc2 = this.GetActiveDocument();
                if (doc2 == null)
                    return false;
                m_Doc2OleCommandTraget = doc2 as IOleCommandTarget;
                if (m_Doc2OleCommandTraget == null)
                    return false;

                bret = (m_Doc2OleCommandTraget.Exec(m_Guid_MSHTML, (uint)CmdID,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    m_NullPointer, m_NullPointer) == Hresults.S_OK) ? true : false;

                Marshal.FreeCoTaskMem(m_Guid_MSHTML);
                m_Guid_MSHTML = m_NullPointer;
            }
            finally
            {
                if (m_Guid_MSHTML != m_NullPointer)
                    Marshal.FreeCoTaskMem(m_Guid_MSHTML);
            }
            return bret;
        }
        public object QueryCommandValue(string CmdID)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;

            IHTMLDocument2 doc2 = null;
            doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.queryCommandValue(CmdID);

            return null;
        }
        public bool QueryCommandState(bool bTopLevel, string CmdId)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;

            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.queryCommandState(CmdId);
            else
                return false;
        }
        public IHTMLElement GetElementByID(bool bTopLevel, string idval)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
            else
                doc3 = GetActiveDocument() as IHTMLDocument3;
            if (doc3 != null)
                return doc3.getElementById(idval);
            else
                return null;
        }
        public IHTMLElementCollection GetElementsByName(bool bTopLevel, string elemname)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
            else
                doc3 = GetActiveDocument() as IHTMLDocument3;
            if (doc3 != null)
                return doc3.getElementsByName(elemname) as IHTMLElementCollection;
            else
                return null;
        }
        public IHTMLElementCollection GetElementsByTagName(bool bTopLevel, String tagname)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
            else
                doc3 = GetActiveDocument() as IHTMLDocument3;
            if (doc3 != null)
                return doc3.getElementsByTagName(tagname) as IHTMLElementCollection;
            else
                return null;
        }
        //m_CurWB.execScript(true, "javascript:__doPostBack('NY,412800013,09/15/2007,10010,18,C,165,0','false')", "JavaScript");
        public object execScript(bool bTopLevel, string ScriptName, string ScriptLanguage)
        {
            if ((this.m_WBWebBrowser2 == null) || (ScriptName.Length == 0))
                return null;

            IHTMLDocument2 doc2 = null;
            IHTMLWindow2 win2 = null;

            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 == null)
                return null;

            win2 = doc2.parentWindow as IHTMLWindow2;
            if (win2 == null) //change from !=
                return null;

            //MSDN, JScript is MSHTML default
            if (ScriptLanguage.Length == 0)
                ScriptLanguage = "JavaScript";
            return win2.execScript(ScriptName, ScriptLanguage);
        }
        /// <summary>
        /// Invokes a script within the HTML page
        /// </summary>
        /// <param name="ScriptName"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public object InvokeScript(string ScriptName, object[] Data)
        {
            object oRet = null;

            if (m_WBWebBrowser2 == null)
                return oRet;

            IHTMLDocument doc = m_WBWebBrowser2.Document as IHTMLDocument;
            if (doc == null)
                return oRet;
            object oScript = doc.Script;
            if (oScript == null)
                return oRet;
            //Invoke script
            if (Data == null)
                Data = new object[] { };
            //http://msdn2.microsoft.com/en-us/library/system.reflection.bindingflags.aspx
            oRet = oScript.GetType().InvokeMember(ScriptName,
                System.Reflection.BindingFlags.InvokeMethod, null, oScript, Data);
            return oRet;
        }
        public object InvokeScript(IWebBrowser2 wb, string ScriptName, object[] Data)
        {
            object oRet = null;

            if (wb == null)
                return oRet;

            IHTMLDocument doc = wb.Document as IHTMLDocument;
            if (doc == null)
                return oRet;
            object oScript = doc.Script;
            if (oScript == null)
                return oRet;
            //Invoke script
            if (Data == null)
                Data = new object[] { };
            //http://msdn2.microsoft.com/en-us/library/system.reflection.bindingflags.aspx
            oRet = oScript.GetType().InvokeMember(ScriptName,
                System.Reflection.BindingFlags.InvokeMethod, null, oScript, Data);
            return oRet;
        }

        //Frames related
        public bool IsFrameset()
        {
            return IsWBFrameset(this.m_WBWebBrowser2);
        }
        public int FramesCount()
        {
            return WBFramesCount(this.m_WBWebBrowser2);
        }
        public List<IWebBrowser2> GetFrames()
        {
            return GetFrames(this.m_WBWebBrowser2);
        }
        private List<IWebBrowser2> GetFrames(IWebBrowser2 pWB)
        {
            List<IWebBrowser2> wbFrames = new List<IWebBrowser2>();

            IOleContainer oc = pWB.Document as IOleContainer;
            if (oc == null)
                return null;

            //get the OLE enumerator for the embedded objects
            int hr = 0;
            IEnumUnknown eu;

            hr = oc.EnumObjects(tagOLECONTF.OLECONTF_EMBEDDINGS, out eu); //EU ALLOC
            Marshal.ReleaseComObject(oc);                                 //OC FREE
            Marshal.ThrowExceptionForHR(hr);

            object pUnk = null;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;

            //get the first ebmedded object
            hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);         //PUNK ALLOC
            Marshal.ThrowExceptionForHR(hr);
            //while sucessfully get a new embedding, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                //QI pUnk for the IWebBrowser2 interface
                IWebBrowser2 brow = pUnk as IWebBrowser2;
                if (brow != null)
                {
                    if (IsWBFrameset(brow))
                    {
                        List<IWebBrowser2> frames = GetFrames(brow);
                        if ((frames != null) && (frames.Count > 0))
                        {
                            wbFrames.AddRange(frames);
                            frames.Clear();
                        }
                    }
                    else
                    {
                        wbFrames.Add(brow);
                        //Marshal.ReleaseComObject(brow);                         //PUNK FREE
                    }
                } //if(brow != null)

                //get the next ebmedded object
                hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);       //PUNK ALLOC
                Marshal.ThrowExceptionForHR(hr);

            } //for(int i = 0; HRESULTS.S_OK == hr; i++)
            Marshal.ReleaseComObject(eu);                                 //EU FREE

            return wbFrames;
        }
        private bool IsWBFrameset(IWebBrowser2 pWB)
        {
            bool bRet = true;

            IHTMLDocument2 doc2 = pWB.Document as IHTMLDocument2;
            if (doc2 == null)
                return bRet;

            IHTMLElement elem = doc2.body;
            if (elem != null)
            {
                //QI for IHtmlBodyElement
                IntPtr pbody = Marshal.GetIUnknownForObject(elem);
                IntPtr pbodyelem = IntPtr.Zero;
                if (pbody != IntPtr.Zero)
                {
                    int iRet = Marshal.QueryInterface(pbody, 
                        ref Iid_Clsids.IID_IHTMLBodyElement, out pbodyelem);
                    Marshal.Release(pbody);
                    if( pbodyelem != IntPtr.Zero )
                    {
                        bRet = false;
                        Marshal.Release(pbodyelem);
                    }
                }
                //IHTMLBodyElement bodyelem = (IHTMLBodyElement)elem;
                //MSDN, If no body present then this is a frameset
                //if (bodyelem != null)
                //    bRet = false;
            }

            return bRet;
        }
        private bool IsWBFrameset(IHTMLDocument2 doc2)
        {
            bool bRet = true;
            if (doc2 == null)
                return bRet;

            IHTMLElement elem = doc2.body;
            if (elem != null)
            {
                //QI for IHtmlBodyElement
                IntPtr pbody = Marshal.GetIUnknownForObject(elem);
                IntPtr pbodyelem = IntPtr.Zero;
                if (pbody != IntPtr.Zero)
                {
                    int iRet = Marshal.QueryInterface(pbody,
                        ref Iid_Clsids.IID_IHTMLBodyElement, out pbodyelem);
                    Marshal.Release(pbody);
                    if (pbodyelem != IntPtr.Zero)
                    {
                        bRet = false;
                        Marshal.Release(pbodyelem);
                    }
                }
            }

            return bRet;
        }
        private int WBFramesCount(IWebBrowser2 pWB)
        {
            int lRet = 0;

            IOleContainer oc = pWB.Document as IOleContainer;
            if (oc == null)
                return lRet;

            //get the OLE enumerator for the embedded objects
            int hr = 0;
            IEnumUnknown eu;

            hr = oc.EnumObjects(tagOLECONTF.OLECONTF_EMBEDDINGS, out eu); //EU ALLOC
            Marshal.ReleaseComObject(oc);                                 //OC FREE
            Marshal.ThrowExceptionForHR(hr);

            object pUnk = null;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;

            //get the first ebmedded object
            hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);         //PUNK ALLOC
            Marshal.ThrowExceptionForHR(hr);
            //while sucessfully get a new embedding, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                //QI pUnk for the IWebBrowser2 interface
                IWebBrowser2 brow = pUnk as IWebBrowser2;
                if (brow != null)
                {
                    if (IsWBFrameset(brow))
                        lRet += WBFramesCount(brow);
                    else
                    {
                        lRet++;
                        Marshal.ReleaseComObject(brow);                         //PUNK FREE
                    }
                } //if(brow != null)

                //get the next ebmedded object
                hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);       //PUNK ALLOC
                Marshal.ThrowExceptionForHR(hr);

            } //for(int i = 0; HRESULTS.S_OK == hr; i++)
            Marshal.ReleaseComObject(eu);                                 //EU FREE

            return lRet;
        }

        //Internet shortcuts
        public bool CreateInternetShortCut(string LocalFileName, string URL, string Description, string IconFileName, int IconIndex)
        {
            bool bRet = false;
            Type iURL = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_InternetShortcut);
//#if UNICODE
            IUniformResourceLocatorW pURL = System.Activator.CreateInstance(iURL) as IUniformResourceLocatorW;
//#else
//            IUniformResourceLocatorA pURL = (IUniformResourceLocatorA)System.Activator.CreateInstance(iURL);
//#endif
            if (pURL == null)
                return bRet;

            IPersistFile pPF = pURL as IPersistFile;
            if (pPF == null)
                return bRet;
//#if UNICODE
            IShellLinkW pSL = pURL as IShellLinkW;
//#else
//            IShellLinkA pSL = (IShellLinkA)pURL;
//#endif
            if (pSL == null)
                return bRet;

            int hr = pURL.SetURL(URL, (uint)0);
            if (hr != Hresults.S_OK)
                return bRet;

            if (Description.Length > 0)
                pSL.SetDescription(Description);
            if (IconFileName.Length > 0)
                pSL.SetIconLocation(IconFileName, IconIndex);

            //Save
            pPF.Save(LocalFileName, true);

            return bRet;
        }
        public string ResolveInternetShortCut(string InternetShortCutPath)
        {
            string URL = string.Empty;
            Type iURL = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_InternetShortcut);
//#if UNICODE
            IUniformResourceLocatorW pURL = System.Activator.CreateInstance(iURL) as IUniformResourceLocatorW;
//#else
//            IUniformResourceLocatorA pURL = (IUniformResourceLocatorA)System.Activator.CreateInstance(iURL);
//#endif
            if (pURL == null)
                return URL;

            IPersistFile pPF = pURL as IPersistFile;
            if (pPF == null)
                return URL;

            pPF.Load(InternetShortCutPath, (int)WinApis.STGM_READ);

            IntPtr str = IntPtr.Zero;
            int hr = pURL.GetURL(out str);
            
            if (str == m_NullPointer)
                return URL;

            //IntPtr hIcon, hInst;
            //Icon ico, clone;
            //StringBuilder sb = new StringBuilder(MAX_PATH);
            //int nIconIdx;
////#if UNICODE
//            IShellLinkW pSL = (IShellLinkW)pURL;
////#else
////            IShellLinkA pSL = (IShellLinkA)pURL;
////#endif
            //pSL.GetIconLocation(sb, sb.Capacity, out nIconIdx);
            ////Icon Path: sb.ToString();
            ////Icon index: nIconIdx
            //hInst = Marshal.GetHINSTANCE(this.GetType().Module);
            //hIcon = WinApis.ExtractIcon(hInst, sb.ToString(), nIconIdx);
            //if (hIcon == IntPtr.Zero)
            //    return null;

            //// Return a cloned Icon, because we have to free the original ourselves.
            //ico = Icon.FromHandle(hIcon);
            //clone = (Icon)ico.Clone();
            //ico.Dispose();
            //WinApis.DestroyIcon(hIcon);
            ////clone: Url icon

//#if UNICODE
            URL = Marshal.PtrToStringUni(str);
//#else
//            URL = Marshal.PtrToStringAnsi(str);
//#endif
            Marshal.FreeCoTaskMem(str);

            return URL;
        }

        public bool ClearHistory()
        {
            int hr = Hresults.S_OK;
            Type urlhistorystg2type = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_CUrlHistory, true);
            IUrlHistoryStg2 urlhistorystg2 = System.Activator.CreateInstance(urlhistorystg2type) as IUrlHistoryStg2;
            if (urlhistorystg2 == null)
                return false;
            hr = urlhistorystg2.ClearHistory();
            return (hr == Hresults.S_OK) ? true : false;
        }

        /// <summary>
        /// Call this only once, as other calls are ignored by library.
        /// Allow or disallow HTML dialogs launched using showModelessDialog() 
        /// and showModalDialog() methods using CBT Window Hook.
        /// Default, allow = true
        /// </summary>
        /// <param name="bAllow"></param>
        public void SetAllowHTMLDialogs(bool bAllow)
        {
            if (this.DesignMode)
                return;
            if (bAllow)
            {
                if (m_CBT.IsHooked) //Unhook
                {
                    m_CBT.IsHooked = false;
                    m_csexwbCOMLib.SetupWindowsHook(
                        CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT,
                        (int)this.Handle.ToInt32(),
                        m_CBT.IsHooked,
                        ref m_CBT.UniqueMsgID);
                }
            }
            else
            {
                if (!m_CBT.IsHooked) //Hook
                {
                    m_CBT.IsHooked = true;
                    m_csexwbCOMLib.SetupWindowsHook(
                        CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT,
                        (int)this.Handle.ToInt32(),
                        m_CBT.IsHooked,
                        ref m_CBT.UniqueMsgID);
                }
            }
        }
        public bool GetAllowHTMLDialogs()
        {
            return (m_CBT.IsHooked) ? false : true;
        }

        /// <summary>
        /// Attempts to convert UNICODE chars to their numeric values
        /// to be used with LoadHtmlIntoBrowser methods. sample
        /// "&#1581;&#1602;&#1608;&#1602; &#1575;&#1604;&#1591;&#1576;&#1593;"
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string UnicodeToHTMLEncoding(string html)
        {
            StringBuilder sb = new StringBuilder(html.Length * 7);
            int i = 0;
            const string pre = "&#";
            const string post = ";";
            foreach (char c in html)
            {
                i = (int)c;
                if (i > 127) //Unicode
                {
                    sb.Append(pre);
                    sb.Append(i.ToString()); //Use numeric value 1581
                    sb.Append(post);
                }
                else
                    sb.Append(c);
            }
            if (sb.Length > 0)
                return sb.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// Clears session cookies
        /// </summary>
        /// <returns></returns>
        public bool ClearSessionCookies()
        {
            return WinApis.InternetSetOption(IntPtr.Zero, 
                InternetSetOptionFlags.INTERNET_OPTION_END_BROWSER_SESSION,
                IntPtr.Zero, 0);
        }

        /// <summary>
        /// Adds a given url to the Internet explorer trusted zone
        /// </summary>
        /// <param name="url">format: http://msdn.microsoft.com</param>
        /// <returns></returns>
        public int AddUrlToTrustedZone(string url)
        {
            //Create a new InternetSecurityManager
            Type ismtype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_InternetSecurityManager, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            IInternetSecurityManager ismhelper = System.Activator.CreateInstance(ismtype) as IInternetSecurityManager;
            if (ismhelper == null)
                return Hresults.S_FALSE;
            return ismhelper.SetZoneMapping(
                (int)(tagURLZONE.URLZONE_ESC_FLAG | tagURLZONE.URLZONE_TRUSTED), 
                url, (int)SZM_FLAGS.SZM_CREATE);
        }

        /// <summary>
        /// Attempts to retreive UserAgent from
        /// IHTMLWindow2.navigator object
        /// </summary>
        /// <returns></returns>
        public string UserAgnet()
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;

            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            IHTMLWindow2 win2 = null;
            IOmNavigator navigator = null;

            if (doc2 == null)
                return string.Empty;

            win2 = doc2.parentWindow as IHTMLWindow2;
            if (win2 == null)
                return string.Empty;

            navigator = win2.navigator;
            if (navigator == null)
                return string.Empty;
            return navigator.userAgent;
        }

        /// <summary>
        /// Attempts to set the optical zoom value. Example: 
        /// <code>
        /// m_CurWB.SetOpticalZoomValue(300);
        /// </code>
        /// </summary>
        /// <param name="zoomvalue">Must be in the range 10 - 1000 percent</param>
        /// <returns>One of Hresults.S_OK or S_FALSE</returns>
        public int SetOpticalZoomValue(int zoomvalue)
        {
            if ((zoomvalue < 10) || (zoomvalue > 1000) || (m_WBOleCommandTarget == null))
                return Hresults.S_FALSE;
            IntPtr pRet = m_NullPointer;
            int hr = Hresults.S_FALSE;

            try
            {
                pRet = Marshal.AllocCoTaskMem((int)1024);
                Marshal.GetNativeVariantForObject((int)zoomvalue, pRet);

                hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)OLECMDID.OLECMDID_OPTICAL_ZOOM,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    pRet, m_NullPointer);
                Marshal.FreeCoTaskMem(pRet);
                pRet = m_NullPointer;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (pRet != m_NullPointer)
                    Marshal.FreeCoTaskMem(pRet);
            }
            return hr;
        }

        /// <summary>
        /// Attempts to retreive optical zoom range. Example: 
        /// <code>
        /// int[] range = m_CurWB.GetOpticalZoomRange();
        /// AllForms.m_frmLog.AppendToLog(
        /// "Min==>" + range[0].ToString() + 
        /// "\r\nMax==>" + range[1].ToString());
        /// </code>
        /// </summary>
        /// <returns>Return int array index 0 = Min and index 1 = Max</returns>
        public int[] GetOpticalZoomRange()
        {
            object retVal = new object(); //VT_NULL
            IntPtr pRet = m_NullPointer;
            int iZoom = (int)0;
            int[] range = { 0, 0 };

            if (m_WBOleCommandTarget == null)
                return range;

            try
            {
                pRet = Marshal.AllocCoTaskMem((int)1024);
                Marshal.GetNativeVariantForObject(retVal, pRet);

                //NULL to specify the standard group
                int hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)OLECMDID.OLECMDID_OPTICAL_GETZOOMRANGE,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    m_NullPointer, pRet);

                retVal = Marshal.GetObjectForNativeVariant(pRet);
                Marshal.FreeCoTaskMem(pRet);
                pRet = m_NullPointer;
                if (Type.GetTypeCode(retVal.GetType()) == TypeCode.Int32)
                    iZoom = int.Parse(retVal.ToString());
            }
            catch (Exception)
            {
            }
            finally
            {
                if (pRet != m_NullPointer)
                    Marshal.FreeCoTaskMem(pRet);
            }
            if (iZoom > 0)
            {
                range[0] = WinApis.LoWord(iZoom); //Min
                range[1] = WinApis.HiWord(iZoom); //Max
            }
            return range;
        }

        #endregion

#region Interfaces Implementation

        #region IOleClientSite Members

        int IOleClientSite.SaveObject()
        {
            return Hresults.E_NOTIMPL;
            //throw new Exception("The method or operation is not implemented.");
        }

        int IOleClientSite.GetMoniker(uint dwAssign, uint dwWhichMoniker, out IMoniker ppmk)
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

        #region IOleInPlaceSite Members

        int IOleInPlaceSite.GetWindow(ref IntPtr phwnd)
        {
            phwnd = IntPtr.Zero;
            if (this.IsHandleCreated)
            {
                phwnd = this.Handle;
                return Hresults.S_OK;
            }
            else
                return Hresults.E_FAIL;
        }

        int IOleInPlaceSite.ContextSensitiveHelp(bool fEnterMode)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.CanInPlaceActivate()
        {
            return Hresults.S_OK;
        }

        int IOleInPlaceSite.OnInPlaceActivate()
        {
            return Hresults.S_OK;
        }

        int IOleInPlaceSite.OnUIActivate()
        {
            if (!this.DesignMode)
                m_ieServerWindow = new IEServerWindow(this);
            return Hresults.S_OK;
        }

        int IOleInPlaceSite.GetWindowContext(out IOleInPlaceFrame ppFrame, out IOleInPlaceUIWindow ppDoc, ref tagRECT lprcPosRect, ref tagRECT lprcClipRect, ref tagOIFI lpFrameInfo)
        {
            ppDoc = null;
            ppFrame = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.Scroll(ref tagSIZE scrollExtent)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.OnUIDeactivate(bool fUndoable)
        {
            if( (!this.DesignMode) && (m_ieServerWindow != null) )
            {
                m_ieServerWindow.Release();
                m_ieServerWindow = null;
            }
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.OnInPlaceDeactivate()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.DiscardUndoState()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.DeactivateAndUndo()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.OnPosRectChange(ref tagRECT lprcPosRect)
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region IDocHostShowUI Members
        //Can not catch VBScript MsgBox and InputBox functions and javascript prompt
        //This does catch alert and confirm (VBScript as well)
        int IDocHostShowUI.ShowMessage(IntPtr hwnd, string lpstrText, 
            string lpstrCaption, uint dwType, 
            string lpstrHelpFile, uint dwHelpContext, ref int lpResult)
        {
            //Initially
            //lpResult is set 0 //S_OK
            
            //Host did not display its UI. MSHTML displays its message box.
            int iRet = Hresults.S_FALSE;
            
            //raise event?
            if (WBDocHostShowUIShowMessage != null)
            {
                //Refer to http://msdn2.microsoft.com/en-us/library/ms645505.aspx
                //for possible values of dwType
                DocHostShowUIShowMessageEvent.SetParameters(hwnd, lpstrText, lpstrCaption, dwType, lpstrHelpFile, dwHelpContext, lpResult);
                WBDocHostShowUIShowMessage(this, DocHostShowUIShowMessageEvent);
                if (DocHostShowUIShowMessageEvent.handled)
                {
                    //Host displayed its user interface (UI). MSHTML does not display its message box.
                    iRet = Hresults.S_OK;
                    lpResult = DocHostShowUIShowMessageEvent.result;
                }
                DocHostShowUIShowMessageEvent.Reset();
            }
            ////uncomment to use
            //else
            //{
            //  lpResult = (int)WinApis.MessageBox(hwnd, lpstrText, lpstrCaption, dwType);
            //  iRet = Hresults.S_OK;
            //}
            return iRet;
        }

        int IDocHostShowUI.ShowHelp(IntPtr hwnd, string pszHelpFile, uint uCommand, uint dwData, tagPOINT ptMouse, object pDispatchObjectHit)
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region IDocHostUIHandler Members

        int IDocHostUIHandler.ShowContextMenu(uint dwID, ref tagPOINT pt, object pcmdtReserved, object pdispReserved)
        {
            //    return Hresults.S_OK; //Do not display context menu
            //    return Hresults.S_FALSE; //Default IE ctxmnu

            Point outpt = new Point(pt.X, pt.Y);
            //Raise event
            if (WBContextMenu != null)
            {
                ContextMenuEvent.SetParameters((WB_CONTEXTMENU_TYPES)dwID, outpt, pdispReserved);
                WBContextMenu(this, ContextMenuEvent);
                if (ContextMenuEvent.displaydefault == false) //Handled or don't display
                    return Hresults.S_OK;
                ContextMenuEvent.dispctxmenuobj = null;
            }
            return Hresults.S_FALSE;
        }

        int IDocHostUIHandler.GetHostInfo(ref DOCHOSTUIINFO info)
        {
            //Default, selecttext+no3dborder+flatscrollbars+themes(xp look)
            //Size has be set
            info.cbSize = (uint)Marshal.SizeOf(info);
            info.dwDoubleClick = (uint)m_DocHostUiDbClkFlag;
            info.dwFlags = (uint)m_DocHostUiFlags;
            //info.pchHostCss = "BODY {background-color:#ffcccc}";
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.ShowUI(int dwID, IOleInPlaceActiveObject activeObject, IOleCommandTarget commandTarget, IOleInPlaceFrame frame, IOleInPlaceUIWindow doc)
        {
            //activeObject.GetWindow should return Internet Explorer_Server hwnd
            if (activeObject != null)
                activeObject.GetWindow(ref m_hWBServerHandle);
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.HideUI()
        {
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.UpdateUI()
        {
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.EnableModeless(bool fEnable)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.OnDocWindowActivate(bool fActivate)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.OnFrameWindowActivate(bool fActivate)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.ResizeBorder(ref tagRECT rect, IOleInPlaceUIWindow doc, bool fFrameWindow)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.TranslateAccelerator(ref tagMSG msg, ref Guid group, uint nCmdID)
        {
            //    return Hresults.S_OK; //Cancel
            //    return Hresults.S_FALSE; //IE default action
            Keys nVirtExtKey = Keys.None; // (int)0;
            if ((ModifierKeys & Keys.Control) != 0)
                nVirtExtKey = Keys.ControlKey; //CONTROL 17
            if ((ModifierKeys & Keys.ShiftKey) != 0)
                nVirtExtKey = Keys.ShiftKey; //SHIFT 16
            if ((ModifierKeys & Keys.Menu) != 0)
                nVirtExtKey = Keys.Menu; //ALT 18
            Keys keyCode = (Keys)msg.wParam;

            if ((msg.message == WindowsMessages.WM_KEYDOWN) && (WBKeyDown != null))
            {
                WBKeyDownEvent.SetParameters(keyCode, nVirtExtKey);
                WBKeyDown(this, WBKeyDownEvent);
                if (WBKeyDownEvent.handled)
                    return Hresults.S_OK;
            }
            if ((msg.message == WindowsMessages.WM_KEYUP) && (WBKeyUp != null))
            {
                WBKeyUpEvent.SetParameters(keyCode, nVirtExtKey);
                WBKeyUp(this, WBKeyUpEvent);
                if (WBKeyUpEvent.handled == true)
                    return Hresults.S_OK;
            }
            //IE default action
            return Hresults.S_FALSE;
        }

        int IDocHostUIHandler.GetOptionKeyPath(out string pbstrKey, uint dw)
        {
            //pbstrKey[0] = null;
            pbstrKey = null;
            if (WBGetOptionKeyPath != null)
            {
                GetOptionKeyPathEvent.SetParameters();
                WBGetOptionKeyPath(this, GetOptionKeyPathEvent);
                if (GetOptionKeyPathEvent.handled == true)
                {
                    pbstrKey = GetOptionKeyPathEvent.keypath;
                    GetOptionKeyPathEvent.SetParameters();
                    return Hresults.S_OK;
                }
            }
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.GetDropTarget(IfacesEnumsStructsClasses.IDropTarget pDropTarget, out IfacesEnumsStructsClasses.IDropTarget ppDropTarget)
        {
            int hret = Hresults.E_NOTIMPL;
            ppDropTarget = null;
            if (m_bUseInternalDragDrop)
            {
                ppDropTarget = this as IfacesEnumsStructsClasses.IDropTarget;
                if(ppDropTarget != null)
                    hret = Hresults.S_OK;
            }
            return hret;
        }

        int IDocHostUIHandler.GetExternal(out object ppDispatch)
        {
            if (m_WinExternal != null)
            {
                ppDispatch = m_WinExternal;
                return Hresults.S_OK;
            }
            else
            {
                ppDispatch = null;
                return Hresults.E_NOTIMPL;
            }
        }

        int IDocHostUIHandler.TranslateUrl(uint dwTranslate, string strURLIn, out string pstrURLOut)
        {
            pstrURLOut = null;
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.FilterDataObject(System.Runtime.InteropServices.ComTypes.IDataObject pDO, out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet)
        {
            ppDORet = null;
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region DWebBrowserEvents2 Members

        [System.Runtime.InteropServices.DispId(250)]
        void DWebBrowserEvents2.BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            //For catching Refresh and coordinating events
            m_nPageCounter++;
            bool bTopFrame = m_WBWebBrowser2.Equals(pDisp);

            if(bTopFrame)
                m_DocDone = false;

            //Want events
            if( m_WantHTMLEvents )
            {
                //Top level
                if (bTopFrame)
                {
                    if (m_WantHtmlDocumentEvents)
                        m_TopLevelHtmlDocumentevents.DisconnectHtmlEvents();
                    if (m_WantHtmlWindowEvents)
                        m_TopLevelHtmlWindowEvents.DisconnectHtmlEvents();
                }
                else //Secondary pages (frameset)
                {
                    //Want events and we don't bother with navigation within framesets
                    if ((m_WantHtmlDocumentEvents) && (m_nPageCounter > 1) )
                        DisconnectHtmlDocumentEvents();

                    if( (m_WantHtmlWindowEvents) && (m_nPageCounter > 1) )
                        DisconnectHtmlWindowEvnets();
                }
            }

            if (BeforeNavigate2 != null)
            {
                //Reserved, must be set to null
                Flags = null;
                BeforeNavigate2Event.SetParameters(pDisp, URL.ToString(), TargetFrameName, PostData, Headers, bTopFrame);
                BeforeNavigate2(this, BeforeNavigate2Event);
                Cancel = BeforeNavigate2Event.Cancel;
                BeforeNavigate2Event.Reset();
            }
        }

        [DispId(268)]
        void DWebBrowserEvents2.ClientToHostWindow(ref int CX, ref int CY)
        {
            if (ClientToHostWindow != null)
            {
                ClientToHostWindowEvent.SetParameters(CX, CY);
                ClientToHostWindow(this, ClientToHostWindowEvent);
                if (ClientToHostWindowEvent.handled == true)
                {
                    CX = ClientToHostWindowEvent.cx;
                    CY = ClientToHostWindowEvent.cy;
                }
            }
        }

        [DispId(105)]
        void DWebBrowserEvents2.CommandStateChange(int Command, bool Enable)
        {
            if (Command == (int)CommandStateChangeConstants.CSC_NAVIGATEBACK)
                m_bCanGoBack = Enable;
            else if (Command == (int)CommandStateChangeConstants.CSC_NAVIGATEFORWARD)
                m_bCanGoForward = Enable;

            if (CommandStateChange != null)
            {
                CommandStateChangeEvent.SetParameters(Command, Enable);
                CommandStateChange(this, CommandStateChangeEvent);
            }
        }

        [DispId(104)]
        void DWebBrowserEvents2.DocumentComplete(object pDisp, ref object URL)
        {
            m_nPageCounter--;

            bool bTopFrame = m_WBWebBrowser2.Equals(pDisp);
            if(bTopFrame)
                m_DocDone = true;

            if (m_WantHTMLEvents)
            {
                IHTMLDocument2 doc2 = null;
                if (bTopFrame)
                {
                    doc2 = (IHTMLDocument2)m_WBWebBrowser2.Document;
                    if(m_WantHtmlDocumentEvents)
                        m_TopLevelHtmlDocumentevents.ConnectToHtmlEvents(doc2);
                    if (m_WantHtmlWindowEvents)
                    {
                        IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
                        m_TopLevelHtmlWindowEvents.ConnectToHtmlEvents(win2);
                    }
                }
                else
                {
                    //Nav within frameset, don't bother
                    //Uses the same document object
                    if (m_nPageCounter > 0)
                    {
                        IWebBrowser2 wb2 = (IWebBrowser2)pDisp;
                        doc2 = (IHTMLDocument2)wb2.Document;
                        if (m_WantHtmlDocumentEvents)
                        {
                            cHTMLDocumentEvents doceve = null;
                            ActivateSecondaryHtmlDocumentEvents(ref doceve);
                            if (doceve != null)
                                doceve.ConnectToHtmlEvents(doc2);
                        }
                        if (m_WantHtmlWindowEvents)
                        {
                            cHTMLWindowEvents wineve = null;
                            IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
                            ActivateSecondaryHtmlWindowEvents(ref wineve);
                            if (wineve != null)
                                wineve.ConnectToHtmlEvents(win2);
                        }
                    }
                }
            }

            if (m_bSendSourceOnDocumentCompleteWBEx) //want source?
            {
                if (DocumentCompleteEX != null)
                {
                    //Declare vars
                    string strSource = "";
                    IWebBrowser2 thisBrowser = null;

                    //Reset event object parameters
                    DocumentCompleteExEvent.SetParameters(pDisp, URL.ToString(), bTopFrame, strSource);

                    //Attempt to get a IWebBrowser2 iface from disp
                    //throws an exception if not an html doc
                    thisBrowser = (IWebBrowser2)pDisp;
                    if (thisBrowser == null)
                        return;

                    strSource = GetSource(thisBrowser);
                    DocumentCompleteExEvent.docsource = strSource;
                    DocumentCompleteEX(this, DocumentCompleteExEvent);
                    DocumentCompleteExEvent.Reset();
                }
            }
            else if (DocumentComplete != null) //Do not want source
            {
                DocumentCompleteEvent.SetParameters(pDisp, URL.ToString(), bTopFrame);
                DocumentComplete(this, DocumentCompleteEvent);
                DocumentCompleteEvent.Reset();
            }
            //Go to MSDN library(archive) + stop + refresh
            //without this, refresh end hits somewhere in between documentCompletes
            if ((m_bIsRefresh) && (m_nPageCounter == 0) && (m_nObjCounter == 0))
            {
                m_bIsRefresh = false;
                if (RefreshEnd != null)
                    RefreshEnd(this);
            }
        }

        [DispId(106)]
        void DWebBrowserEvents2.DownloadBegin()
        {
            m_nObjCounter++;
            if (DownloadBegin != null)
                DownloadBegin(this);
            if (m_nPageCounter == 0)
            {
                m_bIsRefresh = true;
                if (RefreshBegin != null)
                    RefreshBegin(this);
            }
        }

        [DispId(259)]
        void DWebBrowserEvents2.DownloadComplete()
        {
            m_nObjCounter--;
            if (DownloadComplete != null)
                DownloadComplete(this);
            if ((m_bIsRefresh) && (m_nPageCounter == 0) && (m_nObjCounter == 0))
            {
                m_bIsRefresh = false;
                if (RefreshEnd != null)
                    RefreshEnd(this);
            }
        }

        [DispId(270)]
        void DWebBrowserEvents2.FileDownload(bool ActiveDocument, ref bool Cancel)
        {
            if ((FileDownload != null) && (m_UseInternalDownloadManager == false))
            {
                FileDownloadEvent.Cancel = false;
                FileDownloadEvent.ActiveDocument = ActiveDocument;
                FileDownload(this, FileDownloadEvent);
                Cancel = FileDownloadEvent.Cancel;
            }
        }

        [DispId(252)]
        void DWebBrowserEvents2.NavigateComplete2(object pDisp, ref object URL)
        {
            if (NavigateComplete2 != null)
            {
                NavigateComplete2Event.SetParameters(pDisp, URL.ToString());
                NavigateComplete2(this, NavigateComplete2Event);
                NavigateComplete2Event.Reset();
            }
        }

        [DispId(271)]
        void DWebBrowserEvents2.NavigateError(object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel)
        {
            if (NavigateError != null)
            {
                if (Frame != null) //Thank you Arjan
                    NavigateErrorEvent.SetParameters(pDisp, URL.ToString(), Frame.ToString(), (int)StatusCode);
                else
                    NavigateErrorEvent.SetParameters(pDisp, URL.ToString(), string.Empty, (int)StatusCode);
                NavigateError(this,NavigateErrorEvent);
                Cancel = NavigateErrorEvent.Cancel;
                NavigateErrorEvent.Reset();
            }
        }

        [DispId(251)]
        void DWebBrowserEvents2.NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            if (NewWindow2 != null)
            {
                NewWindow2Event.SetParameters();
                NewWindow2(this, NewWindow2Event);
                Cancel = NewWindow2Event.Cancel;
                if ((!Cancel) && (NewWindow2Event.browser != null))
                {
                    ppDisp = NewWindow2Event.browser;
                }
                NewWindow2Event.SetParameters();
            }
        }
        
        [DispId(0x111)]
        void DWebBrowserEvents2.NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            
            if (NewWindow3 != null)
            {
                NewWindow3Event.SetParameters(bstrUrlContext, bstrUrl,(NWMF)dwFlags);
                NewWindow3(this, NewWindow3Event);
                Cancel = NewWindow3Event.Cancel;
                if ((!Cancel) && (NewWindow3Event.browser != null))
                {
                    ppDisp = NewWindow3Event.browser;
                }
                NewWindow3Event.Reset();
            }
        }

        #region Unused Events
        void DWebBrowserEvents2.OnFullScreen(bool FullScreen)
        {
            //
        }

        void DWebBrowserEvents2.OnMenuBar(bool MenuBar)
        {
            //
        }

        void DWebBrowserEvents2.OnQuit()
        {
            //
        }

        void DWebBrowserEvents2.OnStatusBar(bool StatusBar)
        {
            //
        }

        void DWebBrowserEvents2.OnTheaterMode(bool TheaterMode)
        {
            //
        }

        void DWebBrowserEvents2.OnToolBar(bool ToolBar)
        {
            //
        }

        void DWebBrowserEvents2.OnVisible(bool Visible)
        {
            //
        }
        #endregion
        
        [DispId(227)]
        void DWebBrowserEvents2.UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
        {
            if (UpdatePageStatus != null)
            {
                if(nPage != null)
                    UpdatePageStatusEvent.SetParameters(pDisp, (int)nPage, (bool)fDone);
                else
                    UpdatePageStatusEvent.SetParameters(pDisp, 0, (bool)fDone);
                UpdatePageStatus(this, UpdatePageStatusEvent);
                UpdatePageStatusEvent.Reset();
            }
        }

        [DispId(225)]
        void DWebBrowserEvents2.PrintTemplateInstantiation(object pDisp)
        {
            if (PrintTemplateInstantiation != null)
            {
                PrintTemplateInstantiationEvent.browser = pDisp;
                PrintTemplateInstantiation(this, PrintTemplateInstantiationEvent);
                PrintTemplateInstantiationEvent.browser = null;
            }
        }

        [DispId(226)]
        void DWebBrowserEvents2.PrintTemplateTeardown(object pDisp)
        {
            if (PrintTemplateTeardown != null)
            {
                PrintTemplateTeardownEvent.browser = pDisp;
                PrintTemplateTeardown(this, PrintTemplateTeardownEvent);
                PrintTemplateTeardownEvent.browser = null;
            }
        }

        [DispId(272)]
        void DWebBrowserEvents2.PrivacyImpactedStateChange(bool bImpacted)
        {
            if (PrivacyImpactedStateChange != null)
            {
                PrivacyImpactedStateChangeEvent.impacted = bImpacted;
                PrivacyImpactedStateChange(this, PrivacyImpactedStateChangeEvent);
            }
        }

        [DispId(108)]
        void DWebBrowserEvents2.ProgressChange(int Progress, int ProgressMax)
        {
            if (ProgressChange != null)
            {
                ProgressChangeEvent.SetParameters(Progress, ProgressMax);
                ProgressChange(this, ProgressChangeEvent);
            }
        }

        [DispId(112)]
        void DWebBrowserEvents2.PropertyChange(string szProperty)
        {
            if (PropertyChange != null)
            {
                PropertyChangeEvent.szproperty = szProperty;
                PropertyChange(this, PropertyChangeEvent);
                PropertyChangeEvent.szproperty = string.Empty;
            }
        }

        [DispId(269)]
        void DWebBrowserEvents2.SetSecureLockIcon(int SecureLockIcon)
        {
            m_SecureLockIcon = SecureLockIcon;
            if (SetSecureLockIcon != null)
            {
                SetSecureLockIconEvent.SetParameters(SecureLockIcon);
                SetSecureLockIcon(this, SetSecureLockIconEvent);
            }
        }

        [DispId(102)]
        void DWebBrowserEvents2.StatusTextChange(string Text)
        {
            if (StatusTextChange != null)
            {
                StatusTextChangeEvent.text = Text;
                StatusTextChange(this, StatusTextChangeEvent);
                StatusTextChangeEvent.text = string.Empty;
            }
        }

        [DispId(113)]
        void DWebBrowserEvents2.TitleChange(string Text)
        {
            if (TitleChange != null)
            {
                TitleChangeEvent.title = Text;
                TitleChange(this, TitleChangeEvent);
                TitleChangeEvent.title = "";
            }
        }

        //DWebBrowserEvents2.WindowClosing is never called?
        //So here is the workaround
        [DispId(263)]
        public void DISPATCH_WindowClosing(bool IsChildWindow, ref bool Cancel)
        {
            if (WindowClosing != null)
            {
                WindowClosingEvent.SetParameters(IsChildWindow);
                WindowClosing(this, WindowClosingEvent);
                Cancel = WindowClosingEvent.Cancel;
            }
        }

        [DispId(263)]
        void DWebBrowserEvents2.WindowClosing(bool IsChildWindow, ref bool Cancel)
        {
        }

        [DispId(267)]
        void DWebBrowserEvents2.WindowSetHeight(int Height)
        {
            if (WindowSetHeight != null)
            {
                WindowSetHeightEvent.height = Height;
                WindowSetHeight(this, WindowSetHeightEvent);
            }
        }

        [DispId(264)]
        void DWebBrowserEvents2.WindowSetLeft(int Left)
        {
            if (WindowSetLeft != null)
            {
                WindowSetLeftEvent.left = Left;
                WindowSetLeft(this, WindowSetLeftEvent);
            }
        }

        [DispId(262)]
        void DWebBrowserEvents2.WindowSetResizable(bool Resizable)
        {
            if (WindowSetResizable != null)
            {
                WindowSetResizableEvent.resizable = Resizable;
                WindowSetResizable(this, WindowSetResizableEvent);
            }
        }

        [DispId(265)]
        void DWebBrowserEvents2.WindowSetTop(int Top)
        {
            if (WindowSetTop != null)
            {
                WindowSetTopEvent.top = Top;
                WindowSetTop(this, WindowSetTopEvent);
            }
        }

        [DispId(266)]
        void DWebBrowserEvents2.WindowSetWidth(int Width)
        {
            if (WindowSetWidth != null)
            {
                WindowSetWidthEvent.width = Width;
                WindowSetWidth(this, WindowSetWidthEvent);
            }
        }

        #endregion

        #region IDropTarget Members

        int IfacesEnumsStructsClasses.IDropTarget.DragEnter(System.Runtime.InteropServices.ComTypes.IDataObject pDataObj, uint grfKeyState, tagPOINT pt, ref uint pdwEffect)
        {
            if (WBDragEnter != null)
            {
                DataObject obja = null;
                if (pDataObj != null)
                    obja = new DataObject(pDataObj);
                Point ppt = new Point(pt.X, pt.Y);
                WBDragEnterEvent.SetParameters(obja, grfKeyState, ppt, pdwEffect);
                WBDragEnter(this, WBDragEnterEvent);
                if (WBDragEnterEvent.handled == true)
                    pdwEffect = (uint)WBDragEnterEvent.dropeffect;
            }
            return Hresults.S_OK;
        }
        int IfacesEnumsStructsClasses.IDropTarget.DragOver(uint grfKeyState, tagPOINT pt, ref uint pdwEffect)
        {
            if (WBDragOver != null)
            {
                Point ppt = new Point(pt.X, pt.Y);
                WBDragOverEvent.SetParameters(grfKeyState, ppt, pdwEffect);
                WBDragOver(this, WBDragOverEvent);
                if (WBDragOverEvent.handled == true)
                    pdwEffect = (uint)WBDragOverEvent.dropeffect;
            }
            return Hresults.S_OK;
        }
        int IfacesEnumsStructsClasses.IDropTarget.DragLeave()
        {
            if (WBDragLeave != null)
                WBDragLeave(this);
            return Hresults.S_OK;
        }
        int IfacesEnumsStructsClasses.IDropTarget.Drop(System.Runtime.InteropServices.ComTypes.IDataObject pDataObj, uint grfKeyState, tagPOINT pt, ref uint pdwEffect)
        {
            if (pDataObj == null)
                return Hresults.S_OK;
            if (WBDragDrop != null)
            {
                DataObject obja = new DataObject(pDataObj);
                Point ppt = new Point(pt.X, pt.Y);
                WBDropEvent.SetParameters(grfKeyState, ppt, obja, pdwEffect);
                WBDragDrop(this, WBDropEvent);
                if (WBDropEvent.handled == true)
                    pdwEffect = (uint)WBDropEvent.dropeffect;
            }
            return Hresults.S_OK;
        }

        #endregion

        #region IOleCommandTarget Members

        int IOleCommandTarget.QueryStatus(IntPtr pguidCmdGroup, uint cCmds, ref tagOLECMD prgCmds, IntPtr pCmdText)
        {
            //int hr = Hresults.S_OK;
            //if (m_WBOleCommandTarget != null)
            //{
            //    try
            //    {
            //        hr = m_WBOleCommandTarget.QueryStatus(pguidCmdGroup,
            //            cCmds, ref prgCmds, ref pCmdText);
            //    }
            //    finally
            //    {
            //    }
            //}
            //else
            //    hr = OLECMDERR_E_NOTSUPPORTED;
            return Hresults.OLECMDERR_E_NOTSUPPORTED;
        }

        //pguidCmdGroup must be declared as IntPtr not a GUID, as pguidCmdGroup may be null, hence generating execption
        int IOleCommandTarget.Exec(IntPtr pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            int hr = Hresults.S_OK;
            
            if ((pguidCmdGroup != m_NullPointer) &&
                (Type.GetTypeCode(pguidCmdGroup.GetType()) != TypeCode.Empty))
            {
                try
                {
                    ////Allocate mem for a GUID
                    //byte[] bguid = Guid.Empty.ToByteArray();
                    ////Copy incoming into byte array
                    //Marshal.Copy(pguidCmdGroup, bguid, 0, bguid.Length);
                    ////back to GUID
                    //Guid guid = new Guid(bguid);

                    Guid guid = (Guid)Marshal.PtrToStructure(pguidCmdGroup, typeof(Guid));

                    //Only group we are interested
                    if (guid == Iid_Clsids.CLSID_CGID_DocHostCommandHandler)
                    {
                        //http://support.microsoft.com/kb/261003
                        if (nCmdID == (int)OLECMDID.OLECMDID_SHOWSCRIPTERROR)
                        {
                            //Default Continue running scripts
                            if (pvaOut != IntPtr.Zero)
                                Marshal.GetNativeVariantForObject(true, pvaOut);
                            //false -> stop running scripts
                            if (ScriptError != null)
                            {
                                ScriptErrorEvent.SetParameters();
                                try
                                {
                                    IHTMLDocument2 doc2 = (IHTMLDocument2)Marshal.GetObjectForNativeVariant(pvaIn);
                                    IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
                                    IHTMLEventObj2 eveobj = (IHTMLEventObj2)win2.eventobj;

                                    if (eveobj != null)
                                    {
                                        ScriptErrorEvent.lineNumber = (int)eveobj.getAttribute("errorLine", 0);
                                        ScriptErrorEvent.characterNumber = (int)eveobj.getAttribute("errorCharacter", 0);
                                        ScriptErrorEvent.errorCode = (int)eveobj.getAttribute("errorCode", 0);
                                        ScriptErrorEvent.errorMessage = eveobj.getAttribute("errorMessage", 0) as string;
                                        ScriptErrorEvent.url = eveobj.getAttribute("errorUrl", 0) as string;
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                ScriptError(this, ScriptErrorEvent);
                                if (pvaOut != IntPtr.Zero)
                                    Marshal.GetNativeVariantForObject(ScriptErrorEvent.continueScripts, pvaOut);
                                ScriptErrorEvent.SetParameters();
                           }
                        }
                        else
                            hr = Hresults.OLECMDERR_E_NOTSUPPORTED;
                    }
                    else
                        hr = Hresults.OLECMDERR_E_UNKNOWNGROUP;
                }
                catch (Exception)
                {
                    hr = Hresults.OLECMDERR_E_UNKNOWNGROUP;
                }
            }
            else
                hr = Hresults.OLECMDERR_E_UNKNOWNGROUP;
            return hr;
        }

        #endregion

        #region IServiceProvider Members

        int IfacesEnumsStructsClasses.IServiceProvider.QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
        {
            int hr = Hresults.E_NOINTERFACE;
            ppvObject = m_NullPointer;

            if ((guidService == Iid_Clsids.SID_SDownloadManager) &&
                (riid == Iid_Clsids.IID_IDownloadManager) &&
                (m_UseInternalDownloadManager))
            {
                AddThisIEServerHwndToComLib();
                //QI for IDownloadManager interface from our COM object
                ppvObject = Marshal.GetComInterfaceForObject(m_csexwbCOMLib, typeof(IDownloadManager));
                hr = Hresults.S_OK;
            }
            else if (riid == Iid_Clsids.IID_IHttpSecurity)
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IHttpSecurity));
                hr = Hresults.S_OK;

                //Ulternative
                //try
                //{
                //    m_pUnk = IntPtr.Zero;
                //    m_pTargetIface = IntPtr.Zero;
                //    m_pUnk = Marshal.GetIUnknownForObject(this);
                //    Marshal.QueryInterface(m_pUnk, ref IID_IHttpSecurity, out m_pTargetIface);
                //    Marshal.Release(m_pUnk);
                //    ppvObject = m_pTargetIface;
                //    hr = Hresults.S_OK;
                //}
                //catch (Exception)
                //{
                //}
            }
            else if (riid == Iid_Clsids.IID_INewWindowManager) //xpsp2
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(INewWindowManager));
                hr = Hresults.S_OK;
            }
            else if (riid == Iid_Clsids.IID_IWindowForBindingUI)
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IWindowForBindingUI));
                hr = Hresults.S_OK;
            }
            else if (guidService == Iid_Clsids.IID_IInternetSecurityManager)
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IInternetSecurityManager));
                hr = Hresults.S_OK;
            }
            else if ((guidService == Iid_Clsids.IID_IAuthenticate)
               && (riid == Iid_Clsids.IID_IAuthenticate))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IAuthenticate));
                hr = Hresults.S_OK;
            }
            else if (riid == Iid_Clsids.IID_IProtectFocus) //IE7 + Vista
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IProtectFocus));
                hr = Hresults.S_OK;
            }
            else if ((riid == Iid_Clsids.IID_IHTMLOMWindowServices) &&
                (guidService == Iid_Clsids.IID_IHTMLOMWindowServices))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IHTMLOMWindowServices));
                hr = Hresults.S_OK;
            }
            else if ((riid == Iid_Clsids.IID_IHTMLEditHost) &&
                (guidService == Iid_Clsids.SID_SHTMLEditHost))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IHTMLEditHost));
                hr = Hresults.S_OK;
            }

            return hr;
        }

        #endregion

        #region IHttpSecurity Members

        int IHttpSecurity.GetWindow(ref Guid rguidReason, ref IntPtr phwnd)
        {
            phwnd = m_NullPointer;
            int hr = Hresults.S_FALSE;
            if ((rguidReason == Iid_Clsids.IID_IHttpSecurity) || (rguidReason == Iid_Clsids.IID_IAuthenticate))
            {
                if (!WBIEServerHandle().Equals(m_NullPointer))
                {
                    phwnd = m_hWBServerHandle;
                    hr = Hresults.S_OK;
                }
            }
            return hr;
        }
        int IHttpSecurity.OnSecurityProblem(uint dwProblem)
        {
            /*
            IHttpSecurity, Some possible problems:
                ERROR_INTERNET_SEC_CERT_DATE_INVALID
                ERROR_INTERNET_SEC_CERT_CN_INVALID
                ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR
                ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR
                ERROR_HTTP_REDIRECT_NEEDS_CONFIRMATION
                ERROR_INTERNET_INVALID_CA
                ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED
            Implementing this method incorrectly can compromise the security of your application.
            Returning a value of RPC_E_RETRY can potentially leave users of your application exposed
            to unwanted information disclosure. RPC_E_RETRY should only be returned when
            the application is running on a known trusted server or after you have verified
            information from the user.
            
		    Returning S_FALSE implies that you have asked the user
		    if it is ok to proceed despite a security problem and they have agreed
		    return RPC_E_RETRY;
		    Retries using Registry options and most likely fails again
            */

            //dwProblem one of WinInetErrors enum (need more additions)
            int iRet = Hresults.S_FALSE;
            int hr = iRet;
            if (WBSecurityProblem != null)
            {
                SecurityProblemEvent.SetParameters((int)dwProblem);
                WBSecurityProblem(this, SecurityProblemEvent);
                //Possible ret values
                if (SecurityProblemEvent.handled == true)
                {
                    iRet = SecurityProblemEvent.retvalue;
                    if ((iRet == Hresults.RPC_E_RETRY) || (iRet == Hresults.S_FALSE) || (iRet == Hresults.E_ABORT))
                        hr = iRet;
                }
            }
            //Possible return values;
            //RPC_E_RETRY (cautious) The calling application should continue or retry the download. 
            //S_FALSE The calling application should open a dialog box to warn the user. 
            //E_ABORT The calling application should abort the download.
            return hr;
        }

        #endregion

        #region IWindowForBindingUI Members

        int IWindowForBindingUI.GetWindow(ref Guid rguidReason, ref IntPtr phwnd)
        {
            phwnd = m_NullPointer;
            int hr = Hresults.S_FALSE;
            if ((rguidReason == Iid_Clsids.IID_IHttpSecurity) || (rguidReason == Iid_Clsids.IID_IAuthenticate))
            {
                if (!WBIEServerHandle().Equals(m_NullPointer))
                {
                    phwnd = m_hWBServerHandle;
                    hr = Hresults.S_OK;
                }
            }
            return hr;
        }

        #endregion

        #region INewWindowManager Members

        int INewWindowManager.EvaluateNewWindow(string pszUrl, string pszName,
            string pszUrlContext, string pszFeatures, bool fReplace, uint dwFlags, uint dwUserActionTime)
        {
            int hr = Hresults.E_FAIL; //To perform default IE action - Calls NewWindow3 else NewWindow2 else shows popup
            if (WBEvaluteNewWindow != null)
            {
                EvaluateNewWindowEvent.SetParameters(pszUrl, pszName, pszUrlContext, pszFeatures, fReplace, (int)dwFlags, (int)dwUserActionTime);
                WBEvaluteNewWindow(this, EvaluateNewWindowEvent);
                if (EvaluateNewWindowEvent.Cancel == true)
                    hr = Hresults.S_FALSE; //Block
                    //hr = Hresults.S_OK; //Allow all
                EvaluateNewWindowEvent.Reset();
            }
            return hr;
        }

        #endregion

        #region IAuthenticate Members

        //To pass a doamin as in a NTLM authentication scheme, use this format: Username = Domain\username
        int IAuthenticate.Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername, ref IntPtr pszPassword)
        {
            int hr = Hresults.E_ACCESSDENIED; //to abort, to proceed Hresults.S_OK
            int iRet = hr; //Assume failure
            phwnd = this.Handle;
            pszUsername = IntPtr.Zero;
            pszPassword = IntPtr.Zero;
            if (WBAuthenticate != null)
            {
                AuthenticateEvent.SetParameters();
                WBAuthenticate(this, AuthenticateEvent);
                if (AuthenticateEvent.handled == true)
                {
                    //Marshal.StringToCoTaskMemAuto
                    pszUsername = Marshal.StringToCoTaskMemUni(AuthenticateEvent.username);
                    pszPassword = Marshal.StringToCoTaskMemUni(AuthenticateEvent.password);
                    iRet = AuthenticateEvent.retvalue; //Should be 0
                }
                //Reset
                AuthenticateEvent.SetParameters();
                //accepted return values
                if ((iRet == Hresults.S_OK) || (iRet == Hresults.E_INVALIDARG) || (iRet == Hresults.E_ACCESSDENIED))
                    hr = iRet;
            }
            return hr;
        }

        #endregion
        
        #region IInternetSecurityManager Members

        int IInternetSecurityManager.SetSecuritySite(IntPtr pSite)
        {
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.GetSecuritySite(out IntPtr pSite)
        {
            pSite = IntPtr.Zero;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.MapUrlToZone(string pwszUrl, out uint pdwZone, uint dwFlags)
        {
            // All URLs are on the local machine - most trusted and return S_OK;
            //pdwZone = (uint)tagURLZONE.URLZONE_LOCAL_MACHINE;
            //pdwZone =  (uint)tagURLZONE.URLZONE_INTRANET;
            //pdwZone =  (uint)tagURLZONE.URLZONE_TRUSTED; //....
            //return Hresults.S_OK;

            pdwZone = 0;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        //private const string m_strSecurity = "None:localhost+My Computer";
        int IInternetSecurityManager.GetSecurityId(string pwszUrl, IntPtr pbSecurityId, ref uint pcbSecurityId, ref uint dwReserved)
        {
            //pbSecurityId = Marshal.StringToCoTaskMemAnsi(m_strSecurity);
            //pcbSecurityId = (uint)m_strSecurity.Length;
            //return Hresults.S_OK;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        /*
        MSDN:
        The current list of URLACTION that will not be passed to the custom security manager
        in most circumstances by Internet Explorer 5 are:
	        URLACTION_SHELL_FILE_DOWNLOAD 
	        URLACTION_COOKIES 
	        URLACTION_JAVA_PERMISSIONS 
	        URLACTION_SCRIPT_PASTE 
        There is no workaround for this problem. The behavior for the URLACTION can only be
        changed for all browser clients on the system by altering the security zone settings
        from Internet Options.
        */
        int IInternetSecurityManager.ProcessUrlAction(string pwszUrl, uint dwAction, IntPtr pPolicy, uint cbPolicy, IntPtr pContext, uint cbContext, uint dwFlags, uint dwReserved)
        {
            if(ProcessUrlAction == null)
                return (int)WinInetErrors.INET_E_DEFAULT_ACTION;

            try
            {
                URLACTION action = (URLACTION)dwAction;
                ProcessUrlActionFlags flags = (ProcessUrlActionFlags)dwFlags;
                bool hasUrlPolicy = (cbPolicy >= unchecked((uint)Marshal.SizeOf(typeof(int))));
                URLPOLICY urlPolicy = (hasUrlPolicy) ? urlPolicy = (URLPOLICY)Marshal.ReadInt32(pPolicy) : URLPOLICY.ALLOW;
                bool hasContext = (cbContext >= unchecked((uint)Marshal.SizeOf(typeof(Guid))));
                Guid context = (hasContext) ? (Guid)Marshal.PtrToStructure(pContext, typeof(Guid)) : Guid.Empty;

                ProcessUrlActionEvent.SetParameters(pwszUrl, action, urlPolicy, context, flags, hasContext);
                ProcessUrlAction(this, ProcessUrlActionEvent);

                if (ProcessUrlActionEvent.handled && hasUrlPolicy)
                {
                    Marshal.WriteInt32(pPolicy, (int)ProcessUrlActionEvent.urlPolicy);
                    return (ProcessUrlActionEvent.Cancel) ? Hresults.S_FALSE : Hresults.S_OK;
                }
            }
            finally
            {
                ProcessUrlActionEvent.ResetParameters();
            }
            
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.QueryCustomPolicy(string pwszUrl, ref Guid guidKey, out IntPtr ppPolicy, out uint pcbPolicy, IntPtr pContext, uint cbContext, uint dwReserved)
        {
            ppPolicy = IntPtr.Zero;
            pcbPolicy = 0;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.SetZoneMapping(uint dwZone, string lpszPattern, uint dwFlags)
        {
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.GetZoneMappings(uint dwZone, out IEnumString ppenumString, uint dwFlags)
        {
            ppenumString = null;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        #endregion

        #region IProtectFocus Members

            void IProtectFocus.AllowFocusChange(ref bool pfAllow)
            {
                if (AllowFocusChange != null)
                {
                    AllowFocusChangeEvent.Cancel = false;
                    AllowFocusChange(this, AllowFocusChangeEvent);
                    if (AllowFocusChangeEvent.Cancel)
                        pfAllow = false;
                }
            }

        #endregion

        #region IHTMLOMWindowServices Members

        void IHTMLOMWindowServices.moveTo(int x, int y)
        {
            if (HTMLOMWindowServices_moveTo != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_moveTo(this, HTMLOMWindowServicesEvent);
            }
        }

        void IHTMLOMWindowServices.moveBy(int x, int y)
        {
            if (HTMLOMWindowServices_moveBy != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_moveBy(this, HTMLOMWindowServicesEvent);
            }
        }

        void IHTMLOMWindowServices.resizeTo(int x, int y)
        {
            if (HTMLOMWindowServices_resizeTo != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_resizeTo(this, HTMLOMWindowServicesEvent);
            }
        }

        void IHTMLOMWindowServices.resizeBy(int x, int y)
        {
            if (HTMLOMWindowServices_resizeBy != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_resizeBy(this, HTMLOMWindowServicesEvent);
            }
        }

        #endregion

#endregion //Interfaces Implementation

#region HTML Document and Window Events

        //For now, only HtmlDocumentEvents and HtmlWindowEvents2 are supported
        public void ActivateHTMLEvents(HTMLEventType EventType, int[] HTMLEventDispIds)
        {
            if (EventType == HTMLEventType.HTMLDocumentEvent)
            {
                m_TopLevelHtmlDocumentevents.InitHTMLEvents(this, HTMLEventDispIds, Iid_Clsids.DIID_HTMLDocumentEvents2);
                m_WantHtmlDocumentEvents = true;
            }
            else if (EventType == HTMLEventType.HTMLWindowEvent)
            {
                m_TopLevelHtmlWindowEvents.InitHTMLEvents(this, HTMLEventDispIds, Iid_Clsids.DIID_HTMLWindowEvents2);
                m_WantHtmlWindowEvents = true;
            }
            else
                return;
            m_WantHTMLEvents = true;
        }

        private void ActivateSecondaryHtmlDocumentEvents(ref cHTMLDocumentEvents doceve)
        {
            if (m_HtmlDocumentEventsList.Count == 0) //first one
            {
                doceve = new cHTMLDocumentEvents();
            }
            else
            {
                //Search for an idle one
                foreach (cHTMLDocumentEvents eve in m_HtmlDocumentEventsList)
                {
                    if (!eve.m_IsCOnnected)
                    {
                        doceve = eve;
                        break;
                    }
                }
                //Did we find any
                if (doceve == null)
                    doceve = new cHTMLDocumentEvents();
            }

            if (doceve != null)
            {
                doceve.InitHTMLEvents(this, m_TopLevelHtmlDocumentevents.m_dispIds, m_TopLevelHtmlDocumentevents.m_guid);
                m_HtmlDocumentEventsList.Add(doceve);
            }
        }

        private void ActivateSecondaryHtmlWindowEvents(ref cHTMLWindowEvents wineve)
        {
            if (m_HtmlWindowEventsList.Count == 0)
            {
                wineve = new cHTMLWindowEvents();
            }
            else
            {
                foreach (cHTMLWindowEvents eve in m_HtmlWindowEventsList)
                {
                    if (!eve.m_IsCOnnected)
                    {
                        wineve = eve;
                        break;
                    }
                }
                if (wineve == null)
                    wineve = new cHTMLWindowEvents();
            }

            if (wineve != null)
            {
                wineve.InitHTMLEvents(this, m_TopLevelHtmlWindowEvents.m_dispIds, m_TopLevelHtmlWindowEvents.m_guid);
                m_HtmlWindowEventsList.Add(wineve);
            }
        }

        private void DisconnectHtmlDocumentEvents()
        {
            if (m_HtmlDocumentEventsList.Count > 0)
            {
                foreach (cHTMLDocumentEvents doceve in m_HtmlDocumentEventsList)
                {
                    doceve.DisconnectHtmlEvents();
                }
            }
        }

        private void DisconnectHtmlWindowEvnets()
        {
            if (m_HtmlWindowEventsList.Count > 0)
            {
                foreach (cHTMLWindowEvents wineven in m_HtmlWindowEventsList)
                {
                    wineven.DisconnectHtmlEvents();
                }
            }
        }

        public void DeactivateHTMLEvents(HTMLEventType EventType)
        {
            m_WantHTMLEvents = false;
            if (EventType == HTMLEventType.HTMLDocumentEvent)
            {
                m_WantHtmlDocumentEvents = false;
                m_TopLevelHtmlDocumentevents.DisconnectHtmlEvents();
                DisconnectHtmlDocumentEvents();
            }
            else
            {
                m_WantHtmlWindowEvents = false;
                m_TopLevelHtmlWindowEvents.DisconnectHtmlEvents();
                DisconnectHtmlWindowEvnets();
            }
        }

        bool IHTMLEventCallBack.HandleHTMLEvent(HTMLEventType EventType, HTMLEventDispIds EventDispId, IHTMLEventObj pEvtObj)
        {
            bool bret = true; //always allow default processing
            if (HTMLEvent != null)
            {
                HtmlEventArg.ResetParameters(EventType, EventDispId, pEvtObj);
                HTMLEvent(this, HtmlEventArg);
                //Not all events are cancellable
                if (HtmlEventArg.Cancel)
                    bret = false;
                HtmlEventArg.ResetParameters(HTMLEventType.HTMLEventNone, 0, null);
            }
            return bret;
        }

#endregion //HTML Document and Window Events

#region Subclassing IEServer
    
    /// <summary>
    /// Class to enable this control to catch back and forward mouse buttons
    /// and call webbrowser GoBack and GoForward methods.
    /// Contributed by logan1337 - Aug 13 2007
    /// http://www.codeproject.com/cs/miscctrl/csEXWB.asp?df=100&forumid=422031&select=2180453#xx2180453xx
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class IEServerWindow : NativeWindow
    {

        private cEXWB browser;

        public IEServerWindow(cEXWB wb)
        {
            this.browser = wb;

            if (!wb.IEServerHwnd.Equals(IntPtr.Zero))
            {
                AssignHandle(wb.IEServerHwnd);
            }
        }

        public void Release()
        {
            ReleaseHandle();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WindowsMessages.WM_XBUTTONDOWN:
                    if (m.WParam.ToInt32() >> 16 == 1) // back button
                    {
                        if(browser.CanGoBack)
                            browser.GoBack();
                    }
                    else if (m.WParam.ToInt32() >> 16 == 2) // forward button
                    {
                        if (browser.CanGoForward)
                            browser.GoForward();
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }

#endregion

#region Downloader + Asynchronous pluggable protocols (APP), via CSEXWBDLMAN COM assembly

    private string m_DownloadDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar.ToString();
    private bool m_UseInternalDownloadManager = true;
    private CSEXWBDLMANLib.csDLManClass m_csexwbCOMLib = null;

    public event csExWB.FileDownloadExEventHandler FileDownloadExStart = null;
    public event csExWB.FileDownloadExEndEventHandler FileDownloadExEnd = null;
    public event csExWB.FileDownloadExProgressEventHandler FileDownloadExProgress = null;
    public event csExWB.FileDownloadExAuthenticateEventHandler FileDownloadExAuthenticate = null;
    public event csExWB.FileDownloadExErrorEventHandler FileDownloadExError = null;
    public event csExWB.ProtocolHandlerOnBeginTransactionEventHandler ProtocolHandlerOnBeginTransaction = null;
    public event csExWB.ProtocolHandlerOnResponseEventHandler ProtocolHandlerOnResponse = null;

    private FileDownloadExEventArgs FileDownloadExEventArg = new FileDownloadExEventArgs();
    private FileDownloadExEndEventArgs FileDownloadExEndEventArg = new FileDownloadExEndEventArgs();
    private FileDownloadExProgressEventArgs FileDownloadExProgressEventArg = new FileDownloadExProgressEventArgs();
    private FileDownloadExAuthenticateEventArgs FileDownloadExAuthenticateEventArg = new FileDownloadExAuthenticateEventArgs();
    private FileDownloadExErrorEventArgs FileDownloadExErrorEventArg = new FileDownloadExErrorEventArgs();
    private ProtocolHandlerOnBeginTransactionEventArgs ProtocolHandlerOnBeginTransactionEventArg = new ProtocolHandlerOnBeginTransactionEventArgs();
    private ProtocolHandlerOnResponseEventArgs ProtocolHandlerOnResponseEventArg = new ProtocolHandlerOnResponseEventArgs();

    [Category("ExWB"), Description("Set to true, default, to allow the control to take over file downloads. FileDownloadExxxx events are fired instead of FileDownload.")]
    public bool UseInternalDownloadManager
    {
        get
        {
            return m_UseInternalDownloadManager;
        }

        set
        {
            m_UseInternalDownloadManager = value;
        }
    }

    [Category("ExWB"), Description("Default file download directory. Set to MyDocuments by default. Used only if UseInternalDownloadManager property is set to true.")]
    public string FileDownloadDirectory
    {
        get
        {
            return m_DownloadDir;
        }

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                    m_DownloadDir = value;
                else
                    m_DownloadDir = value + System.IO.Path.DirectorySeparatorChar;
            }
        }
    }

    /// <summary>
    /// Checks to determine if m_DownloadManager object has been set up.
    /// </summary>
    private void InitCOMLibrary()
    {
        //if (m_DownloadManager == null)
        //{
            m_csexwbCOMLib = new CSEXWBDLMANLib.csDLManClass();
            m_csexwbCOMLib.ProtocolHandlerOnBeginTransaction += new CSEXWBDLMANLib._IcsDLManEvents_ProtocolHandlerOnBeginTransactionEventHandler(dlman_ProtocolHandlerOnBeginTransaction);
            m_csexwbCOMLib.ProtocolHandlerOnResponse += new CSEXWBDLMANLib._IcsDLManEvents_ProtocolHandlerOnResponseEventHandler(dlman_ProtocolHandlerOnResponse);
            m_csexwbCOMLib.FileDownloadEx += new CSEXWBDLMANLib._IcsDLManEvents_FileDownloadExEventHandler(dl_FileDownloadEx);
            m_csexwbCOMLib.OnFileDLEndDownload += new CSEXWBDLMANLib._IcsDLManEvents_OnFileDLEndDownloadEventHandler(dl_OnFileDLEndDownload);
            m_csexwbCOMLib.OnFileDLDownloadError += new CSEXWBDLMANLib._IcsDLManEvents_OnFileDLDownloadErrorEventHandler(dl_OnFileDLDownloadError);
            m_csexwbCOMLib.OnFileDLAuthenticate += new CSEXWBDLMANLib._IcsDLManEvents_OnFileDLAuthenticateEventHandler(m_DownloadManager_OnFileDLAuthenticate);
            m_csexwbCOMLib.OnFileDLProgress += new CSEXWBDLMANLib._IcsDLManEvents_OnFileDLProgressEventHandler(m_DownloadManager_OnFileDLProgress);
            //m_DownloadManager.OnFileDLBeginningTransaction += new CSEXWBDLMANLib._IcsDLManEvents_OnFileDLBeginningTransactionEventHandler(m_DownloadManager_OnFileDLBeginningTransaction);
            //m_DownloadManager.OnFileDLResponse += new CSEXWBDLMANLib._IcsDLManEvents_OnFileDLResponseEventHandler(m_DownloadManager_OnFileDLResponse);
        //}
    }

    private void AddThisIEServerHwndToComLib()
    {
        if (m_hWBServerHandle != IntPtr.Zero)
            m_csexwbCOMLib.HWNDInternetExplorerServer = m_hWBServerHandle.ToInt32();
        else if (WBIEServerHandle() != IntPtr.Zero)
                m_csexwbCOMLib.HWNDInternetExplorerServer = m_hWBServerHandle.ToInt32();
    }

    /// <summary>
    /// Attempts to download a file asynch.
    /// FileDownloadExxxx events are used for notifications.
    /// </summary>
    /// <param name="Url"></param>
    /// <returns>A unique id assigned to this file download.
    /// Can be used to cancel a download.</returns>
    public int DownloadFile(string Url)
    {
        AddThisIEServerHwndToComLib();
        int i = 0;
        m_csexwbCOMLib.DownloadUrlAsync(Url, ref i);
        return i;
    }

    /// <summary>
    /// Stops a file download
    /// </summary>
    /// <param name="dlUID">Unique id for this file download</param>
    public void StopFileDownload(int dlUID)
    {
        if (m_csexwbCOMLib == null)
            return;
        m_csexwbCOMLib.CancelFileDownload(dlUID);
    }

    /// <summary>
    /// Monitor and/or cancel every HTTP protocol request and responde
    /// including images, sounds, scripts, ... 
    /// Notifications are send via ProtocolHandlerOnResponse and
    /// ProtocolHandlerOnBeginTransaction events
    /// </summary>
    public void StartHTTPAPP()
    {
        AddThisIEServerHwndToComLib();
        if (!m_csexwbCOMLib.HTTPprotocol)
        {
            m_csexwbCOMLib.HTTPprotocol = true;
        }
    }

    public void StopHTTPAPP()
    {
        if (m_csexwbCOMLib.HTTPprotocol)
        {
            m_csexwbCOMLib.HTTPprotocol = false;
        }
    }

    public void StopHTTPSAPP()
    {
        if (m_csexwbCOMLib.HTTPSprotocol)
        {
            m_csexwbCOMLib.HTTPSprotocol = false;
        }
    }

    /// <summary>
    /// Monitor and/or cancel every HTTPS protocol request and responde
    /// including images, sounds, scripts, ... 
    /// Notifications are send via ProtocolHandlerOnResponse and
    /// ProtocolHandlerOnBeginTransaction events
    /// </summary>
    public void StartHTTPSAPP()
    {
        AddThisIEServerHwndToComLib();
        if (!m_csexwbCOMLib.HTTPSprotocol)
        {
            m_csexwbCOMLib.HTTPSprotocol = true;
        }
    }

    //
    //EVENTS
    //

    void dlman_ProtocolHandlerOnResponse(int IEServerHwnd, string sURL, string sResponseHeaders, string sRedirectedUrl, string sRedirectHeaders, ref bool Cancel)
    {
        if (ProtocolHandlerOnResponse != null)
        {
            ProtocolHandlerOnResponseEventArg.SetParameters(sURL, sResponseHeaders, sRedirectedUrl, sRedirectHeaders);
            ProtocolHandlerOnResponse(this, ProtocolHandlerOnResponseEventArg);
            if (ProtocolHandlerOnResponseEventArg.Cancel)
                Cancel = true;
            ProtocolHandlerOnResponseEventArg.Reset();
        }
    }

    void dlman_ProtocolHandlerOnBeginTransaction(int IEServerHwnd, string sURL, string sRequestHeaders, ref string sAdditionalHeaders, ref bool Cancel)
    {
        if (ProtocolHandlerOnBeginTransaction != null)
        {
            ProtocolHandlerOnBeginTransactionEventArg.SetParameters(sURL, sRequestHeaders);
            ProtocolHandlerOnBeginTransaction(this, ProtocolHandlerOnBeginTransactionEventArg);
            if (!ProtocolHandlerOnBeginTransactionEventArg.Cancel)
            {
                //Additional headers can be added to what is already
                //being send by Webbrowser control
                if (!string.IsNullOrEmpty(ProtocolHandlerOnBeginTransactionEventArg.m_AdditionalHeadersToAdd))
                    sAdditionalHeaders = ProtocolHandlerOnBeginTransactionEventArg.m_AdditionalHeadersToAdd;
            }
            else
                Cancel = true;
            ProtocolHandlerOnBeginTransactionEventArg.Reset();
        }
    }

    void dl_OnFileDLDownloadError(int dlUID, string sURL, string sErrorMsg)
    {
        if (FileDownloadExError != null)
        {
            FileDownloadExErrorEventArg.SetParameters(dlUID, sURL, sErrorMsg);
            FileDownloadExError(this, FileDownloadExErrorEventArg);
            FileDownloadExErrorEventArg.Reset();
        }
    }

    void m_DownloadManager_OnFileDLProgress(int dlUID, string sURL, int lProgress, int lProgressMax, ref bool CancelDl)
    {
        if (this.FileDownloadExProgress != null)
        {
            FileDownloadExProgressEventArg.SetParameters(dlUID, sURL, lProgress, lProgressMax);
            FileDownloadExProgress(this, FileDownloadExProgressEventArg);
            if (FileDownloadExProgressEventArg.Cancel)
                CancelDl = FileDownloadExProgressEventArg.Cancel;
            FileDownloadExProgressEventArg.Reset();
        }
    }

    //Default value of Cancel = false
    void m_DownloadManager_OnFileDLAuthenticate(int dlUID, ref string sUsername, ref string sPassword, ref bool Cancel)
    {
        if (FileDownloadExAuthenticate != null)
        {
            FileDownloadExAuthenticateEventArg.SetParameters(dlUID);
            FileDownloadExAuthenticate(this, FileDownloadExAuthenticateEventArg);
            if (!FileDownloadExAuthenticateEventArg.Cancel)
            {
                sUsername = FileDownloadExAuthenticateEventArg.username;
                sPassword = FileDownloadExAuthenticateEventArg.password;
            }
            FileDownloadExAuthenticateEventArg.Reset();
        }
    }

    void dl_OnFileDLEndDownload(int dlUID, string sURL, string sSavedFilePath)
    {
        if (FileDownloadExEnd != null)
        {
            FileDownloadExEndEventArg.SetParameters(dlUID, sURL, sSavedFilePath);
            FileDownloadExEnd(this, FileDownloadExEndEventArg);
            FileDownloadExEndEventArg.Reset();
        }
        else
        {
            //Just let user know for now
            WinApis.MessageBox(this.Handle, "Download URL:\r\n" + sURL + "Saved To:\r\n" + sSavedFilePath, "File Download Completed", 0);
        }
    }

    void dl_FileDownloadEx(int dlUID, string sURL, string sFilename, string sExt, string sFileSize, string sExtraHeaders, string sRedirURL, ref bool SendProgressEvents, ref bool bStopDownload, ref string sPathToSave)
    {
        if (FileDownloadExStart != null)
        {
            FileDownloadExEventArg.SetParameters(dlUID, sURL, sFilename, sExt, sFileSize, sExtraHeaders, sRedirURL);
            FileDownloadExStart(this, FileDownloadExEventArg);
            if (!FileDownloadExEventArg.Cancel)
            {
                //Otherwise file will be saved in the same dir as exe
                //with the sFilename (file.zip)
                if (!string.IsNullOrEmpty(FileDownloadExEventArg.m_PathToSave))
                    sPathToSave = FileDownloadExEventArg.m_PathToSave;
                SendProgressEvents = FileDownloadExEventArg.m_SendProgressEvents;
            }
            else
                bStopDownload = true;
            FileDownloadExEventArg.Reset();
        }
        else
        {
            SendProgressEvents = false;
            //Save it in the downloaddir
            if (!string.IsNullOrEmpty(m_DownloadDir)) //Users MyDocument
                sPathToSave = m_DownloadDir + sFilename;
        }
    }

    //void m_DownloadManager_OnFileDLResponse(int dlUID, string sURL, int lResponseCode, string sResponseHeaders, ref bool CancelDl)
    //{
    //    //Check against WinInetErrors enum
    //    if( (lResponseCode == 301) || (lResponseCode > 399) ) //abort and notify the user 
    //}

    ////Only fired if file download is initiated using DownloadFile method
    ////gives the client a chnace to add extra headers. Example: resume header
    ////Syntax: Range: bytes=n-m
    ////bResuming = true;
    ////sAdditionalRequestHeaders = "Range: bytes=" + iLocalFileSize.ToString() + "-\r\n"
    //void m_DownloadManager_OnFileDLBeginningTransaction(int dlUID, string sURL, string sRequestHeaders, ref string sAdditionalRequestHeaders, ref bool bResuming, ref bool bCancel)
    //{
    //    
    //}

#endregion

#region Automation of webbrowser control

        //All elements are searched by id and name for a match
        //If frameset, it will search all frames for given element name or id.
        //Please refer to frmAutomation for an example of usage

        private enum AutomationTasks
        {
            ClickButton = 0,
            ClickLink,
            EnterData,
            EnterDataTextArea,
            SelectListItem,
            SelectRadioButton,
            SubmitForm
        }
        
        private bool GetElementByName(AutomationTasks task, string elemname, string data)
        {
            if( (this.m_WBWebBrowser2 == null) ||
                string.IsNullOrEmpty(elemname) )
                return false;
            bool result = false;

            IHTMLDocument2 doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return false;
            IHTMLElementCollection col = null;

            if (this.IsWBFrameset(doc2))
            {
                List<IWebBrowser2> frames = this.GetFrames(this.m_WBWebBrowser2);
                if (frames == null)
                    return false;
                foreach (IWebBrowser2 wb in frames)
                {
                    if (task == AutomationTasks.ClickLink)
                    {
                        IHTMLDocument2 framedoc = wb.Document as IHTMLDocument2;
                        if (framedoc == null)
                            continue;
                        col = framedoc.anchors as IHTMLElementCollection;
                    }
                    else if (task == AutomationTasks.SelectListItem)
                    {
                        IHTMLDocument3 doc3 = wb.Document as IHTMLDocument3;
                        if (doc3 == null)
                            continue;
                        col = doc3.getElementsByTagName("select") as IHTMLElementCollection;
                    }
                    else if (task == AutomationTasks.EnterDataTextArea)
                    {
                        IHTMLDocument3 doc3 = wb.Document as IHTMLDocument3;
                        if (doc3 == null)
                            continue;
                        col = doc3.getElementsByTagName("textarea") as IHTMLElementCollection;
                    }
                    else if (task == AutomationTasks.SubmitForm)
                    {
                        IHTMLDocument2 framedoc = wb.Document as IHTMLDocument2;
                        if (framedoc == null)
                            continue;
                        col = framedoc.forms as IHTMLElementCollection;
                    }
                    else
                    {
                        IHTMLDocument3 doc3 = wb.Document as IHTMLDocument3;
                        if (doc3 == null)
                            continue;
                        col = doc3.getElementsByTagName("input") as IHTMLElementCollection;
                    }

                    if (col == null)
                        continue;
                    result = this.PerformAutomationTask(col, task, elemname, data);
                    if (result)
                        return result;
                }
            }
            else
            {
                if (task == AutomationTasks.ClickLink)
                {
                    col = doc2.anchors as IHTMLElementCollection;
                    //IHTMLElement elem = col.item(elemname, 0) as IHTMLElement;
                    //if (elem != null)
                    //    elem.click();
                    //return true;
                }
                else if (task == AutomationTasks.SelectListItem)
                {
                    //IHTMLDocument2 framedoc = this.m_WBWebBrowser2.Document as IHTMLDocument2;
                    //if (framedoc == null)
                    //    return result;
                    //col = framedoc.all as IHTMLElementCollection;
                    
                    //IHTMLElement elem = col.item(elemname, 0) as IHTMLElement;
                    //if (elem != null)
                    //{
                    //    IHTMLSelectElement selelem = elem as IHTMLSelectElement;
                    //    if (selelem != null)
                    //        selelem.value = data;
                    //}
                    //return true;
                    IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                    if (doc3 == null)
                        return result;
                    col = doc3.getElementsByTagName("select") as IHTMLElementCollection;
                }
                else if (task == AutomationTasks.EnterDataTextArea)
                {
                    IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                    if (doc3 == null)
                        return result;
                    col = doc3.getElementsByTagName("textarea") as IHTMLElementCollection;
                }
                else if (task == AutomationTasks.SubmitForm)
                {
                    IHTMLDocument2 framedoc = this.m_WBWebBrowser2.Document as IHTMLDocument2;
                    if (framedoc == null)
                        return result;
                    col = framedoc.forms as IHTMLElementCollection;
                }
                else
                {
                    IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                    if (doc3 == null)
                        return result;
                    col = doc3.getElementsByTagName("input") as IHTMLElementCollection;
                }
                if (col == null)
                    return result;
                result = this.PerformAutomationTask(col, task, elemname, data);
            }
            return result;
        }

        private bool PerformAutomationTask(IHTMLElementCollection col, AutomationTasks task, string elemname, string data)
        {
            bool bret = false;

            if (col == null) return bret;

            foreach (IHTMLElement elem in col)
            {
                if (elem != null)
                {
                    switch (task)
                    {
                        case AutomationTasks.ClickButton:
                            {
                                IHTMLInputElement btn = elem as IHTMLInputElement;
                                if ((btn != null) &&
                                    ((elem.id == elemname) ||(btn.name == elemname))
                                    )
                                {
                                    elem.click();
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.ClickLink:
                            {
                                IHTMLAnchorElement anchor = elem as IHTMLAnchorElement;
                                if( (anchor != null) &&
                                    ((elem.id == elemname) ||(anchor.name == elemname))
                                    )
                                {
                                    elem.click();
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.EnterData:
                            {
                                IHTMLInputElement inputelem = elem as IHTMLInputElement;
                                if( (inputelem != null) &&
                                    ((elem.id == elemname) ||(inputelem.name == elemname))
                                    )
                                {
                                    inputelem.value = data;
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.EnterDataTextArea:
                            {
                                IHTMLTextAreaElement txtarea = elem as IHTMLTextAreaElement;
                                if ((txtarea != null) &&
                                    ((elem.id == elemname) ||(txtarea.name == elemname))
                                    )
                                {
                                    txtarea.value = data;
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.SelectListItem:
                            {
                                IHTMLSelectElement selelem = elem as IHTMLSelectElement;
                                if( (selelem != null) &&
                                    ((elem.id == elemname) || (selelem.name == elemname))
                                    )
                                {
                                    //data can be value or text of the htmloptionelement
                                    // Obtain the number of option objects in the select object.
                                    int icount = selelem.length;
                                    IHTMLOptionElement optelem = null;
                                    for (int i = 0; i < icount; i++)
                                    {
                                        optelem = selelem.item(i, i) as IHTMLOptionElement;
                                        if (optelem != null)
                                        {
                                            if ((optelem.text == data) ||
                                                (optelem.value == data))
                                            {
                                                optelem.selected = true;
                                                return true;
                                            }
                                        }
                                    }
                                    return false;
                                }
                            }
                            break;
                        case AutomationTasks.SelectRadioButton:
                            {
                                IHTMLInputElement inputelem = elem as IHTMLInputElement;
                                if( (inputelem != null) && 
                                    ((elem.id == elemname) ||(inputelem.name == elemname))
                                    )
                                {
                                    inputelem.checkeda = true;
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.SubmitForm:
                            {
                                IHTMLFormElement form = elem as IHTMLFormElement;
                                if ((form != null) &&
                                   ((elem.id == elemname) ||(form.name == elemname))
                                    )
                                {
                                    form.submit();
                                    return true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            } //End foreach

            return bret;
        }

        /// <summary>
        /// Performs a click on a Button element with given name
        /// </summary>
        /// <param name="elemname">Name of Button element</param>
        /// <returns></returns>
        public bool AutomationTask_PerformClickButton(string btnnameorid)
        {
            return this.GetElementByName(AutomationTasks.ClickButton, btnnameorid, string.Empty);
        }

        public bool AutomationTask_PerformClickLink(string linknameorid)
        {
            return this.GetElementByName(AutomationTasks.ClickLink, linknameorid, string.Empty);
        }

        public bool AutomationTask_PerformEnterData(string inputnameorid, string strValue)
        {
            return this.GetElementByName(AutomationTasks.EnterData, inputnameorid, strValue);
        }

        public bool AutomationTask_PerformEnterDataTextArea(string inputnameorid, string strValue)
        {
            return this.GetElementByName(AutomationTasks.EnterDataTextArea, inputnameorid, strValue);
        }

        /// <summary>
        /// Attempts to select an item from a selection list
        /// based on the item value or text
        /// </summary>
        /// <param name="selectnameorid"></param>
        /// <param name="listitemvalueortext"></param>
        /// <returns></returns>
        public bool AutomationTask_PerformSelectList(string selectnameorid, string listitemvalueortext)
        {
            return this.GetElementByName(AutomationTasks.SelectListItem, selectnameorid, listitemvalueortext);
        }

        public bool AutomationTask_PerformSelectRadio(string radionameorid)
        {
            return this.GetElementByName(AutomationTasks.SelectRadioButton, radionameorid, string.Empty);
        }

        public bool AutomationTask_PerformSubmitForm(string formnameorid)
        {
            return this.GetElementByName(AutomationTasks.SubmitForm, formnameorid, string.Empty);
        }

        /// <summary>
        /// Attempts to scroll into view a link given it's name or id
        /// </summary>
        /// <param name="nameorid"></param>
        public bool AutomationTask_NamedLinkScrollIntoView(string nameorid)
        {
            IHTMLDocument2 pdoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (pdoc2 != null)
            {
                IHTMLElementCollection hrefs = pdoc2.anchors as IHTMLElementCollection;

                if (hrefs != null)
                {
                    ////If there are two elements by the same name exists
                    ////we receive the item based on the index passed (0)
                    //IHTMLElement elem = hrefs.item(namedLink, 0) as IHTMLElement;
                    //if (elem != null)
                    //    elem.scrollIntoView(true);
                    foreach (IHTMLElement elem in hrefs)
                    {
                        if (elem != null)
                        {
                            IHTMLAnchorElement anchor = elem as IHTMLAnchorElement;
                            if ( (anchor != null) &&
                                ((elem.id == nameorid) || (anchor.name == nameorid)) )
                            {
                                elem.scrollIntoView(true);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Simulates a keystroke. The targetelement must have focus
        /// </summary>
        /// <param name="keycode">One of Keys enum</param>
        public void AutomationTask_SimulateKeyStroke(Keys keycode)
        {
            WinApis.keybd_event((byte)keycode, 0, 0, UIntPtr.Zero); //keydown
            WinApis.keybd_event((byte)keycode, 0, WinApis.KEYEVENTF_KEYUP, UIntPtr.Zero); //Keydown
        }

        /// <summary>
        /// Attempts to select all the items within a given select list
        /// </summary>
        /// <param name="selects">A List of MultiSelectHTMLList classes containning a list of
        /// items to select</param>
        public void AutomationTask_PerformMultiSelectListItems(List<MultiSelectHTMLList> selects)
        {
            if ((this.m_WBWebBrowser2 == null) ||
                (selects == null) || (selects.Count == 0))
                return;
            //throw new Exception("

            //get the select collection from IHTMLDocument3
            IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
            if (doc3 == null)
                return;
            IHTMLElementCollection col = doc3.getElementsByTagName("select") as IHTMLElementCollection;

            if (col == null)
                return;

            int icount = 0;
            int i = 0;
            IHTMLOptionElement optelem = null;
            IHTMLSelectElement selelem = null;

            //Loop through
            foreach (MultiSelectHTMLList list in selects)
            {
                if ((list != null) && (!string.IsNullOrEmpty(list.m_SelectNameOrId)) &&
                    (list.m_ListItemsNamesOrIds != null) && (list.m_ListItemsNamesOrIds.Count > 0))
                {
                    //find the list in the collection
                    foreach (IHTMLElement elem in col)
                    {
                        if (elem != null)
                        {
                            selelem = elem as IHTMLSelectElement;
                            if ((selelem != null) &&
                                ((elem.id == list.m_SelectNameOrId) || //check id
                                (selelem.name == list.m_SelectNameOrId)) //check name as well
                                )
                            {
                                //data can be value or text of the htmloptionelement
                                // Obtain the number of option objects in the select object.
                                icount = selelem.length;
                                //loop through all items
                                for (i = 0; i < icount; i++)
                                {
                                    optelem = selelem.item(i, i) as IHTMLOptionElement;
                                    if (optelem != null)
                                    {
                                        //see if this the one
                                        foreach (string data in list.m_ListItemsNamesOrIds)
                                        {
                                            if ((optelem.text == data) ||
                                                (optelem.value == data))
                                            {
                                                optelem.selected = true;
                                                //selected this item, break and
                                                //continue with the rest of the items
                                                break;
                                            }
                                        }
                                    }
                                }
                                //Checked this select, break and continue with the next select in the list
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool AutomationTask_PerformAuthentication(string txtUserNameOrId, string txtPasswordNameOrId, string strUserName, string strPassword, bool bForceNewValue, bool bAutoSubmit)
        {
            bool result = false;
            bool doneusername = false;
            bool donepassword = false;
            //checks
            if (this.m_WBWebBrowser2 == null)
                return result;

            //get the select collection from IHTMLDocument3
            IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
            if (doc3 == null)
                return result;
            IHTMLElementCollection col = doc3.getElementsByTagName("input") as IHTMLElementCollection;

            if (col == null)
                return result;

            IHTMLInputElement inputelem = null;
            foreach (IHTMLElement elem in col)
            {
                if (elem != null)
                {
                    inputelem = elem as IHTMLInputElement;
                    if (inputelem != null)                        
                    {
                        if ((elem.id == txtUserNameOrId) || 
                            (inputelem.name == txtUserNameOrId))
                        {
                            if ((string.IsNullOrEmpty(inputelem.value)) ||
                                (bForceNewValue))
                            {
                                doneusername = true;
                                inputelem.value = strUserName;
                            }
                        }
                        else if ((elem.id == txtPasswordNameOrId) ||
                            (inputelem.name == txtPasswordNameOrId))
                        {
                            //To make sure this is the one we 
                            //can also check for hidden or password 
                            //value indicated by type property.
                            if ((string.IsNullOrEmpty(inputelem.value)) ||
                                (bForceNewValue))
                            {
                                donepassword = true;
                                inputelem.value = strPassword;
                            }
                        }
                    }
                    if ((doneusername) && (donepassword))
                        break;
                }
            }
            if (((doneusername) && (donepassword)) && bAutoSubmit)
            {
                this.AutomationTask_SimulateKeyStroke(Keys.Enter);
                //if ((inputelem != null) && (inputelem.form != null))
                //{
                //    IHTMLFormElement form = inputelem.form as IHTMLFormElement;
                //    if (form != null)
                //        form.submit();
                //}
            }
            return ((doneusername) && (donepassword)) ? true : false;
        }

#endregion

#region TravelLog - this webbrowser session history

        private ITravelLogStg m_TravelLogStg = null;

        private bool GetHistorySession()
        {
            if (m_TravelLogStg != null)
                return true;
            //QI for serviceprovider
            IfacesEnumsStructsClasses.IServiceProvider psp = m_WBUnknown as IfacesEnumsStructsClasses.IServiceProvider;
            if (psp == null)
                return false;

            IntPtr oret = IntPtr.Zero;
            //QueryService for ITravelLogStg
            int hr = psp.QueryService(ref Iid_Clsids.SID_STravelLogCursor, ref Iid_Clsids.IID_ITravelLogStg, out oret);
            if ((oret == IntPtr.Zero) || (hr != Hresults.S_OK))
                return false;
            Marshal.ReleaseComObject(psp);
            m_TravelLogStg = Marshal.GetObjectForIUnknown(oret) as ITravelLogStg;
            return (m_TravelLogStg != null) ? true : false;
        }

        public int GetTravelLogCount()
        {
            int iret = 0;
            if (!GetHistorySession())
                return iret;
            m_TravelLogStg.GetCount((int)TLMENUF.TLEF_ABSOLUTE, out iret);
            return iret;
        }

        //If there is no title, the method returns the URL of the page.
        //The method returns zero length string for the 
        //current page's title and url
        public List<TravelLogStruct> GetTraveLogEntries()
        {
            List<TravelLogStruct> entries = new List<TravelLogStruct>();
            if (!GetHistorySession())
                return entries;

            //Enum the travel log entries
            IEnumTravelLogEntry penumtle = null;
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return entries;

            int hr = 0;
            ITravelLogEntry ptle = null;
            int fetched = 0;
            IntPtr pTitle = IntPtr.Zero;
            IntPtr pUrl = IntPtr.Zero;
            const int MAX_FETCH_COUNT = 1;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pTitle = IntPtr.Zero;
                    pUrl = IntPtr.Zero;
                    ptle.GetTitle(out pTitle);
                    TravelLogStruct tlg = new TravelLogStruct();
                    if (pTitle != IntPtr.Zero)
                        tlg.Title = Marshal.PtrToStringUni(pTitle);
                    else
                        tlg.Title = string.Empty;

                    ptle.GetURL(out pUrl);
                    if (pUrl != IntPtr.Zero)
                        tlg.URL = Marshal.PtrToStringUni(pUrl);
                    else
                        tlg.URL = string.Empty;

                    entries.Add(tlg);
                    //We are responsible to free the memory
                    Marshal.FreeCoTaskMem(pTitle);
                    Marshal.FreeCoTaskMem(pUrl);
                    //http://msdn2.microsoft.com/en-us/library/aa753624.aspx
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);
            return entries;
        }

        public ITravelLogEntry AddTravelLogEntry(string url, string title)
        {
            ITravelLogEntry ptle = null;
            if (!GetHistorySession())
                return ptle;
            
            m_TravelLogStg.CreateEntry(url, title, null, true, out ptle);
            return ptle;
        }

        /// <summary>
        /// Removes all travel log entries for this webbrowser instance
        /// </summary>
        /// <returns></returns>
        public bool RemoveAllTravelLogEntries()
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pTitle = IntPtr.Zero;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pTitle = IntPtr.Zero;
                    ptle.GetTitle(out pTitle);
                    if (pTitle != IntPtr.Zero) //Current entry?
                    {
                        Marshal.FreeCoTaskMem(pTitle);
                        m_TravelLogStg.RemoveEntry(ptle);
                    }
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);
            return true;
        }

        /// <summary>
        /// Removes all entries matching given url
        /// The current entry cannot be deleted.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool RemoveTravelLogEntries(string url)
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pUrl = IntPtr.Zero;
            string targeturl = string.Empty;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pUrl = IntPtr.Zero;
                    ptle.GetURL(out pUrl);
                    if (pUrl != IntPtr.Zero)
                    {
                        targeturl = Marshal.PtrToStringUni(pUrl);
                        Marshal.FreeCoTaskMem(pUrl);
                        if( (!string.IsNullOrEmpty(targeturl)) &&
                            (targeturl == url) )
                            m_TravelLogStg.RemoveEntry(ptle);
                    }
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);

            return true;
        }

        /// <summary>
        /// Removes first entry matching given url and title
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool RemoveTravelLogEntry(string url, string title)
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pTitle = IntPtr.Zero;
            IntPtr pUrl = IntPtr.Zero;
            string targeturl = string.Empty;
            string targettitle = string.Empty;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pTitle = IntPtr.Zero;
                    pUrl = IntPtr.Zero;
                    ptle.GetURL(out pUrl);
                    ptle.GetTitle(out pTitle);
                    if( (pUrl != IntPtr.Zero) &&
                        (pTitle != IntPtr.Zero) )
                    {
                        targeturl = Marshal.PtrToStringUni(pUrl);
                        targettitle = Marshal.PtrToStringUni(pTitle);
                        Marshal.FreeCoTaskMem(pTitle);
                        Marshal.FreeCoTaskMem(pUrl);
                        if ((!string.IsNullOrEmpty(targettitle)) &&
                            (targettitle == title) &&
                            (!string.IsNullOrEmpty(targeturl)) &&
                            (targeturl == url))
                        {
                            m_TravelLogStg.RemoveEntry(ptle);
                            return true;
                        }
                    }
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);

            return false;
        }

        /// <summary>
        /// Removes one entry based on index
        /// Can not delete current entry
        /// </summary>
        /// <param name="index">0 based index</param>
        /// <returns></returns>
        public bool RemoveTravelLogEntry(int index)
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pTitle = IntPtr.Zero;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if( (ptle != null) &&
                    (i == index) )
                {
                    pTitle = IntPtr.Zero;
                    ptle.GetTitle(out pTitle);
                    if (pTitle != IntPtr.Zero) //Current entry?
                    {
                        Marshal.FreeCoTaskMem(pTitle);
                        m_TravelLogStg.RemoveEntry(ptle);
                        return true;
                    }
                    else
                        return false;
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);
            return false;
        }

#endregion

#region IHTMLEditHost Members

    public event HTMLEditHostSnapRectEventHandler HTMLEditHostSnapRect = null;
    private HTMLEditHostSnapRectEventArgs HTMLEditHostSnapRectEvent = new HTMLEditHostSnapRectEventArgs();

    int IHTMLEditHost.SnapRect(IHTMLElement pIElement, ref tagRECT prcNew, int eHandle)
    {
        if (HTMLEditHostSnapRect != null)
        {
            HTMLEditHostSnapRectEvent.SetParameters(pIElement, prcNew, eHandle);
            HTMLEditHostSnapRect(this, HTMLEditHostSnapRectEvent);
            //if things changed
            prcNew = HTMLEditHostSnapRectEvent.ElemRect;
        }
        return Hresults.S_OK;
    }

#endregion

    } //class cEXWB

} //csExWB



