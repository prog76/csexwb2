using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLBaseFontElement Interface
    [ComImport, ComVisible(true), Guid("3050f202-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLBaseFontElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLBASEFONTELEMENT_COLOR)]
        object color { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLBASEFONTELEMENT_FACE)]
        string face { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLBASEFONTELEMENT_SIZE)]
        int size { set; get; }
    }
    #endregion
}