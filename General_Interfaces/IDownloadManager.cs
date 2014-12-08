using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IDownloadManager Interface
    //MIDL_INTERFACE("988934A4-064B-11D3-BB80-00104B35E7F9")
    //IDownloadManager : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE Download( 
    //        /* [in] */ IMoniker *pmk,
    //        /* [in] */ IBindCtx *pbc,
    //        /* [in] */ DWORD dwBindVerb,
    //        /* [in] */ LONG grfBINDF,
    //        /* [in] */ BINDINFO *pBindInfo,
    //        /* [in] */ LPCOLESTR pszHeaders,
    //        /* [in] */ LPCOLESTR pszRedir,
    //        /* [in] */ UINT uiCP) = 0;
    //}
    [ComVisible(true), ComImport]
    [Guid("988934A4-064B-11D3-BB80-00104B35E7F9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDownloadManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Download(
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
            [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc,
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwBindVerb,
            [In] int grfBINDF,
            [In, MarshalAs(UnmanagedType.Struct)] ref BINDINFO pBindInfo,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszHeaders,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszRedir,
            [In, MarshalAs(UnmanagedType.U4)] uint uiCP);
    }
    #endregion
}