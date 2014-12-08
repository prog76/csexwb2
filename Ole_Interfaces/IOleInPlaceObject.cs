using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleInPlaceObject Interface
    //MIDL_INTERFACE("00000113-0000-0000-C000-000000000046")
    //IOleInPlaceObject : public IOleWindow
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE InPlaceDeactivate( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE UIDeactivate( void) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetObjectRects( 
    //        /* [in] */ LPCRECT lprcPosRect,
    //        /* [in] */ LPCRECT lprcClipRect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ReactivateAndUndo( void) = 0;

    //};
    [ComVisible(true), ComImport(),
    Guid("00000113-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceObject
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);

        //IOleInPlaceObject
        void InPlaceDeactivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int UIDeactivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetObjectRects(
           [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect,
           [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcClipRect);

        void ReactivateAndUndo();
    }
    #endregion
}