using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleControl Interface
    //MIDL_INTERFACE("B196B288-BAB4-101A-B69C-00AA00341D07")
    //IOleControl : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetControlInfo( 
    //        /* [out] */ CONTROLINFO *pCI) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnMnemonic( 
    //        /* [in] */ MSG *pMsg) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnAmbientPropertyChange( 
    //        /* [in] */ DISPID dispID) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE FreezeEvents( 
    //        /* [in] */ BOOL bFreeze) = 0;
    //}
    [ComImport, ComVisible(true)]
    [Guid("B196B288-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleControl
    {
        //struct tagCONTROLINFO
        //{
        //    ULONG cb; uint32
        //    HACCEL hAccel; intptr
        //    USHORT cAccel; ushort
        //    DWORD dwFlags; uint32
        //}
        void GetControlInfo(out object pCI);
        void OnMnemonic([In, MarshalAs(UnmanagedType.Struct)]ref tagMSG pMsg);
        void OnAmbientPropertyChange([In] int dispID);
        void FreezeEvents([In, MarshalAs(UnmanagedType.Bool)] bool bFreeze);
    }
    #endregion
}