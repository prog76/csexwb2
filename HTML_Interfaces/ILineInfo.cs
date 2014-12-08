using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f7e2-98b5-11cf-bb82-00aa00bdce0b")]
    public interface ILineInfo
    {
        //    [propget, id(DISPID_ILINEINFO_X)] HRESULT x([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_ILINEINFO_X)]
        int x { get;}

        //    [propget, id(DISPID_ILINEINFO_BASELINE)] HRESULT baseLine([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_ILINEINFO_BASELINE)]
        int baseLine { get;}

        //    [propget, id(DISPID_ILINEINFO_TEXTDESCENT)] HRESULT textDescent([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_ILINEINFO_TEXTDESCENT)]
        int textDescent { get;}

        //    [propget, id(DISPID_ILINEINFO_TEXTHEIGHT)] HRESULT textHeight([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_ILINEINFO_TEXTHEIGHT)]
        int textHeight { get;}

        //    [propget, id(DISPID_ILINEINFO_LINEDIRECTION)] HRESULT lineDirection([retval, out] LONG * p);
        [DispId(HTMLDispIDs.DISPID_ILINEINFO_LINEDIRECTION)]
        int lineDirection { get;}

    }

}
