using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f658-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLCurrentStyle2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_LAYOUTFLOW)]
        string layoutFlow { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_WORDWRAP)]
        string wordWrap { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_TEXTUNDERLINEPOSITION)]
        string textUnderlinePosition { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_HASLAYOUT)]
        bool hasLayout { [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARBASECOLOR)]
        object scrollbarBaseColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARFACECOLOR)]
        object scrollbarFaceColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBAR3DLIGHTCOLOR)]
        object scrollbar3dLightColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARSHADOWCOLOR)]
        object scrollbarShadowColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARHIGHLIGHTCOLOR)]
        object scrollbarHighlightColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARDARKSHADOWCOLOR)]
        object scrollbarDarkShadowColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARARROWCOLOR)]
        object scrollbarArrowColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_SCROLLBARTRACKCOLOR)]
        object scrollbarTrackColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_WRITINGMODE)]
        string writingMode { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_ZOOM)]
        object zoom { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_FILTER)]
        string filter { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_TEXTALIGNLAST)]
        string textAlignLast { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_TEXTKASHIDASPACE)]
        object textKashidaSpace { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE2_ISBLOCK)]
        bool isBlock { [return: MarshalAs(UnmanagedType.VariantBool)] get;}
    }

}
