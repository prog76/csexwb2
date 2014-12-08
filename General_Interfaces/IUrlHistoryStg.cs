using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IUrlHistoryStg Interface
    [ComImport, ComVisible(true)]
    [Guid("3C374A41-BAE4-11CF-BF7D-00AA006946EE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUrlHistoryStg
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int AddUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
            uint dwFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int DeleteUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            uint dwFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int QueryUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            uint dwFlags,
            [MarshalAs(UnmanagedType.Interface)] out STATURL lpSTATURL);
        /// <summary>
        /// Currently not implemented
        /// </summary>
        /// <param name="pocsUrl"></param>
        /// <param name="riid"></param>
        /// <param name="ppvOut"></param>
        /// <returns></returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int BindToObject(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            ref Guid riid,
            object ppvOut);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int EnumUrls(out IEnumSTATURL ppEnum);
    }
    #endregion
}