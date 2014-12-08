
namespace IfacesEnumsStructsClasses
{
    #region Enums

    //Travel Log
    public enum TLMENUF
    {
        /// <summary>
        /// Enumeration should include the current travel log entry.
        /// </summary>
        TLEF_RELATIVE_INCLUDE_CURRENT = 0x00000001,
        /// <summary>
        /// Enumeration should include entries before the current entry.
        /// </summary>
        TLEF_RELATIVE_BACK = 0x00000010,
        /// <summary>
        /// Enumeration should include entries after the current entry.
        /// </summary>
        TLEF_RELATIVE_FORE = 0x00000020,
        /// <summary>
        /// Enumeration should include entries which cannot be navigated to.
        /// </summary>
        TLEF_INCLUDE_UNINVOKEABLE = 0x00000040,
        /// <summary>
        /// Enumeration should include all invokable entries.
        /// </summary>
        TLEF_ABSOLUTE = 0x00000031
    }

    public enum STATURLFLAGS
    {
        STATURL_QUERYFLAG_ISCACHED = 0x00010000,
        STATURL_QUERYFLAG_NOURL = 0x00020000,
        STATURL_QUERYFLAG_NOTITLE = 0x00040000,
        STATURL_QUERYFLAG_TOPLEVEL = 0x00080000,
        STATURLFLAG_ISCACHED = 0x00000001,
        STATURLFLAG_ISTOPLEVEL = 0x00000002
    }

    public enum ADDURL_FLAG
    {
        ADDURL_FIRST = 0,
        ADDURL_ADDTOHISTORYANDCACHE = 0,
        ADDURL_ADDTOCACHE = 1,
        ADDURL_Max = 2147483647
    }

    public enum BINDSTATUS
    {
        BINDSTATUS_FINDINGRESOURCE = 1,
        BINDSTATUS_CONNECTING,
        BINDSTATUS_REDIRECTING,
        BINDSTATUS_BEGINDOWNLOADDATA,
        BINDSTATUS_DOWNLOADINGDATA,
        BINDSTATUS_ENDDOWNLOADDATA,
        BINDSTATUS_BEGINDOWNLOADCOMPONENTS,
        BINDSTATUS_INSTALLINGCOMPONENTS,
        BINDSTATUS_ENDDOWNLOADCOMPONENTS,
        BINDSTATUS_USINGCACHEDCOPY,
        BINDSTATUS_SENDINGREQUEST,
        BINDSTATUS_CLASSIDAVAILABLE,
        BINDSTATUS_MIMETYPEAVAILABLE,
        BINDSTATUS_CACHEFILENAMEAVAILABLE,
        BINDSTATUS_BEGINSYNCOPERATION,
        BINDSTATUS_ENDSYNCOPERATION,
        BINDSTATUS_BEGINUPLOADDATA,
        BINDSTATUS_UPLOADINGDATA,
        BINDSTATUS_ENDUPLOADDATA,
        BINDSTATUS_PROTOCOLCLASSID,
        BINDSTATUS_ENCODING,
        BINDSTATUS_VERIFIEDMIMETYPEAVAILABLE,
        BINDSTATUS_CLASSINSTALLLOCATION,
        BINDSTATUS_DECODING,
        BINDSTATUS_LOADINGMIMEHANDLER,
        BINDSTATUS_CONTENTDISPOSITIONATTACH,
        BINDSTATUS_FILTERREPORTMIMETYPE,
        BINDSTATUS_CLSIDCANINSTANTIATE,
        BINDSTATUS_IUNKNOWNAVAILABLE,
        BINDSTATUS_DIRECTBIND,
        BINDSTATUS_RAWMIMETYPE,
        BINDSTATUS_PROXYDETECTING,
        BINDSTATUS_ACCEPTRANGES,
        BINDSTATUS_COOKIE_SENT,
        BINDSTATUS_COMPACT_POLICY_RECEIVED,
        BINDSTATUS_COOKIE_SUPPRESSED,
        BINDSTATUS_COOKIE_STATE_UNKNOWN,
        BINDSTATUS_COOKIE_STATE_ACCEPT,
        BINDSTATUS_COOKIE_STATE_REJECT,
        BINDSTATUS_COOKIE_STATE_PROMPT,
        BINDSTATUS_COOKIE_STATE_LEASH,
        BINDSTATUS_COOKIE_STATE_DOWNGRADE,
        BINDSTATUS_POLICY_HREF,
        BINDSTATUS_P3P_HEADER,
        BINDSTATUS_SESSION_COOKIE_RECEIVED,
        BINDSTATUS_PERSISTENT_COOKIE_RECEIVED,
        BINDSTATUS_SESSION_COOKIES_ALLOWED
    }

    public enum BSCF
    {
        BSCF_FIRSTDATANOTIFICATION = 0x1,
        BSCF_INTERMEDIATEDATANOTIFICATION = 0x2,
        BSCF_LASTDATANOTIFICATION = 0x4,
        BSCF_DATAFULLYAVAILABLE = 0x8,
        BSCF_AVAILABLEDATASIZEUNKNOWN = 0x10
    }

    public enum BINDF
    {
        BINDF_DEFAULT = 0x00000000,
        BINDF_ASYNCHRONOUS = 0x00000001,
        BINDF_ASYNCSTORAGE = 0x00000002,
        BINDF_NOPROGRESSIVERENDERING = 0x00000004,
        BINDF_OFFLINEOPERATION = 0x00000008,
        BINDF_GETNEWESTVERSION = 0x00000010,
        BINDF_NOWRITECACHE = 0x00000020,
        BINDF_NEEDFILE = 0x00000040,
        BINDF_PULLDATA = 0x00000080,
        BINDF_IGNORESECURITYPROBLEM = 0x00000100,
        BINDF_RESYNCHRONIZE = 0x00000200,
        BINDF_HYPERLINK = 0x00000400,
        BINDF_NO_UI = 0x00000800,
        BINDF_SILENTOPERATION = 0x00001000,
        BINDF_PRAGMA_NO_CACHE = 0x00002000,
        BINDF_GETCLASSOBJECT = 0x00004000,
        BINDF_RESERVED_1 = 0x00008000,
        BINDF_FREE_THREADED = 0x00010000,
        BINDF_DIRECT_READ = 0x00020000,
        BINDF_FORMS_SUBMIT = 0x00040000,
        BINDF_GETFROMCACHE_IF_NET_FAIL = 0x00080000,
        BINDF_FROMURLMON = 0x00100000,
        BINDF_FWD_BACK = 0x00200000,
        BINDF_PREFERDEFAULTHANDLER = 0x00400000,
        BINDF_ENFORCERESTRICTED = 0x00800000
    }

    public enum BINDVERB
    {
        BINDVERB_GET = 0x00000000,       // default action
        BINDVERB_POST = 0x00000001,       // post verb
        BINDVERB_PUT = 0x00000002,       // put verb
        BINDVERB_CUSTOM = 0x00000003      // custom verb
    }

    public enum tagTYMED
    {
        TYMED_HGLOBAL = 1,
        TYMED_FILE = 2,
        TYMED_ISTREAM = 4,
        TYMED_ISTORAGE = 8,
        TYMED_GDI = 16,
        TYMED_MFPICT = 32,
        TYMED_ENHMF = 64,
        TYMED_NULL = 0
    }

    public enum DOCHOSTUITYPE
    {
        DOCHOSTUITYPE_BROWSE = 0,
        DOCHOSTUITYPE_AUTHOR = 1
    }

    public enum DOCHOSTUIDBLCLK
    {
        DEFAULT = 0,
        SHOWPROPERTIES = 1,
        SHOWCODE = 2
    }

    public enum DOCHOSTUIFLAG
    {
        DIALOG = 0x00000001,
        DISABLE_HELP_MENU = 0x00000002,
        NO3DBORDER = 0x00000004,
        SCROLL_NO = 0x00000008,
        //does not execute any script when loading pages.
        DISABLE_SCRIPT_INACTIVE = 0x00000010,
        OPENNEWWIN = 0x00000020,
        DISABLE_OFFSCREEN = 0x00000040,
        FLAT_SCROLLBAR = 0x00000080,
        DIV_BLOCKDEFAULT = 0x00000100,
        ACTIVATE_CLIENTHIT_ONLY = 0x00000200,
        OVERRIDEBEHAVIORFACTORY = 0x00000400,
        CODEPAGELINKEDFONTS = 0x00000800,
        URL_ENCODING_DISABLE_UTF8 = 0x00001000,
        URL_ENCODING_ENABLE_UTF8 = 0x00002000,
        ENABLE_FORMS_AUTOCOMPLETE = 0x00004000,
        ENABLE_INPLACE_NAVIGATION = 0x00010000,
        IME_ENABLE_RECONVERSION = 0x00020000,
        THEME = 0x00040000,
        NOTHEME = 0x00080000,
        NOPICS = 0x00100000,
        NO3DOUTERBORDER = 0x00200000,
        DISABLE_EDIT_NS_FIXUP = 0x400000,
        LOCAL_MACHINE_ACCESS_CHECK = 0x800000,
        DISABLE_UNTRUSTEDPROTOCOL = 0x1000000
    }

    public enum DOCDOWNLOADCTLFLAG
    {
        DLIMAGES = unchecked((int)0x00000010),
        VIDEOS = unchecked((int)0x00000020),
        BGSOUNDS = unchecked((int)0x00000040),
        NO_SCRIPTS = unchecked((int)0x00000080),
        NO_JAVA = unchecked((int)0x00000100),
        NO_RUNACTIVEXCTLS = unchecked((int)0x00000200),
        NO_DLACTIVEXCTLS = unchecked((int)0x00000400),
        DOWNLOADONLY = unchecked((int)0x00000800),
        NO_FRAMEDOWNLOAD = unchecked((int)0x00001000),
        RESYNCHRONIZE = unchecked((int)0x00002000),
        PRAGMA_NO_CACHE = unchecked((int)0x00004000),
        NO_BEHAVIORS = unchecked((int)0x00008000),
        NO_METACHARSET = unchecked((int)0x00010000),
        URL_ENCODING_DISABLE_UTF8 = unchecked((int)0x00020000),
        URL_ENCODING_ENABLE_UTF8 = unchecked((int)0x00040000),
        NOFRAMES = unchecked((int)0x00080000),
        FORCEOFFLINE = unchecked((int)0x10000000),
        NO_CLIENTPULL = unchecked((int)0x20000000),
        SILENT = unchecked((int)0x40000000),
        OFFLINEIFNOTCONNECTED = unchecked((int)0x80000000),
        OFFLINE = unchecked((int)0x80000000), //DLCTL_OFFLINEIFNOTCONNECTED

    }

    public enum CLSCTX
    {
        CLSCTX_INPROC_SERVER = 0x1,
        CLSCTX_INPROC_HANDLER = 0x2,
        CLSCTX_LOCAL_SERVER = 0x4,
        CLSCTX_INPROC_SERVER16 = 0x8,
        CLSCTX_REMOTE_SERVER = 0x10,
        CLSCTX_INPROC_HANDLER16 = 0x20,
        CLSCTX_RESERVED1 = 0x40,
        CLSCTX_RESERVED2 = 0x80,
        CLSCTX_RESERVED3 = 0x100,
        CLSCTX_RESERVED4 = 0x200,
        CLSCTX_NO_CODE_DOWNLOAD = 0x400,
        CLSCTX_RESERVED5 = 0x800,
        CLSCTX_NO_CUSTOM_MARSHAL = 0x1000,
        CLSCTX_ENABLE_CODE_DOWNLOAD = 0x2000,
        CLSCTX_NO_FAILURE_LOG = 0x4000,
        CLSCTX_DISABLE_AAA = 0x8000,
        CLSCTX_ENABLE_AAA = 0x10000,
        CLSCTX_FROM_DEFAULT_CONTEXT = 0x20000,
        CLSCTX_INPROC = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER,
        CLSCTX_SERVER = CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,
        CLSCTX_ALL = CLSCTX_SERVER | CLSCTX_INPROC_HANDLER
    }

    public enum tagREADYSTATE
    {
        READYSTATE_UNINITIALIZED = 0,
        READYSTATE_LOADING = 1,
        READYSTATE_LOADED = 2,
        READYSTATE_INTERACTIVE = 3,
        READYSTATE_COMPLETE = 4
    }

    public enum OLEDOVERB : int
    {
        OLEIVERB_DISCARDUNDOSTATE = -6,
        OLEIVERB_HIDE = -3,
        OLEIVERB_INPLACEACTIVATE = -5,
        OLECLOSE_NOSAVE = 1,
        OLEIVERB_OPEN = -2,
        OLEIVERB_PRIMARY = 0,
        OLEIVERB_PROPERTIES = -7,
        OLEIVERB_SHOW = -1,
        OLEIVERB_UIACTIVATE = -4
    }

    public enum OLECMDID
    {
        OLECMDID_OPEN = 1,
        OLECMDID_NEW = 2,
        OLECMDID_SAVE = 3,
        OLECMDID_SAVEAS = 4,
        OLECMDID_SAVECOPYAS = 5,
        OLECMDID_PRINT = 6,
        OLECMDID_PRINTPREVIEW = 7,
        OLECMDID_PAGESETUP = 8,
        OLECMDID_SPELL = 9,
        OLECMDID_PROPERTIES = 10,
        OLECMDID_CUT = 11,
        OLECMDID_COPY = 12,
        OLECMDID_PASTE = 13,
        OLECMDID_PASTESPECIAL = 14,
        OLECMDID_UNDO = 15,
        OLECMDID_REDO = 16,
        OLECMDID_SELECTALL = 17,
        OLECMDID_CLEARSELECTION = 18,
        OLECMDID_ZOOM = 19,
        OLECMDID_GETZOOMRANGE = 20,
        OLECMDID_UPDATECOMMANDS = 21,
        OLECMDID_REFRESH = 22,
        OLECMDID_STOP = 23,
        OLECMDID_HIDETOOLBARS = 24,
        OLECMDID_SETPROGRESSMAX = 25,
        OLECMDID_SETPROGRESSPOS = 26,
        OLECMDID_SETPROGRESSTEXT = 27,
        OLECMDID_SETTITLE = 28,
        OLECMDID_SETDOWNLOADSTATE = 29,
        OLECMDID_STOPDOWNLOAD = 30,
        OLECMDID_ONTOOLBARACTIVATED = 31,
        OLECMDID_FIND = 32,
        OLECMDID_DELETE = 33,
        OLECMDID_HTTPEQUIV = 34,
        OLECMDID_HTTPEQUIV_DONE = 35,
        OLECMDID_ENABLE_INTERACTION = 36,
        OLECMDID_ONUNLOAD = 37,
        OLECMDID_PROPERTYBAG2 = 38,
        OLECMDID_PREREFRESH = 39,
        OLECMDID_SHOWSCRIPTERROR = 40,
        OLECMDID_SHOWMESSAGE = 41,
        OLECMDID_SHOWFIND = 42,
        OLECMDID_SHOWPAGESETUP = 43,
        OLECMDID_SHOWPRINT = 44,
        OLECMDID_CLOSE = 45,
        OLECMDID_ALLOWUILESSSAVEAS = 46,
        OLECMDID_DONTDOWNLOADCSS = 47,
        OLECMDID_UPDATEPAGESTATUS = 48,
        OLECMDID_PRINT2 = 49,
        OLECMDID_PRINTPREVIEW2 = 50,
        OLECMDID_SETPRINTTEMPLATE = 51,
        OLECMDID_GETPRINTTEMPLATE = 52,
        OLECMDID_PAGEACTIONBLOCKED = 55,
        OLECMDID_PAGEACTIONUIQUERY = 56,
        OLECMDID_FOCUSVIEWCONTROLS = 57,
        OLECMDID_FOCUSVIEWCONTROLSQUERY = 58,
        OLECMDID_SHOWPAGEACTIONMENU = 59,
        OLECMDID_ADDTRAVELENTRY = 60,
        OLECMDID_UPDATETRAVELENTRY = 61,
        OLECMDID_UPDATEBACKFORWARDSTATE = 62,
        OLECMDID_OPTICAL_ZOOM = 63,
        OLECMDID_OPTICAL_GETZOOMRANGE = 64,
        OLECMDID_WINDOWSTATECHANGED = 65

    }

    public enum OLECMDEXECOPT
    {
        OLECMDEXECOPT_DODEFAULT = 0,
        OLECMDEXECOPT_PROMPTUSER = 1,
        OLECMDEXECOPT_DONTPROMPTUSER = 2,
        OLECMDEXECOPT_SHOWHELP = 3
    }

    public enum OLECMDF
    {
        OLECMDF_SUPPORTED = 1,
        OLECMDF_ENABLED = 2,
        OLECMDF_LATCHED = 4,
        OLECMDF_NINCHED = 8,
        OLECMDF_INVISIBLE = 16,
        OLECMDF_DEFHIDEONCTXTMENU = 32
    }

    public enum GetWindow_Cmd
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6
    }

    public enum DROPEFFECT : uint
    {
        NONE = 0,
        COPY = 1,
        MOVE = 2,
        LINK = 4,
        SCROLL = 0x80000000
    }

    public enum WB_CONTEXTMENU_TYPES
    {
        CONTEXT_MENU_DEFAULT = 0,
        CONTEXT_MENU_IMAGE = 1,
        CONTEXT_MENU_CONTROL = 2,
        CONTEXT_MENU_TABLE = 3,
        // in browse mode
        CONTEXT_MENU_TEXTSELECT = 4,
        CONTEXT_MENU_ANCHOR = 5,
        CONTEXT_MENU_UNKNOWN = 6,
        CONTEXT_MENU_IMGDYNSRC = 7,
        CONTEXT_MENU_IMGART = 8,
        CONTEXT_MENU_DEBUG = 9,
        CONTEXT_MENU_VSCROLL = 10,
        CONTEXT_MENU_HSCROLL = 11,
        PRINT_DONTBOTHERUSER = unchecked((int)0x01),
        PRINT_WAITFORCOMPLETION = unchecked((int)0x02)
    }

    public enum WB_MiscCommandTarget
    {
        Find = 1,
        ViewSource,
        Options
    }

    public enum tagSTREAM_SEEK
    {
        STREAM_SEEK_SET = 0,
        STREAM_SEEK_CUR = 1,
        STREAM_SEEK_END = 2
    }

    public enum tagSTATFLAG
    {
        STATFLAG_DEFAULT = 0,
        STATFLAG_NONAME = 1,
        STATFLAG_NOOPEN = 2
    }

    public enum BrowserNavConstants
    {
        navOpenInNewWindow = 0x1,
        navNoHistory = 0x2,
        navNoReadFromCache = 0x4,
        navNoWriteToCache = 0x8,
        navAllowAutosearch = 0x10,
        navBrowserBar = 0x20,
        navHyperlink = 0x40,
        navEnforceRestricted = 0x80,
        navNewWindowsManaged = 0x0100,
        navUntrustedForDownload = 0x0200,
        navTrustedForActiveX = 0x0400,
        navOpenInNewTab = 0x0800,
        navOpenInBackgroundTab = 0x1000,
        navKeepWordWheelText = 0x2000
    }

    public enum CommandStateChangeConstants
    {
        CSC_UPDATECOMMANDS = unchecked((int)0xFFFFFFFF),
        CSC_NAVIGATEFORWARD = unchecked((int)0x00000001),
        CSC_NAVIGATEBACK = unchecked((int)0x00000002)
    }

    public enum RefreshConstants
    {
        REFRESH_NORMAL = 0,
        REFRESH_IFEXPIRED = 1,
        REFRESH_CONTINUE = 2,
        REFRESH_COMPLETELY = 3
    }

    public enum SecureLockIconConstants
    {
        secureLockIconUnsecure = 0,
        secureLockIconMixed = 0x1,
        secureLockIconUnknownBits = 0x2,
        secureLockIcon40Bit = 0x3,
        secureLockIcon56Bit = 0x4,
        secureLockIconFortezza = 0x5,
        secureLockIcon128Bit = 0x6
    }

    public enum WinInetErrors : int
    {
        HTTP_STATUS_CONTINUE = 100, //The request can be continued.
        HTTP_STATUS_SWITCH_PROTOCOLS = 101, //The server has switched protocols in an upgrade header.
        HTTP_STATUS_OK = 200, //The request completed successfully.
        HTTP_STATUS_CREATED = 201, //The request has been fulfilled and resulted in the creation of a new resource.
        HTTP_STATUS_ACCEPTED = 202, //The request has been accepted for processing, but the processing has not been completed.
        HTTP_STATUS_PARTIAL = 203, //The returned meta information in the entity-header is not the definitive set available from the origin server.
        HTTP_STATUS_NO_CONTENT = 204, //The server has fulfilled the request, but there is no new information to send back.
        HTTP_STATUS_RESET_CONTENT = 205, //The request has been completed, and the client program should reset the document view that caused the request to be sent to allow the user to easily initiate another input action.
        HTTP_STATUS_PARTIAL_CONTENT = 206, //The server has fulfilled the partial GET request for the resource.
        HTTP_STATUS_AMBIGUOUS = 300, //The server couldn't decide what to return.
        HTTP_STATUS_MOVED = 301, //The requested resource has been assigned to a new permanent URI (Uniform Resource Identifier), and any future references to this resource should be done using one of the returned URIs.
        HTTP_STATUS_REDIRECT = 302, //The requested resource resides temporarily under a different URI (Uniform Resource Identifier).
        HTTP_STATUS_REDIRECT_METHOD = 303, //The response to the request can be found under a different URI (Uniform Resource Identifier) and should be retrieved using a GET HTTP verb on that resource.
        HTTP_STATUS_NOT_MODIFIED = 304, //The requested resource has not been modified.
        HTTP_STATUS_USE_PROXY = 305, //The requested resource must be accessed through the proxy given by the location field.
        HTTP_STATUS_REDIRECT_KEEP_VERB = 307, //The redirected request keeps the same HTTP verb. HTTP/1.1 behavior.

        HTTP_STATUS_BAD_REQUEST = 400,
        HTTP_STATUS_DENIED = 401,
        HTTP_STATUS_PAYMENT_REQ = 402,
        HTTP_STATUS_FORBIDDEN = 403,
        HTTP_STATUS_NOT_FOUND = 404,
        HTTP_STATUS_BAD_METHOD = 405,
        HTTP_STATUS_NONE_ACCEPTABLE = 406,
        HTTP_STATUS_PROXY_AUTH_REQ = 407,
        HTTP_STATUS_REQUEST_TIMEOUT = 408,
        HTTP_STATUS_CONFLICT = 409,
        HTTP_STATUS_GONE = 410,
        HTTP_STATUS_LENGTH_REQUIRED = 411,
        HTTP_STATUS_PRECOND_FAILED = 412,
        HTTP_STATUS_REQUEST_TOO_LARGE = 413,
        HTTP_STATUS_URI_TOO_LONG = 414,
        HTTP_STATUS_UNSUPPORTED_MEDIA = 415,
        HTTP_STATUS_RETRY_WITH = 449,
        HTTP_STATUS_SERVER_ERROR = 500,
        HTTP_STATUS_NOT_SUPPORTED = 501,
        HTTP_STATUS_BAD_GATEWAY = 502,
        HTTP_STATUS_SERVICE_UNAVAIL = 503,
        HTTP_STATUS_GATEWAY_TIMEOUT = 504,
        HTTP_STATUS_VERSION_NOT_SUP = 505,

        ERROR_INTERNET_ASYNC_THREAD_FAILED = 12047,    //The application could not start an asynchronous thread.
        ERROR_INTERNET_BAD_AUTO_PROXY_SCRIPT = 12166,    //There was an error in the automatic proxy configuration script.
        ERROR_INTERNET_BAD_OPTION_LENGTH = 12010,    //The length of an option supplied to InternetQueryOption or InternetSetOption is incorrect for the type of option specified.
        ERROR_INTERNET_BAD_REGISTRY_PARAMETER = 12022,    //A required registry value was located but is an incorrect type or has an invalid value.
        ERROR_INTERNET_CANNOT_CONNECT = 12029,    //The attempt to connect to the server failed.
        ERROR_INTERNET_CHG_POST_IS_NON_SECURE = 12042,    //The application is posting and attempting to change multiple lines of text on a server that is not secure.
        ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED = 12044,    //The server is requesting client authentication.
        ERROR_INTERNET_CLIENT_AUTH_NOT_SETUP = 12046,    //Client authorization is not set up on this computer.
        ERROR_INTERNET_CONNECTION_ABORTED = 12030,    //The connection with the server has been terminated.
        ERROR_INTERNET_CONNECTION_RESET = 12031,    //The connection with the server has been reset.
        ERROR_INTERNET_DIALOG_PENDING = 12049,    //Another thread has a password dialog box in progress.
        ERROR_INTERNET_DISCONNECTED = 12163,    //The Internet connection has been lost.
        ERROR_INTERNET_EXTENDED_ERROR = 12003,    //An extended error was returned from the server. This is typically a string or buffer containing a verbose error message. Call InternetGetLastResponseInfo to retrieve the error text.
        ERROR_INTERNET_FAILED_DUETOSECURITYCHECK = 12171,    //The function failed due to a security check.
        ERROR_INTERNET_FORCE_RETRY = 12032,    //The function needs to redo the request.
        ERROR_INTERNET_FORTEZZA_LOGIN_NEEDED = 12054,    //The requested resource requires Fortezza authentication.
        ERROR_INTERNET_HANDLE_EXISTS = 12036,    //The request failed because the handle already exists.
        ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR = 12039,    //The application is moving from a non-SSL to an SSL connection because of a redirect.
        ERROR_INTERNET_HTTPS_HTTP_SUBMIT_REDIR = 12052,    //The data being submitted to an SSL connection is being redirected to a non-SSL connection.
        ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR = 12040,    //The application is moving from an SSL to an non-SSL connection because of a redirect.
        ERROR_INTERNET_INCORRECT_FORMAT = 12027,    //The format of the request is invalid.
        ERROR_INTERNET_INCORRECT_HANDLE_STATE = 12019,    //The requested operation cannot be carried out because the handle supplied is not in the correct state.
        ERROR_INTERNET_INCORRECT_HANDLE_TYPE = 12018,    //The type of handle supplied is incorrect for this operation.
        ERROR_INTERNET_INCORRECT_PASSWORD = 12014,    //The request to connect and log on to an FTP server could not be completed because the supplied password is incorrect.
        ERROR_INTERNET_INCORRECT_USER_NAME = 12013,    //The request to connect and log on to an FTP server could not be completed because the supplied user name is incorrect.
        ERROR_INTERNET_INSERT_CDROM = 12053,    //The request requires a CD-ROM to be inserted in the CD-ROM drive to locate the resource requested.
        ERROR_INTERNET_INTERNAL_ERROR = 12004,    //An internal error has occurred.
        ERROR_INTERNET_INVALID_CA = 12045,    //The function is unfamiliar with the Certificate Authority that generated the server's certificate.
        ERROR_INTERNET_INVALID_OPERATION = 12016,    //The requested operation is invalid.
        ERROR_INTERNET_INVALID_OPTION = 12009,    //A request to InternetQueryOption or InternetSetOption specified an invalid option value.
        ERROR_INTERNET_INVALID_PROXY_REQUEST = 12033,    //The request to the proxy was invalid.
        ERROR_INTERNET_INVALID_URL = 12005,    //The URL is invalid.
        ERROR_INTERNET_ITEM_NOT_FOUND = 12028,    //The requested item could not be located.
        ERROR_INTERNET_LOGIN_FAILURE = 12015,    //The request to connect and log on to an FTP server failed.
        ERROR_INTERNET_LOGIN_FAILURE_DISPLAY_ENTITY_BODY = 12174,    //The MS-Logoff digest header has been returned from the Web site. This header specifically instructs the digest package to purge credentials for the associated realm. This error will only be returned if INTERNET_ERROR_MASK_LOGIN_FAILURE_DISPLAY_ENTITY_BODY has been set.
        ERROR_INTERNET_MIXED_SECURITY = 12041,    //The content is not entirely secure. Some of the content being viewed may have come from unsecured servers.
        ERROR_INTERNET_NAME_NOT_RESOLVED = 12007,    //The server name could not be resolved.
        ERROR_INTERNET_NEED_MSN_SSPI_PKG = 12173,    //Not currently implemented.
        ERROR_INTERNET_NEED_UI = 12034,    //A user interface or other blocking operation has been requested.
        ERROR_INTERNET_NO_CALLBACK = 12025,    //An asynchronous request could not be made because a callback function has not been set.
        ERROR_INTERNET_NO_CONTEXT = 12024,    //An asynchronous request could not be made because a zero context value was supplied.
        ERROR_INTERNET_NO_DIRECT_ACCESS = 12023,    //Direct network access cannot be made at this time.
        ERROR_INTERNET_NOT_INITIALIZED = 12172,    //Initialization of the WinINet API has not occurred. Indicates that a higher-level function, such as InternetOpen, has not been called yet.
        ERROR_INTERNET_NOT_PROXY_REQUEST = 12020,    //The request cannot be made via a proxy.
        ERROR_INTERNET_OPERATION_CANCELLED = 12017,    //The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
        ERROR_INTERNET_OPTION_NOT_SETTABLE = 12011,    //The requested option cannot be set, only queried.
        ERROR_INTERNET_OUT_OF_HANDLES = 12001,    //No more handles could be generated at this time.
        ERROR_INTERNET_POST_IS_NON_SECURE = 12043,    //The application is posting data to a server that is not secure.
        ERROR_INTERNET_PROTOCOL_NOT_FOUND = 12008,    //The requested protocol could not be located.
        ERROR_INTERNET_PROXY_SERVER_UNREACHABLE = 12165,    //The designated proxy server cannot be reached.
        ERROR_INTERNET_REDIRECT_SCHEME_CHANGE = 12048,    //The function could not handle the redirection, because the scheme changed (for example, HTTP to FTP).
        ERROR_INTERNET_REGISTRY_VALUE_NOT_FOUND = 12021,    //A required registry value could not be located.
        ERROR_INTERNET_REQUEST_PENDING = 12026,    //The required operation could not be completed because one or more requests are pending.
        ERROR_INTERNET_RETRY_DIALOG = 12050,    //The dialog box should be retried.
        ERROR_INTERNET_SEC_CERT_CN_INVALID = 12038,    //SSL certificate common name (host name field) is incorrect—for example, if you entered www.server.com and the common name on the certificate says www.different.com.
        ERROR_INTERNET_SEC_CERT_DATE_INVALID = 12037,    //SSL certificate date that was received from the server is bad. The certificate is expired.
        ERROR_INTERNET_SEC_CERT_ERRORS = 12055,    //The SSL certificate contains errors.
        ERROR_INTERNET_SEC_CERT_NO_REV = 12056,
        ERROR_INTERNET_SEC_CERT_REV_FAILED = 12057,
        ERROR_INTERNET_SEC_CERT_REVOKED = 12170,    //SSL certificate was revoked.
        ERROR_INTERNET_SEC_INVALID_CERT = 12169,    //SSL certificate is invalid.
        ERROR_INTERNET_SECURITY_CHANNEL_ERROR = 12157,    //The application experienced an internal error loading the SSL libraries.
        ERROR_INTERNET_SERVER_UNREACHABLE = 12164,    //The Web site or server indicated is unreachable.
        ERROR_INTERNET_SHUTDOWN = 12012,    //WinINet support is being shut down or unloaded.
        ERROR_INTERNET_TCPIP_NOT_INSTALLED = 12159,    //The required protocol stack is not loaded and the application cannot start WinSock.
        ERROR_INTERNET_TIMEOUT = 12002,    //The request has timed out.
        ERROR_INTERNET_UNABLE_TO_CACHE_FILE = 12158,    //The function was unable to cache the file.
        ERROR_INTERNET_UNABLE_TO_DOWNLOAD_SCRIPT = 12167,    //The automatic proxy configuration script could not be downloaded. The INTERNET_FLAG_MUST_CACHE_REQUEST flag was set.

        INET_E_INVALID_URL = unchecked((int)0x800C0002),
        INET_E_NO_SESSION = unchecked((int)0x800C0003),
        INET_E_CANNOT_CONNECT = unchecked((int)0x800C0004),
        INET_E_RESOURCE_NOT_FOUND = unchecked((int)0x800C0005),
        INET_E_OBJECT_NOT_FOUND = unchecked((int)0x800C0006),
        INET_E_DATA_NOT_AVAILABLE = unchecked((int)0x800C0007),
        INET_E_DOWNLOAD_FAILURE = unchecked((int)0x800C0008),
        INET_E_AUTHENTICATION_REQUIRED = unchecked((int)0x800C0009),
        INET_E_NO_VALID_MEDIA = unchecked((int)0x800C000A),
        INET_E_CONNECTION_TIMEOUT = unchecked((int)0x800C000B),
        INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011),
        INET_E_INVALID_REQUEST = unchecked((int)0x800C000C),
        INET_E_UNKNOWN_PROTOCOL = unchecked((int)0x800C000D),
        INET_E_QUERYOPTION_UNKNOWN = unchecked((int)0x800C0013),
        INET_E_SECURITY_PROBLEM = unchecked((int)0x800C000E),
        INET_E_CANNOT_LOAD_DATA = unchecked((int)0x800C000F),
        INET_E_CANNOT_INSTANTIATE_OBJECT = unchecked((int)0x800C0010),
        INET_E_REDIRECT_FAILED = unchecked((int)0x800C0014),
        INET_E_REDIRECT_TO_DIR = unchecked((int)0x800C0015),
        INET_E_CANNOT_LOCK_REQUEST = unchecked((int)0x800C0016),
        INET_E_USE_EXTEND_BINDING = unchecked((int)0x800C0017),
        INET_E_TERMINATED_BIND = unchecked((int)0x800C0018),
        INET_E_ERROR_FIRST = unchecked((int)0x800C0002),
        INET_E_CODE_DOWNLOAD_DECLINED = unchecked((int)0x800C0100),
        INET_E_RESULT_DISPATCHED = unchecked((int)0x800C0200),
        INET_E_CANNOT_REPLACE_SFP_FILE = unchecked((int)0x800C0300),

        HTTP_COOKIE_DECLINED = 12162,    //The HTTP cookie was declined by the server.
        HTTP_COOKIE_NEEDS_CONFIRMATION = 12161,    //The HTTP cookie requires confirmation.
        HTTP_DOWNLEVEL_SERVER = 12151,    //The server did not return any headers.
        HTTP_HEADER_ALREADY_EXISTS = 12155,    //The header could not be added because it already exists.
        HTTP_HEADER_NOT_FOUND = 12150,    //The requested header could not be located.
        HTTP_INVALID_HEADER = 12153,    //The supplied header is invalid.
        HTTP_INVALID_QUERY_REQUEST = 12154,    //The request made to HttpQueryInfo is invalid.
        HTTP_INVALID_SERVER_RESPONSE = 12152,    //The server response could not be parsed.
        HTTP_NOT_REDIRECTED = 12160,    //The HTTP request was not redirected.
        HTTP_REDIRECT_FAILED = 12156,    //The redirection failed because either the scheme changed (for example, HTTP to FTP) or all attempts made to redirect failed (default is five attempts).
        HTTP_REDIRECT_NEEDS_CONFIRMATION = 12168    //The redirection requires user confirmation.
    }

    public enum TextSizeWB
    {
        Smallest = 0,
        Smaller = 1,
        Medium = 2,
        Larger = 3,
        Largest = 4
    }

    public enum NWMF
    {
        UNLOADING = 0x0001,
        USERINITED = 0x0002,
        FIRST_USERINITED = 0x0004,
        OVERRIDEKEY = 0x0008,
        SHOWHELP = 0x0010,
        HTMLDIALOG = 0x0020,
        FROMPROXY = 0x0040
    }

    public enum ProcessUrlActionFlags : uint
    {
        PUAF_DEFAULT = 0,
        PUAF_NOUI = 0x1,
        PUAF_ISFILE = 0x2,
        PUAF_WARN_IF_DENIED = 0x4,
        PUAF_FORCEUI_FOREGROUND = 0x8,
        PUAF_CHECK_TIFS = 0x10,
        PUAF_DONTCHECKBOXINDIALOG = 0x20,
        PUAF_TRUSTED = 0x40,
        PUAF_ACCEPT_WILDCARD_SCHEME = 0x80,
        PUAF_ENFORCERESTRICTED = 0x100
    }

    public enum URLPOLICY : uint
    {
        // Permissions 
        ALLOW = 0x00,
        QUERY = 0x01,
        DISALLOW = 0x03,

        ACTIVEX_CHECK_LIST = 0x00010000,
        CREDENTIALS_SILENT_LOGON_OK = 0x00000000,
        CREDENTIALS_MUST_PROMPT_USER = 0x00010000,
        CREDENTIALS_CONDITIONAL_PROMPT = 0x00020000,
        CREDENTIALS_ANONYMOUS_ONLY = 0x00030000,
        AUTHENTICATE_CLEARTEXT_OK = 0x00000000,
        AUTHENTICATE_CHALLENGE_RESPONSE = 0x00010000,
        AUTHENTICATE_MUTUAL_ONLY = 0x00030000,
        JAVA_PROHIBIT = 0x00000000,
        JAVA_HIGH = 0x00010000,
        JAVA_MEDIUM = 0x00020000,
        JAVA_LOW = 0x00030000,
        JAVA_CUSTOM = 0x00800000,
        CHANNEL_SOFTDIST_PROHIBIT = 0x00010000,
        CHANNEL_SOFTDIST_PRECACHE = 0x00020000,
        CHANNEL_SOFTDIST_AUTOINSTALL = 0x00030000,

        // For each action specified above the system maintains
        // a set of policies for the action. 
        // The only policies supported currently are permissions (i.e. is something allowed)
        // and logging status. 
        // IMPORTANT: If you are defining your own policies don't overload the meaning of the
        // loword of the policy. You can use the hiword to store any policy bits which are only
        // meaningful to your action.
        // For an example of how to do this look at the URLPOLICY_JAVA above

        // Notifications are not done when user already queried.
        NOTIFY_ON_ALLOW = 0x10,
        NOTIFY_ON_DISALLOW = 0x20,

        // Logging is done regardless of whether user was queried.
        LOG_ON_ALLOW = 0x40,
        LOG_ON_DISALLOW = 0x80,
        DONTCHECKDLGBOX = 0x100
    }

    public enum URLACTION : uint
    {
        // The zone manager maintains policies for a set of standard actions. 
        // These actions are identified by integral values (called action indexes)
        // specified below.

        // Minimum legal value for an action    
        MIN = 0x00001000,

        DOWNLOAD_MIN = 0x00001000,
        DOWNLOAD_SIGNED_ACTIVEX = 0x00001001,
        DOWNLOAD_UNSIGNED_ACTIVEX = 0x00001004,
        DOWNLOAD_CURR_MAX = 0x00001004,
        DOWNLOAD_MAX = 0x000011FF,

        ACTIVEX_MIN = 0x00001200,
        ACTIVEX_RUN = 0x00001200,
        ACTIVEX_OVERRIDE_OBJECT_SAFETY = 0x00001201, // aggregate next four
        ACTIVEX_OVERRIDE_DATA_SAFETY = 0x00001202, //
        ACTIVEX_OVERRIDE_SCRIPT_SAFETY = 0x00001203, //
        SCRIPT_OVERRIDE_SAFETY = 0x00001401, //
        ACTIVEX_CONFIRM_NOOBJECTSAFETY = 0x00001204, //
        ACTIVEX_TREATASUNTRUSTED = 0x00001205,
        ACTIVEX_NO_WEBOC_SCRIPT = 0x00001206,
        ACTIVEX_CURR_MAX = 0x00001206,
        ACTIVEX_MAX = 0x000013ff,

        SCRIPT_MIN = 0x00001400,
        SCRIPT_RUN = 0x00001400,
        SCRIPT_JAVA_USE = 0x00001402,
        SCRIPT_SAFE_ACTIVEX = 0x00001405,
        CROSS_DOMAIN_DATA = 0x00001406,
        SCRIPT_PASTE = 0x00001407,
        SCRIPT_CURR_MAX = 0x00001407,
        SCRIPT_MAX = 0x000015ff,

        HTML_MIN = 0x00001600,
        HTML_SUBMIT_FORMS = 0x00001601, // aggregate next two
        HTML_SUBMIT_FORMS_FROM = 0x00001602, //
        HTML_SUBMIT_FORMS_TO = 0x00001603, //
        HTML_FONT_DOWNLOAD = 0x00001604,
        HTML_JAVA_RUN = 0x00001605, // derive from Java custom policy
        HTML_USERDATA_SAVE = 0x00001606,
        HTML_SUBFRAME_NAVIGATE = 0x00001607,
        HTML_META_REFRESH = 0x00001608,
        HTML_MIXED_CONTENT = 0x00001609,
        HTML_MAX = 0x000017ff,

        SHELL_MIN = 0x00001800,
        SHELL_INSTALL_DTITEMS = 0x00001800,
        SHELL_MOVE_OR_COPY = 0x00001802,
        SHELL_FILE_DOWNLOAD = 0x00001803,
        SHELL_VERB = 0x00001804,
        SHELL_WEBVIEW_VERB = 0x00001805,
        SHELL_SHELLEXECUTE = 0x00001806,
        SHELL_CURR_MAX = 0x00001806,
        SHELL_MAX = 0x000019ff,

        NETWORK_MIN = 0x00001A00,
        CREDENTIALS_USE = 0x00001A00,
        AUTHENTICATE_CLIENT = 0x00001A01,

        COOKIES = 0x00001A02,
        COOKIES_SESSION = 0x00001A03,
        CLIENT_CERT_PROMPT = 0x00001A0,
        COOKIES_THIRD_PARTY = 0x00001A05,
        COOKIES_SESSION_THIRD_PARTY = 0x00001A06,
        COOKIES_ENABLED = 0x00001A10,
        NETWORK_CURR_MAX = 0x00001A10,
        NETWORK_MAX = 0x00001Bff,

        JAVA_MIN = 0x00001C00,
        JAVA_PERMISSIONS = 0x00001C00,
        JAVA_CURR_MAX = 0x00001C00,
        JAVA_MAX = 0x00001Cff,

        // The following Infodelivery actions should have no default policies
        // in the registry.  They assume that no default policy means fall
        // back to the global restriction.  If an admin sets a policy per
        // zone, then it overrides the global restriction.

        INFODELIVERY_MIN = 0x00001D00,
        INFODELIVERY_NO_ADDING_CHANNELS = 0x00001D00,
        INFODELIVERY_NO_EDITING_CHANNELS = 0x00001D01,
        INFODELIVERY_NO_REMOVING_CHANNELS = 0x00001D02,
        INFODELIVERY_NO_ADDING_SUBSCRIPTIONS = 0x00001D03,
        INFODELIVERY_NO_EDITING_SUBSCRIPTIONS = 0x00001D04,
        INFODELIVERY_NO_REMOVING_SUBSCRIPTIONS = 0x00001D05,
        INFODELIVERY_NO_CHANNEL_LOGGING = 0x00001D06,
        INFODELIVERY_CURR_MAX = 0x00001D06,
        INFODELIVERY_MAX = 0x00001Dff,
        CHANNEL_SOFTDIST_MIN = 0x00001E00,
        CHANNEL_SOFTDIST_PERMISSIONS = 0x00001E05,
        CHANNEL_SOFTDIST_MAX = 0x00001Eff
    }

    public enum SZM_FLAGS
    {
        SZM_CREATE = 0,
        SZM_DELETE = 0x1
    }

    public enum tagURLZONE
    {
        URLZONE_PREDEFINED_MIN = 0,
        URLZONE_LOCAL_MACHINE = 0,
        URLZONE_INTRANET = URLZONE_LOCAL_MACHINE + 1,
        URLZONE_TRUSTED = URLZONE_INTRANET + 1,
        URLZONE_INTERNET = URLZONE_TRUSTED + 1,
        URLZONE_UNTRUSTED = URLZONE_INTERNET + 1,
        URLZONE_PREDEFINED_MAX = 999,
        URLZONE_USER_MIN = 1000,
        URLZONE_USER_MAX = 10000,
        URLZONE_ESC_FLAG = 0x100
    }

    public enum _URLZONEREG
    {
        URLZONEREG_DEFAULT = 0,
        URLZONEREG_HKLM = URLZONEREG_DEFAULT + 1,
        URLZONEREG_HKCU = URLZONEREG_HKLM + 1
    }

    public enum tagDVASPECT
    {
        DVASPECT_CONTENT = 1,
        DVASPECT_THUMBNAIL = 2,
        DVASPECT_ICON = 4,
        DVASPECT_DOCPRINT = 8
    }

    public enum TernaryRasterOperations
    {
        SRCCOPY = unchecked((int)0x00CC0020), /* dest = source*/
        SRCPAINT = unchecked((int)0x00EE0086), /* dest = source OR dest*/
        SRCAND = unchecked((int)0x008800C6), /* dest = source AND dest*/
        SRCINVERT = unchecked((int)0x00660046), /* dest = source XOR dest*/
        SRCERASE = unchecked((int)0x00440328), /* dest = source AND (NOT dest )*/
        NOTSRCCOPY = unchecked((int)0x00330008), /* dest = (NOT source)*/
        NOTSRCERASE = unchecked((int)0x001100A6), /* dest = (NOT src) AND (NOT dest) */
        MERGECOPY = unchecked((int)0x00C000CA), /* dest = (source AND pattern)*/
        MERGEPAINT = unchecked((int)0x00BB0226), /* dest = (NOT source) OR dest*/
        PATCOPY = unchecked((int)0x00F00021), /* dest = pattern*/
        PATPAINT = unchecked((int)0x00FB0A09), /* dest = DPSnoo*/
        PATINVERT = unchecked((int)0x005A0049), /* dest = pattern XOR dest*/
        DSTINVERT = unchecked((int)0x00550009), /* dest = (NOT dest)*/
        BLACKNESS = unchecked((int)0x00000042), /* dest = BLACK*/
        WHITENESS = unchecked((int)0x00FF0062) /* dest = WHITE*/
    }

    public enum StretchMode
    {
        STRETCH_ANDSCANS = 1,
        STRETCH_ORSCANS = 2,
        STRETCH_DELETESCANS = 3,
        STRETCH_HALFTONE = 4
    }

    public enum ScriptErrorAction
    {
        DisplayAll = 0,
        DispalyNone_ContinueRunningScripts = 1,
        DisplayNone_StopRunningScripts = 2
    }

    public enum tagOLECONTF
    {
        OLECONTF_EMBEDDINGS = 1,
        OLECONTF_LINKS = 2,
        OLECONTF_OTHERS = 4,
        OLECONTF_ONLYUSER = 8,
        OLECONTF_ONLYIFRUNNING = 16
    }

    public enum HTMLEventType
    {
        HTMLEventNone = 0,
        HTMLDocumentEvent = 1,
        HTMLWindowEvent = 2,
        HTMLElementEvent = 3
    }

    public enum HTMLEventDispIds : int
    {
        ID_ONMOUSEOVER = unchecked((int)(0x80010000 + 8)),
        ID_ONMOUSEOUT = unchecked((int)(0x80010000 + 9)),
        ID_ONMOUSEDOWN = (-605),
        ID_ONMOUSEUP = (-607),
        ID_ONMOUSEMOVE = (-606),
        ID_ONKEYDOWN = (-602),
        ID_ONKEYUP = (-604),
        ID_ONKEYPRESS = (-603),
        ID_ONCLICK = (-600),
        ID_ONDBLCLICK = (-601),
        ID_ONSELECT = (1006), //DISPID_NORMAL_FIRST = 1000 + 6 
        ID_ONSUBMIT = (1007),
        ID_ONRESET = (1015),
        ID_ONHELP = unchecked((int)(0x80010000 + 10)),
        ID_ONFOCUS = unchecked((int)(0x80010000 + 1)),
        ID_ONBLUR = unchecked((int)(0x80010000)),
        ID_ONROWEXIT = unchecked((int)(0x80010000 + 6)),
        ID_ONROWENTER = unchecked((int)(0x80010000 + 7)),
        ID_ONBOUNCE = unchecked((int)(0x80010000 + 9)),
        ID_ONBEFOREUPDATE = unchecked((int)(0x80010000 + 4)),
        ID_ONAFTERUPDATE = unchecked((int)(0x80010000 + 5)),
        //ID_ONBEFOREDRAGOVER      = EVENTID_CommonCtrlEvent_BeforeDragOver,
        //ID_ONBEFOREDROPORPASTE   = EVENTID_CommonCtrlEvent_BeforeDropOrPaste,
        ID_ONREADYSTATECHANGE = (-609),
        ID_ONFINISH = (1010),
        ID_ONSTART = (1011),
        ID_ONABORT = (1000),
        ID_ONERROR = (1002),
        ID_ONCHANGE = (1001),
        ID_ONSCROLL = (1014),
        ID_ONLOAD = (1003),
        ID_ONUNLOAD = (1008),
        ID_ONLAYOUT = (1013),
        ID_ONDRAGSTART = unchecked((int)(0x80010000 + 11)),
        ID_ONRESIZE = (1016),
        ID_ONSELECTSTART = unchecked((int)(0x80010000 + 12)),
        ID_ONERRORUPDATE = unchecked((int)(0x80010000 + 13)),
        ID_ONBEFOREUNLOAD = (1017),
        ID_ONDATASETCHANGED = unchecked((int)(0x80010000 + 14)),
        ID_ONDATAAVAILABLE = unchecked((int)(0x80010000 + 15)),
        ID_ONDATASETCOMPLETE = unchecked((int)(0x80010000 + 16)),
        ID_ONFILTER = unchecked((int)(0x80010000 + 17)),
        ID_ONCHANGEFOCUS = (1018),
        ID_ONCHANGEBLUR = (1019),
        ID_ONLOSECAPTURE = unchecked((int)(0x80010000 + 18)),
        ID_ONPROPERTYCHANGE = unchecked((int)(0x80010000 + 19)),
        ID_ONPERSISTSAVE = (1021),
        ID_ONDRAG = unchecked((int)(0x80010000 + 20)),
        ID_ONDRAGEND = unchecked((int)(0x80010000 + 21)),
        ID_ONDRAGENTER = unchecked((int)(0x80010000 + 22)),
        ID_ONDRAGOVER = unchecked((int)(0x80010000 + 23)),
        ID_ONDRAGLEAVE = unchecked((int)(0x80010000 + 24)),
        ID_ONDROP = unchecked((int)(0x80010000 + 25)),
        ID_ONCUT = unchecked((int)(0x80010000 + 26)),
        ID_ONCOPY = unchecked((int)(0x80010000 + 27)),
        ID_ONPASTE = unchecked((int)(0x80010000 + 28)),
        ID_ONBEFORECUT = unchecked((int)(0x80010000 + 29)),
        ID_ONBEFORECOPY = unchecked((int)(0x80010000 + 30)),
        ID_ONBEFOREPASTE = unchecked((int)(0x80010000 + 31)),
        ID_ONPERSISTLOAD = (1022),
        ID_ONROWSDELETE = unchecked((int)(0x80010000 + 32)),
        ID_ONROWSINSERTED = unchecked((int)(0x80010000 + 33)),
        ID_ONCELLCHANGE = unchecked((int)(0x80010000 + 34)),
        ID_ONCONTEXTMENU = (1023),
        ID_ONBEFOREPRINT = (1024),
        ID_ONAFTERPRINT = (1025),
        ID_ONSTOP = (1026),
        ID_ONBEFOREEDITFOCUS = (1027),
        ID_ONMOUSEHOVER = (1028),
        ID_ONCONTENTREADY = (1029),
        ID_ONLAYOUTCOMPLETE = (1030),
        ID_ONPAGE = (1031),
        ID_ONLINKEDOVERFLOW = (1032),
        ID_ONMOUSEWHEEL = (1033),
        ID_ONBEFOREDEACTIVATE = (1034),
        ID_ONMOVE = (1035),
        ID_ONCONTROLSELECT = (1036),
        ID_ONSELECTIONCHANGE = (1037),
        ID_ONMOVESTART = (1038),
        ID_ONMOVEEND = (1039),
        ID_ONRESIZESTART = (1040),
        ID_ONRESIZEEND = (1041),
        ID_ONMOUSEENTER = (1042),
        ID_ONMOUSELEAVE = (1043),
        ID_ONACTIVATE = (1044),
        ID_ONDEACTIVATE = (1045),
        ID_ONMULTILAYOUTCLEANUP = (1046),
        ID_ONBEFOREACTIVATE = (1047),
        ID_ONFOCUSIN = (1048),
        ID_ONFOCUSOUT = (1049),
        ID_HTMLOBJECTELEMENTEVENTS2_ONERROR = unchecked((int)(0x80010000 + 19)),
        ID_HTMLOBJECTELEMENTEVENTS2_ONREADYSTATECHANGE = unchecked((int)(0x80010000 + 20)),
        ID_IME_EVENT = 0
    }

    // Input flags for IUniformResourceLocator::SetURL().
    public enum iurl_seturl_flags : uint
    {
        IURL_SETURL_FL_GUESS_PROTOCOL = 0x0001,     // Guess protocol if missing
        IURL_SETURL_FL_USE_DEFAULT_PROTOCOL = 0x0002     // Use default protocol if missing
    }

    public enum SLGP_FLAGS : uint
    {
        SLGP_SHORTPATH = 0x1,
        SLGP_UNCPRIORITY = 0x2,
        SLGP_RAWPATH = 0x4
    }

    public enum SLR_FLAGS : uint
    {
        SLR_NO_UI = 0x1,
        SLR_ANY_MATCH = 0x2,
        SLR_UPDATE = 0x4,
        SLR_NOUPDATE = 0x8,
        SLR_NOSEARCH = 0x10,
        SLR_NOTRACK = 0x20,
        SLR_NOLINKINFO = 0x40,
        SLR_INVOKE_MSI = 0x80,
        SLR_NO_UI_WITH_MSG_PUMP = 0x101
    }

    public enum MSHTML_COMMAND_IDS
    {
        IDM_UNKNOWN = 0,
        IDM_ALIGNBOTTOM = 1,
        IDM_ALIGNHORIZONTALCENTERS = 2,
        IDM_ALIGNLEFT = 3,
        IDM_ALIGNRIGHT = 4,
        IDM_ALIGNTOGRID = 5,
        IDM_ALIGNTOP = 6,
        IDM_ALIGNVERTICALCENTERS = 7,
        IDM_ARRANGEBOTTOM = 8,
        IDM_ARRANGERIGHT = 9,
        IDM_BRINGFORWARD = 10,
        IDM_BRINGTOFRONT = 11,
        IDM_CENTERHORIZONTALLY = 12,
        IDM_CENTERVERTICALLY = 13,
        IDM_CODE = 14,
        IDM_DELETE = 17,
        IDM_FONTNAME = 18,
        IDM_FONTSIZE = 19,
        IDM_GROUP = 20,
        IDM_HORIZSPACECONCATENATE = 21,
        IDM_HORIZSPACEDECREASE = 22,
        IDM_HORIZSPACEINCREASE = 23,
        IDM_HORIZSPACEMAKEEQUAL = 24,
        IDM_INSERTOBJECT = 25,
        IDM_MULTILEVELREDO = 30,
        IDM_SENDBACKWARD = 32,
        IDM_SENDTOBACK = 33,
        IDM_SHOWTABLE = 34,
        IDM_SIZETOCONTROL = 35,
        IDM_SIZETOCONTROLHEIGHT = 36,
        IDM_SIZETOCONTROLWIDTH = 37,
        IDM_SIZETOFIT = 38,
        IDM_SIZETOGRID = 39,
        IDM_SNAPTOGRID = 40,
        IDM_TABORDER = 41,
        IDM_TOOLBOX = 42,
        IDM_MULTILEVELUNDO = 44,
        IDM_UNGROUP = 45,
        IDM_VERTSPACECONCATENATE = 46,
        IDM_VERTSPACEDECREASE = 47,
        IDM_VERTSPACEINCREASE = 48,
        IDM_VERTSPACEMAKEEQUAL = 49,
        IDM_JUSTIFYFULL = 50,
        IDM_BACKCOLOR = 51,
        IDM_BOLD = 52,
        IDM_BORDERCOLOR = 53,
        IDM_FLAT = 54,
        IDM_FORECOLOR = 55,
        IDM_ITALIC = 56,
        IDM_JUSTIFYCENTER = 57,
        IDM_JUSTIFYGENERAL = 58,
        IDM_JUSTIFYLEFT = 59,
        IDM_JUSTIFYRIGHT = 60,
        IDM_RAISED = 61,
        IDM_SUNKEN = 62,
        IDM_UNDERLINE = 63,
        IDM_CHISELED = 64,
        IDM_ETCHED = 65,
        IDM_SHADOWED = 66,
        IDM_FIND = 67,
        IDM_SHOWGRID = 69,
        IDM_OBJECTVERBLIST0 = 72,
        IDM_OBJECTVERBLIST1 = 73,
        IDM_OBJECTVERBLIST2 = 74,
        IDM_OBJECTVERBLIST3 = 75,
        IDM_OBJECTVERBLIST4 = 76,
        IDM_OBJECTVERBLIST5 = 77,
        IDM_OBJECTVERBLIST6 = 78,
        IDM_OBJECTVERBLIST7 = 79,
        IDM_OBJECTVERBLIST8 = 80,
        IDM_OBJECTVERBLIST9 = 81,
        IDM_OBJECTVERBLISTLAST = IDM_OBJECTVERBLIST9,
        IDM_CONVERTOBJECT = 82,
        IDM_CUSTOMCONTROL = 83,
        IDM_CUSTOMIZEITEM = 84,
        IDM_RENAME = 85,
        IDM_IMPORT = 86,
        IDM_NEWPAGE = 87,
        IDM_MOVE = 88,
        IDM_CANCEL = 89,
        IDM_FONT = 90,
        IDM_STRIKETHROUGH = 91,
        IDM_DELETEWORD = 92,
        IDM_EXECPRINT = 93,
        IDM_JUSTIFYNONE = 94,
        IDM_TRISTATEBOLD = 95,
        IDM_TRISTATEITALIC = 96,
        IDM_TRISTATEUNDERLINE = 97,
        IDM_FOLLOW_ANCHOR = 2008,
        IDM_INSINPUTIMAGE = 2114,
        IDM_INSINPUTBUTTON = 2115,
        IDM_INSINPUTRESET = 2116,
        IDM_INSINPUTSUBMIT = 2117,
        IDM_INSINPUTUPLOAD = 2118,
        IDM_INSFIELDSET = 2119,
        IDM_PASTEINSERT = 2120,
        IDM_REPLACE = 2121,
        IDM_EDITSOURCE = 2122,
        IDM_BOOKMARK = 2123,
        IDM_HYPERLINK = 2124,
        IDM_UNLINK = 2125,
        IDM_BROWSEMODE = 2126,
        IDM_EDITMODE = 2127,
        IDM_UNBOOKMARK = 2128,
        IDM_TOOLBARS = 2130,
        IDM_STATUSBAR = 2131,
        IDM_FORMATMARK = 2132,
        IDM_TEXTONLY = 2133,
        IDM_OPTIONS = 2135,
        IDM_FOLLOWLINKC = 2136,
        IDM_FOLLOWLINKN = 2137,
        IDM_VIEWSOURCE = 2139,
        IDM_ZOOMPOPUP = 2140,
        IDM_BASELINEFONT1 = 2141,
        IDM_BASELINEFONT2 = 2142,
        IDM_BASELINEFONT3 = 2143,
        IDM_BASELINEFONT4 = 2144,
        IDM_BASELINEFONT5 = 2145,
        IDM_HORIZONTALLINE = 2150,
        IDM_LINEBREAKNORMAL = 2151,
        IDM_LINEBREAKLEFT = 2152,
        IDM_LINEBREAKRIGHT = 2153,
        IDM_LINEBREAKBOTH = 2154,
        IDM_NONBREAK = 2155,
        IDM_SPECIALCHAR = 2156,
        IDM_HTMLSOURCE = 2157,
        IDM_IFRAME = 2158,
        IDM_HTMLCONTAIN = 2159,
        IDM_TEXTBOX = 2161,
        IDM_TEXTAREA = 2162,
        IDM_CHECKBOX = 2163,
        IDM_RADIOBUTTON = 2164,
        IDM_DROPDOWNBOX = 2165,
        IDM_LISTBOX = 2166,
        IDM_BUTTON = 2167,
        IDM_IMAGE = 2168,
        IDM_OBJECT = 2169,
        IDM_1D = 2170,
        IDM_IMAGEMAP = 2171,
        IDM_FILE = 2172,
        IDM_COMMENT = 2173,
        IDM_SCRIPT = 2174,
        IDM_JAVAAPPLET = 2175,
        IDM_PLUGIN = 2176,
        IDM_PAGEBREAK = 2177,
        IDM_HTMLAREA = 2178,
        IDM_PARAGRAPH = 2180,
        IDM_FORM = 2181,
        IDM_MARQUEE = 2182,
        IDM_LIST = 2183,
        IDM_ORDERLIST = 2184,
        IDM_UNORDERLIST = 2185,
        IDM_INDENT = 2186,
        IDM_OUTDENT = 2187,
        IDM_PREFORMATTED = 2188,
        IDM_ADDRESS = 2189,
        IDM_BLINK = 2190,
        IDM_DIV = 2191,
        IDM_TABLEINSERT = 2200,
        IDM_RCINSERT = 2201,
        IDM_CELLINSERT = 2202,
        IDM_CAPTIONINSERT = 2203,
        IDM_CELLMERGE = 2204,
        IDM_CELLSPLIT = 2205,
        IDM_CELLSELECT = 2206,
        IDM_ROWSELECT = 2207,
        IDM_COLUMNSELECT = 2208,
        IDM_TABLESELECT = 2209,
        IDM_TABLEPROPERTIES = 2210,
        IDM_CELLPROPERTIES = 2211,
        IDM_ROWINSERT = 2212,
        IDM_COLUMNINSERT = 2213,
        IDM_HELP_CONTENT = 2220,
        IDM_HELP_ABOUT = 2221,
        IDM_HELP_README = 2222,
        IDM_REMOVEFORMAT = 2230,
        IDM_PAGEINFO = 2231,
        IDM_TELETYPE = 2232,
        IDM_GETBLOCKFMTS = 2233,
        IDM_BLOCKFMT = 2234,
        IDM_SHOWHIDE_CODE = 2235,
        IDM_TABLE = 2236,
        IDM_COPYFORMAT = 2237,
        IDM_PASTEFORMAT = 2238,
        IDM_GOTO = 2239,
        IDM_CHANGEFONT = 2240,
        IDM_CHANGEFONTSIZE = 2241,
        IDM_CHANGECASE = 2246,
        IDM_SHOWSPECIALCHAR = 2249,
        IDM_SUBSCRIPT = 2247,
        IDM_SUPERSCRIPT = 2248,
        IDM_CENTERALIGNPARA = 2250,
        IDM_LEFTALIGNPARA = 2251,
        IDM_RIGHTALIGNPARA = 2252,
        IDM_REMOVEPARAFORMAT = 2253,
        IDM_APPLYNORMAL = 2254,
        IDM_APPLYHEADING1 = 2255,
        IDM_APPLYHEADING2 = 2256,
        IDM_APPLYHEADING3 = 2257,
        IDM_DOCPROPERTIES = 2260,
        IDM_ADDFAVORITES = 2261,
        IDM_COPYSHORTCUT = 2262,
        IDM_SAVEBACKGROUND = 2263,
        IDM_SETWALLPAPER = 2264,
        IDM_COPYBACKGROUND = 2265,
        IDM_CREATESHORTCUT = 2266,
        IDM_PAGE = 2267,
        IDM_SAVETARGET = 2268,
        IDM_SHOWPICTURE = 2269,
        IDM_SAVEPICTURE = 2270,
        IDM_DYNSRCPLAY = 2271,
        IDM_DYNSRCSTOP = 2272,
        IDM_PRINTTARGET = 2273,
        IDM_IMGARTPLAY = 2274,
        IDM_IMGARTSTOP = 2275,
        IDM_IMGARTREWIND = 2276,
        IDM_PRINTQUERYJOBSPENDING = 2277,
        IDM_SETDESKTOPITEM = 2278,
        IDM_CONTEXTMENU = 2280,
        IDM_GOBACKWARD = 2282,
        IDM_GOFORWARD = 2283,
        IDM_PRESTOP = 2284,
        IDM_MP_MYPICS = 2287,
        IDM_MP_EMAILPICTURE = 2288,
        IDM_MP_PRINTPICTURE = 2289,
        IDM_CREATELINK = 2290,
        IDM_COPYCONTENT = 2291,
        IDM_LANGUAGE = 2292,
        IDM_GETPRINTTEMPLATE = 2295,
        IDM_SETPRINTTEMPLATE = 2296,
        IDM_TEMPLATE_PAGESETUP = 2298,
        IDM_REFRESH = 2300,
        IDM_STOPDOWNLOAD = 2301,
        IDM_ENABLE_INTERACTION = 2302,
        IDM_LAUNCHDEBUGGER = 2310,
        IDM_BREAKATNEXT = 2311,
        IDM_INSINPUTHIDDEN = 2312,
        IDM_INSINPUTPASSWORD = 2313,
        IDM_OVERWRITE = 2314,
        IDM_PARSECOMPLETE = 2315,
        IDM_HTMLEDITMODE = 2316,
        IDM_REGISTRYREFRESH = 2317,
        IDM_COMPOSESETTINGS = 2318,
        IDM_SHOWALLTAGS = 2327,
        IDM_SHOWALIGNEDSITETAGS = 2321,
        IDM_SHOWSCRIPTTAGS = 2322,
        IDM_SHOWSTYLETAGS = 2323,
        IDM_SHOWCOMMENTTAGS = 2324,
        IDM_SHOWAREATAGS = 2325,
        IDM_SHOWUNKNOWNTAGS = 2326,
        IDM_SHOWMISCTAGS = 2320,
        IDM_SHOWZEROBORDERATDESIGNTIME = 2328,
        IDM_AUTODETECT = 2329,
        IDM_SCRIPTDEBUGGER = 2330,
        IDM_GETBYTESDOWNLOADED = 2331,
        IDM_NOACTIVATENORMALOLECONTROLS = 2332,
        IDM_NOACTIVATEDESIGNTIMECONTROLS = 2333,
        IDM_NOACTIVATEJAVAAPPLETS = 2334,
        IDM_NOFIXUPURLSONPASTE = 2335,
        IDM_EMPTYGLYPHTABLE = 2336,
        IDM_ADDTOGLYPHTABLE = 2337,
        IDM_REMOVEFROMGLYPHTABLE = 2338,
        IDM_REPLACEGLYPHCONTENTS = 2339,
        IDM_SHOWWBRTAGS = 2340,
        IDM_PERSISTSTREAMSYNC = 2341,
        IDM_SETDIRTY = 2342,
        IDM_RUNURLSCRIPT = 2343,
        IDM_ZOOMRATIO = 2344,
        IDM_GETZOOMNUMERATOR = 2345,
        IDM_GETZOOMDENOMINATOR = 2346,
        IDM_DIRLTR = 2350,
        IDM_DIRRTL = 2351,
        IDM_BLOCKDIRLTR = 2352,
        IDM_BLOCKDIRRTL = 2353,
        IDM_INLINEDIRLTR = 2354,
        IDM_INLINEDIRRTL = 2355,
        IDM_ISTRUSTEDDLG = 2356,
        IDM_INSERTSPAN = 2357,
        IDM_LOCALIZEEDITOR = 2358,
        IDM_SAVEPRETRANSFORMSOURCE = 2370,
        IDM_VIEWPRETRANSFORMSOURCE = 2371,
        IDM_SCROLL_HERE = 2380,
        IDM_SCROLL_TOP = 2381,
        IDM_SCROLL_BOTTOM = 2382,
        IDM_SCROLL_PAGEUP = 2383,
        IDM_SCROLL_PAGEDOWN = 2384,
        IDM_SCROLL_UP = 2385,
        IDM_SCROLL_DOWN = 2386,
        IDM_SCROLL_LEFTEDGE = 2387,
        IDM_SCROLL_RIGHTEDGE = 2388,
        IDM_SCROLL_PAGELEFT = 2389,
        IDM_SCROLL_PAGERIGHT = 2390,
        IDM_SCROLL_LEFT = 2391,
        IDM_SCROLL_RIGHT = 2392,
        IDM_MULTIPLESELECTION = 2393,
        IDM_2D_POSITION = 2394,
        IDM_2D_ELEMENT = 2395,
        IDM_1D_ELEMENT = 2396,
        IDM_ABSOLUTE_POSITION = 2397,
        IDM_LIVERESIZE = 2398,
        IDM_AUTOURLDETECT_MODE = 2400,
        IDM_IE50_PASTE = 2401,
        IDM_IE50_PASTE_MODE = 2402,
        IDM_GETIPRINT = 2403,
        IDM_DISABLE_EDITFOCUS_UI = 2404,
        IDM_RESPECTVISIBILITY_INDESIGN = 2405,
        IDM_CSSEDITING_LEVEL = 2406,
        IDM_UI_OUTDENT = 2407,
        IDM_UPDATEPAGESTATUS = 2408,
        IDM_UNLOADDOCUMENT = 2411,
        IDM_OVERRIDE_CURSOR = 2420,
        IDM_PEERHITTESTSAMEINEDIT = 2423,
        IDM_TRUSTAPPCACHE = 2425,
        IDM_BACKGROUNDIMAGECACHE = 2430,
        IDM_GETUSERACTIONTIME = 2431,
        IDM_BEGINUSERACTION = 2432,
        IDM_ENDUSERACTION = 2433,
        IDM_SETCUSTOMCURSOR = 2434,
        IDM_DEFAULTBLOCK = 6046,
        IDM_MIMECSET__FIRST__ = 3609,
        IDM_MIMECSET__LAST__ = 3699,
        IDM_MENUEXT_FIRST__ = 3700,
        IDM_MENUEXT_LAST__ = 3732,
        IDM_MENUEXT_COUNT = 3733,
        IDM_OPEN = 2000,
        IDM_NEW = 2001,
        IDM_SAVE = 70,
        IDM_SAVEAS = 71,
        IDM_SAVECOPYAS = 2002,
        IDM_PRINTPREVIEW = 2003,
        IDM_SHOWPRINT = 2010,
        IDM_SHOWPAGESETUP = 2011,
        IDM_PRINT = 27,
        IDM_PAGESETUP = 2004,
        IDM_SPELL = 2005,
        IDM_PASTESPECIAL = 2006,
        IDM_CLEARSELECTION = 2007,
        IDM_PROPERTIES = 28,
        IDM_REDO = 29,
        IDM_UNDO = 43,
        IDM_SELECTALL = 31,
        IDM_ZOOMPERCENT = 50,
        IDM_GETZOOM = 68,
        IDM_STOP = 2138,
        IDM_COPY = 15,
        IDM_CUT = 16,
        IDM_PASTE = 26,
        CMD_ZOOM_PAGEWIDTH = -1,
        CMD_ZOOM_ONEPAGE = -2,
        CMD_ZOOM_TWOPAGES = -3,
        CMD_ZOOM_SELECTION = -4,
        CMD_ZOOM_FIT = -5,
        IDM_CONTEXT = 1,
        IDM_HWND = 2,
        IDM_NEW_TOPLEVELWINDOW = 7050,
        IDM_PRESERVEUNDOALWAYS = 6049,
        IDM_PERSISTDEFAULTVALUES = 7100,
        IDM_PROTECTMETATAGS = 7101,
        IDM_GETFRAMEZONE = 6037,
        IDM_FIRE_PRINTTEMPLATEUP = 15000,
        IDM_FIRE_PRINTTEMPLATEDOWN = 15001,
        IDM_SETPRINTHANDLES = 15002,
        IDM_GETUSERINITFLAGS = 15004,
        IDM_GETDOCDLGFLAGS = 15005
    }

    #region HTML Edit Services
    public enum SELECTION_TYPE
    {
        SELECTION_TYPE_None = 0,
        SELECTION_TYPE_Caret = 1,
        SELECTION_TYPE_Text = 2,
        SELECTION_TYPE_Control = 3,
        SELECTION_TYPE_Max = 2147483647
    }

    public enum POINTER_GRAVITY
    {
        POINTER_GRAVITY_Left = 0,
        POINTER_GRAVITY_Right = 1,
        POINTER_GRAVITY_Max = 2147483647
    }

    public enum MARKUP_CONTEXT_TYPE
    {
        CONTEXT_TYPE_None = 0,
        CONTEXT_TYPE_Text = 1,
        CONTEXT_TYPE_EnterScope = 2,
        CONTEXT_TYPE_ExitScope = 3,
        CONTEXT_TYPE_NoScope = 4,
        MARKUP_CONTEXT_TYPE_Max = 2147483647
    }

    public enum MOVEUNIT_ACTION
    {
        MOVEUNIT_PREVCHAR = 0,
        MOVEUNIT_NEXTCHAR = 1,
        MOVEUNIT_PREVCLUSTERBEGIN = 2,
        MOVEUNIT_NEXTCLUSTERBEGIN = 3,
        MOVEUNIT_PREVCLUSTEREND = 4,
        MOVEUNIT_NEXTCLUSTEREND = 5,
        MOVEUNIT_PREVWORDBEGIN = 6,
        MOVEUNIT_NEXTWORDBEGIN = 7,
        MOVEUNIT_PREVWORDEND = 8,
        MOVEUNIT_NEXTWORDEND = 9,
        MOVEUNIT_PREVPROOFWORD = 10,
        MOVEUNIT_NEXTPROOFWORD = 11,
        MOVEUNIT_NEXTURLBEGIN = 12,
        MOVEUNIT_PREVURLBEGIN = 13,
        MOVEUNIT_NEXTURLEND = 14,
        MOVEUNIT_PREVURLEND = 15,
        MOVEUNIT_PREVSENTENCE = 16,
        MOVEUNIT_NEXTSENTENCE = 17,
        MOVEUNIT_PREVBLOCK = 18,
        MOVEUNIT_NEXTBLOCK = 19,
        MOVEUNIT_ACTION_Max = 2147483647
    }

    public enum ELEMENT_ADJACENCY
    {
        ELEM_ADJ_BeforeBegin = 0,
        ELEM_ADJ_AfterBegin = 1,
        ELEM_ADJ_BeforeEnd = 2,
        ELEM_ADJ_AfterEnd = 3,
        ELEMENT_ADJACENCY_Max = 2147483647
    }

    public enum ELEMENT_CORNER
    {
        ELEMENT_CORNER_NONE = 0,
        ELEMENT_CORNER_TOP = 1,
        ELEMENT_CORNER_LEFT = 2,
        ELEMENT_CORNER_BOTTOM = 3,
        ELEMENT_CORNER_RIGHT = 4,
        ELEMENT_CORNER_TOPLEFT = 5,
        ELEMENT_CORNER_TOPRIGHT = 6,
        ELEMENT_CORNER_BOTTOMLEFT = 7,
        ELEMENT_CORNER_BOTTOMRIGHT = 8,
        ELEMENT_CORNER_Max = 2147483647
    };

    public enum SECUREURLHOSTVALIDATE_FLAGS
    {
        SUHV_PROMPTBEFORENO = 0x00000001,
        SUHV_SILENTYES = 0x00000002,
        SUHV_UNSECURESOURCE = 0x00000004,
        SECUREURLHOSTVALIDATE_FLAGS_Max = 2147483647
    };

    public enum FINDTEXT_FLAGS
    {
        FINDTEXT_BACKWARDS = 0x00000001,
        FINDTEXT_WHOLEWORD = 0x00000002,
        FINDTEXT_MATCHCASE = 0x00000004,
        FINDTEXT_RAW = 0x00020000,
        FINDTEXT_MATCHDIAC = 0x20000000,
        FINDTEXT_MATCHKASHIDA = 0x40000000,
        FINDTEXT_MATCHALEFHAMZA = unchecked((int)0x80000000),
        FINDTEXT_FLAGS_Max = 2147483647
    };

    public enum PARSE_FLAGS
    {
        PARSE_ABSOLUTIFYIE40URLS = 0x00000001,
        PARSE_FLAGS_Max = 2147483647
    };

    public enum ELEMENT_TAG_ID
    {
        TAGID_NULL = 0,
        TAGID_UNKNOWN = 1,
        TAGID_A = 2,
        TAGID_ACRONYM = 3,
        TAGID_ADDRESS = 4,
        TAGID_APPLET = 5,
        TAGID_AREA = 6,
        TAGID_B = 7,
        TAGID_BASE = 8,
        TAGID_BASEFONT = 9,
        TAGID_BDO = 10,
        TAGID_BGSOUND = 11,
        TAGID_BIG = 12,
        TAGID_BLINK = 13,
        TAGID_BLOCKQUOTE = 14,
        TAGID_BODY = 15,
        TAGID_BR = 16,
        TAGID_BUTTON = 17,
        TAGID_CAPTION = 18,
        TAGID_CENTER = 19,
        TAGID_CITE = 20,
        TAGID_CODE = 21,
        TAGID_COL = 22,
        TAGID_COLGROUP = 23,
        TAGID_COMMENT = 24,
        TAGID_COMMENT_RAW = 25,
        TAGID_DD = 26,
        TAGID_DEL = 27,
        TAGID_DFN = 28,
        TAGID_DIR = 29,
        TAGID_DIV = 30,
        TAGID_DL = 31,
        TAGID_DT = 32,
        TAGID_EM = 33,
        TAGID_EMBED = 34,
        TAGID_FIELDSET = 35,
        TAGID_FONT = 36,
        TAGID_FORM = 37,
        TAGID_FRAME = 38,
        TAGID_FRAMESET = 39,
        TAGID_GENERIC = 40,
        TAGID_H1 = 41,
        TAGID_H2 = 42,
        TAGID_H3 = 43,
        TAGID_H4 = 44,
        TAGID_H5 = 45,
        TAGID_H6 = 46,
        TAGID_HEAD = 47,
        TAGID_HR = 48,
        TAGID_HTML = 49,
        TAGID_I = 50,
        TAGID_IFRAME = 51,
        TAGID_IMG = 52,
        TAGID_INPUT = 53,
        TAGID_INS = 54,
        TAGID_KBD = 55,
        TAGID_LABEL = 56,
        TAGID_LEGEND = 57,
        TAGID_LI = 58,
        TAGID_LINK = 59,
        TAGID_LISTING = 60,
        TAGID_MAP = 61,
        TAGID_MARQUEE = 62,
        TAGID_MENU = 63,
        TAGID_META = 64,
        TAGID_NEXTID = 65,
        TAGID_NOBR = 66,
        TAGID_NOEMBED = 67,
        TAGID_NOFRAMES = 68,
        TAGID_NOSCRIPT = 69,
        TAGID_OBJECT = 70,
        TAGID_OL = 71,
        TAGID_OPTION = 72,
        TAGID_P = 73,
        TAGID_PARAM = 74,
        TAGID_PLAINTEXT = 75,
        TAGID_PRE = 76,
        TAGID_Q = 77,
        TAGID_RP = 78,
        TAGID_RT = 79,
        TAGID_RUBY = 80,
        TAGID_S = 81,
        TAGID_SAMP = 82,
        TAGID_SCRIPT = 83,
        TAGID_SELECT = 84,
        TAGID_SMALL = 85,
        TAGID_SPAN = 86,
        TAGID_STRIKE = 87,
        TAGID_STRONG = 88,
        TAGID_STYLE = 89,
        TAGID_SUB = 90,
        TAGID_SUP = 91,
        TAGID_TABLE = 92,
        TAGID_TBODY = 93,
        TAGID_TC = 94,
        TAGID_TD = 95,
        TAGID_TEXTAREA = 96,
        TAGID_TFOOT = 97,
        TAGID_TH = 98,
        TAGID_THEAD = 99,
        TAGID_TITLE = 100,
        TAGID_TR = 101,
        TAGID_TT = 102,
        TAGID_U = 103,
        TAGID_UL = 104,
        TAGID_VAR = 105,
        TAGID_WBR = 106,
        TAGID_XMP = 107,
        TAGID_ROOT = 108,
        TAGID_OPTGROUP = 109,
        TAGID_COUNT = 110,
        TAGID_LAST_PREDEFINED = 10000,
        ELEMENT_TAG_ID_Max = 2147483647
    };

    public enum SAVE_SEGMENTS_FLAGS
    {
        SAVE_SEGMENTS_NoIE4SelectionCompat = 0x0001,
        SAVE_SEGMENTS_FLAGS_Max = 2147483647
    };

    public enum CARET_DIRECTION
    {
        CARET_DIRECTION_INDETERMINATE = 0,
        CARET_DIRECTION_SAME = 1,
        CARET_DIRECTION_BACKWARD = 2,
        CARET_DIRECTION_FORWARD = 3,
        CARET_DIRECTION_Max = 2147483647
    };

    public enum LINE_DIRECTION
    {
        LINE_DIRECTION_RightToLeft = 1,
        LINE_DIRECTION_LeftToRight = 2,
        LINE_DIRECTION_Max = 2147483647
    };

    public enum HT_OPTIONS
    {
        HT_OPT_AllowAfterEOL = 0x1,
        HT_OPTIONS_Max = 2147483647
    };

    public enum HT_RESULTS
    {
        HT_RESULTS_Glyph = 0x1,
        HT_RESULTS_Max = 2147483647
    };

    public enum DISPLAY_MOVEUNIT
    {
        DISPLAY_MOVEUNIT_PreviousLine = 1,
        DISPLAY_MOVEUNIT_NextLine = 2,
        DISPLAY_MOVEUNIT_CurrentLineStart = 3,
        DISPLAY_MOVEUNIT_CurrentLineEnd = 4,
        DISPLAY_MOVEUNIT_TopOfWindow = 5,
        DISPLAY_MOVEUNIT_BottomOfWindow = 6,
        DISPLAY_MOVEUNIT_Max = 2147483647
    };

    public enum DISPLAY_GRAVITY
    {
        DISPLAY_GRAVITY_PreviousLine = 1,
        DISPLAY_GRAVITY_NextLine = 2,
        DISPLAY_GRAVITY_Max = 2147483647
    };

    public enum DISPLAY_BREAK
    {
        DISPLAY_BREAK_None = 0x0,
        DISPLAY_BREAK_Block = 0x1,
        DISPLAY_BREAK_Break = 0x2,
        DISPLAY_BREAK_Max = 2147483647
    };

    public enum COORD_SYSTEM
    {
        COORD_SYSTEM_GLOBAL = 0,
        COORD_SYSTEM_PARENT = 1,
        COORD_SYSTEM_CONTAINER = 2,
        COORD_SYSTEM_CONTENT = 3,
        COORD_SYSTEM_FRAME = 4,
        COORD_SYSTEM_Max = 2147483647
    }; 
    #endregion

    public enum HTML_PAINTER
    {
        HTMLPAINTER_OPAQUE = 0x000001,
        HTMLPAINTER_TRANSPARENT = 0x000002,
        HTMLPAINTER_ALPHA = 0x000004,
        HTMLPAINTER_COMPLEX = 0x000008,
        HTMLPAINTER_OVERLAY = 0x000010,
        HTMLPAINTER_HITTEST = 0x000020,
        HTMLPAINTER_SURFACE = 0x000100,
        HTMLPAINTER_3DSURFACE = 0x000200,
        HTMLPAINTER_NOBAND = 0x000400,
        HTMLPAINTER_NODC = 0x001000,
        HTMLPAINTER_NOPHYSICALCLIP = 0x002000,
        HTMLPAINTER_NOSAVEDC = 0x004000,
        HTMLPAINTER_SUPPORTS_XFORM = 0x008000,
        HTMLPAINTER_EXPAND = 0x010000,
        HTMLPAINTER_NOSCROLLBITS = 0x020000,
        HTML_PAINTER_Max = 2147483647
    }

    public enum HTML_PAINT_ZORDER
    {
        HTMLPAINT_ZORDER_NONE = 0,
        HTMLPAINT_ZORDER_REPLACE_ALL = 1,
        HTMLPAINT_ZORDER_REPLACE_CONTENT = 2,
        HTMLPAINT_ZORDER_REPLACE_BACKGROUND = 3,
        HTMLPAINT_ZORDER_BELOW_CONTENT = 4,
        HTMLPAINT_ZORDER_BELOW_FLOW = 5,
        HTMLPAINT_ZORDER_ABOVE_FLOW = 6,
        HTMLPAINT_ZORDER_ABOVE_CONTENT = 7,
        HTMLPAINT_ZORDER_WINDOW_TOP = 8,
        HTML_PAINT_ZORDER_Max = 2147483647
    }

    public enum HTML_PAINT_DRAW_FLAGS
    {
        HTMLPAINT_DRAW_UPDATEREGION = 0x000001,
        HTMLPAINT_DRAW_USE_XFORM = 0x000002,
        HTML_PAINT_DRAW_FLAGS_Max = 2147483647
    }

    public enum HTML_PAINT_EVENT_FLAGS
    {
        HTMLPAINT_EVENT_TARGET = 0x0001,
        HTMLPAINT_EVENT_SETCURSOR = 0x0002,
        HTML_PAINT_EVENT_FLAGS_Max = 2147483647
    }

    public enum HTML_PAINT_DRAW_INFO_FLAGS
    {
        HTMLPAINT_DRAWINFO_VIEWPORT = 0x000001,
        HTMLPAINT_DRAWINFO_UPDATEREGION = 0x000002,
        HTMLPAINT_DRAWINFO_XFORM = 0x000004,
        HTML_PAINT_DRAW_INFO_FLAGS_Max = 2147483647
    }

    #endregion

}