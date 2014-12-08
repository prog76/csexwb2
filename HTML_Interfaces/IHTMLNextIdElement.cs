using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLNextIdElement Interface
    [ComImport, ComVisible(true), Guid("3050f207-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLNextIdElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLNEXTIDELEMENT_N)]
        string n { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}