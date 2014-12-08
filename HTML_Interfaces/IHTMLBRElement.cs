using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1f0-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLBRElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLBRELEMENT_CLEAR)]
        string clear { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
