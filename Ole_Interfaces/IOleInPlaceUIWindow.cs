using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleInPlaceUIWindow Interface
    //MIDL_INTERFACE("00000115-0000-0000-C000-000000000046")
    //IOleInPlaceUIWindow : public IOleWindow
    //{
    //public:
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE GetBorder( 
    //        /* [out] */ LPRECT lprectBorder) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE RequestBorderSpace( 
    //        /* [unique][in] */ LPCBORDERWIDTHS pborderwidths) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetBorderSpace( 
    //        /* [unique][in] */ LPCBORDERWIDTHS pborderwidths) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetActiveObject( 
    //        /* [unique][in] */ IOleInPlaceActiveObject *pActiveObject,
    //        /* [unique][string][in] */ LPCOLESTR pszObjName) = 0;

    //};

    [ComVisible(true), ComImport(), Guid("00000115-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceUIWindow
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
        int GetBorder([In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprectBorder);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetActiveObject(
            [In, MarshalAs(UnmanagedType.Interface)]
                ref IOleInPlaceActiveObject pActiveObject,
            [In, MarshalAs(UnmanagedType.LPWStr)]
                string pszObjName);
    }
    #endregion
}