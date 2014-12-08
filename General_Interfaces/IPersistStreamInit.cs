using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IPersistStreamInit Interface
    //MIDL_INTERFACE("7FD52380-4E07-101B-AE2D-08002B2EC713")
    //IPersistStreamInit : public IPersist
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE IsDirty( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Load( 
    //        /* [in] */ LPSTREAM pStm) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Save( 
    //        /* [in] */ LPSTREAM pStm,
    //        /* [in] */ BOOL fClearDirty) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetSizeMax( 
    //        /* [out] */ ULARGE_INTEGER *pCbSize) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE InitNew( void) = 0;

    //};
    [ComVisible(true), ComImport(),
    Guid("7FD52380-4E07-101B-AE2D-08002B2EC713"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStreamInit
    {
        void GetClassID(
            [In, Out] ref Guid pClassID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDirty();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Load(
            [In, MarshalAs(UnmanagedType.Interface)] 
            System.Runtime.InteropServices.ComTypes.IStream pstm);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Save(
            [In, MarshalAs(UnmanagedType.Interface)]
            System.Runtime.InteropServices.ComTypes.IStream pstm,
            [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

        void GetSizeMax(
            [Out, MarshalAs(UnmanagedType.LPArray)] long pcbSize);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InitNew();
    }
    #endregion
}