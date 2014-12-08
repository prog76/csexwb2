using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f319-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLFrameSetElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_ROWS)]
        string rows { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_COLS)]
        string cols { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_BORDER)]
        object border { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_BORDERCOLOR)]
        object borderColor { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_FRAMEBORDER)]
        string frameBorder { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_FRAMESPACING)]
        object frameSpacing { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_ONLOAD)]
        object onload { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_ONUNLOAD)]
        object onunload { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESETELEMENT_ONBEFOREUNLOAD)]
        object onbeforeunload { set;  get;}
    }
}
