using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f818-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLCurrentStyle3
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE3_TEXTOVERFLOW)]
        string textOverflow { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE3_MINHEIGHT)]
        object minHeight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE3_WORDSPACING)]
        object wordSpacing { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE3_WHITESPACE)]
        string whiteSpace { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
