using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f265-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLAreaElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_SHAPE)]
        string shape { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_COORDS)]
        string coords { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_ALT)]
        string alt { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_NOHREF)]
        bool noHref { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_HOST)]
        string host { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_HOSTNAME)]
        string hostname { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_PATHNAME)]
        string pathname { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_PORT)]
        string port { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_PROTOCOL)]
        string protocol { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_SEARCH)]
        string search { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_HASH)]
        string hash { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_ONBLUR)]
        object onblur { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_ONFOCUS)]
        object onfocus { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_TABINDEX)]
        short tabIndex { set; [return: MarshalAs(UnmanagedType.I2)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_FOCUS)]
        void focus();
        [DispId(HTMLDispIDs.DISPID_IHTMLAREAELEMENT_BLUR)]
        void blur();
    }

}
