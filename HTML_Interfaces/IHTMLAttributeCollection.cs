using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLAttributeCollection Interface
    [ComImport, ComVisible(true), Guid("3050f4c3-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLAttributeCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLATTRIBUTECOLLECTION_LENGTH)]
        int length { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLATTRIBUTECOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLATTRIBUTECOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name);

    }
    #endregion
}