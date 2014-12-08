using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHtmlFramesCollection2 Interface

    [ComImport, Guid("332c4426-26cb-11d0-b483-00c04fd90119"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLFramesCollection2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESCOLLECTION2_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object pvarIndex);

        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESCOLLECTION2_LENGTH)]
        int length { get;}
    }

    #endregion
}