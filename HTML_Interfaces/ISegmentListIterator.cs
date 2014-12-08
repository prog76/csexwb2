using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f692-98b5-11cf-bb82-00aa00bdce0b")]
    public interface ISegmentListIterator
    {
        //    [] HRESULT Current([out] ISegment** ppISegment);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Current(
           [Out, MarshalAs(UnmanagedType.Interface)] out ISegment ppISegment
           );

        //    [] HRESULT First();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int First();

        //    [] HRESULT IsDone();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDone();

        //    [] HRESULT Advance();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Advance();

    }

}
