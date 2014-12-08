using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f69e-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IDisplayPointer
    {
        //    [] HRESULT MoveToPoint([in] POINT ptPoint,[in] COORD_SYSTEM eCoordSystem,[in] IHTMLElement* pElementContext,[in] DWORD dwHitTestOptions,[out] DWORD* pdwHitTestResults);
        void MoveToPoint(
           tagPOINT ptPoint,
            int /* COORD_SYSTEM */ eCoordSystem,
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElementContext,
           uint dwHitTestOptions,
           [Out] out uint pdwHitTestResults
           );

        //    [] HRESULT MoveUnit([in] DISPLAY_MOVEUNIT eMoveUnit,[in] LONG lXPos);
        void MoveUnit(
            int /* DISPLAY_MOVEUNIT */ eMoveUnit,
           int lXPos
           );

        //    [] HRESULT PositionMarkupPointer([in] IMarkupPointer* pMarkupPointer);
        void PositionMarkupPointer(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pMarkupPointer
           );

        //    [] HRESULT MoveToPointer([in] IDisplayPointer* pDispPointer);
        void MoveToPointer(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer
           );

        //    [] HRESULT SetPointerGravity([in] POINTER_GRAVITY eGravity);
        void SetPointerGravity(
            int /* POINTER_GRAVITY */ eGravity
           );

        //    [] HRESULT GetPointerGravity([out] POINTER_GRAVITY* peGravity);
        void GetPointerGravity(
           [Out] out int /* POINTER_GRAVITY */ peGravity
           );

        //    [] HRESULT SetDisplayGravity([in] DISPLAY_GRAVITY eGravity);
        void SetDisplayGravity(
            int /* DISPLAY_GRAVITY */ eGravity
           );

        //    [] HRESULT GetDisplayGravity([out] DISPLAY_GRAVITY* peGravity);
        void GetDisplayGravity(
           [Out] out int /* DISPLAY_GRAVITY */ peGravity
           );

        //    [] HRESULT IsPositioned([out] BOOL* pfPositioned);
        void IsPositioned(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfPositioned
           );

        //    [] HRESULT Unposition();
        void Unposition();

        //    [] HRESULT IsEqualTo([in] IDisplayPointer* pDispPointer,[out] BOOL* pfIsEqual);
        void IsEqualTo(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsEqual
           );

        //    [] HRESULT IsLeftOf([in] IDisplayPointer* pDispPointer,[out] BOOL* pfIsLeftOf);
        void IsLeftOf(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsLeftOf
           );

        //    [] HRESULT IsRightOf([in] IDisplayPointer* pDispPointer,[out] BOOL* pfIsRightOf);
        void IsRightOf(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsRightOf
           );

        //    [] HRESULT IsAtBOL([out] BOOL* pfBOL);
        void IsAtBOL(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfBOL
           );

        //    [] HRESULT MoveToMarkupPointer([in] IMarkupPointer* pPointer,[in] IDisplayPointer* pDispLineContext);
        void MoveToMarkupPointer(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointer,
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispLineContext
           );

        //    [] HRESULT ScrollIntoView();
        void ScrollIntoView();

        //    [] HRESULT GetLineInfo([out] ILineInfo** ppLineInfo);
        void GetLineInfo(
           [Out, MarshalAs(UnmanagedType.Interface)] out ILineInfo ppLineInfo
           );

        //    [] HRESULT GetFlowElement([out] IHTMLElement** ppLayoutElement);
        void GetFlowElement(
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppLayoutElement
           );

        //    [] HRESULT QueryBreaks([out] DWORD* pdwBreaks);
        void QueryBreaks(
           [Out] out uint pdwBreaks
           );

    }

}
