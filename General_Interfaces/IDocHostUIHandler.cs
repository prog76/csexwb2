using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IDocHostUIHandler Interface
    //MIDL_INTERFACE("bd3f23c0-d43e-11cf-893b-00aa00bdce1a")
    //IDocHostUIHandler : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE ShowContextMenu( 
    //        /* [in] */ DWORD dwID,
    //        /* [in] */ POINT *ppt,
    //        /* [in] */ IUnknown *pcmdtReserved,
    //        /* [in] */ IDispatch *pdispReserved) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetHostInfo( 
    //        /* [out][in] */ DOCHOSTUIINFO *pInfo) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowUI( 
    //        /* [in] */ DWORD dwID,
    //        /* [in] */ IOleInPlaceActiveObject *pActiveObject,
    //        /* [in] */ IOleCommandTarget *pCommandTarget,
    //        /* [in] */ IOleInPlaceFrame *pFrame,
    //        /* [in] */ IOleInPlaceUIWindow *pDoc) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE HideUI( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE UpdateUI( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnableModeless( 
    //        /* [in] */ BOOL fEnable) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnDocWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnFrameWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ResizeBorder( 
    //        /* [in] */ LPCRECT prcBorder,
    //        /* [in] */ IOleInPlaceUIWindow *pUIWindow,
    //        /* [in] */ BOOL fRameWindow) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE TranslateAccelerator( 
    //        /* [in] */ LPMSG lpMsg,
    //        /* [in] */ const GUID *pguidCmdGroup,
    //        /* [in] */ DWORD nCmdID) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetOptionKeyPath( 
    //        /* [out] */ LPOLESTR *pchKey,
    //        /* [in] */ DWORD dw) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetDropTarget( 
    //        /* [in] */ IDropTarget *pDropTarget,
    //        /* [out] */ IDropTarget **ppDropTarget) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetExternal( 
    //        /* [out] */ IDispatch **ppDispatch) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE TranslateUrl( 
    //        /* [in] */ DWORD dwTranslate,
    //        /* [in] */ OLECHAR *pchURLIn,
    //        /* [out] */ OLECHAR **ppchURLOut) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE FilterDataObject( 
    //        /* [in] */ IDataObject *pDO,
    //        /* [out] */ IDataObject **ppDORet) = 0;

    //};
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("bd3f23c0-d43e-11cf-893b-00aa00bdce1a")]
    public interface IDocHostUIHandler
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowContextMenu(
            [In, MarshalAs(UnmanagedType.U4)] uint dwID,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagPOINT pt,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pcmdtReserved,
            [In, MarshalAs(UnmanagedType.IDispatch)] object pdispReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetHostInfo([In, Out, MarshalAs(UnmanagedType.Struct)] ref DOCHOSTUIINFO info);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowUI(
            [In, MarshalAs(UnmanagedType.I4)] int dwID,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceActiveObject activeObject,
            [In, MarshalAs(UnmanagedType.Interface)] IOleCommandTarget commandTarget,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceFrame frame,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceUIWindow doc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int HideUI();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int UpdateUI();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless(
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT rect,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceUIWindow doc,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG msg,
            [In] ref Guid group,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetOptionKeyPath(
            //out IntPtr pbstrKey,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out String pbstrKey,
            //[Out, MarshalAs(UnmanagedType.LPArray)] String[] pbstrKey,
            [In, MarshalAs(UnmanagedType.U4)] uint dw);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetDropTarget(
            [In, MarshalAs(UnmanagedType.Interface)] IDropTarget pDropTarget,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDropTarget ppDropTarget);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetExternal(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppDispatch);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateUrl(
            [In, MarshalAs(UnmanagedType.U4)] uint dwTranslate,
            [In, MarshalAs(UnmanagedType.LPWStr)] string strURLIn,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int FilterDataObject(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDO,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet);
    }
    #endregion
}