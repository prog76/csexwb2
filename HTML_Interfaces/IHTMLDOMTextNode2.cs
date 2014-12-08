using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDOMTextNode2 Interface
    [ComImport, ComVisible(true), Guid("3050f809-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMTextNode2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_SUBSTRINGDATA)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string substringData([In] int offset, [In] int Count);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_APPENDDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int appendData([In, MarshalAs(UnmanagedType.BStr)] string bstrstring);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_INSERTDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int insertData([In] int offset, [In, MarshalAs(UnmanagedType.BStr)] string bstrstring);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_DELETEDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int deleteData([In] int offset, [In] int Count);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_REPLACEDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int replaceData([In] int offset, [In] int Count, [In, MarshalAs(UnmanagedType.BStr)] string bstrstring);
    }
    #endregion
}