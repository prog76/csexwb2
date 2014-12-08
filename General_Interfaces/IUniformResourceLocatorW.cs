using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IUniformResourceLocatorW Interface
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CABB0DA0-DA57-11CF-9974-0020AFD79762")]
    public interface IUniformResourceLocatorW
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int SetURL([In, MarshalAs(UnmanagedType.LPWStr)] string pcszURL, [In] uint dwInFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int GetURL(out IntPtr ppszURL);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int InvokeCommand([In, MarshalAs(UnmanagedType.LPStruct)] ref URLINVOKECOMMANDINFOW purlici);
    }
    #endregion
}