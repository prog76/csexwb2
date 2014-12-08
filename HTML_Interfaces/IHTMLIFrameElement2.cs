using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f4e6-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLIFrameElement2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLIFRAMEELEMENT2_HEIGHT)]
        object height { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIFRAMEELEMENT2_WIDTH)]
        object width { set;  get;}
    }

}
