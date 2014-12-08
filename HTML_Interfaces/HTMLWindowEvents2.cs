using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region HTMLWindowEvents2 Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f625-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLWindowEvents2
    {
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONLOAD)]
        void onload([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONUNLOAD)]
        void onunload([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        void onhelp([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONFOCUS)]
        void onfocus([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBLUR)]
        void onblur([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONERROR)]
        void onerror([In, MarshalAs(UnmanagedType.BStr)] string description, [In, MarshalAs(UnmanagedType.BStr)] string url, [In] long line);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONRESIZE)]
        void onresize([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONSCROLL)]
        void onscroll([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBEFOREUNLOAD)]
        void onbeforeunload([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBEFOREPRINT)]
        void onbeforeprint([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONAFTERPRINT)]
        void onafterprint([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }

    #endregion
}