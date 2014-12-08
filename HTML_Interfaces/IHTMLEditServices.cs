using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComImport, ComVisible(true)]
    [Guid("3050f663-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHTMLEditServices
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int AddDesigner([In] IHTMLEditDesigner pIDesigner);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RemoveDesigner([In] IHTMLEditDesigner pIDesigner);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSelectionServices(
            [In] IMarkupPointer pIContainer,
           [Out, MarshalAs(UnmanagedType.Interface)] out ISelectionServices ppSelSvc); //ISelectionServices**
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveToSelectionAnchor([In] IMarkupPointer pIStartAnchor);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveToSelectionEnd(
            [In] IMarkupPointer pIEndAnchor);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SelectRange(
            [In] IMarkupPointer pStart,
            [In] IMarkupPointer pEnd,
            [In] int eType);
    }
}
