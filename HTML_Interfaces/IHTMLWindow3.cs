using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f4ae-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLWindow3 
    {
        //    [propget, id(DISPID_IHTMLWINDOW3_SCREENLEFT)] HRESULT screenLeft([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_SCREENLEFT)] int screenLeft { get;}

        //    [propget, id(DISPID_IHTMLWINDOW3_SCREENTOP)] HRESULT screenTop([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_SCREENTOP)] int screenTop { get;}

        //    [id(DISPID_IHTMLWINDOW3_ATTACHEVENT)] HRESULT attachEvent([in] BSTR event,[in] IDispatch* pDisp,[retval, out] VARIANT_BOOL* pfResult);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_ATTACHEVENT)] [return: MarshalAs(UnmanagedType.VariantBool)]
        bool attachEvent(
            [MarshalAs(UnmanagedType.BStr)] string pevent,
            [MarshalAs(UnmanagedType.IDispatch)] object pDisp
            );

        //    [id(DISPID_IHTMLWINDOW3_DETACHEVENT)] HRESULT detachEvent([in] BSTR event,[in] IDispatch* pDisp);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_DETACHEVENT)] void detachEvent(
            [MarshalAs(UnmanagedType.BStr)] string pevent,
            [MarshalAs(UnmanagedType.IDispatch)] object pDisp
            );

        //    [id(DISPID_IHTMLWINDOW3_SETTIMEOUT)] HRESULT setTimeout([in] VARIANT* expression,[in] long msec,[optional, in] VARIANT* language,[retval, out] long* timerID);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_SETTIMEOUT)] int setTimeout(
            ref object expression,
            int msec,
            ref object language
            );

        //    [id(DISPID_IHTMLWINDOW3_SETINTERVAL)] HRESULT setInterval([in] VARIANT* expression,[in] long msec,[optional, in] VARIANT* language,[retval, out] long* timerID);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_SETINTERVAL)] int setInterval(
            ref object expression,
            int msec,
            ref object language
            );

        //    [id(DISPID_IHTMLWINDOW3_PRINT)] HRESULT print();
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_PRINT)] void print();

        //    [propput, id(DISPID_IHTMLWINDOW3_ONBEFOREPRINT), displaybind, bindable] HRESULT onbeforeprint([in] VARIANT v);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_ONBEFOREPRINT)] object onbeforeprint {set;  get;}

        //    [propput, id(DISPID_IHTMLWINDOW3_ONAFTERPRINT), displaybind, bindable] HRESULT onafterprint([in] VARIANT v);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_ONAFTERPRINT)] object onafterprint {set;  get;}

        //    [propget, id(DISPID_IHTMLWINDOW3_CLIPBOARDDATA)] HRESULT clipboardData([retval, out] IHTMLDataTransfer* * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_CLIPBOARDDATA)] IHTMLDataTransfer clipboardData {[return: MarshalAs(UnmanagedType.Interface)] get;}

        //    [id(DISPID_IHTMLWINDOW3_SHOWMODELESSDIALOG)] HRESULT showModelessDialog([defaultvalue(""), in] BSTR url,[optional, in] VARIANT* varArgIn,[optional, in] VARIANT* options,[retval, out] IHTMLWindow2** pDialog);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW3_SHOWMODELESSDIALOG)] [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLWindow2 showModelessDialog(
            [MarshalAs(UnmanagedType.BStr)] string url,
            ref object varArgIn,
            ref object options
            );

    }

}
