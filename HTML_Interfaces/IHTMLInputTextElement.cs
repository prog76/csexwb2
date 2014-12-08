using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2a6-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLInputTextElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_STATUS)]
        object status { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_DEFAULTVALUE)]
        string defaultValue { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_SIZE)]
        int size { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_MAXLENGTH)]
        int maxLength { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_SELECT)]
        void select();
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_ONCHANGE)]
        object onchange { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_ONSELECT)]
        object onselect { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_READONLY)]
        bool readOnly { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTTEXTELEMENT_CREATETEXTRANGE)]
        IHTMLTxtRange createTextRange();
    }

}
