using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTable Interface
    [ComImport, ComVisible(true), Guid("3050f21e-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_COLS)]
        int cols { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDER)]
        object border { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_FRAME)]
        string frame { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_RULES)]
        string rules { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CELLSPACING)]
        object cellSpacing { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CELLPADDING)]
        object cellPadding { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BACKGROUND)]
        string background { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BGCOLOR)]
        object bgColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDERCOLOR)]
        object borderColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDERCOLORLIGHT)]
        object borderColorLight { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDERCOLORDARK)]
        object borderColorDark { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_REFRESH)]
        int refresh();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_ROWS)]
        IHTMLElementCollection rows { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_HEIGHT)]
        object height { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DATAPAGESIZE)]
        int dataPageSize { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_NEXTPAGE)]
        int nextPage();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_PREVIOUSPAGE)]
        int previousPage();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_THEAD)]
        object tHead { [return: MarshalAs(UnmanagedType.Interface)] get; } //IHTMLTableSection

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_TFOOT)]
        object tFoot { [return: MarshalAs(UnmanagedType.Interface)] get; } //IHTMLTableSection

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_TBODIES)]
        IHTMLElementCollection tBodies { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CAPTION)]
        object caption { [return: MarshalAs(UnmanagedType.Interface)] get; } //IHTMLTableCaption

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CREATETHEAD)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object createTHead();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETETHEAD)]
        void deleteTHead();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CREATETFOOT)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object createTFoot();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETETFOOT)]
        void deleteTFoot();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CREATECAPTION)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object createCaption(); //IHTMLTableCaption

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETECAPTION)]
        int deleteCaption();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_INSERTROW)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object insertRow(int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETEROW)]
        void deleteRow(int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_ONREADYSTATECHANGE)]
        object onreadystatechange { set; get; }

    }
    #endregion
}