using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLCommentElement Interface
    [ComImport, ComVisible(true), Guid("3050f20c-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLCommentElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMMENTELEMENT_TEXT)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLCOMMENTELEMENT_ATOMIC)]
        int atomic { set; get; }
    }
    #endregion
}