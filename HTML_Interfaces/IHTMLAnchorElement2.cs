using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f825-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLAnchorElement2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT2_CHARSET)]
        string charset { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT2_COORDS)]
        string coords { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT2_HREFLANG)]
        string hreflang { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT2_SHAPE)]
        string shape { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT2_TYPE)]
        string type { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
