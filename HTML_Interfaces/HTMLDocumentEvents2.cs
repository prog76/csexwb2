using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region HTMLDocumentEvents2 Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f613-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLDocumentEvents2
    {
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onhelp([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDBLCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondblclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYDOWN)]
        void onkeydown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYUP)]
        void onkeyup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYPRESS)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onkeypress([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEDOWN)]
        void onmousedown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEMOVE)]
        void onmousemove([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEUP)]
        void onmouseup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOUT)]
        void onmouseout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOVER)]
        void onmouseover([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONREADYSTATECHANGE)]
        void onreadystatechange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONAFTERUPDATE)]
        void onafterupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWEXIT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onrowexit([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWENTER)]
        void onrowenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDRAGSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSELECTSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onselectstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONERRORUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onerrorupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCONTEXTMENU)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontextmenu([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSTOP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onstop([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWSDELETE)]
        void onrowsdelete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWSINSERTED)]
        void onrowsinserted([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCELLCHANGE)]
        void oncellchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONPROPERTYCHANGE)]
        void onpropertychange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCHANGED)]
        void ondatasetchanged([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATAAVAILABLE)]
        void ondataavailable([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCOMPLETE)]
        void ondatasetcomplete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREEDITFOCUS)]
        void onbeforeeditfocus([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSELECTIONCHANGE)]
        void onselectionchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCONTROLSELECT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontrolselect([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEWHEEL)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmousewheel([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSIN)]
        void onfocusin([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSOUT)]
        void onfocusout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONACTIVATE)]
        void onactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDEACTIVATE)]
        void ondeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREDEACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforedeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }

    #endregion
}