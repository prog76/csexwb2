using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLElementCollection Interface

    [ComImport(), ComVisible(true),
    Guid("3050F21F-98B5-11CF-BB82-00AA00BDCE0B"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLElementCollection : IEnumerable
    {

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_TOSTRING)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_LENGTH)]
        int length { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name, [In] object index);

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_TAGS)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object tags([In] object tagName);
    }

    #endregion
}