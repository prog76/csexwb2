using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLHRElement interface
    [ComImport, ComVisible(true), Guid("3050f1f4-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLHRElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_COLOR)]
        object color { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_NOSHADE)]
        bool noShade { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_SIZE)]
        object size { set; get; }
    }
    #endregion
}