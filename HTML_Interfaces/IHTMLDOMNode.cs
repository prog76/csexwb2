using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDOMNode Interface
    [ComVisible(true), ComImport()]
    [Guid("3050f5da-98b5-11cf-bb82-00aa00bdce0b")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDOMNode
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NODETYPE)]
        int nodeType { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_PARENTNODE)]
        IHTMLDOMNode parentNode { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_HASCHILDNODES)]
        bool hasChildNodes();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_CHILDNODES)]
        IHTMLDOMChildrenCollection childNodes { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_ATTRIBUTES)]
        IHTMLAttributeCollection attributes { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_INSERTBEFORE)]
        IHTMLDOMNode insertBefore([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode newChild, [In, MarshalAs(UnmanagedType.IDispatch)] object refchild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REMOVECHILD)]
        IHTMLDOMNode removeChild([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode oldChild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REPLACECHILD)]
        IHTMLDOMNode replaceChild([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode newChild, [In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode oldChild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_CLONENODE)]
        IHTMLDOMNode cloneNode([In] bool fDeep);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REMOVENODE)]
        IHTMLDOMNode removeNode([In] bool fDeep);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_SWAPNODE)]
        IHTMLDOMNode swapNode([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode otherNode);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REPLACENODE)]
        IHTMLDOMNode replaceNode([In] IHTMLDOMNode replacement);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_APPENDCHILD)]
        IHTMLDOMNode appendChild([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode newChild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NODENAME)]
        String nodeName { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NODEVALUE)]
        Object nodeValue { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_FIRSTCHILD)]
        IHTMLDOMNode firstChild { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_LASTCHILD)]
        IHTMLDOMNode lastChild { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_PREVIOUSSIBLING)]
        IHTMLDOMNode previousSibling { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NEXTSIBLING)]
        IHTMLDOMNode nextSibling { get;}
    }
    #endregion
}