using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Collections;
using System.Text;

namespace IfacesEnumsStructsClasses
{
    #region IWebBrowser2 Interface

    [ComImport,
    Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    SuppressUnmanagedCodeSecurity]
    public interface IWebBrowser2
    {
        [DispId(100)]
        void GoBack();
        [DispId(0x65)]
        void GoForward();
        [DispId(0x66)]
        void GoHome();
        [DispId(0x67)]
        void GoSearch();
        [DispId(0x68)]
        void Navigate([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);
        [DispId(-550)]
        void Refresh();
        [DispId(0x69)]
        void Refresh2([In] ref object Level);
        [DispId(0x6a)]
        void Stop();
        [DispId(300)]
        void Quit();
        [DispId(0x12d)]
        void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);
        [DispId(0x12e)]
        void PutProperty([MarshalAs(UnmanagedType.BStr)] string Property, object vtValue);
        [DispId(0x12f)]
        object GetProperty([MarshalAs(UnmanagedType.BStr)] string Property);
        [DispId(500)]
        void Navigate2([In] ref object URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);
        [DispId(0x1f5)]
        OLECMDF QueryStatusWB(OLECMDID cmdID);
        [DispId(0x1f6)]
        void ExecWB(OLECMDID cmdID, OLECMDEXECOPT cmdexecopt, [In] ref object pvaIn, [In, Out] ref object pvaOut);
        [DispId(0x1f7)]
        void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);
        bool AddressBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22b)] get; [DispId(0x22b)] set; }
        object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(200)] get; }
        bool Busy { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0xd4)] get; }
        object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xca)] get; }
        object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xcb)] get; }
        string FullName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(400)] get; }
        bool FullScreen { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x197)] get; [DispId(0x197)] set; }
        int Height { [DispId(0xd1)] get; [DispId(0xd1)] set; }
        int HWND { [DispId(-515)] get; }
        int Left { [DispId(0xce)] get; [DispId(0xce)] set; }
        string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(210)] get; }
        string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xd3)] get; }
        bool MenuBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x196)] get; [DispId(0x196)] set; }
        string Name { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0)] get; }
        bool Offline { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(550)] get; [DispId(550)] set; }
        object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xc9)] get; }
        string Path { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x191)] get; }
        tagREADYSTATE ReadyState { [DispId(-525)] get; }
        bool RegisterAsBrowser { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x228)] get; [DispId(0x228)] set; }
        bool RegisterAsDropTarget { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x229)] get; [DispId(0x229)] set; }
        bool Resizable { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22c)] get; [DispId(0x22c)] set; }
        bool Silent { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x227)] get; [DispId(0x227)] set; }
        bool StatusBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x193)] get; [DispId(0x193)] set; }
        string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] get; [DispId(0x194)] set; }
        bool TheaterMode { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22a)] get; [DispId(0x22a)] set; }
        int ToolBar { [DispId(0x195)] get; [DispId(0x195)] set; }
        int Top { [DispId(0xcf)] get; [DispId(0xcf)] set; }
        bool TopLevelContainer { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0xcc)] get; }
        string Type { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xcd)] get; }
        bool Visible { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x192)] get; [DispId(0x192)] set; }
        int Width { [DispId(0xd0)] get; [DispId(0xd0)] set; }
    }

    #endregion
}