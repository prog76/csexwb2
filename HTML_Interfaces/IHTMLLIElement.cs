using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1e0-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLLIElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLLIELEMENT_TYPE)]
        string type { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLLIELEMENT_VALUE)]
        int value { set;  get;}
    }

}
