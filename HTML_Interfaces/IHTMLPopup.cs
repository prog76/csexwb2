using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f666-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLPopup
    {
        //    [id(DISPID_IHTMLPOPUP_SHOW)] HRESULT show([in] long x,[in] long y,[in] long w,[in] long h,[in] VARIANT* pElement);
        [DispId(HTMLDispIDs.DISPID_IHTMLPOPUP_SHOW)]
        void show(
            int x,
            int y,
            int w,
            int h,
            object pElement
            );

        //    [id(DISPID_IHTMLPOPUP_HIDE)] HRESULT hide();
        [DispId(HTMLDispIDs.DISPID_IHTMLPOPUP_HIDE)]
        void hide();

        //    [propget, id(DISPID_IHTMLPOPUP_DOCUMENT)] HRESULT document([retval, out] IHTMLDocument* * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLPOPUP_DOCUMENT)]
        IHTMLDocument document { [return: MarshalAs(UnmanagedType.Interface)] get;}

        //    [propget, id(DISPID_IHTMLPOPUP_ISOPEN)] HRESULT isOpen([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLPOPUP_ISOPEN)]
        bool isOpen { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

    }

}
