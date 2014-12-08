using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f606-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHighlightRenderingServices
    {
        //    [] HRESULT AddSegment([in] IDisplayPointer* pDispPointerStart,[in] IDisplayPointer* pDispPointerEnd,[in] IHTMLRenderStyle* pIRenderStyle,[out] IHighlightSegment** ppISegment);
        void AddSegment(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointerEnd,
           [MarshalAs(UnmanagedType.Interface)] IHTMLRenderStyle pIRenderStyle,
           [Out, MarshalAs(UnmanagedType.Interface)] out IHighlightSegment ppISegment
           );

        //    [] HRESULT MoveSegmentToPointers([in] IHighlightSegment* pISegment,[in] IDisplayPointer* pDispPointerStart,[in] IDisplayPointer* pDispPointerEnd);
        void MoveSegmentToPointers(
           [MarshalAs(UnmanagedType.Interface)] IHighlightSegment pISegment,
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointerEnd
           );

        //    [] HRESULT RemoveSegment([in] IHighlightSegment* pISegment);
        void RemoveSegment(
           [MarshalAs(UnmanagedType.Interface)] IHighlightSegment pISegment
           );

    }

}
