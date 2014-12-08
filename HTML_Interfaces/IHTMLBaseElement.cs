using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLBaseElement Interface
    [ComImport, ComVisible(true), Guid("3050f204-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLBaseElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLBASEELEMENT_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLBASEELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}