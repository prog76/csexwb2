using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleCommandTarget Interface
    //MIDL_INTERFACE("b722bccb-4e68-101b-a2bc-00aa00404770")
    //IOleCommandTarget : public IUnknown
    //{
    //public:
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE QueryStatus( 
    //        /* [unique][in] */ const GUID *pguidCmdGroup,
    //        /* [in] */ ULONG cCmds,
    //        /* [out][in][size_is] */ OLECMD prgCmds[  ],
    //        /* [unique][out][in] */ OLECMDTEXT *pCmdText) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Exec( 
    //        /* [unique][in] */ const GUID *pguidCmdGroup,
    //        /* [in] */ DWORD nCmdID,
    //        /* [in] */ DWORD nCmdexecopt,
    //        /* [unique][in] */ VARIANT *pvaIn,
    //        /* [unique][out][in] */ VARIANT *pvaOut) = 0;

    //};
    [ComImport(), ComVisible(true),
    Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleCommandTarget
    {

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryStatus(
            [In] IntPtr pguidCmdGroup,
            [In, MarshalAs(UnmanagedType.U4)] uint cCmds,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagOLECMD prgCmds,
            //This parameter must be IntPtr, as it can be null
            [In, Out] IntPtr pCmdText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Exec(
            //[In] ref Guid pguidCmdGroup,
            //have to be IntPtr, since null values are unacceptable
            //and null is used as default group!
            [In] IntPtr pguidCmdGroup,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdID,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdexecopt,
            [In] IntPtr pvaIn,
            [In, Out] IntPtr pvaOut);
    }
    #endregion
}