using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLHeadElement Interface
    [ComImport, ComVisible(true), Guid("3050f81d-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLHeadElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLHEADELEMENT_PROFILE)]
        string profile { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}