using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLControlRange interfaces
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f29c-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLControlRange
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_SELECT)]
        void select();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_ADD)]
        void add([MarshalAs(UnmanagedType.Interface)] IHTMLControlElement item);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_REMOVE)]
        void remove(int index);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_ITEM)]
        IHTMLElement item(int index);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_SCROLLINTOVIEW)]
        void scrollIntoView(object varargStart);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDSUPPORTED)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandSupported([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDENABLED)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandEnabled([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDSTATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandState([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDINDETERM)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandIndeterm([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDTEXT)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string queryCommandText([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDVALUE)]
        object queryCommandValue([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_EXECCOMMAND)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommand([MarshalAs(UnmanagedType.BStr)] string cmdID, [MarshalAs(UnmanagedType.VariantBool)] bool showUI, object value);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_EXECCOMMANDSHOWHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommandShowHelp([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_COMMONPARENTELEMENT)]
        IHTMLElement commonParentElement();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_LENGTH)]
        int length { get;}
    }
    #endregion
}