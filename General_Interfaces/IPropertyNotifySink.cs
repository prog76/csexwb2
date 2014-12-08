using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IPropertyNotifySink Interface
    //MIDL_INTERFACE("9BFBBC02-EFF1-101A-84ED-00AA00341D07")
    //IPropertyNotifySink : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE OnChanged( 
    //        /* [in] */ DISPID dispID) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnRequestEdit( 
    //        /* [in] */ DISPID dispID) = 0;

    //};
    [ComImport, ComVisible(true),
    Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyNotifySink
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnChanged([In, MarshalAs(UnmanagedType.I4)] int dispID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnRequestEdit([In, MarshalAs(UnmanagedType.I4)] int dispID);
    }
    #endregion
}