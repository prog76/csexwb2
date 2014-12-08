using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2c2-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLInputImage
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_BORDER)]
        object border { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_VSPACE)]
        int vspace { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_HSPACE)]
        int hspace { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_ALT)]
        string alt { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_SRC)]
        string src { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_LOWSRC)]
        string lowsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_VRML)]
        string vrml { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_DYNSRC)]
        string dynsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_COMPLETE)]
        bool complete { [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_LOOP)]
        object loop { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_ONLOAD)]
        object onload { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_ONERROR)]
        object onerror { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_ONABORT)]
        object onabort { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_WIDTH)]
        int width { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_HEIGHT)]
        int height { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTIMAGE_START)]
        string start { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
