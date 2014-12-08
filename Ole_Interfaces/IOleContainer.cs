using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IOleContainer Interface
    //MIDL_INTERFACE("0000011b-0000-0000-C000-000000000046")
    //IOleContainer : public IParseDisplayName
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE EnumObjects( 
    //        /* [in] */ DWORD grfFlags,
    //        /* [out] */ IEnumUnknown **ppenum) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE LockContainer( 
    //        /* [in] */ BOOL fLock) = 0;

    //};
    [ComImport(), ComVisible(true),
    Guid("0000011B-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleContainer
    {
        //IParseDisplayName
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ParseDisplayName(
            [In, MarshalAs(UnmanagedType.Interface)] object pbc,
            [In, MarshalAs(UnmanagedType.BStr)]      string pszDisplayName,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten,
            [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);

        //IOleContainer
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumObjects(
            [In, MarshalAs(UnmanagedType.U4)] tagOLECONTF grfFlags,
            out IEnumUnknown ppenum);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int LockContainer(
            [In, MarshalAs(UnmanagedType.Bool)] Boolean fLock);
    }
    #endregion
}