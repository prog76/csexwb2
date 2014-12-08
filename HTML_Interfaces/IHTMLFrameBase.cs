using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f311-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLFrameBase
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_SRC)]
        string src { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_BORDER)]
        object border { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_FRAMEBORDER)]
        string frameBorder { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_FRAMESPACING)]
        object frameSpacing { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_MARGINWIDTH)]
        object marginWidth { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_MARGINHEIGHT)]
        object marginHeight { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_NORESIZE)]
        bool noResize { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMEBASE_SCROLLING)]
        string scrolling { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

}
