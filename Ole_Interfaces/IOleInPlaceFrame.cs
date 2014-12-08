using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleInPlaceFrame Interface

    //MIDL_INTERFACE("00000116-0000-0000-C000-000000000046")
    //IOleInPlaceFrame : public IOleInPlaceUIWindow
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE InsertMenus( 
    //        /* [in] */ HMENU hmenuShared,
    //        /* [out][in] */ LPOLEMENUGROUPWIDTHS lpMenuWidths) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetMenu( 
    //        /* [in] */ HMENU hmenuShared,
    //        /* [in] */ HOLEMENU holemenu,
    //        /* [in] */ HWND hwndActiveObject) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE RemoveMenus( 
    //        /* [in] */ HMENU hmenuShared) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetStatusText( 
    //        /* [unique][in] */ LPCOLESTR pszStatusText) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnableModeless( 
    //        /* [in] */ BOOL fEnable) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE TranslateAccelerator( 
    //        /* [in] */ LPMSG lpmsg,
    //        /* [in] */ WORD wID) = 0;

    //};
    [ComVisible(true), ComImport(), Guid("00000116-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceFrame
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

        //IOleInPlaceUIWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetBorder(
            [Out, MarshalAs(UnmanagedType.LPStruct)] tagRECT lprectBorder);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetActiveObject(
            [In, MarshalAs(UnmanagedType.Interface)] ref IOleInPlaceActiveObject pActiveObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjName);

        //IOleInPlaceFrame 
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertMenus([In] IntPtr hmenuShared,
           [In, Out, MarshalAs(UnmanagedType.Struct)] ref object lpMenuWidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetMenu(
            [In] IntPtr hmenuShared,
            [In] IntPtr holemenu,
            [In] IntPtr hwndActiveObject);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RemoveMenus([In] IntPtr hmenuShared);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetStatusText([In, MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg,
            [In, MarshalAs(UnmanagedType.U2)] short wID);
    }
    #endregion
}