using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLImgElement Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f240-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLImgElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ISMAP)]
        bool isMap { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_USEMAP)]
        string useMap { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_MIMETYPE)]
        string mimeType { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILESIZE)]
        string fileSize { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILECREATEDDATE)]
        string fileCreatedDate { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILEMODIFIEDDATE)]
        string fileModifiedDate { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILEUPDATEDDATE)]
        string fileUpdatedDate { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_PROTOCOL)]
        string protocol { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_HREF)]
        string href { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_NAMEPROP)]
        string nameProp { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_BORDER)]
        object border { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_VSPACE)]
        int vspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_HSPACE)]
        int hspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ALT)]
        string alt { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_SRC)]
        string src { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_LOWSRC)]
        string lowsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_VRML)]
        string vrml { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_DYNSRC)]
        string dynsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_COMPLETE)]
        bool complete { [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_LOOP)]
        object loop { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ONLOAD)]
        object onload { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ONERROR)]
        object onerror { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ONABORT)]
        object onabort { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_WIDTH)]
        int width { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_HEIGHT)]
        int height { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_START)]
        string start { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion
}