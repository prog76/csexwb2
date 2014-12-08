using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IInternetSecurityManager Interface
    [ComVisible(true), ComImport,
    GuidAttribute("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInternetSecurityManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetSecuritySite(
            [In] IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecuritySite(
            out IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MapUrlToZone(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            out UInt32 pdwZone,
            [In] UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecurityId(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            [Out] IntPtr pbSecurityId, [In, Out] ref UInt32 pcbSecurityId,
            [In] ref UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ProcessUrlAction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            UInt32 dwAction,
            IntPtr pPolicy, UInt32 cbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwFlags,
            UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryCustomPolicy(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            ref Guid guidKey,
            out IntPtr ppPolicy, out UInt32 pcbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetZoneMapping(
            UInt32 dwZone,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern,
            UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetZoneMappings(
            [In] UInt32 dwZone, //One or more of tagURLZONE enums
            out IEnumString ppenumString,
            [In] UInt32 dwFlags);
    }
    #endregion

    /*
        InternetSecurityZoneManager example;
        Creating + getting + setting ZoneActionPolicy
           HRESULT hRes = ::CoCreateInstance( CLSID_InternetZoneManager, NULL, CLSCTX_SERVER, IID_IInternetZoneManager,
              reinterpret_cast< void ** >( &m_pZone ) );

           _ASSERTE( SUCCEEDED( hRes ) );

           m_pZone->GetZoneActionPolicy( URLZONE_INTERNET, DOWNLOAD_UNSIGNED_ACTIVEX, reinterpret_cast< BYTE * >( &m_dwOldPolicy ),
              sizeof( DWORD ), URLZONEREG_HKCU );

           DWORD dwPolicy = URLPOLICY_QUERY;
           m_pZone->SetZoneActionPolicy( URLZONE_INTERNET, 
           DOWNLOAD_UNSIGNED_ACTIVEX, 
           reinterpret_cast< BYTE * >( &dwPolicy ),
              sizeof( DWORD ), URLZONEREG_HKCU );
     */

}