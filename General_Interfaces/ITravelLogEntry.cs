using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("7EBFDD87-AD18-11d3-A4C5-00C04F72D6B8")]
    public interface ITravelLogEntry
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetTitle([Out] out IntPtr ppszTitle); //LPOLESTR LPWSTR

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetURL([Out] out IntPtr ppszURL); //LPOLESTR LPWSTR
    }
}
