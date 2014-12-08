using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDocument5 Interface

    [ComImport, ComVisible(true), Guid("3050f80c-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)
    ]
    public interface IHTMLDocument5
    {
        //VARIANT
        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONMOUSEWHEEL)]
        object onmousewheel { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_DOCTYPE)]
        object getDoctype { [return: MarshalAs(UnmanagedType.IDispatch)] get;} //IHTMLDOMNode

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_IMPLEMENTATION)]
        object getImplementation { [return: MarshalAs(UnmanagedType.IDispatch)] get;} //IHTMLDOMImplementation

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_CREATEATTRIBUTE)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object /*IHTMLDOMAttribute*/ createAttribute([In, MarshalAs(UnmanagedType.BStr)] String bstrattrName);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_CREATECOMMENT)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object /*IHTMLDOMNode*/ createComment([In, MarshalAs(UnmanagedType.BStr)] String bstrdata);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONFOCUSIN)]
        object onfocusin { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONFOCUSOUT)]
        object onfocusout { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONACTIVATE)]
        object onactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONDEACTIVATE)]
        object ondeactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONBEFOREACTIVATE)]
        object onbeforeactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONBEFOREDEACTIVATE)]
        object onbeforedeactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_COMPATMODE)]
        String compatMode { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion
}