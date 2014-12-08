using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IPersistMoniker Interface
    //MIDL_INTERFACE("79eac9c9-baf9-11ce-8c82-00aa004ba90b")
    //IPersistMoniker : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetClassID( 
    //        /* [out] */ CLSID *pClassID) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE IsDirty( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Load( 
    //        /* [in] */ BOOL fFullyAvailable,
    //        /* [in] */ IMoniker *pimkName,
    //        /* [in] */ LPBC pibc,
    //        /* [in] */ DWORD grfMode) = 0; 
    //    virtual HRESULT STDMETHODCALLTYPE Save( 
    //        /* [in] */ IMoniker *pimkName,
    //        /* [in] */ LPBC pbc,
    //        /* [in] */ BOOL fRemember) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE SaveCompleted( 
    //        /* [in] */ IMoniker *pimkName,
    //        /* [in] */ LPBC pibc) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE GetCurMoniker( 
    //        /* [out] */ IMoniker **ppimkName) = 0;
    //}
    [ComImport, ComVisible(true),
    Guid("79eac9c9-baf9-11ce-8c82-00aa004ba90b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistMoniker
    {
        void GetClassID(
            [In, Out] ref Guid pClassID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDirty();

        void Load([In] int fFullyAvailable,
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
            [In, MarshalAs(UnmanagedType.Interface)] Object pbc,
            [In, MarshalAs(UnmanagedType.U4)] uint grfMode);

        void SaveCompleted(
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
            [In, MarshalAs(UnmanagedType.Interface)] Object pbc);

        [return: MarshalAs(UnmanagedType.Interface)]
        IMoniker GetCurMoniker();
    }
    #endregion
}