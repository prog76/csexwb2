using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f684-98b5-11cf-bb82-00aa00bdce0b")]
    public interface ISelectionServices
    {
        //    [] HRESULT SetSelectionType([in] SELECTION_TYPE eType,[in] ISelectionServicesListener* pIListener);
        void SetSelectionType(
            int /* SELECTION_TYPE */ eType,
           [MarshalAs(UnmanagedType.Interface)] ISelectionServicesListener pIListener
           );

        //    [] HRESULT GetMarkupContainer([out] IMarkupContainer** ppIContainer);
        void GetMarkupContainer(
           [Out, MarshalAs(UnmanagedType.Interface)] out IMarkupContainer ppIContainer
           );

        //    [] HRESULT AddSegment([in] IMarkupPointer* pIStart,[in] IMarkupPointer* pIEnd,[out] ISegment** ppISegmentAdded);
        void AddSegment(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIEnd,
           [Out, MarshalAs(UnmanagedType.Interface)] out ISegment ppISegmentAdded
           );

        //    [] HRESULT AddElementSegment([in] IHTMLElement* pIElement,[out] IElementSegment** ppISegmentAdded);
        void AddElementSegment(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pIElement,
           [Out, MarshalAs(UnmanagedType.Interface)] out IElementSegment ppISegmentAdded
           );

        //    [] HRESULT RemoveSegment([in] ISegment* pISegment);
        void RemoveSegment(
           [MarshalAs(UnmanagedType.Interface)] ISegment pISegment
           );

        //    [] HRESULT GetSelectionServicesListener([out] ISelectionServicesListener** ppISelectionServicesListener);
        void GetSelectionServicesListener(
           [Out, MarshalAs(UnmanagedType.Interface)] out ISelectionServicesListener ppISelectionServicesListener
           );

    }

}
