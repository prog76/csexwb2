using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace IfacesEnumsStructsClasses
{
    #region DWebBrowserEvents Interface
    [ComImport, SuppressUnmanagedCodeSecurity,
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    Guid("EAB22AC2-30C1-11CF-A7EB-0000C05BAE0B"),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface DWebBrowserEvents
    {
        [DispId(100)]
        void BeforeNavigate(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Cancel);
        [DispId(0x65)]
        void NavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [DispId(0x66)]
        void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [DispId(0x6c)]
        void ProgressChange([In] int Progress, [In] int ProgressMax);
        [DispId(0x68)]
        void DownloadComplete();
        [DispId(0x69)]
        void CommandStateChange([In] int Command, [In] bool Enable);
        [DispId(0x6a)]
        void DownloadBegin();
        [DispId(0x6b)]
        void NewWindow(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [In, MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [In, MarshalAs(UnmanagedType.BStr)] string Headers,
            [In, Out] ref bool Processed);
        [DispId(0x71)]
        void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [DispId(200)]
        void FrameBeforeNavigate(
            [In, MarshalAs(UnmanagedType.BStr)] string URL, int Flags,
            [MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [MarshalAs(UnmanagedType.BStr)] string Headers,
            [In, Out] ref bool Cancel);
        [DispId(0xc9)]
        void FrameNavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [DispId(0xcc)]
        void FrameNewWindow(
            [In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags,
            [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [In, MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [In, MarshalAs(UnmanagedType.BStr)] string Headers,
            [In, Out] ref bool Processed);
        [DispId(0x67)]
        void Quit([In, Out] ref bool Cancel);
        [DispId(0x6d)]
        void WindowMove();
        [DispId(110)]
        void WindowResize();
        [DispId(0x6f)]
        void WindowActivate();
        [DispId(0x70)]
        void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string Property);
    }

    #endregion
}