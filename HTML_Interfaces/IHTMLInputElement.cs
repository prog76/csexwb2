using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLInputElement Interface
    [ComImport, ComVisible(true), Guid("3050f5d2-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLInputElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_TYPE)]
        string type { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_STATUS)]
        bool status { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_FORM)]
        object form { [return: MarshalAs(UnmanagedType.Interface)] get;} //IHTMLFormElement* * p

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_SIZE)]
        int size { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_MAXLENGTH)]
        int maxLength { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_SELECT)]
        int select();

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONCHANGE)]
        object onchange { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONSELECT)]
        object onselect { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DEFAULTVALUE)]
        string defaultValue { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_READONLY)]
        object readOnly { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_CREATETEXTRANGE)]
        IHTMLTxtRange createTextRange();

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_INDETERMINATE)]
        bool indeterminate { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DEFAULTCHECKED)]
        bool defaultChecked { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        //checked can not be used
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_CHECKED)]
        bool checkeda { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_BORDER)]
        object border { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_VSPACE)]
        int vspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_HSPACE)]
        int hspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ALT)]
        string alt { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_SRC)]
        string src { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_LOWSRC)]
        string lowsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_VRML)]
        string vrml { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DYNSRC)]
        string dynsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_COMPLETE)]
        bool complete { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_LOOP)]
        object loop { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONLOAD)]
        object onload { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONERROR)]
        object onerror { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONABORT)]
        object onabort { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_WIDTH)]
        int width { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_HEIGHT)]
        int height { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_START)]
        string start { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}