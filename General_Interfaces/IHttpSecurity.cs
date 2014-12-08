using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHttpSecurity Interface
    //MIDL_INTERFACE("79eac9d7-bafa-11ce-8c82-00aa004ba90b")
    //IHttpSecurity : public IWindowForBindingUI
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE OnSecurityProblem( 
    //        /* [in] */ DWORD dwProblem) = 0;
    //}
    //requested via IServiceProvider::QueryService
    [ComImport(), ComVisible(true),
    Guid("79eac9d7-bafa-11ce-8c82-00aa004ba90b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHttpSecurity
    {
        //IWindowForBindingUI
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow(
            [In] ref Guid rguidReason,
            [In, Out] ref IntPtr phwnd);

        //IHttpSecurity
        //http://msdn.microsoft.com/library/default.asp?url=/workshop/networking/moniker/reference/ifaces/ihttpsecurity/onsecurityproblem.asp?frame=true
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnSecurityProblem(
            [In, MarshalAs(UnmanagedType.U4)] uint dwProblem);
        //dwProblem one of wininet error Messages
        //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wininet/wininet/wininet_errors.asp?frame=true
    }
    #endregion
}