using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace IfacesEnumsStructsClasses
{
    #region IShellUIHelper Interface

    //MIDL_INTERFACE("729FE2F8-1EA8-11d1-8F85-00C04FC2FBE1")
    //IShellUIHelper : public IDispatch
    //{
    //public:
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE ResetFirstBootMode( void) = 0;
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE ResetSafeMode( void) = 0;
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE RefreshOfflineDesktop( void) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddFavorite( 
    //        /* [in] */ BSTR URL,
    //        /* [in][optional] */ VARIANT *Title) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddChannel( 
    //        /* [in] */ BSTR URL) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddDesktopComponent( 
    //        /* [in] */ BSTR URL,
    //        /* [in] */ BSTR Type,
    //        /* [in][optional] */ VARIANT *Left,
    //        /* [in][optional] */ VARIANT *Top,
    //        /* [in][optional] */ VARIANT *Width,
    //        /* [in][optional] */ VARIANT *Height) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE IsSubscribed( 
    //        /* [in] */ BSTR URL,
    //        /* [retval][out] */ VARIANT_BOOL *pBool) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE NavigateAndFind( 
    //        /* [in] */ BSTR URL,
    //        /* [in] */ BSTR strQuery,
    //        /* [in] */ VARIANT *varTargetFrame) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE ImportExportFavorites( 
    //        /* [in] */ VARIANT_BOOL fImport,
    //        /* [in] */ BSTR strImpExpPath) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AutoCompleteSaveForm( 
    //        /* [in][optional] */ VARIANT *Form) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AutoScan( 
    //        /* [in] */ BSTR strSearch,
    //        /* [in] */ BSTR strFailureUrl,
    //        /* [in][optional] */ VARIANT *pvarTargetFrame) = 0;
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE AutoCompleteAttach( 
    //        /* [in][optional] */ VARIANT *Reserved) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE ShowBrowserUI( 
    //        /* [in] */ BSTR bstrName,
    //        /* [in] */ VARIANT *pvarIn,
    //        /* [retval][out] */ VARIANT *pvarOut) = 0;
    //}
    [ComImport, ComVisible(true)]
    [Guid("729FE2F8-1EA8-11d1-8F85-00C04FC2FBE1"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    SuppressUnmanagedCodeSecurity]
    public interface IShellUIHelper
    {
        [DispId(1)]
        void ResetFirstBootMode(); //[hidden]
        [DispId(2)]
        void ResetSafeMode(); //[hidden]
        [DispId(3)]
        void RefreshOfflineDesktop(); //[hidden]

        [DispId(4)]
        void AddFavorite(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In] object Title);

        [DispId(5)]
        void AddChannel(
            [In, MarshalAs(UnmanagedType.BStr)] string URL);

        [DispId(6)]
        void AddDesktopComponent(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In, MarshalAs(UnmanagedType.BStr)] string Type,
            [In] ref object Left, [In] ref object Top,
            [In] ref object Width, [In] ref object Height);

        [DispId(7)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool IsSubscribed(
            [In, MarshalAs(UnmanagedType.BStr)] string URL);

        [DispId(8)]
        void NavigateAndFind(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In, MarshalAs(UnmanagedType.BStr)] string strQuery,
            ref object varTargetFrame);

        [DispId(9)]
        void ImportExportFavorites(
            [In, MarshalAs(UnmanagedType.VariantBool)] bool fImport,
            [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

        [DispId(10)]
        void AutoCompleteSaveForm(ref object Form);

        [DispId(11)]
        void AutoScan(
            [In, MarshalAs(UnmanagedType.BStr)] string strSearch,
            [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl,
            [In, Optional] ref object pvarTargetFrame);

        [DispId(12)]
        void AutoCompleteAttach(ref object Reserved);  //[hidden]

        [DispId(13)]
        object ShowBrowserUI(
            [In, MarshalAs(UnmanagedType.BStr)] string bstrName,
            [In] ref object pvarIn);
    }
    #endregion
}