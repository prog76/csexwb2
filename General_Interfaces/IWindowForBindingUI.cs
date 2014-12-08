using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IWindowForBindingUI Interface
    //MIDL_INTERFACE("79eac9d5-bafa-11ce-8c82-00aa004ba90b")
    //IWindowForBindingUI : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetWindow( 
    //        /* [in] */ REFGUID rguidReason, [In] ref Guid rguidReason
    //        /* [out] */ HWND *phwnd) = 0;    
    //}
    //requested via IServiceProvider::QueryService
    [ComImport(), ComVisible(true),
    Guid("79eac9d5-bafa-11ce-8c82-00aa004ba90b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWindowForBindingUI
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow(
            [In] ref Guid rguidReason,
            ref IntPtr phwnd);
    }
    #endregion
}