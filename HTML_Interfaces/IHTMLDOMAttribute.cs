using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDOMAttribute Interface
    [ComImport, ComVisible(true), Guid("3050f4b0-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMAttribute
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE_NODENAME)]
        string nodeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE_NODEVALUE)]
        object nodeValue { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE_SPECIFIED)]
        bool specified { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
    }
    #endregion
}