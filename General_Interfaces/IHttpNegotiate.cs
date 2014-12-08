using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHttpNegotiate Interface
    //MIDL_INTERFACE("79eac9d2-baf9-11ce-8c82-00aa004ba90b")
    //IHttpNegotiate : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE BeginningTransaction( 
    //        /* [in] */ LPCWSTR szURL,
    //        /* [unique][in] */ LPCWSTR szHeaders,
    //        /* [in] */ DWORD dwReserved,
    //        /* [out] */ LPWSTR *pszAdditionalHeaders) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnResponse( 
    //        /* [in] */ DWORD dwResponseCode,
    //        /* [unique][in] */ LPCWSTR szResponseHeaders,
    //        /* [unique][in] */ LPCWSTR szRequestHeaders,
    //        /* [out] */ LPWSTR *pszAdditionalRequestHeaders) = 0;
    //}
    [ComImport, ComVisible(true)]
    [Guid("79eac9d2-baf9-11ce-8c82-00aa004ba90b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHttpNegotiate
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int BeginningTransaction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szURL,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szHeaders,
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwReserved,
            [Out] out IntPtr pszAdditionalHeaders);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnResponse(
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwResponseCode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szResponseHeaders,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szRequestHeaders,
            [Out] out IntPtr pszAdditionalRequestHeaders);
    }
    #endregion
}