using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTitleElement Interface
    [ComImport, ComVisible(true), Guid("3050f322-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTitleElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTITLEELEMENT_TEXT)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}