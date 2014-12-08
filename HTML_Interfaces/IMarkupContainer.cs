using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComImport, ComVisible(true)]
    [Guid("3050f5f9-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMarkupContainer
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OwningDoc([Out] out IHTMLDocument2 ppDoc);
    }
}
