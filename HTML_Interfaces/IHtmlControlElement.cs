using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHtmlControlElement Interface

    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f4e9-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLControlElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_TABINDEX)]
        short tabIndex { set; [return: MarshalAs(UnmanagedType.I2)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_FOCUS)]
        void focus();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ACCESSKEY)]
        string accessKey { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ONBLUR)]
        object onblur { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ONFOCUS)]
        object onfocus { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ONRESIZE)]
        object onresize { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_BLUR)]
        void blur();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ADDFILTER)]
        void addFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_REMOVEFILTER)]
        void removeFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTHEIGHT)]
        int clientHeight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTWIDTH)]
        int clientWidth { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTTOP)]
        int clientTop { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTLEFT)]
        int clientLeft { get;}
    }

    #endregion
}