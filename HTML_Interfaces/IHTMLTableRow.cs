using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTableRow Interface
    [ComImport, ComVisible(true), Guid("3050f23c-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTableRow
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_VALIGN)]
        string vAlign { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BGCOLOR)]
        object bgColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BORDERCOLOR)]
        object borderColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BORDERCOLORLIGHT)]
        object borderColorLight { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BORDERCOLORDARK)]
        object borderColorDark { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_ROWINDEX)]
        int rowIndex { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_SECTIONROWINDEX)]
        int sectionRowIndex { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_CELLS)]
        IHTMLElementCollection cells { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_INSERTCELL)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object insertCell(int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_DELETECELL)]
        int deleteCell(int index);
    }
    #endregion
}