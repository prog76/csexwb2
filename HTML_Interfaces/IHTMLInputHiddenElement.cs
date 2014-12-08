using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2a4-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLInputHiddenElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_STATUS)]
        object status { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTHIDDENELEMENT_CREATETEXTRANGE)]
        IHTMLTxtRange createTextRange();
    }

}
