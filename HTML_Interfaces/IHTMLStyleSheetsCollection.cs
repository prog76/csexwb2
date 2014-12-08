using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLStyleSheetsCollection Interface
    [ComImport, ComVisible(true), Guid("3050f37e-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLStyleSheetsCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEETSCOLLECTION_LENGTH)]
        int length { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEETSCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEETSCOLLECTION_ITEM)]
        object item([In] object pvarIndex);
    }
    #endregion
}