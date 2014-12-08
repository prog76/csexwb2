using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("7EBFDD85-AD18-11d3-A4C5-00C04F72D6B8")]
    public interface IEnumTravelLogEntry
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Next(
            [In, MarshalAs(UnmanagedType.U4)] int celt,
            [Out] out ITravelLogEntry rgelt,
            [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);

        void Reset();

        void Clone([Out] out ITravelLogEntry ppenum);
    }
}
