using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IServiceProvider Interface
    //MIDL_INTERFACE("6d5140c1-7436-11ce-8034-00aa006009fa")
    //IServiceProvider : public IUnknown
    //{
    //public:
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE QueryService( 
    //        /* [in] */ REFGUID guidService,
    //        /* [in] */ REFIID riid,
    //        /* [out] */ void __RPC_FAR *__RPC_FAR *ppvObject) = 0;

    //    template <class Q>
    //    HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, Q** pp)
    //    {
    //        return QueryService(guidService, __uuidof(Q), (void **)pp);
    //    }
    //};
    [ComImport, ComVisible(true)]
    [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServiceProvider
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryService(
            [In] ref Guid guidService,
            [In] ref Guid riid,
            [Out] out IntPtr ppvObject);
        //This does not work i.e.-> ppvObject = (INewWindowManager)this
        //[Out, MarshalAs(UnmanagedType.Interface)] out object ppvObject);
    }
    #endregion
}