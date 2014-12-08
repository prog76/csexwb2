using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f315-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLIFrameElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLIFRAMEELEMENT_VSPACE)]
        int vspace { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIFRAMEELEMENT_HSPACE)]
        int hspace { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIFRAMEELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
