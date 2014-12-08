using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f3db-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLCurrentStyle
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_POSITION)]
        string position { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_STYLEFLOAT)]
        string styleFloat { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_COLOR)]
        object color { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BACKGROUNDCOLOR)]
        object backgroundColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_FONTFAMILY)]
        string fontFamily { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_FONTSTYLE)]
        string fontStyle { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_FONTVARIANT)]
        string fontVariant { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_FONTWEIGHT)]
        object fontWeight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_FONTSIZE)]
        object fontSize { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BACKGROUNDIMAGE)]
        string backgroundImage { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BACKGROUNDPOSITIONX)]
        object backgroundPositionX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BACKGROUNDPOSITIONY)]
        object backgroundPositionY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BACKGROUNDREPEAT)]
        string backgroundRepeat { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERLEFTCOLOR)]
        object borderLeftColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERTOPCOLOR)]
        object borderTopColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERRIGHTCOLOR)]
        object borderRightColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERBOTTOMCOLOR)]
        object borderBottomColor { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERTOPSTYLE)]
        string borderTopStyle { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERRIGHTSTYLE)]
        string borderRightStyle { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERBOTTOMSTYLE)]
        string borderBottomStyle { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERLEFTSTYLE)]
        string borderLeftStyle { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERTOPWIDTH)]
        object borderTopWidth { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERRIGHTWIDTH)]
        object borderRightWidth { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERBOTTOMWIDTH)]
        object borderBottomWidth { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERLEFTWIDTH)]
        object borderLeftWidth { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LEFT)]
        object left { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TOP)]
        object top { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_WIDTH)]
        object width { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_HEIGHT)]
        object height { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PADDINGLEFT)]
        object paddingLeft { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PADDINGTOP)]
        object paddingTop { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PADDINGRIGHT)]
        object paddingRight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PADDINGBOTTOM)]
        object paddingBottom { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTALIGN)]
        string textAlign { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTDECORATION)]
        string textDecoration { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_DISPLAY)]
        string display { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_VISIBILITY)]
        string visibility { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_ZINDEX)]
        object zIndex { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LETTERSPACING)]
        object letterSpacing { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LINEHEIGHT)]
        object lineHeight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTINDENT)]
        object textIndent { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_VERTICALALIGN)]
        object verticalAlign { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BACKGROUNDATTACHMENT)]
        string backgroundAttachment { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_MARGINTOP)]
        object marginTop { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_MARGINRIGHT)]
        object marginRight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_MARGINBOTTOM)]
        object marginBottom { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_MARGINLEFT)]
        object marginLeft { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_CLEAR)]
        string clear { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LISTSTYLETYPE)]
        string listStyleType { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LISTSTYLEPOSITION)]
        string listStylePosition { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LISTSTYLEIMAGE)]
        string listStyleImage { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_CLIPTOP)]
        object clipTop { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_CLIPRIGHT)]
        object clipRight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_CLIPBOTTOM)]
        object clipBottom { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_CLIPLEFT)]
        object clipLeft { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_OVERFLOW)]
        string overflow { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PAGEBREAKBEFORE)]
        string pageBreakBefore { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PAGEBREAKAFTER)]
        string pageBreakAfter { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_CURSOR)]
        string cursor { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TABLELAYOUT)]
        string tableLayout { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERCOLLAPSE)]
        string borderCollapse { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_DIRECTION)]
        string direction { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BEHAVIOR)]
        string behavior { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_GETATTRIBUTE)]
        object getAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_UNICODEBIDI)]
        string unicodeBidi { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_RIGHT)]
        object right { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BOTTOM)]
        object bottom { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_IMEMODE)]
        string imeMode { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_RUBYALIGN)]
        string rubyAlign { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_RUBYPOSITION)]
        string rubyPosition { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_RUBYOVERHANG)]
        string rubyOverhang { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTAUTOSPACE)]
        string textAutospace { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LINEBREAK)]
        string lineBreak { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_WORDBREAK)]
        string wordBreak { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTJUSTIFY)]
        string textJustify { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTJUSTIFYTRIM)]
        string textJustifyTrim { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTKASHIDA)]
        object textKashida { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BLOCKDIRECTION)]
        string blockDirection { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LAYOUTGRIDCHAR)]
        object layoutGridChar { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LAYOUTGRIDLINE)]
        object layoutGridLine { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LAYOUTGRIDMODE)]
        string layoutGridMode { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_LAYOUTGRIDTYPE)]
        string layoutGridType { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERSTYLE)]
        string borderStyle { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERCOLOR)]
        string borderColor { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_BORDERWIDTH)]
        string borderWidth { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_PADDING)]
        string padding { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_MARGIN)]
        string margin { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_ACCELERATOR)]
        string accelerator { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_OVERFLOWX)]
        string overflowX { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_OVERFLOWY)]
        string overflowY { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCURRENTSTYLE_TEXTTRANSFORM)]
        string textTransform { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
