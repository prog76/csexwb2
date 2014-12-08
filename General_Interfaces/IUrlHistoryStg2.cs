using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IUrlHistoryStg2 Interface
    [ComImport, ComVisible(true)]
    [Guid("AFA0DC11-C313-11d0-831A-00C04FD5AE38")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUrlHistoryStg2
    {
        //
        //IUrlHistoryStg
        //

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

        //Currently not implemented
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int BindToObject(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            ref Guid riid,
            object ppvOut);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int EnumUrls(out IEnumSTATURL ppEnum);

        //
        //IUrlHistoryStg2
        //

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int AddUrlAndNotify(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
            uint dwFlags,
            bool fWriteHistory,
            [In, MarshalAs(UnmanagedType.Interface)] IOleCommandTarget poctNotify,
            [In, MarshalAs(UnmanagedType.IUnknown)] object punkISFolder);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int ClearHistory();
    }
    #endregion
}