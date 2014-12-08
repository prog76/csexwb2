using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComImport, ComVisible(true)]
    [Guid("3050f662-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHTMLEditDesigner
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int PreHandleEvent([In] int inEvtDispId, [In] IHTMLEventObj pIEventObj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int PostHandleEvent([In] int inEvtDispId, [In] IHTMLEventObj pIEventObj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator([In] int inEvtDispId, [In] IHTMLEventObj pIEventObj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int PostEditorEventNotify([In] int inEvtDispId, [In] IHTMLEventObj pIEventObj);
    }
}
