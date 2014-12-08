using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTableCell Interface
    [ComImport, ComVisible(true), Guid("3050f23d-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTableCell
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_ROWSPAN)]
        int rowSpan { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_COLSPAN)]
        int colSpan { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_VALIGN)]
        string vAlign { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BGCOLOR)]
        object bgColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_NOWRAP)]
        bool noWrap { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BACKGROUND)]
        string background { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BORDERCOLOR)]
        object borderColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BORDERCOLORLIGHT)]
        object borderColorLight { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BORDERCOLORDARK)]
        object borderColorDark { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_HEIGHT)]
        object height { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_CELLINDEX)]
        int cellIndex { get; }
    }
    #endregion
}