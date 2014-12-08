using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLSelectElement Interface
    [ComImport, ComVisible(true), Guid("3050f244-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLSelectElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_SIZE)]
        int size { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_MULTIPLE)]
        bool multiple { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_OPTIONS)]
        object options { [return: MarshalAs(UnmanagedType.IDispatch)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_ONCHANGE)]
        object onchange { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_SELECTEDINDEX)]
        int selectedIndex { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_FORM)]
        object form { [return: MarshalAs(UnmanagedType.Interface)] get;} //([retval, out] IHTMLFormElement* * p);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_ADD)]
        int add([In] IHTMLElement element, [In] object before);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_REMOVE)]
        int remove([In] int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_LENGTH)]
        int length { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT__NEWENUM)]
        object _newEnum { set; [return: MarshalAs(UnmanagedType.IUnknown)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_ITEM)]
        object item([In] object name, [In] object index);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_TAGS)]
        object tags([In] object tagName);
    }
    #endregion
}