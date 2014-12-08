using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f605-98b5-11cf-bb82-00aa00bdce0b")]
    public interface ISegmentList
    {
        //    [] HRESULT CreateIterator([out] ISegmentListIterator** ppIIter);
        void CreateIterator(
           [Out, MarshalAs(UnmanagedType.Interface)] out ISegmentListIterator ppIIter
           );

        //    [] HRESULT GetType([out] SELECTION_TYPE* peType);
        void GetType(
           [Out] out int /* SELECTION_TYPE */ peType
           );

        //    [] HRESULT IsEmpty([out] BOOL* pfEmpty);
        void IsEmpty(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEmpty
           );

    }

}
