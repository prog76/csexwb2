using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region INewWindowManager Interface

    //For popup blocking. Only for XP sp2 or higher
    //http://windowssdk.msdn.microsoft.com/library/default.asp?url=/library/en-us/shellcc/platform/shell/reference/ifaces/inewwindowmanager/evaluatenewwindow.asp
    //requested via IServiceProvider::QueryService
    [ComImport(), ComVisible(true),
    Guid("D2BC4C84-3F72-4a52-A604-7BCBF3982CBB"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INewWindowManager
    {
        //MSDN documentation is wrong
        //First, this iface is declared in ShObjIdl.h??
        //Second, dwUserActionTime param is missing from MSDN????
        //HRESULT EvaluateNewWindow(
        //    LPCWSTR pszUrl,
        //    LPCWSTR pszName, //can be NULL
        //    LPCWSTR pszUrlContext,
        //    LPCWSTR pszFeatures, //can be NULL
        //    BOOL fReplace,
        //    DWORD dwFlags,
        //    DWORD dwUserActionTime
        //);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EvaluateNewWindow(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszUrlContext,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFeatures,
            [In, MarshalAs(UnmanagedType.Bool)] bool fReplace,
            [In, MarshalAs(UnmanagedType.U4)] uint dwFlags, //NWMF flags
            [In, MarshalAs(UnmanagedType.U4)] uint dwUserActionTime);
    }

    #endregion
}