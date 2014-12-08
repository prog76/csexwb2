using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f683-98b5-11cf-bb82-00aa00bdce0b")]
    public interface ISegment
    {
        //    [] HRESULT GetPointers([in] IMarkupPointer* pIStart,[in] IMarkupPointer* pIEnd);
        void GetPointers(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIEnd
           );

    }
}
