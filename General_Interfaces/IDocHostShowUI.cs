using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IDocHostShowUI Interface
    //MIDL_INTERFACE("c4d244b0-d43e-11cf-893b-00aa00bdce1a")
    //IDocHostShowUI : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE ShowMessage( 
    //        /* [in] */ HWND hwnd,
    //        /* [in] */ LPOLESTR lpstrText,
    //        /* [in] */ LPOLESTR lpstrCaption,
    //        /* [in] */ DWORD dwType,
    //        /* [in] */ LPOLESTR lpstrHelpFile,
    //        /* [in] */ DWORD dwHelpContext,
    //        /* [out] */ LRESULT *plResult) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowHelp( 
    //        /* [in] */ HWND hwnd,
    //        /* [in] */ LPOLESTR pszHelpFile,
    //        /* [in] */ UINT uCommand,
    //        /* [in] */ DWORD dwData,
    //        /* [in] */ POINT ptMouse,
    //        /* [out] */ IDispatch *pDispatchObjectHit) = 0;

    //};
    [ComImport, ComVisible(true)]
    [Guid("C4D244B0-D43E-11CF-893B-00AA00BDCE1A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDocHostShowUI
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowMessage(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string lpstrText,
            [MarshalAs(UnmanagedType.LPWStr)] string lpstrCaption,
            [MarshalAs(UnmanagedType.U4)] uint dwType,
            [MarshalAs(UnmanagedType.LPWStr)] string lpstrHelpFile,
            [MarshalAs(UnmanagedType.U4)] uint dwHelpContext,
            [In, Out] ref int lpResult);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowHelp(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszHelpFile,
            [MarshalAs(UnmanagedType.U4)] uint uCommand,
            [MarshalAs(UnmanagedType.U4)] uint dwData,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT ptMouse,
            [Out, MarshalAs(UnmanagedType.IDispatch)] object pDispatchObjectHit);
    }
    #endregion
}