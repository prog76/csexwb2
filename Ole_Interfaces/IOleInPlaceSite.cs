using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace IfacesEnumsStructsClasses
{
    #region IOleInPlaceSite Interface
    //MIDL_INTERFACE("00000119-0000-0000-C000-000000000046")
    //IOleInPlaceSite : public IOleWindow
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE CanInPlaceActivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnInPlaceActivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnUIActivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE GetWindowContext( 
    //        /* [out] */ IOleInPlaceFrame **ppFrame,
    //        /* [out] */ IOleInPlaceUIWindow **ppDoc,
    //        /* [out] */ LPRECT lprcPosRect,
    //        /* [out] */ LPRECT lprcClipRect,
    //        /* [out][in] */ LPOLEINPLACEFRAMEINFO lpFrameInfo) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Scroll( 
    //        /* [in] */ SIZE scrollExtant) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnUIDeactivate( 
    //        /* [in] */ BOOL fUndoable) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnInPlaceDeactivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE DiscardUndoState( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE DeactivateAndUndo( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnPosRectChange( 
    //        /* [in] */ LPCRECT lprcPosRect) = 0;
    //};
    [ComVisible(true), ComImport(), Guid("00000119-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceSite
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);

        //IOleInPlaceSite
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CanInPlaceActivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnInPlaceActivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnUIActivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindowContext(
           [Out, MarshalAs(UnmanagedType.Interface)]
                out IOleInPlaceFrame ppFrame,
           [Out, MarshalAs(UnmanagedType.Interface)]
                out IOleInPlaceUIWindow ppDoc,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]
            //     object lprcPosRect,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]
            //     object lprcClipRect,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]
            //     object lpFrameInfo);
          [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect,
          [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcClipRect,
          [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagOIFI lpFrameInfo);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Scroll([In, MarshalAs(UnmanagedType.Struct)] ref tagSIZE scrollExtent);
        //int Scroll([In, MarshalAs(UnmanagedType.U4)] Object scrollExtent);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnUIDeactivate([In, MarshalAs(UnmanagedType.Bool)] bool fUndoable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnInPlaceDeactivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DiscardUndoState();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DeactivateAndUndo();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnPosRectChange(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect);
    }
    #endregion
}