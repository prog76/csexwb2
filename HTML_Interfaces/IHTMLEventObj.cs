using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLEventObj Interface
    //MIDL_INTERFACE("3050f32d-98b5-11cf-bb82-00aa00bdce0b")
    //IHTMLEventObj : public IDispatch
    //{
    //public:
    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_srcElement( 
    //        /* [out][retval] */ IHTMLElement **p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_altKey( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_ctrlKey( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_shiftKey( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propput] */ HRESULT STDMETHODCALLTYPE put_returnValue( 
    //        /* [in] */ VARIANT v) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_returnValue( 
    //        /* [out][retval] */ VARIANT *p) = 0;

    //    virtual /* [id][propput] */ HRESULT STDMETHODCALLTYPE put_cancelBubble( 
    //        /* [in] */ VARIANT_BOOL v) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_cancelBubble( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_fromElement( 
    //        /* [out][retval] */ IHTMLElement **p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_toElement( 
    //        /* [out][retval] */ IHTMLElement **p) = 0;

    //    virtual /* [id][propput] */ HRESULT STDMETHODCALLTYPE put_keyCode( 
    //        /* [in] */ long v) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_keyCode( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_button( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_type( 
    //        /* [out][retval] */ BSTR *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_qualifier( 
    //        /* [out][retval] */ BSTR *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_reason( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_x( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_y( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_clientX( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_clientY( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_offsetX( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_offsetY( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_screenX( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_screenY( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_srcFilter( 
    //        /* [out][retval] */ IDispatch **p) = 0;
    //};
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f32d-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEventObj
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SRCELEMENT)]
        IHTMLElement SrcElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_ALTKEY)]
        bool AltKey { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CTRLKEY)]
        bool CtrlKey { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SHIFTKEY)]
        bool ShiftKey { get;}
        //VARIANT
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_RETURNVALUE)]
        Object ReturnValue { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CANCELBUBBLE)]
        bool CancelBubble { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_FROMELEMENT)]
        IHTMLElement FromElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_TOELEMENT)]
        IHTMLElement ToElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_KEYCODE)]
        int keyCode { set; get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_BUTTON)]
        int Button { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_TYPE)]
        string EventType { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_QUALIFIER)]
        string Qualifier { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_REASON)]
        int Reason { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_X)]
        int X { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_Y)]
        int Y { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CLIENTX)]
        int ClientX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CLIENTY)]
        int ClientY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_OFFSETX)]
        int OffsetX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_OFFSETY)]
        int OffsetY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SCREENX)]
        int ScreenX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SCREENY)]
        int ScreenY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SRCFILTER)]
        object SrcFilter { [return: MarshalAs(UnmanagedType.IDispatch)] get;}
    }
    #endregion
}