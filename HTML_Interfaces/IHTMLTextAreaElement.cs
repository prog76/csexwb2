using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTextAreaElement Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2aa-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLTextAreaElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_STATUS)]
        object status { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_DISABLED)]
        object disabled { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_DEFAULTVALUE)]
        string defaultValue { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_SELECT)]
        void select();
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_ONCHANGE)]
        object onchange { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_ONSELECT)]
        object onselect { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_READONLY)]
        object readOnly { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_ROWS)]
        int rows { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_COLS)]
        int cols { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_WRAP)]
        string wrap { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_CREATETEXTRANGE)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLTxtRange createTextRange();
    }
    #endregion
}