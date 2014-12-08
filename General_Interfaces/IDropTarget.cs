using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IDropTarget Interface
    //MIDL_INTERFACE("00000122-0000-0000-C000-000000000046")
    //IDropTarget : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE DragEnter( 
    //        /* [unique][in] */ IDataObject *pDataObj,
    //        /* [in] */ DWORD grfKeyState,
    //        /* [in] */ POINTL pt,
    //        /* [out][in] */ DWORD *pdwEffect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE DragOver( 
    //        /* [in] */ DWORD grfKeyState,
    //        /* [in] */ POINTL pt,
    //        /* [out][in] */ DWORD *pdwEffect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE DragLeave( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Drop( 
    //        /* [unique][in] */ IDataObject *pDataObj,
    //        /* [in] */ DWORD grfKeyState,
    //        /* [in] */ POINTL pt,
    //        /* [out][in] */ DWORD *pdwEffect) = 0;

    //};
    [ComVisible(true), ComImport(),
    Guid("00000122-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropTarget
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DragEnter(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObj,
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DragOver(
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DragLeave();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Drop(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObj,
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);
    }
    #endregion
}