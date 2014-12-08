using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleClientSite Interface
    //MIDL_INTERFACE("00000118-0000-0000-C000-000000000046")
    //IOleClientSite : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE SaveObject( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetMoniker( 
    //        /* [in] */ DWORD dwAssign,
    //        /* [in] */ DWORD dwWhichMoniker,
    //        /* [out] */ IMoniker **ppmk) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetContainer( 
    //        /* [out] */ IOleContainer **ppContainer) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowObject( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnShowWindow( 
    //        /* [in] */ BOOL fShow) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE RequestNewObjectLayout( void) = 0;

    //};
    [ComImport, ComVisible(true)]
    [Guid("00000118-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleClientSite
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveObject();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)]         uint dwAssign,
            [In, MarshalAs(UnmanagedType.U4)]         uint dwWhichMoniker,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetContainer(
            [Out, MarshalAs(UnmanagedType.Interface)] out IOleContainer ppContainer);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowObject();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnShowWindow([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestNewObjectLayout();
    }
    #endregion
}