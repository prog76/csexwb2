using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IViewObject Interface

    //MIDL_INTERFACE("0000010d-0000-0000-C000-000000000046")
    //IViewObject : public IUnknown
    //{
    //public:
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE Draw( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ LONG lindex,
    //        /* [unique][in] */ void *pvAspect,
    //        /* [unique][in] */ DVTARGETDEVICE *ptd,
    //        /* [in] */ HDC hdcTargetDev,
    //        /* [in] */ HDC hdcDraw,
    //        /* [in] */ LPCRECTL lprcBounds,
    //        /* [unique][in] */ LPCRECTL lprcWBounds,
    //        /* [in] */ BOOL ( STDMETHODCALLTYPE *pfnContinue )( 
    //            ULONG_PTR dwContinue),
    //        /* [in] */ ULONG_PTR dwContinue) = 0;

    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE GetColorSet( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ LONG lindex,
    //        /* [unique][in] */ void *pvAspect,
    //        /* [unique][in] */ DVTARGETDEVICE *ptd,
    //        /* [in] */ HDC hicTargetDev,
    //        /* [out] */ LOGPALETTE **ppColorSet) = 0;

    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE Freeze( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ LONG lindex,
    //        /* [unique][in] */ void *pvAspect,
    //        /* [out] */ DWORD *pdwFreeze) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Unfreeze( 
    //        /* [in] */ DWORD dwFreeze) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetAdvise( 
    //        /* [in] */ DWORD aspects,
    //        /* [in] */ DWORD advf,
    //        /* [unique][in] */ IAdviseSink *pAdvSink) = 0;

    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE GetAdvise( 
    //        /* [unique][out] */ DWORD *pAspects,
    //        /* [unique][out] */ DWORD *pAdvf,
    //        /* [out] */ IAdviseSink **ppAdvSink) = 0;

    //}
    [ComVisible(true), ComImport()]
    [GuidAttribute("0000010d-0000-0000-C000-000000000046")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IViewObject
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Draw(
            //tagDVASPECT
            [MarshalAs(UnmanagedType.U4)] UInt32 dwDrawAspect,
            int lindex,
            IntPtr pvAspect,
            [In] IntPtr ptd,
            //[MarshalAs(UnmanagedType.Struct)] ref DVTARGETDEVICE ptd,
            IntPtr hdcTargetDev,
            IntPtr hdcDraw,
            [MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcBounds,
            [MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcWBounds,
            IntPtr pfnContinue,
            [MarshalAs(UnmanagedType.U4)] UInt32 dwContinue);

        void GetColorSet(
            [MarshalAs(UnmanagedType.U4)] UInt32 dwDrawAspect,
            int lindex,
            IntPtr pvAspect,
            [MarshalAs(UnmanagedType.Struct)] DVTARGETDEVICE ptd,
            IntPtr hicTargetDev,
            [Out, MarshalAs(UnmanagedType.Struct)] out tagLOGPALETTE ppColorSet);

        void Freeze(
            [MarshalAs(UnmanagedType.U4)] UInt32 dwDrawAspect,
            int lindex,
            IntPtr pvAspect,
            out IntPtr pdwFreeze);

        void Unfreeze(
            [MarshalAs(UnmanagedType.U4)] int dwFreeze);

        void SetAdvise
            ([MarshalAs(UnmanagedType.U4)] int aspects,
            [MarshalAs(UnmanagedType.U4)] int advf,
            [MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);

        void GetAdvise(
            IntPtr paspects,
            IntPtr advf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IAdviseSink pAdvSink);
    }
    #endregion
}