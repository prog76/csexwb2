using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHtmlControlRange2 Interface

    [ComVisible(true), Guid("3050f65e-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHtmlControlRange2
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int addElement([In, MarshalAs(UnmanagedType.Interface)] IHTMLElement element);
    }

    #endregion
}