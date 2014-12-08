using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    /// <summary>
    /// When the MSHTML Editor calls IHTMLEditHost::SnapRect,
    /// the method's arguments will tell you which element is
    /// being resized, the original size and position of the element,
    /// and which handle the user has grabbed. You have the ability to 
    /// control the size and position of the element when the user 
    /// releases the handle.
    /// Returns S_OK if successful, or an error value otherwise.
    /// </summary>
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f6a0-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEditHost
    {
        //    [] HRESULT SnapRect([in] IHTMLElement* pIElement,[in, out] RECT* prcNew,[in] ELEMENT_CORNER eHandle);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SnapRect(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pIElement,
           [In, Out] ref tagRECT prcNew,
            int /* ELEMENT_CORNER */ eHandle
           );

    }

}
