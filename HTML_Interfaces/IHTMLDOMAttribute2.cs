using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDOMAttribute2 Interface

    [ComImport, ComVisible(true), Guid("3050f810-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMAttribute2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_NAME)]
        string name { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_VALUE)]
        string value { set;  [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_EXPANDO)]
        bool expando { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_NODETYPE)]
        int nodeType { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_PARENTNODE)]
        IHTMLDOMNode parentNode { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_CHILDNODES)]
        object childNodes { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_FIRSTCHILD)]
        IHTMLDOMNode firstChild { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_LASTCHILD)]
        IHTMLDOMNode lastChild { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_PREVIOUSSIBLING)]
        IHTMLDOMNode previousSibling { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_NEXTSIBLING)]
        IHTMLDOMNode nextSibling { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_ATTRIBUTES)]
        object attributes { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_OWNERDOCUMENT)]
        object ownerDocument { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_INSERTBEFORE)]
        IHTMLDOMNode insertBefore([In] IHTMLDOMNode newChild, [In] object refChild);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_REPLACECHILD)]
        IHTMLDOMNode replaceChild([In] IHTMLDOMNode newChild);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_REMOVECHILD)]
        IHTMLDOMNode removeChild([In] IHTMLDOMNode oldChild);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_APPENDCHILD)]
        IHTMLDOMNode appendChild([In] IHTMLDOMNode newChild);

        [return: MarshalAs(UnmanagedType.VariantBool)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_HASCHILDNODES)]
        bool hasChildNodes();

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_CLONENODE)]
        IHTMLDOMAttribute cloneNode([In] bool fDeep);
    }
    #endregion
}