using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Collections;
using System.Text;

namespace IfacesEnumsStructsClasses
{
    #region IClassFactory Interface
    [ComVisible(true), ComImport(),
    Guid("00000001-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClassFactory
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateInstance(
            [In, MarshalAs(UnmanagedType.Interface)] object pUnkOuter,
            ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object obj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int LockServer(
            [In] bool fLock);
    }
    #endregion
}