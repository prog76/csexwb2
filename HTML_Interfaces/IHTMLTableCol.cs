using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTableCol Interface
    [ComImport, ComVisible(true), Guid("3050f23a-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTableCol
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_SPAN)]
        string span { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_VALIGN)]
        string vAlign { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}