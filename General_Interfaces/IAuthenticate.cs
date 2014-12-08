using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IAuthenticate Interface
    //MIDL_INTERFACE("79eac9d0-baf9-11ce-8c82-00aa004ba90b")
    //IAuthenticate : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE Authenticate( 
    //        /* [out] */ HWND *phwnd,
    //        /* [out] */ LPWSTR *pszUsername,
    //        /* [out] */ LPWSTR *pszPassword) = 0;
    //}
    [ComVisible(true), ComImport()]
    [GuidAttribute("79eac9d0-baf9-11ce-8c82-00aa004ba90b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAuthenticate
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Authenticate(
            ref IntPtr phwnd,
            //or [Out, MarshalAs(UnmanagedType.LPWStr)] out string
            ref IntPtr pszUsername,
            ref IntPtr pszPassword);
    }
    #endregion
}