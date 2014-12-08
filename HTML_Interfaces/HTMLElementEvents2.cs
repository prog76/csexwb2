using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region HTMLElementEvents2 Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f60f-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLElementEvents2
    {
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onhelp([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondblclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onkeypress([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN)]
        void onkeydown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYUP)]
        void onkeyup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT)]
        void onmouseout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER)]
        void onmouseover([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE)]
        void onmousemove([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN)]
        void onmousedown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP)]
        void onmouseup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART)]
        bool onselectstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE)]
        void onfilterchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE)]
        void onafterupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onerrorupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWEXIT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onrowexit([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWENTER)]
        void onrowenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED)]
        void ondatasetchanged([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE)]
        void ondataavailable([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE)]
        void ondatasetcomplete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE)]
        void onlosecapture([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE)]
        void onpropertychange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSCROLL)]
        void onscroll([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUS)]
        void onfocus([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBLUR)]
        void onblur([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZE)]
        void onresize([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAG)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondrag([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGEND)]
        void ondragend([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragover([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE)]
        void ondragleave([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDROP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondrop([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforecut([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCUT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncut([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforecopy([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCOPY)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncopy([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforepaste([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPASTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onpaste([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontextmenu([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE)]
        void onrowsdelete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED)]
        void onrowsinserted([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE)]
        void oncellchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE)]
        void onreadystatechange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE)]
        void onlayoutcomplete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPAGE)]
        void onpage([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER)]
        void onmouseenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE)]
        void onmouseleave([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONACTIVATE)]
        void onactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE)]
        void ondeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforedeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN)]
        void onfocusin([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT)]
        void onfocusout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVE)]
        void onmove([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontrolselect([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVESTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmovestart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVEEND)]
        void onmoveend([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onresizestart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND)]
        void onresizeend([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmousewheel([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }
    #endregion
}