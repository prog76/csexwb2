using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDOMChildrenCollection Interface
    [ComImport, ComVisible(true), Guid("3050f5ab-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMChildrenCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMCHILDRENCOLLECTION_LENGTH)]
        int length { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMCHILDRENCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMCHILDRENCOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] int lIndex);

    }
    #endregion
}