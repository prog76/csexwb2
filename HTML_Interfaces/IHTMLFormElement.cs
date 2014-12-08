using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLFormElement Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1f7-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLFormElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ACTION)]
        string action { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_DIR)]
        string dir { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ENCODING)]
        string encoding { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_METHOD)]
        string method { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ELEMENTS)]
        object elements { [return: MarshalAs(UnmanagedType.IDispatch)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ONSUBMIT)]
        object onsubmit { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ONRESET)]
        object onreset { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_SUBMIT)]
        void submit();
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_RESET)]
        void reset();
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_LENGTH)]
        int length { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT__NEWENUM)]
        object _newEnum { [return: MarshalAs(UnmanagedType.IUnknown)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name, [In] object index);
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_TAGS)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object tags();
    }
    #endregion
}