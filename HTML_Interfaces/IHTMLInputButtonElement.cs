using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2b2-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLInputButtonElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_STATUS)]
        object status { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTBUTTONELEMENT_CREATETEXTRANGE)]
        IHTMLTxtRange createTextRange();
    }

}
