using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f6cf-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLWindow4
    {
        //    [id(DISPID_IHTMLWINDOW4_CREATEPOPUP)] HRESULT createPopup([optional, in] VARIANT* varArgIn,[retval, out] IDispatch** ppPopup);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW4_CREATEPOPUP)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object createPopup(
            object varArgIn //Reserved for future use
            );

        //    [propget, id(DISPID_IHTMLWINDOW4_FRAMEELEMENT)] HRESULT frameElement([retval, out] IHTMLFrameBase* * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW4_FRAMEELEMENT)]
        IHTMLFrameBase frameElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

    }

}
