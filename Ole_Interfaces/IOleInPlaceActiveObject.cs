using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleInPlaceActiveObject Interface
    //MIDL_INTERFACE("00000117-0000-0000-C000-000000000046")
    //IOleInPlaceActiveObject : public IOleWindow
    //{
    //public:
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE TranslateAccelerator( 
    //        /* [in] */ LPMSG lpmsg) = 0;  
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE OnFrameWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0;  
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE OnDocWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0; 
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE ResizeBorder( 
    //        /* [in] */ LPCRECT prcBorder,
    //        /* [unique][in] */ IOleInPlaceUIWindow *pUIWindow,
    //        /* [in] */ BOOL fFrameWindow) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE EnableModeless( 
    //        /* [in] */ BOOL fEnable) = 0;
    //};
    [ComVisible(true), ComImport(), Guid("00000117-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceActiveObject
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);

        //IOleInPlaceActiveObject
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref  tagMSG lpmsg);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT prcBorder,
            [In, MarshalAs(UnmanagedType.Interface)] ref IOleInPlaceUIWindow pUIWindow,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless(
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);
    }
    #endregion
}