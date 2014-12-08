using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2bb-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLButtonElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_STATUS)]
        object status { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLBUTTONELEMENT_CREATETEXTRANGE)]
        IHTMLTxtRange createTextRange();
    }

}
