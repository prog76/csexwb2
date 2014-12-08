using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f812-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEditServices2
    {
        //    [] HRESULT MoveToSelectionAnchorEx([in] IDisplayPointer* pIStartAnchor);
        void MoveToSelectionAnchorEx(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pIStartAnchor
           );

        //    [] HRESULT MoveToSelectionEndEx([in] IDisplayPointer* pIEndAnchor);
        void MoveToSelectionEndEx(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pIEndAnchor
           );

        //    [] HRESULT FreezeVirtualCaretPos([in] BOOL fReCompute);
        void FreezeVirtualCaretPos(
           [MarshalAs(UnmanagedType.Bool)] bool fReCompute
           );

        //    [] HRESULT UnFreezeVirtualCaretPos([in] BOOL fReset);
        void UnFreezeVirtualCaretPos(
           [MarshalAs(UnmanagedType.Bool)] bool fReset
           );

    }

}
