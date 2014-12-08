using System;
using System.Text;
using System.Runtime.InteropServices;

namespace IfacesEnumsStructsClasses
{
    public struct HTML_PAINT_XFORM
    {
        public Single eM11;
        public Single eM12;
        public Single eM21;
        public Single eM22;
        public Single eDx;
        public Single eDy;
    }

    public struct HTML_PAINT_DRAW_INFO
    {
        public tagRECT rcViewport;
        public UInt32 hrgnUpdate;
        public HTML_PAINT_XFORM xform;
    }

    public struct HTML_PAINTER_INFO
    {
        public int lFlags;
        public int lZOrder;
        public int iidDrawObject;
        public tagRECT rcExpand;
    }

    /// <summary>
    /// Used to handle Travel log entries
    /// </summary>
    public struct TravelLogStruct
    {
        public string URL;
        public string Title;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct URLINVOKECOMMANDINFOA
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwcbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwFlags;
        public IntPtr hwndParent;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pcszVerb;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct URLINVOKECOMMANDINFOW
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwcbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwFlags;
        public IntPtr hwndParent;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pcszVerb;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct STATURL
    {
        public uint cbSize;
        
        /// <summary>
        /// The specified URL.The calling function must free this parameter.
        /// Set this parameter to STATURL_QUERYFLAG_NOURL if no URL is specified.
        /// </summary>
        public IntPtr pwcsUrl;
        /// <summary>
        /// The title of the Web page, as contained in the title tags.
        /// This calling application must free this parameter.
        /// Set this parameter to STATURL_QUERYFLAG_NOTITLE if no Web page is specified.
        /// </summary>
        public IntPtr pwcsTitle;
        public FILETIME ftLastVisited;
        public FILETIME ftLastUpdated;
        public FILETIME ftExpires;
        public uint dwFlags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATAA
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
        public StringBuilder cFileName;
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 14)]
        public StringBuilder cAlternateFileName;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATAW
    {
        public uint dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.LPWStr, SizeConst = 260)]
        public StringBuilder cFileName;
        [MarshalAs(UnmanagedType.LPWStr, SizeConst = 14)]
        public StringBuilder cAlternateFileName;
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagDVASPECTINFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 cb;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwFlags;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DVTARGETDEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 tdSize;
        [MarshalAs(UnmanagedType.U2)]
        public short tdDriverNameOffset;
        [MarshalAs(UnmanagedType.U2)]
        public short tdDeviceNameOffset;
        [MarshalAs(UnmanagedType.U2)]
        public short tdPortNameOffset;
        [MarshalAs(UnmanagedType.U2)]
        public short tdExtDevmodeOffset;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
        public byte[] tdData;
    }

    public struct tagPALETTEENTRY
    {
        public byte peRed;
        public byte peGreen;
        public byte peBlue;
        public byte peFlags;
    }

    public struct tagLOGPALETTE
    {
        [MarshalAs(UnmanagedType.U2)]
        public short palVersion;
        [MarshalAs(UnmanagedType.U2)]
        public short palNumEntries;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
        public tagPALETTEENTRY[] palPalEntry;
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagPOINT
    {
        [MarshalAs(UnmanagedType.I4)]
        public int X;
        [MarshalAs(UnmanagedType.I4)]
        public int Y;

        //public tagPOINT(int x, int y)
        //{
        //    this.X = x;
        //    this.Y = y;
        //}

        //public static implicit operator System.Drawing.Point(tagPOINT p)
        //{
        //    return new System.Drawing.Point(p.X, p.Y);
        //}

        //public static implicit operator tagPOINT(System.Drawing.Point p)
        //{
        //    return new tagPOINT(p.X, p.Y);
        //}
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagSIZE
    {
        [MarshalAs(UnmanagedType.I4)]
        public int cx;
        [MarshalAs(UnmanagedType.I4)]
        public int cy;
        //public tagSIZE(int cx, int cy)
        //{
        //    this.cx = cx;
        //    this.cy = cy;
        //}
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagSIZEL
    {
        [MarshalAs(UnmanagedType.I4)]
        public int cx;
        [MarshalAs(UnmanagedType.I4)]
        public int cy;
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagRECT
    {
        [MarshalAs(UnmanagedType.I4)]
        public int Left;
        [MarshalAs(UnmanagedType.I4)]
        public int Top;
        [MarshalAs(UnmanagedType.I4)]
        public int Right;
        [MarshalAs(UnmanagedType.I4)]
        public int Bottom;

        public tagRECT(int left_, int top_, int right_, int bottom_)
        {
            Left = left_;
            Top = top_;
            Right = right_;
            Bottom = bottom_;
        }

        //public int Height { get { return Bottom - Top + 1; } }
        //public int Width { get { return Right - Left + 1; } }
        //public tagSIZE Size { get { return new tagSIZE(Width, Height); } }
        //public tagPOINT Location { get { return new tagPOINT(Left, Top); } }

        //// Handy method for converting to a System.Drawing.Rectangle
        //public System.Drawing.Rectangle ToRectangle()
        //{ return System.Drawing.Rectangle.FromLTRB(Left, Top, Right, Bottom); }

        //public static tagRECT FromRectangle(System.Drawing.Rectangle rectangle)
        //{
        //    return new tagRECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        //}

        //public override int GetHashCode()
        //{
        //    return Left ^ ((Top << 13) | (Top >> 0x13))
        //      ^ ((Width << 0x1a) | (Width >> 6))
        //      ^ ((Height << 7) | (Height >> 0x19));
        //}

        //#region Operator overloads

        //public static implicit operator System.Drawing.Rectangle(tagRECT rect)
        //{
        //    return System.Drawing.Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        //}

        //public static implicit operator tagRECT(System.Drawing.Rectangle rect)
        //{
        //    return new tagRECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
        //}

        //#endregion
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagMSG
    {
        public IntPtr hwnd;
        [MarshalAs(UnmanagedType.I4)]
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        [MarshalAs(UnmanagedType.I4)]
        public int time;
        // pt was a by-value POINT structure
        [MarshalAs(UnmanagedType.I4)]
        public int pt_x;
        [MarshalAs(UnmanagedType.I4)]
        public int pt_y;
        //public tagPOINT pt;
    }

    //typedef struct _DOCHOSTUIINFO
    //{
    //ULONG cbSize;
    //DWORD dwFlags;
    //DWORD dwDoubleClick;
    //OLECHAR *pchHostCss;
    //OLECHAR *pchHostNS;
    //} 	DOCHOSTUIINFO;
    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct DOCHOSTUIINFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwFlags;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwDoubleClick;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pchHostCss;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pchHostNS;
    }

    //typedef struct tagOLEVERB
    //{
    //LONG lVerb;
    //LPOLESTR lpszVerbName;
    //DWORD fuFlags;
    //DWORD grfAttribs;
    //} 	OLEVERB;
    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagOLEVERB
    {
        [MarshalAs(UnmanagedType.I4)]
        public int lVerb;
        [MarshalAs(UnmanagedType.LPWStr)]
        public String lpszVerbName;
        [MarshalAs(UnmanagedType.U4)]
        public uint fuFlags;
        [MarshalAs(UnmanagedType.U4)]
        public uint grfAttribs;
    }

    //typedef struct _tagOLECMD
    //{
    //ULONG cmdID;
    //DWORD cmdf;
    //} 	OLECMD;
    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagOLECMD
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cmdID;
        [MarshalAs(UnmanagedType.U4)]
        public uint cmdf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OLECMDTEXT
    {
        public UInt32 cmdtextf;
        public UInt32 cwActual;
        public UInt32 cwBuf;
        public Char rgwz;
    }

    //typedef struct tagOleMenuGroupWidths
    //    {
    //    LONG width[ 6 ];
    //    } 	OLEMENUGROUPWIDTHS;
    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagOleMenuGroupWidths
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public int[] widths;
    }

    //typedef /* [unique] */ IOleInPlaceFrame *LPOLEINPLACEFRAME;
    //typedef struct tagOIFI
    //    {
    //    UINT cb;
    //    BOOL fMDIApp;
    //    HWND hwndFrame;
    //    HACCEL haccel;
    //    UINT cAccelEntries;
    //    } 	OLEINPLACEFRAMEINFO;
    //typedef struct tagOIFI *LPOLEINPLACEFRAMEINFO;
    [StructLayout(LayoutKind.Sequential)]
    public struct tagOIFI
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cb;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fMDIApp;
        public IntPtr hwndFrame;
        public IntPtr hAccel;
        [MarshalAs(UnmanagedType.U4)]
        public uint cAccelEntries;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct STGMEDIUM
    {
        [MarshalAs(UnmanagedType.U4)]
        public int tymed;
        public IntPtr data;
        [MarshalAs(UnmanagedType.IUnknown)]
        public object pUnkForRelease;
    }

    ////typedef struct _REMSECURITY_ATTRIBUTES
    ////{
    ////DWORD nLength;
    ////DWORD lpSecurityDescriptor;
    ////BOOL bInheritHandle;
    ////} 	REMSECURITY_ATTRIBUTES;
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint nLength;
        public IntPtr lpSecurityDescriptor;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bInheritHandle;
    }

    //typedef struct _tagBINDINFO
    //{
    //ULONG cbSize;
    //LPWSTR szExtraInfo;
    //STGMEDIUM stgmedData;
    //DWORD grfBindInfoF;
    //DWORD dwBindVerb;
    //LPWSTR szCustomVerb;
    //DWORD cbstgmedData;
    //DWORD dwOptions;
    //DWORD dwOptionsFlags;
    //DWORD dwCodePage;
    //SECURITY_ATTRIBUTES securityAttributes;
    //IID iid;
    //IUnknown *pUnk;
    //DWORD dwReserved;
    //} 	BINDINFO;
    [StructLayout(LayoutKind.Sequential)]
    public struct BINDINFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szExtraInfo;
        [MarshalAs(UnmanagedType.Struct)]
        public STGMEDIUM stgmedData;
        [MarshalAs(UnmanagedType.U4)]
        public uint grfBindInfoF;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwBindVerb;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szCustomVerb;
        [MarshalAs(UnmanagedType.U4)]
        public uint cbstgmedData;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwOptions;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwOptionsFlags;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwCodePage;
        [MarshalAs(UnmanagedType.Struct)]
        public SECURITY_ATTRIBUTES securityAttributes;
        public Guid iid;
        [MarshalAs(UnmanagedType.IUnknown)]
        public object punk;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        public UInt32 dwLowDateTime;
        public UInt32 dwHighDateTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public UInt16 Year;
        public UInt16 Month;
        public UInt16 DayOfWeek;
        public UInt16 Day;
        public UInt16 Hour;
        public UInt16 Minute;
        public UInt16 Second;
        public UInt16 Milliseconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNET_CACHE_ENTRY_INFO
    {
        public UInt32 dwStructSize;
        public string lpszSourceUrlName;
        public string lpszLocalFileName;
        public UInt32 CacheEntryType;
        public UInt32 dwUseCount;
        public UInt32 dwHitRate;
        public UInt32 dwSizeLow;
        public UInt32 dwSizeHigh;
        public FILETIME LastModifiedTime;
        public FILETIME ExpireTime;
        public FILETIME LastAccessTime;
        public FILETIME LastSyncTime;
        public IntPtr lpHeaderInfo;
        public UInt32 dwHeaderInfoSize;
        public string lpszFileExtension;
        public UInt32 dwExemptDelta;
    };
}