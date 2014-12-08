
using IfacesEnumsStructsClasses;
using System;
using System.Windows.Forms;

namespace csExWB
{
    //General delegates and event arguments

    #region WebBrowser

    public delegate void TitleChangeEventHandler(object sender, TitleChangeEventArgs e);
    public class TitleChangeEventArgs : System.EventArgs
    {
        public string title;
        public TitleChangeEventArgs() { }
    }

    public delegate void DocumentCompleteEventHandler(object sender, DocumentCompleteEventArgs e);
    public class DocumentCompleteEventArgs : System.EventArgs
    {
        public DocumentCompleteEventArgs() { }
        public void SetParameters(object Browser, string Url, bool IsTopLevel)
        {
            this.browser = Browser;
            this.url = Url;
            this.istoplevel = IsTopLevel;
        }
        public void Reset()
        {
            this.browser = null;
            this.url = string.Empty;
            this.istoplevel = false;
        }

        public object browser;
        public string url;
        public bool istoplevel;

    }

    public delegate void DocumentCompleteExEventHandler(object sender, DocumentCompleteExEventArgs e);
    public class DocumentCompleteExEventArgs : System.EventArgs
    {
        public DocumentCompleteExEventArgs() { }
        public void SetParameters(object Browser, string Url, bool IsTopLevel, string DocSource)
        {
            this.browser = Browser;
            this.url = Url;
            this.istoplevel = IsTopLevel;
            this.docsource = DocSource;
        }
        public void Reset()
        {
            this.browser = null;
            this.url = "";
            this.istoplevel = false;
            this.docsource = "";
        }
        public object browser;
        public string url;
        public bool istoplevel;
        public string docsource;
    }

    public delegate void StatusTextChangeEventHandler(object sender, StatusTextChangeEventArgs e);
    public class StatusTextChangeEventArgs : System.EventArgs
    {
        public StatusTextChangeEventArgs() { }
        public string text;
    }

    public delegate void ProgressChangeEventHandler(object sender, ProgressChangeEventArgs e);
    public class ProgressChangeEventArgs : System.EventArgs
    {
        public ProgressChangeEventArgs() { }
        public void SetParameters(int Progress, int ProgressMax)
        {
            this.progress = Progress;
            this.progressmax = ProgressMax;
        }

        public int progress;
        public int progressmax;
    }

    public delegate void CommandStateChangeEventHandler(object sender, CommandStateChangeEventArgs e);
    public class CommandStateChangeEventArgs : System.EventArgs
    {
        public CommandStateChangeEventArgs() { }
        public void SetParameters(int Command, bool Enable)
        {
            this.command = (CommandStateChangeConstants)Command;
            this.enable = Enable;
        }

        public CommandStateChangeConstants command;
        public bool enable;
    }

    public delegate void DownloadBeginEventHandler(object sender);

    public delegate void DownloadCompleteEventHandler(object sender);

    public delegate void PropertyChangeEventHandler(object sender, PropertyChangeEventArgs e);
    public class PropertyChangeEventArgs : System.EventArgs
    {
        public PropertyChangeEventArgs() { }
        public string szproperty;
    }

    public delegate void BeforeNavigate2EventHandler(object sender, BeforeNavigate2EventArgs e);
    public class BeforeNavigate2EventArgs : System.ComponentModel.CancelEventArgs
    {
        public BeforeNavigate2EventArgs() { }
        public void SetParameters(object Browser, string Url, object TargetFrameName, object PostData, object Headers, bool TopLevel)
        {
            this.browser = Browser;
            this.url = Url;
            if (TargetFrameName != null)
                this.targetframename = TargetFrameName.ToString();
            else
                this.targetframename = string.Empty;
            this.postdata = PostData;
            if (Headers != null)
                this.headers = Headers.ToString();
            else
                this.headers = string.Empty;
            this.Cancel = false;
            this.istoplevel = TopLevel;
        }
        public void Reset()
        {
            this.browser = null;
            this.url = string.Empty;
            this.targetframename = string.Empty;
            this.postdata = null;
            this.headers = string.Empty;
            this.Cancel = false;
            this.istoplevel = false;
        }

        public object browser;
        public string url;
        public string targetframename;
        public object postdata;
        public string headers;
        public bool istoplevel;
    }

    public delegate void NavigateComplete2EventHandler(object sender, NavigateComplete2EventArgs e);
    public class NavigateComplete2EventArgs : System.EventArgs
    {
        public NavigateComplete2EventArgs() { }
        public void SetParameters(object Browser, string Url)
        {
            this.browser = Browser;
            this.url = Url;
        }
        public void Reset()
        {
            this.browser = null;
            this.url = "";
        }

        public object browser;
        public string url;
    }

    public delegate void NewWindow2EventHandler(object sender, NewWindow2EventArgs e);
    public class NewWindow2EventArgs : System.ComponentModel.CancelEventArgs
    {
        public NewWindow2EventArgs()
        {
            this.Cancel = false;
        }
        public void SetParameters()
        {
            this.Cancel = false;
            this.browser = null;
        }

        public object browser;
    }

    public delegate void NewWindow3EventHandler(object sender, NewWindow3EventArgs e);
    public class NewWindow3EventArgs : System.ComponentModel.CancelEventArgs
    {
        public NewWindow3EventArgs()
        {
            this.Cancel = false;
        }
        public void SetParameters(string UrlContext, string Url, NWMF Flags)
        {
            this.browser = null;
            this.urlcontext = UrlContext;
            this.url = Url;
            this.flags = Flags;
            this.Cancel = false;
        }
        public void Reset()
        {
            this.browser = null;
            this.urlcontext = "";
            this.url = "";
            this.Cancel = false;
        }

        public object browser;
        public string urlcontext;
        public string url;
        public NWMF flags;
    }

    public delegate void WindowSetResizableEventHandler(object sender, WindowSetResizableEventArgs e);
    public class WindowSetResizableEventArgs : System.EventArgs
    {
        public WindowSetResizableEventArgs() { }
        public bool resizable;
    }

    public delegate void WindowSetLeftEventHandler(object sender, WindowSetLeftEventArgs e);
    public class WindowSetLeftEventArgs : System.EventArgs
    {
        public WindowSetLeftEventArgs() { }
        public int left;
    }

    public delegate void WindowSetTopEventHandler(object sender, WindowSetTopEventArgs e);
    public class WindowSetTopEventArgs : System.EventArgs
    {
        public WindowSetTopEventArgs() { }
        public int top;
    }

    public delegate void WindowSetWidthEventHandler(object sender, WindowSetWidthEventArgs e);
    public class WindowSetWidthEventArgs : System.EventArgs
    {
        public WindowSetWidthEventArgs() { }
        public int width;
    }

    public delegate void WindowSetHeightEventHandler(object sender, WindowSetHeightEventArgs e);
    public class WindowSetHeightEventArgs : System.EventArgs
    {
        public WindowSetHeightEventArgs() { }
        public int height;
    }

    public delegate void WindowClosingEventHandler(object sender, WindowClosingEventArgs e);
    public class WindowClosingEventArgs : System.ComponentModel.CancelEventArgs
    {
        public WindowClosingEventArgs()
        {
            this.Cancel = false;
        }
        public void SetParameters(bool IsChildWindow)
        {
            this.Cancel = false;
            this.ischildwindow = IsChildWindow;
        }

        public bool ischildwindow;
    }

    public delegate void ClientToHostWindowEventHandler(object sender, ClientToHostWindowEventArgs e);
    public class ClientToHostWindowEventArgs : System.EventArgs
    {
        public ClientToHostWindowEventArgs() { }
        public void SetParameters(int CX, int CY)
        {
            this.cx = CX;
            this.cy = CY;
            this.handled = false;
        }

        public bool handled;
        public int cx;
        public int cy;
    }

    public delegate void SetSecureLockIconEventHandler(object sender, SetSecureLockIconEventArgs e);
    public class SetSecureLockIconEventArgs : System.EventArgs
    {
        public SetSecureLockIconEventArgs() { }
        public void SetParameters(int SecureLockIcon)
        {
            this.securelockicon = (SecureLockIconConstants)SecureLockIcon;
        }

        public SecureLockIconConstants securelockicon;
    }

    public delegate void FileDownloadEventHandler(object sender, FileDownloadEventArgs e);
    public class FileDownloadEventArgs : System.ComponentModel.CancelEventArgs
    {
        public FileDownloadEventArgs() { }
        public bool ActiveDocument = false;
    }

    public delegate void NavigateErrorEventHandler(object sender, NavigateErrorEventArgs e);
    public class NavigateErrorEventArgs : System.ComponentModel.CancelEventArgs
    {
        public NavigateErrorEventArgs() { }
        public void SetParameters(object Browser, string Url, string TargetFrame, int StatusCode)
        {
            this.browser = Browser;
            this.url = Url;
            this.targetframe = TargetFrame;
            this.statuscode = (WinInetErrors)StatusCode;
            this.Cancel = false;
        }
        public void Reset()
        {
            this.browser = null;
            this.url = string.Empty;
            this.targetframe = string.Empty;
            this.Cancel = false;
        }

        public object browser;
        public string url;
        public string targetframe;
        public WinInetErrors statuscode;
    }

    public delegate void PrintTemplateInstantiationEventHandler(object sender, PrintTemplateInstantiationEventArgs e);
    public class PrintTemplateInstantiationEventArgs : System.EventArgs
    {
        public PrintTemplateInstantiationEventArgs() { }
        public object browser;
    }

    public delegate void PrintTemplateTeardownEventHandler(object sender, PrintTemplateTeardownEventArgs e);
    public class PrintTemplateTeardownEventArgs : System.EventArgs
    {
        public PrintTemplateTeardownEventArgs() { }
        public object browser;
    }

    public delegate void UpdatePageStatusEventHandler(object sender, UpdatePageStatusEventArgs e);
    public class UpdatePageStatusEventArgs : System.EventArgs
    {
        public UpdatePageStatusEventArgs() { }
        public void SetParameters(object Browser, int Page, bool Done)
        {
            this.browser = Browser;
            this.page = Page;
            this.done = Done;
        }
        public void Reset()
        {
            this.browser = null;
            this.page = 0;
            this.done = false;
        }

        public object browser;
        public int page;
        public bool done;
    }

    public delegate void PrivacyImpactedStateChangeEventHandler(object sender, PrivacyImpactedStateChangeEventArgs e);
    public class PrivacyImpactedStateChangeEventArgs : System.EventArgs
    {
        public PrivacyImpactedStateChangeEventArgs() { }
        public bool impacted;
    } 
    #endregion

    #region Webbrowser Extended

    public delegate void HTMLEditHostSnapRectEventHandler(object sender, HTMLEditHostSnapRectEventArgs e);
    public class HTMLEditHostSnapRectEventArgs : System.EventArgs
    {
        public HTMLEditHostSnapRectEventArgs() { }
        public void SetParameters(IHTMLElement _elem, tagRECT _rect, int _elemcorner)
        {
            Element = _elem;
            ElemRect = _rect;
            ElemCorner = (ELEMENT_CORNER)_elemcorner;
        }

        public IHTMLElement Element = null;
        public tagRECT ElemRect;
        public ELEMENT_CORNER ElemCorner = ELEMENT_CORNER.ELEMENT_CORNER_NONE;
    }

    public delegate void HTMLOMWindowServicesEventHandler(object sender, HTMLOMWindowServicesEventArgs e);
    public class HTMLOMWindowServicesEventArgs : System.EventArgs
    {
        public HTMLOMWindowServicesEventArgs() { }
        public void SetParameters(int _x, int _y)
        {
            this.X = _x;
            this.Y = _y;
        }
        public int X = 0;
        public int Y = 0;
    }

    public delegate void AllowFocusChangeEventHandler(object sender, AllowFocusChangeEventArgs e);
    public class AllowFocusChangeEventArgs : System.ComponentModel.CancelEventArgs
    {
        public AllowFocusChangeEventArgs()
        {

        }
    }

    public delegate void EvaluateNewWindowEventHandler(object sender, EvaluateNewWindowEventArgs e);
    public class EvaluateNewWindowEventArgs : System.ComponentModel.CancelEventArgs
    {
        public EvaluateNewWindowEventArgs() { }
        public void SetParameters(string Url, string Name, string UrlContext, string Features, bool Replace, int Flags, int UserActionTime)
        {
            this.url = Url;
            this.name = Name;
            this.urlcontext = UrlContext;
            this.features = Features;
            this.useractiontime = UserActionTime;
            this.replace = Replace;
            this.flags = (NWMF)Flags;
            this.Cancel = false;
        }
        public void Reset()
        {
            this.url = "";
            this.name = "";
            this.urlcontext = "";
            this.features = "";
            this.useractiontime = 0;
            this.replace = false;
            this.Cancel = false;
        }

        public string url;
        public string name;
        public string urlcontext;
        public string features;
        public bool replace;
        public NWMF flags;
        public int useractiontime;
    }

    public delegate void SecurityProblemEventHandler(object sender, SecurityProblemEventArgs e);
    public class SecurityProblemEventArgs : System.EventArgs
    {
        public SecurityProblemEventArgs() { }
        public void SetParameters(int Problem)
        {
            this.handled = false;
            this.problem = (WinInetErrors)Problem;
            this.retvalue = Hresults.S_FALSE; //1
        }

        public WinInetErrors problem;
        public int retvalue;
        public bool handled;
    }

    public delegate void AuthenticateEventHandler(object sender, AuthenticateEventArgs e);
    public class AuthenticateEventArgs : System.EventArgs
    {
        public AuthenticateEventArgs() { }
        public void SetParameters()
        {
            this.handled = false;
            this.username = string.Empty;
            this.password = string.Empty;
            this.retvalue = 0; //Hresults.S_OK
        }
        public string username;
        public string password;
        public int retvalue;
        public bool handled;
    }

    public delegate void WBDragEnterEventHandler(object sender, WBDragEnterEventArgs e);
    public class WBDragEnterEventArgs : System.EventArgs
    {
        public WBDragEnterEventArgs() { }
        public void SetParameters(DataObject DropDataObject, uint KeyState, System.Drawing.Point pt, uint Effect)
        {
            this.keystate = KeyState;
            this.pt = pt;
            this.dropeffect = (DROPEFFECT)Effect;
            this.handled = false;
            this.dataobject = DropDataObject;
        }

        public uint keystate;
        public System.Drawing.Point pt;
        public DROPEFFECT dropeffect;
        public DataObject dataobject;
        public bool handled;
    }

    public delegate void WBDragOverEventHandler(object sender, WBDragOverEventArgs e);
    public class WBDragOverEventArgs : System.EventArgs
    {
        public WBDragOverEventArgs() { }
        public void SetParameters(uint KeyState, System.Drawing.Point pt, uint Effect)
        {
            this.keystate = KeyState;
            this.pt = pt;
            this.dropeffect = (DROPEFFECT)Effect;
            this.handled = false;
        }

        public uint keystate;
        public System.Drawing.Point pt;
        public DROPEFFECT dropeffect;
        public bool handled;
    }

    public delegate void WBDragLeaveEventHandler(object sender);

    public delegate void WBDropEventHandler(object sender, WBDropEventArgs e);
    public class WBDropEventArgs : System.EventArgs
    {
        public WBDropEventArgs() { }
        public void SetParameters(uint KeyState, System.Drawing.Point pt, DataObject DropDataObject, uint Effect)
        {
            this.handled = false;
            this.keystate = KeyState;
            this.pt = pt;
            this.dropeffect = (DROPEFFECT)Effect;
            this.dataobject = DropDataObject;
        }

        public uint keystate;
        public System.Drawing.Point pt;
        public DROPEFFECT dropeffect;
        public DataObject dataobject;
        public bool handled;
    }

    public delegate void ContextMenuEventHandler(object sender, ContextMenuEventArgs e);
    public class ContextMenuEventArgs : System.EventArgs
    {
        public ContextMenuEventArgs()
        {
            this.displaydefault = true;
        }

        public void SetParameters(WB_CONTEXTMENU_TYPES ContextMenuType, System.Drawing.Point pt, object DispCtxMenuObj)
        {
            this.displaydefault = true;
            this.contextmenutype = ContextMenuType;
            this.pt = pt;
            this.dispctxmenuobj = DispCtxMenuObj;
        }

        public WB_CONTEXTMENU_TYPES contextmenutype;
        public System.Drawing.Point pt;
        public object dispctxmenuobj;
        public bool displaydefault;
    }

    public delegate void DocHostShowUIShowMessageEventHandler(object sender, DocHostShowUIShowMessageEventArgs e);
    public class DocHostShowUIShowMessageEventArgs : System.EventArgs
    {
        public DocHostShowUIShowMessageEventArgs()
        {
            this.handled = false;
        }
        public void SetParameters(IntPtr Hwnd, string Text, string Caption, uint Type, string HelpFile, uint HelpContext, int Result)
        {
            this.handled = false;
            this.hwnd = Hwnd;
            this.text = Text;
            this.caption = Caption;
            this.type = Type;
            this.helpcontext = HelpContext;
            this.result = Result;
        }
        public void Reset()
        {
            this.handled = false;
            this.hwnd = IntPtr.Zero;
            this.text = string.Empty;
            this.caption = string.Empty;
            this.helpcontext = (uint)0;
            this.result = 0; //S_OK
        }

        public IntPtr hwnd;
        public string text;
        public string caption;
        public uint type;
        public string helpfile;
        public uint helpcontext;
        public int result;
        public bool handled;
    }

    public delegate void GetOptionKeyPathEventHandler(object sender, GetOptionKeyPathEventArgs e);
    public class GetOptionKeyPathEventArgs : System.EventArgs
    {
        public GetOptionKeyPathEventArgs()
        {
            this.handled = false;
        }
        public void SetParameters()
        {
            this.handled = false;
            this.keypath = "";
        }

        public string keypath;
        public bool handled;
    }

    public delegate void WBKeyDownEventHandler(object sender, WBKeyDownEventArgs e);
    public class WBKeyDownEventArgs : System.EventArgs
    {
        public WBKeyDownEventArgs()
        {
            this.handled = false;
        }
        public void SetParameters(Keys KeyCode, Keys VirtualKey)
        {
            this.handled = false;
            this.keycode = KeyCode;
            this.virtualkey = VirtualKey;
        }
        public Keys keycode;
        public Keys virtualkey;
        public bool handled;

    }

    public delegate void WBKeyUpEventHandler(object sender, WBKeyUpEventArgs e);
    public class WBKeyUpEventArgs : System.EventArgs
    {
        public WBKeyUpEventArgs()
        {
            this.handled = false;
        }
        public void SetParameters(Keys KeyCode, Keys VirtualKey)
        {
            this.handled = false;
            this.keycode = KeyCode;
            this.virtualkey = VirtualKey;
        }
        public Keys keycode;
        public Keys virtualkey;
        public bool handled;

    }

    public delegate void ScriptErrorEventHandler(object sender, ScriptErrorEventArgs e);
    public class ScriptErrorEventArgs : System.EventArgs
    {
        public int lineNumber;
        public int characterNumber;
        public int errorCode;
        public string errorMessage;
        public string url;
        public bool continueScripts;

        public ScriptErrorEventArgs() { }

        public void SetParameters()
        {
            this.continueScripts = true;
            this.lineNumber = 0;
            this.characterNumber = 0;
            this.errorCode = 0;
            this.errorMessage = "";
            this.url = "";
        }
    }

    public delegate void RefreshBeginEventHandler(object sender);

    public delegate void RefreshEndEventHandler(object sender);

    public delegate void ProcessUrlActionEventHandler(object sender, ProcessUrlActionEventArgs e);
    public class ProcessUrlActionEventArgs : System.ComponentModel.CancelEventArgs
    {
        public bool handled;
        public bool hasContext;
        public string url;
        public URLACTION urlAction;
        public URLPOLICY urlPolicy;
        public Guid context;
        public ProcessUrlActionFlags flags;

        public ProcessUrlActionEventArgs() { }

        public void SetParameters(string surl, URLACTION action, URLPOLICY policy, Guid gcontext, ProcessUrlActionFlags puaf, bool bhascontext)
        {
            this.Cancel = false;
            this.handled = false;

            this.url = surl;
            this.urlAction = action;
            this.urlPolicy = policy;
            this.context = gcontext;
            this.flags = puaf;
            this.hasContext = bhascontext;
        }

        public void ResetParameters()
        {
            this.Cancel = false;
            this.handled = false;
            this.url = string.Empty;
            this.urlAction = URLACTION.MIN;
            this.urlPolicy = URLPOLICY.ALLOW;
            this.context = Guid.Empty;
            this.flags = ProcessUrlActionFlags.PUAF_DEFAULT;
            this.hasContext = false;
        }
    }
    
    #endregion

    #region Asynchronous pluggable protocols (APP) using COM component
    
    public delegate void ProtocolHandlerOnResponseEventHandler(object sender, ProtocolHandlerOnResponseEventArgs e);
    public class ProtocolHandlerOnResponseEventArgs : System.ComponentModel.CancelEventArgs
    {
        public ProtocolHandlerOnResponseEventArgs() { }
        public void SetParameters(string url, string responseheaders, string redirectedurl, string redirectedheaders)
        {
            this.Cancel = false;
            this.m_URL = url;
            this.m_ResponseHeaders = responseheaders;
            this.m_RedirectedUrl = redirectedurl;
            this.m_RedirectHeaders = redirectedheaders;
        }
        public void Reset()
        {
            this.Cancel = false;
            this.m_URL = string.Empty;
            this.m_ResponseHeaders = string.Empty;
            this.m_RedirectedUrl = string.Empty;
            this.m_RedirectHeaders = string.Empty;
        }
        public string m_URL = string.Empty;
        public string m_ResponseHeaders = string.Empty;
        public string m_RedirectedUrl = string.Empty;
        public string m_RedirectHeaders = string.Empty;
    }

    public delegate void ProtocolHandlerOnBeginTransactionEventHandler(object sender, ProtocolHandlerOnBeginTransactionEventArgs e);
    public class ProtocolHandlerOnBeginTransactionEventArgs : System.ComponentModel.CancelEventArgs
    {
        public ProtocolHandlerOnBeginTransactionEventArgs() { }
        public void SetParameters(string url, string requestheaders)
        {
            this.Cancel = false;
            this.m_URL = url;
            this.m_RequestHeaders = requestheaders;
            //Additional headers can be added to what is already
            //being send by Webbrowser control
            this.m_AdditionalHeadersToAdd = string.Empty;
        }
        public void Reset()
        {
            this.Cancel = false;
            this.m_URL = string.Empty;
            this.m_RequestHeaders = string.Empty;
            this.m_AdditionalHeadersToAdd = string.Empty;
        }

        public string m_URL = string.Empty;
        public string m_RequestHeaders = string.Empty;
        public string m_AdditionalHeadersToAdd = string.Empty;
    }
    
    #endregion

    #region FileDownloadEx using COM component
    
    public delegate void FileDownloadExErrorEventHandler(object sender, FileDownloadExErrorEventArgs e);
    public class FileDownloadExErrorEventArgs : System.EventArgs
    {
        public FileDownloadExErrorEventArgs() { }
        public void SetParameters(int uid, string url, string errormsg)
        {
            this.m_dlUID = uid;
            this.m_URL = url;
            m_ErrorMsg = errormsg;
        }
        public void Reset()
        {
            m_dlUID = 0;
            m_URL = string.Empty;
            m_ErrorMsg = string.Empty;
        }

        public int m_dlUID = 0;
        public string m_URL = string.Empty;
        public string m_ErrorMsg = string.Empty;
    }

    public delegate void FileDownloadExProgressEventHandler(object sender, FileDownloadExProgressEventArgs e);
    public class FileDownloadExProgressEventArgs : System.ComponentModel.CancelEventArgs
    {
        public FileDownloadExProgressEventArgs() { }
        public void SetParameters(int uid, string url, int progress, int progressmax)
        {
            this.Cancel = false;
            this.m_dlUID = uid;
            this.m_URL = url;
            this.m_Progress = progress;
            this.m_ProgressMax = progressmax;
        }
        public void Reset()
        {
            this.m_dlUID = 0;
            this.m_URL = string.Empty;
            this.m_Progress = 0;
            this.m_ProgressMax = 0;
        }

        public int m_dlUID = 0;
        public string m_URL = string.Empty;
        public int m_Progress = 0;
        public int m_ProgressMax = 0;
    }

    public delegate void FileDownloadExAuthenticateEventHandler(object sender, FileDownloadExAuthenticateEventArgs e);
    public class FileDownloadExAuthenticateEventArgs : System.ComponentModel.CancelEventArgs
    {
        public FileDownloadExAuthenticateEventArgs() { }
        public void SetParameters(int uid)
        {
            this.Cancel = true;
            this.m_dlUID = uid;
            this.username = string.Empty;
            this.password = string.Empty;
        }
        public void Reset()
        {
            m_dlUID = 0;
            this.username = string.Empty;
            this.password = string.Empty;
        }

        public int m_dlUID = 0;
        public string username;
        public string password;
    }

    public delegate void FileDownloadExEndEventHandler(object sender, FileDownloadExEndEventArgs e);
    public class FileDownloadExEndEventArgs : System.EventArgs
    {
        public FileDownloadExEndEventArgs() { }
        public void SetParameters(int uid, string url, string filename)
        {
            this.m_dlUID = uid;
            this.m_URL = url;
            this.m_SavedFileNamePath = filename;
        }
        public void Reset()
        {
            this.m_dlUID = 0;
            this.m_URL = string.Empty;
            this.m_SavedFileNamePath = string.Empty;
        }
        public int m_dlUID = 0;
        public string m_URL = string.Empty;
        public string m_SavedFileNamePath = string.Empty;
    }

    public delegate void FileDownloadExEventHandler(object sender, FileDownloadExEventArgs e);
    public class FileDownloadExEventArgs : System.ComponentModel.CancelEventArgs
    {
        public FileDownloadExEventArgs() { }
        public void SetParameters(int uid, string url, string filename, string ext, string filesize, string extraheaders, string redirectedurl)
        {
            this.Cancel = false;
            this.m_dlUID = uid;
            this.m_URL = url;
            this.m_Filename = filename;
            this.m_Ext = ext;
            this.m_FileSize = filesize;
            this.m_ExtraHeaders = extraheaders;
            this.m_RedirectedUrl = redirectedurl;
            this.m_PathToSave = string.Empty;
            this.m_SendProgressEvents = false;
        }

        public void Reset()
        {
            this.Cancel = false;
            this.m_dlUID = 0;
            this.m_URL = string.Empty;
            this.m_Filename = string.Empty;
            this.m_Ext = string.Empty;
            this.m_FileSize = string.Empty;
            this.m_ExtraHeaders = string.Empty;
            this.m_RedirectedUrl = string.Empty;
            this.m_PathToSave = string.Empty;
            this.m_SendProgressEvents = false;
        }

        public int m_dlUID = 0;
        public string m_URL = string.Empty;
        public string m_Filename = string.Empty; //somefile.zip
        public string m_Ext = string.Empty; //.zip
        public string m_FileSize = string.Empty; //in bytes
        public string m_ExtraHeaders = string.Empty;
        public string m_RedirectedUrl = string.Empty;
        public bool m_SendProgressEvents = false;
        //Cancel = false;
        public string m_PathToSave = string.Empty; //Drive:\Dir\filename.ext
        //or the file will be saved in the exe dir with the m_Filename
    } 

    #endregion

}