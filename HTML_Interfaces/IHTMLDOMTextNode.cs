using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDOMTextNode Interface
    [ComImport, ComVisible(true), Guid("3050f4b1-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMTextNode
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_DATA)]
        string data { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_TOSTRING)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_LENGTH)]
        int length { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_SPLITTEXT)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLDOMNode splitText([In] int offset);
    }
    #endregion
}