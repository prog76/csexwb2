using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f211-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLOptionElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLOPTIONELEMENT_SELECTED)]
        bool selected { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLOPTIONELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLOPTIONELEMENT_DEFAULTSELECTED)]
        bool defaultSelected { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLOPTIONELEMENT_INDEX)]
        int index { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLOPTIONELEMENT_TEXT)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLOPTIONELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
    }
}
