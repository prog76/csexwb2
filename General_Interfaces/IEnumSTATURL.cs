using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IEnumSTATURL Interface
    [ComImport, ComVisible(true)]
    [Guid("3C374A42-BAE4-11CF-BF7D-00AA006946EE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumSTATURL
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Next(
            [In, MarshalAs(UnmanagedType.U4)] int celt,
            [Out, MarshalAs(UnmanagedType.LPStruct)] out STATURL rgelt,
            [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
        void Reset();
        void Clone(out IEnumSTATURL ppenum);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int SetFilter([In, MarshalAs(UnmanagedType.LPWStr)] string poszFilter, uint dwFlags);
    }
    #endregion
}