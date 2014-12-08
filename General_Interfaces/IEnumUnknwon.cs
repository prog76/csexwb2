using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IEnumUnknwon Interface

    [ComImport, ComVisible(true)]
    [Guid("00000100-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumUnknown
    {
        [PreserveSig]
        int Next(
            [In, MarshalAs(UnmanagedType.U4)] int celt,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object rgelt,
            [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
        void Reset();
        void Clone(out IEnumUnknown ppenum);
    }

    #endregion
}