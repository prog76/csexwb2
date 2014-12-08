using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLMetaElement Interface
    [ComImport, ComVisible(true), Guid("3050f203-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLMetaElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_HTTPEQUIV)]
        string httpEquiv { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_CONTENT)]
        string content { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_URL)]
        string url { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_CHARSET)]
        string charset { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}