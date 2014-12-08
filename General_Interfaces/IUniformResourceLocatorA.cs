using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IUniformResourceLocatorA Interface
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FBF23B80-E3F0-101B-8488-00AA003E56F8")]
    public interface IUniformResourceLocatorA
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int SetURL([In, MarshalAs(UnmanagedType.LPStr)] string pcszURL, [In] uint dwInFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int GetURL(out IntPtr ppszURL);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int InvokeCommand([In, MarshalAs(UnmanagedType.LPStruct)] ref URLINVOKECOMMANDINFOA purlici);
    }
    #endregion
}