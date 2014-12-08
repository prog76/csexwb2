using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1f6-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLHeaderElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLHEADERELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
