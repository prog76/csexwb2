using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleObject Interface
    //MIDL_INTERFACE("00000112-0000-0000-C000-000000000046")
    //IOleObject : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE SetClientSite( 
    //        /* [unique][in] */ IOleClientSite *pClientSite) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetClientSite( 
    //        /* [out] */ IOleClientSite **ppClientSite) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetHostNames( 
    //        /* [in] */ LPCOLESTR szContainerApp,
    //        /* [unique][in] */ LPCOLESTR szContainerObj) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Close( 
    //        /* [in] */ DWORD dwSaveOption) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetMoniker( 
    //        /* [in] */ DWORD dwWhichMoniker,
    //        /* [unique][in] */ IMoniker *pmk) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetMoniker( 
    //        /* [in] */ DWORD dwAssign,
    //        /* [in] */ DWORD dwWhichMoniker,
    //        /* [out] */ IMoniker **ppmk) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE InitFromData( 
    //        /* [unique][in] */ IDataObject *pDataObject,
    //        /* [in] */ BOOL fCreation,
    //        /* [in] */ DWORD dwReserved) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetClipboardData( 
    //        /* [in] */ DWORD dwReserved,
    //        /* [out] */ IDataObject **ppDataObject) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE DoVerb( 
    //        /* [in] */ LONG iVerb,
    //        /* [unique][in] */ LPMSG lpmsg,
    //        /* [unique][in] */ IOleClientSite *pActiveSite,
    //        /* [in] */ LONG lindex,
    //        /* [in] */ HWND hwndParent,
    //        /* [unique][in] */ LPCRECT lprcPosRect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnumVerbs( 
    //        /* [out] */ IEnumOLEVERB **ppEnumOleVerb) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Update( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE IsUpToDate( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetUserClassID( 
    //        /* [out] */ CLSID *pClsid) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetUserType( 
    //        /* [in] */ DWORD dwFormOfType,
    //        /* [out] */ LPOLESTR *pszUserType) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetExtent( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ SIZEL *psizel) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetExtent( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [out] */ SIZEL *psizel) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Advise( 
    //        /* [unique][in] */ IAdviseSink *pAdvSink,
    //        /* [out] */ DWORD *pdwConnection) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Unadvise( 
    //        /* [in] */ DWORD dwConnection) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnumAdvise( 
    //        /* [out] */ IEnumSTATDATA **ppenumAdvise) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetMiscStatus( 
    //        /* [in] */ DWORD dwAspect,
    //        /* [out] */ DWORD *pdwStatus) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetColorScheme( 
    //        /* [in] */ LOGPALETTE *pLogpal) = 0;
    //};
    [ComImport, ComVisible(true)]
    [Guid("00000112-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleObject
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetClientSite(
            [In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pClientSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClientSite(
            [Out, MarshalAs(UnmanagedType.Interface)] out IOleClientSite site);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetHostNames(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerApp,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Close([In, MarshalAs(UnmanagedType.U4)] uint dwSaveOption);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetMoniker(
            [In, MarshalAs(UnmanagedType.U4)] int dwWhichMoniker,
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)] uint dwAssign,
            [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker moniker);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InitFromData(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObject,
            [In, MarshalAs(UnmanagedType.Bool)] bool fCreation,
            [In, MarshalAs(UnmanagedType.U4)] uint dwReserved);

        int GetClipboardData(
            [In, MarshalAs(UnmanagedType.U4)] uint dwReserved,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IDataObject data);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DoVerb(
            [In, MarshalAs(UnmanagedType.I4)] int iVerb,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg,
            //or [In] IntPtr lpmsg,
            [In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pActiveSite,
            [In, MarshalAs(UnmanagedType.I4)] int lindex,
            [In] IntPtr hwndParent,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumVerbs([Out, MarshalAs(UnmanagedType.Interface)] out Object e);
        //int EnumVerbs(out IEnumOLEVERB e);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OleUpdate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsUpToDate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetUserClassID([In, Out] ref Guid pClsid);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetUserType(
            [In, MarshalAs(UnmanagedType.U4)] uint dwFormOfType,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string userType);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetExtent(
            [In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagSIZEL pSizel);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetExtent(
            [In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagSIZEL pSizel);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Advise(
            [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink,
            out int cookie);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Unadvise(
            [In, MarshalAs(UnmanagedType.U4)] uint dwConnection);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumAdvise(out IEnumSTATDATA e);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMiscStatus(
            [In, MarshalAs(UnmanagedType.U4)] uint dwAspect,
            out int misc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetColorScheme([In, MarshalAs(UnmanagedType.Struct)] ref object pLogpal);
    }
    #endregion
}