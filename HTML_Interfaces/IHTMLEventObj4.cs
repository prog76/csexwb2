using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLEventObj4 Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f814-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEventObj4
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ4_WHEELDELTA)]
        int wheelDelta { get;}
    }
    #endregion
}