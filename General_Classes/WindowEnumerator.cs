using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;

namespace IfacesEnumsStructsClasses
{
    // A class to enumerate all child windows of a given window handle
    // A class to get IHTLDocument2 and/or IWebbrowser2 interfaces
    // from a given "Internet Explorer_Server" handle window
    public class WindowEnumerator
    {
        #region Declares
        // Data structures to hold data relevent to a certain window
        private static ArrayList controlsHwnds = new ArrayList();
        private static ArrayList controlsClassNames = new ArrayList();
        private static ArrayList controlsTexts = new ArrayList();

        // A delegate for the enumeration callback
        public delegate bool WindowEnumDelegate(IntPtr hwnd, int lParam);

        // An enumerated integer holding the state for the message timeouts
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }

        // Method import to ensure correct casting of IHTMLDOCUMENT2 class type
        [DllImport("oleacc.dll", PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        private static extern object ObjectFromLresult(UIntPtr lResult, [MarshalAs(UnmanagedType.LPStruct)] Guid refiid, IntPtr wParam);

        // Method import needed to ensure program timeout while waiting for ObjectFromLresult
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, UIntPtr wParam, UIntPtr lParam, SendMessageTimeoutFlags fuFlags, uint uTimeout, out UIntPtr lpdwResult);

        // Used to register WM_HTML_GETOBJECT
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint RegisterWindowMessage(string lpString);

        // Enumerates child windows
        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hwnd, WindowEnumDelegate del, int lParam);

        // Method which returns a window's class name
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hwnd, StringBuilder bld, int size);

        // Method which receives messages sent from a specified window
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, StringBuilder bld);

        #endregion
        // Ctor
        public WindowEnumerator()
        {
        }

        // Enumerates a specified window (specified by handle)
        public void enumerate(IntPtr handle)
        {
            WindowEnumDelegate del = new WindowEnumDelegate(WindowEnumProc);
            EnumChildWindows(handle, del, 0);
        }

        // Functional method
        private const int m_Capacity = 1024;
        public static bool WindowEnumProc(IntPtr hwnd, int lParam)
        {
            controlsHwnds.Add(hwnd);

            StringBuilder bld = new StringBuilder(m_Capacity);
            GetClassName(hwnd, bld, m_Capacity);
            controlsClassNames.Add(bld.ToString());

            //bld = new StringBuilder(m_Capacity);
            //SendMessage(hwnd, WindowsMessages.WM_GETTEXT, new IntPtr(m_Capacity), bld);
            //controlsTexts.Add(bld.ToString());

            return true;
        }

        // Returns an IHTMLDocument2 object for the given "Internet Explorer_Server" handle
        public IHTMLDocument2 GetIEHTMLDocument2FromWindowHandle(IntPtr handle)
        {
            UIntPtr result;
            uint message;
            IHTMLDocument2 htmlDocument = null;

            try
            {
                if (handle != IntPtr.Zero)
                {
                    // Registers the WM_HTML_GETOBJECT message
                    message = RegisterWindowMessage("WM_HTML_GETOBJECT");

                    // Sends this, registered method and waits for time out
                    SendMessageTimeout(handle, message, UIntPtr.Zero, UIntPtr.Zero, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out result);

                    if (result != UIntPtr.Zero)
                    {
                        // Uses the lResult in order to secure a pointer to the Internet Explorer session
                        htmlDocument = ObjectFromLresult(result, typeof(IHTMLDocument).GUID, IntPtr.Zero) as IHTMLDocument2;
                        //htmlDocument maybe null
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return htmlDocument;
        }

        // Returns an IWebBrowser2 object for the given "Internet Explorer_Server" handle
        //This function fails when attempting to get IWebbrowser2 from a dialog launched using
        //showModelessDialog() and showModalDialog() methods
        public IWebBrowser2 GetIEWebbrowser2FromWindowHandle(IntPtr pass)
        {
            IWebBrowser2 pWb2 = null;
            try
            {
                //First, get the IHTMLDocument2 interface
                IHTMLDocument2 htmlDoc = GetIEHTMLDocument2FromWindowHandle(pass);
                if (htmlDoc == null) return pWb2;

                //Get the parentwindow
                IHTMLWindow2 parentwin = htmlDoc.parentWindow as IHTMLWindow2;
                if (parentwin == null) return pWb2;

                //QI parentwin for IServiceProvoider
                IServiceProvider pSp = parentwin as IServiceProvider;
                if (pSp == null) return pWb2;

                //QS serviceprovider for IWebBrowserApp and IWebBrowser2 GUIDs
                IntPtr ipWb2 = IntPtr.Zero;
                int hr = pSp.QueryService(ref Iid_Clsids.IID_WebBrowserApp, ref Iid_Clsids.IID_IWebBrowser2, out ipWb2);
                if ((hr == Hresults.S_OK) && (ipWb2 != IntPtr.Zero))
                {
                    pWb2 = Marshal.GetObjectForIUnknown(ipWb2) as IWebBrowser2;
                    //GetObjectForIUnknown calls addref, so call Release
                    Marshal.Release(ipWb2);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pWb2;
        }

        // Uses GetIEDocumentFromWindowHandle in order to return HTML content
        public string GetIEHtmlDocumentinnerHTML(IntPtr pass)
        {
            IHTMLDocument2 htmlDoc = GetIEHTMLDocument2FromWindowHandle(pass);
            if ((htmlDoc != null) && (htmlDoc.body != null))
                return htmlDoc.body.innerHTML;
            return string.Empty;
        }

        // Uses GetIEDocumentFromWindowHandle in order to return plaintext content
        public string GetIEHtmlDocumentinnerText(IntPtr pass)
        {
            IHTMLDocument2 htmlDoc = GetIEHTMLDocument2FromWindowHandle(pass);
            if ((htmlDoc != null) && (htmlDoc.body != null))
                return htmlDoc.body.innerText;
            return string.Empty;
        }

        // Clears the data arrays
        public void clear()
        {
            controlsHwnds.Clear();
            controlsClassNames.Clear();
            controlsTexts.Clear();
        }
        // Returns the list of control handles
        public ArrayList GetControlsHwnds()
        {
            return controlsHwnds;
        }
        // Returns the list of control class names
        public ArrayList GetControlsClassNames()
        {
            return controlsClassNames;
        }
        // Returns a list of other control data (text)
        public ArrayList GetControlsText()
        {
            return controlsTexts;
        }
    }

    ////Example using frmPopup:
    //m_frmPopup.Show(this);
    //m_frmPopup.PopupNavigate("http://www.google.ca");
    //Application.DoEvents();

    ////================================================
    //WindowEnumerator winenum = new WindowEnumerator();

    //winenum.enumerate(m_frmPopup.Handle);
    //System.Collections.ArrayList ctls = winenum.GetControlsNames();
    //foreach (object item in ctls)
    //{
    //    if(item != null)
    //        AllForms.m_frmLog.AppendToLog(item.ToString());
    //}
    //winenum.clear();

    ////Result:
    ////Shell Embedding
    ////Shell DocObject View
    ////Internet Explorer_Server

    //IHTMLDocument2 pdoc2 = winenum.GetIEDocumentFromWindowHandle(m_CurWB.IEServerHwnd);
    //if (pdoc2 != null)
    //    AllForms.m_frmLog.AppendToLog(pdoc2.url);

    //IWebBrowser2 wb2 = winenum.GetIEWebbrowser2FromWindowHandle(m_CurWB.IEServerHwnd);
    //if(wb2 != null)
    //    AllForms.m_frmLog.AppendToLog(wb2.LocationURL);

}
