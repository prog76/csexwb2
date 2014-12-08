using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8")]
    public interface ITravelLogStg
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateEntry([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle, 
            [In] ITravelLogEntry ptleRelativeTo,
            [In, MarshalAs( UnmanagedType.Bool)] bool fPrepend,
            [Out] out ITravelLogEntry pptle);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TravelTo([In] ITravelLogEntry ptle);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumEntries([In] int TLENUMF_flags, [Out] out IEnumTravelLogEntry ppenum);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int FindEntries([In] int TLENUMF_flags,
        [In, MarshalAs( UnmanagedType.LPWStr)] string pszUrl,
        [Out] out IEnumTravelLogEntry ppenum);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetCount([In] int TLENUMF_flags, [Out] out int pcEntries);
    
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RemoveEntry([In] ITravelLogEntry ptle);
       
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetRelativeEntry([In] int iOffset, [Out] out ITravelLogEntry ptle);
    }
}
