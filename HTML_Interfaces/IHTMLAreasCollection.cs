using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f383-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLAreasCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLAREASCOLLECTION_LENGTH)]
        int length { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREASCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();
        [DispId(HTMLDispIDs.DISPID_IHTMLAREASCOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name, [In] object index);
        [DispId(HTMLDispIDs.DISPID_IHTMLAREASCOLLECTION_TAGS)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object tags([In] object tagName);
        [DispId(HTMLDispIDs.DISPID_IHTMLAREASCOLLECTION_ADD)]
        void add([In] IHTMLElement element, [In] object before);
        [DispId(HTMLDispIDs.DISPID_IHTMLAREASCOLLECTION_REMOVE)]
        void remove(int index);
    }

}
