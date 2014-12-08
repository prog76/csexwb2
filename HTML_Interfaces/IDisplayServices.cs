using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f69d-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IDisplayServices
    {
        //    [] HRESULT CreateDisplayPointer([out] IDisplayPointer** ppDispPointer);
        void CreateDisplayPointer(
           [Out, MarshalAs(UnmanagedType.Interface)] out IDisplayPointer ppDispPointer
           );

        //    [] HRESULT TransformRect([in, out] RECT* pRect,[in] COORD_SYSTEM eSource,[in] COORD_SYSTEM eDestination,[in] IHTMLElement* pIElement);
        void TransformRect(
           [Out] out tagRECT pRect,
           [In]int /* COORD_SYSTEM */ eSource,
           [In]int /* COORD_SYSTEM */ eDestination,
           [In, MarshalAs(UnmanagedType.Interface)] IHTMLElement pIElement
           );

        //    [] HRESULT TransformPoint([in, out] POINT* pPoint,[in] COORD_SYSTEM eSource,[in] COORD_SYSTEM eDestination,[in] IHTMLElement* pIElement);
        void TransformPoint(
           [Out] out tagPOINT pPoint,
           [In]int /* COORD_SYSTEM */ eSource,
           [In]int /* COORD_SYSTEM */ eDestination,
           [In, MarshalAs(UnmanagedType.Interface)] IHTMLElement pIElement
           );

        //    [] HRESULT GetCaret([out] IHTMLCaret** ppCaret);
        void GetCaret(
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLCaret ppCaret
           );

        //    [] HRESULT GetComputedStyle([in] IMarkupPointer* pPointer,[out] IHTMLComputedStyle** ppComputedStyle);
        void GetComputedStyle(
           [In, MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointer,
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLComputedStyle ppComputedStyle
           );

        //    [] HRESULT ScrollRectIntoView([in] IHTMLElement* pIElement,[in] RECT rect);
        void ScrollRectIntoView(
           [In, MarshalAs(UnmanagedType.Interface)] IHTMLElement pIElement,
           [In] tagRECT rect
           );

        //    [] HRESULT HasFlowLayout([in] IHTMLElement* pIElement,[out] BOOL* pfHasFlowLayout);
        void HasFlowLayout(
           [In, MarshalAs(UnmanagedType.Interface)] IHTMLElement pIElement,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfHasFlowLayout
           );

    }

}
