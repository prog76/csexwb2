using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2ad-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLInputFileElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_STATUS)]
        object status { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_SIZE)]
        int size { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_MAXLENGTH)]
        int maxLength { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_SELECT)]
        void select();
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_ONCHANGE)]
        object onchange { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_ONSELECT)]
        object onselect { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTFILEELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
