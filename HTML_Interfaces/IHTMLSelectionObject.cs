using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLSelectionObject Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f25A-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLSelectionObject
    {
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_CREATERANGE)]
        object createRange();
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_EMPTY)]
        void empty();
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_CLEAR)]
        void clear();
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_TYPE)]
        string EventType { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion
}