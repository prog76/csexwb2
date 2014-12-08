using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IBindStatusCallback Interface
    [ComImport, ComVisible(true),
    Guid("79EAC9C1-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBindStatusCallback
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnStartBinding(
            [In] uint dwReserved,
            [In, MarshalAs(UnmanagedType.Interface)] IBinding pib);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetPriority(out int pnPriority);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnLowResource([In] uint reserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnProgress(
            [In] uint ulProgress,
            [In] uint ulProgressMax,
            //[In] BINDSTATUS ulStatusCode,
            [In, MarshalAs(UnmanagedType.U4)] uint ulStatusCode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szStatusText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnStopBinding(
            [In, MarshalAs(UnmanagedType.Error)] uint hresult,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szError);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetBindInfo(
            //out BINDF grfBINDF,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint grfBINDF,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref BINDINFO pbindinfo);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDataAvailable(
            [In, MarshalAs(UnmanagedType.U4)] uint grfBSCF,
            [In, MarshalAs(UnmanagedType.U4)] uint dwSize,
            [In, MarshalAs(UnmanagedType.Struct)] ref FORMATETC pFormatetc,
            [In, MarshalAs(UnmanagedType.Struct)] ref STGMEDIUM pStgmed);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnObjectAvailable(
            [In] ref Guid riid,
            [In, MarshalAs(UnmanagedType.IUnknown)] object punk);
    }
    #endregion
}