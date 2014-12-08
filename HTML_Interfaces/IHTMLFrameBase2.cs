using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f6db-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLFrameBase2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE2_CONTENTWINDOW)]
        IHTMLWindow2 contentWindow { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE2_ONLOAD)]
        object onload { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE2_ONREADYSTATECHANGE)]
        object onreadystatechange { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE2_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE2_ALLOWTRANSPARENCY)]
        bool allowTransparency { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
    }

}
