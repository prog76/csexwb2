using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLAnchorElement Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1da-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLAnchorElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_REL)]
        string rel { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_REV)]
        string rev { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_URN)]
        string urn { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_METHODS)]
        string Methods { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HOST)]
        string host { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HOSTNAME)]
        string hostname { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PATHNAME)]
        string pathname { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PORT)]
        string port { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PROTOCOL)]
        string protocol { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_SEARCH)]
        string search { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HASH)]
        string hash { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_ONBLUR)]
        object onblur { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_ONFOCUS)]
        object onfocus { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_ACCESSKEY)]
        string accessKey { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PROTOCOLLONG)]
        string protocolLong { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_MIMETYPE)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string mimeType();

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_NAMEPROP)]
        string nameProp { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_TABINDEX)]
        short tabIndex { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_FOCUS)]
        void focus();

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_BLUR)]
        void blur();
    }

    #endregion
}