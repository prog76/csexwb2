using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f68f-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IElementSegment
    {
        //ISegment
        //    [] HRESULT GetPointers([in] IMarkupPointer* pIStart,[in] IMarkupPointer* pIEnd);
        void GetPointers(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIEnd
           );

        //IElementSegment
        //    [] HRESULT GetElement([out] IHTMLElement** ppIElement);
        void GetElement(
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppIElement
           );

        //    [] HRESULT SetPrimary([in] BOOL fPrimary);
        void SetPrimary(
           [MarshalAs(UnmanagedType.Bool)] bool fPrimary
           );

        //    [] HRESULT IsPrimary([out] BOOL* pfPrimary);
        void IsPrimary(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfPrimary
           );

    }

}
