using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleWindow Interface
    //MIDL_INTERFACE("00000114-0000-0000-C000-000000000046")
    //IOleWindow : public IUnknown
    //{
    //public:
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE GetWindow( 
    //        /* [out] */ HWND *phwnd) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ContextSensitiveHelp( 
    //        /* [in] */ BOOL fEnterMode) = 0;

    //};

    [ComImport, ComVisible(true)]
    [Guid("00000114-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleWindow
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);
    }
    #endregion
}