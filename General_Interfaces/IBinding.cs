using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IBinding Interface
    //MIDL_INTERFACE("79eac9c0-baf9-11ce-8c82-00aa004ba90b")
    //IBinding : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE Abort( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Suspend( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Resume( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE SetPriority( 
    //        /* [in] */ LONG nPriority) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE GetPriority( 
    //        /* [out] */ LONG *pnPriority) = 0;
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE GetBindResult( 
    //        /* [out] */ CLSID *pclsidProtocol,
    //        /* [out] */ DWORD *pdwResult,
    //        /* [out] */ LPOLESTR *pszResult,
    //        /* [out][in] */ DWORD *pdwReserved) = 0;
    //}
    [ComImport(), ComVisible(true),
    Guid("79EAC9C0-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBinding
    {
        void Abort();
        void Suspend();
        void Resume();
        void SetPriority([In] int nPriority);
        void GetPriority(out int pnPriority);
        void GetBindResult(out Guid pclsidProtocol,
             out uint pdwResult,
            [MarshalAs(UnmanagedType.LPWStr)] out string pszResult,
            [In, Out] ref uint dwReserved);
    }
    #endregion
}