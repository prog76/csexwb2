using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDocument3 Interface
    /// <summary><para><c>IHTMLDocument3</c> interface.</para></summary>
    [Guid("3050F485-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDocument3
    {
        /// <summary><para><c>releaseCapture</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>releaseCapture</c> method was the following:  <c>HRESULT releaseCapture (void)</c>;</para></remarks>
        // IDL: HRESULT releaseCapture (void);
        // VB6: Sub releaseCapture
        [DispId(1072)]
        void releaseCapture();

        /// <summary><para><c>recalc</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>recalc</c> method was the following:  <c>HRESULT recalc ([optional, defaultvalue(0)] VARIANT_BOOL fForce)</c>;</para></remarks>
        // IDL: HRESULT recalc ([optional, defaultvalue(0)] VARIANT_BOOL fForce);
        // VB6: Sub recalc ([ByVal fForce As Boolean = False])
        [DispId(1073)]
        void recalc([MarshalAs(UnmanagedType.VariantBool)] bool fForce);

        /// <summary><para><c>createTextNode</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createTextNode</c> method was the following:  <c>HRESULT createTextNode (BSTR text, [out, retval] IHTMLDOMNode** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createTextNode (BSTR text, [out, retval] IHTMLDOMNode** ReturnValue);
        // VB6: Function createTextNode (ByVal text As String) As IHTMLDOMNode
        [DispId(1074)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLDOMNode
        object createTextNode([MarshalAs(UnmanagedType.BStr)] string text);

        /// <summary><para><c>attachEvent</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>attachEvent</c> method was the following:  <c>HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function attachEvent (ByVal event As String, ByVal pdisp As IDispatch) As Boolean
        [DispId(-2147417605)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool attachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>detachEvent</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>detachEvent</c> method was the following:  <c>HRESULT detachEvent (BSTR event, IDispatch* pdisp)</c>;</para></remarks>
        // IDL: HRESULT detachEvent (BSTR event, IDispatch* pdisp);
        // VB6: Sub detachEvent (ByVal event As String, ByVal pdisp As IDispatch)
        [DispId(-2147417604)]
        void detachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>createDocumentFragment</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createDocumentFragment</c> method was the following:  <c>HRESULT createDocumentFragment ([out, retval] IHTMLDocument2** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createDocumentFragment ([out, retval] IHTMLDocument2** ReturnValue);
        // VB6: Function createDocumentFragment As IHTMLDocument2
        [DispId(1076)]
        IHTMLDocument2 createDocumentFragment();

        /// <summary><para><c>getElementsByName</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementsByName</c> method was the following:  <c>HRESULT getElementsByName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementsByName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue);
        // VB6: Function getElementsByName (ByVal v As String) As IHTMLElementCollection
        [DispId(1086)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
        object getElementsByName([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>getElementById</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementById</c> method was the following:  <c>HRESULT getElementById (BSTR v, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementById (BSTR v, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function getElementById (ByVal v As String) As IHTMLElement
        [DispId(1088)]
        IHTMLElement getElementById([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>getElementsByTagName</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementsByTagName</c> method was the following:  <c>HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue);
        // VB6: Function getElementsByTagName (ByVal v As String) As IHTMLElementCollection
        [DispId(1087)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
        object getElementsByTagName([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>baseUrl</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>baseUrl</c> property was the following:  <c>BSTR baseUrl</c>;</para></remarks>
        // IDL: BSTR baseUrl;
        // VB6: baseUrl As String
        string baseUrl
        {
            // IDL: HRESULT baseUrl ([out, retval] BSTR* ReturnValue);
            // VB6: Function baseUrl As String
            [DispId(1080)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT baseUrl (BSTR value);
            // VB6: Sub baseUrl (ByVal value As String)
            [DispId(1080)]
            set;
        }

        /// <summary><para><c>childNodes</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>childNodes</c> property was the following:  <c>IDispatch* childNodes</c>;</para></remarks>
        // IDL: IDispatch* childNodes;
        // VB6: childNodes As IDispatch
        object childNodes
        {
            // IDL: HRESULT childNodes ([out, retval] IDispatch** ReturnValue);
            // VB6: Function childNodes As IDispatch
            [DispId(-2147417063)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>dir</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>dir</c> property was the following:  <c>BSTR dir</c>;</para></remarks>
        // IDL: BSTR dir;
        // VB6: dir As String
        string dir
        {
            // IDL: HRESULT dir ([out, retval] BSTR* ReturnValue);
            // VB6: Function dir As String
            [DispId(-2147412995)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT dir (BSTR value);
            // VB6: Sub dir (ByVal value As String)
            [DispId(-2147412995)]
            set;
        }

        /// <summary><para><c>documentElement</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>documentElement</c> property was the following:  <c>IHTMLElement* documentElement</c>;</para></remarks>
        // IDL: IHTMLElement* documentElement;
        // VB6: documentElement As IHTMLElement
        IHTMLElement documentElement
        {
            // IDL: HRESULT documentElement ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function documentElement As IHTMLElement
            [DispId(1075)]
            get;
        }

        /// <summary><para><c>enableDownload</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>enableDownload</c> property was the following:  <c>VARIANT_BOOL enableDownload</c>;</para></remarks>
        // IDL: VARIANT_BOOL enableDownload;
        // VB6: enableDownload As Boolean
        bool enableDownload
        {
            // IDL: HRESULT enableDownload ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function enableDownload As Boolean
            [DispId(1079)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT enableDownload (VARIANT_BOOL value);
            // VB6: Sub enableDownload (ByVal value As Boolean)
            [DispId(1079)]
            set;
        }

        /// <summary><para><c>inheritStyleSheets</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>inheritStyleSheets</c> property was the following:  <c>VARIANT_BOOL inheritStyleSheets</c>;</para></remarks>
        // IDL: VARIANT_BOOL inheritStyleSheets;
        // VB6: inheritStyleSheets As Boolean
        bool inheritStyleSheets
        {
            // IDL: HRESULT inheritStyleSheets ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function inheritStyleSheets As Boolean
            [DispId(1082)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT inheritStyleSheets (VARIANT_BOOL value);
            // VB6: Sub inheritStyleSheets (ByVal value As Boolean)
            [DispId(1082)]
            set;
        }

        /// <summary><para><c>onbeforeeditfocus</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeeditfocus</c> property was the following:  <c>VARIANT onbeforeeditfocus</c>;</para></remarks>
        // IDL: VARIANT onbeforeeditfocus;
        // VB6: onbeforeeditfocus As Any
        object onbeforeeditfocus
        {
            // IDL: HRESULT onbeforeeditfocus ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeeditfocus As Any
            [DispId(-2147412043)]
            get;
            // IDL: HRESULT onbeforeeditfocus (VARIANT value);
            // VB6: Sub onbeforeeditfocus (ByVal value As Any)
            [DispId(-2147412043)]
            set;
        }

        /// <summary><para><c>oncellchange</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncellchange</c> property was the following:  <c>VARIANT oncellchange</c>;</para></remarks>
        // IDL: VARIANT oncellchange;
        // VB6: oncellchange As Any
        object oncellchange
        {
            // IDL: HRESULT oncellchange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncellchange As Any
            [DispId(-2147412048)]
            get;
            // IDL: HRESULT oncellchange (VARIANT value);
            // VB6: Sub oncellchange (ByVal value As Any)
            [DispId(-2147412048)]
            set;
        }

        /// <summary><para><c>oncontextmenu</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncontextmenu</c> property was the following:  <c>VARIANT oncontextmenu</c>;</para></remarks>
        // IDL: VARIANT oncontextmenu;
        // VB6: oncontextmenu As Any
        object oncontextmenu
        {
            // IDL: HRESULT oncontextmenu ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncontextmenu As Any
            [DispId(-2147412047)]
            get;
            // IDL: HRESULT oncontextmenu (VARIANT value);
            // VB6: Sub oncontextmenu (ByVal value As Any)
            [DispId(-2147412047)]
            set;
        }

        /// <summary><para><c>ondataavailable</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondataavailable</c> property was the following:  <c>VARIANT ondataavailable</c>;</para></remarks>
        // IDL: VARIANT ondataavailable;
        // VB6: ondataavailable As Any
        object ondataavailable
        {
            // IDL: HRESULT ondataavailable ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondataavailable As Any
            [DispId(-2147412071)]
            get;
            // IDL: HRESULT ondataavailable (VARIANT value);
            // VB6: Sub ondataavailable (ByVal value As Any)
            [DispId(-2147412071)]
            set;
        }

        /// <summary><para><c>ondatasetchanged</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondatasetchanged</c> property was the following:  <c>VARIANT ondatasetchanged</c>;</para></remarks>
        // IDL: VARIANT ondatasetchanged;
        // VB6: ondatasetchanged As Any
        object ondatasetchanged
        {
            // IDL: HRESULT ondatasetchanged ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondatasetchanged As Any
            [DispId(-2147412072)]
            get;
            // IDL: HRESULT ondatasetchanged (VARIANT value);
            // VB6: Sub ondatasetchanged (ByVal value As Any)
            [DispId(-2147412072)]
            set;
        }

        /// <summary><para><c>ondatasetcomplete</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondatasetcomplete</c> property was the following:  <c>VARIANT ondatasetcomplete</c>;</para></remarks>
        // IDL: VARIANT ondatasetcomplete;
        // VB6: ondatasetcomplete As Any
        object ondatasetcomplete
        {
            // IDL: HRESULT ondatasetcomplete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondatasetcomplete As Any
            [DispId(-2147412070)]
            get;
            // IDL: HRESULT ondatasetcomplete (VARIANT value);
            // VB6: Sub ondatasetcomplete (ByVal value As Any)
            [DispId(-2147412070)]
            set;
        }

        /// <summary><para><c>onpropertychange</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpropertychange</c> property was the following:  <c>VARIANT onpropertychange</c>;</para></remarks>
        // IDL: VARIANT onpropertychange;
        // VB6: onpropertychange As Any
        object onpropertychange
        {
            // IDL: HRESULT onpropertychange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpropertychange As Any
            [DispId(-2147412065)]
            get;
            // IDL: HRESULT onpropertychange (VARIANT value);
            // VB6: Sub onpropertychange (ByVal value As Any)
            [DispId(-2147412065)]
            set;
        }

        /// <summary><para><c>onrowsdelete</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowsdelete</c> property was the following:  <c>VARIANT onrowsdelete</c>;</para></remarks>
        // IDL: VARIANT onrowsdelete;
        // VB6: onrowsdelete As Any
        object onrowsdelete
        {
            // IDL: HRESULT onrowsdelete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowsdelete As Any
            [DispId(-2147412050)]
            get;
            // IDL: HRESULT onrowsdelete (VARIANT value);
            // VB6: Sub onrowsdelete (ByVal value As Any)
            [DispId(-2147412050)]
            set;
        }

        /// <summary><para><c>onrowsinserted</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowsinserted</c> property was the following:  <c>VARIANT onrowsinserted</c>;</para></remarks>
        // IDL: VARIANT onrowsinserted;
        // VB6: onrowsinserted As Any
        object onrowsinserted
        {
            // IDL: HRESULT onrowsinserted ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowsinserted As Any
            [DispId(-2147412049)]
            get;
            // IDL: HRESULT onrowsinserted (VARIANT value);
            // VB6: Sub onrowsinserted (ByVal value As Any)
            [DispId(-2147412049)]
            set;
        }

        /// <summary><para><c>onstop</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onstop</c> property was the following:  <c>VARIANT onstop</c>;</para></remarks>
        // IDL: VARIANT onstop;
        // VB6: onstop As Any
        object onstop
        {
            // IDL: HRESULT onstop ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onstop As Any
            [DispId(-2147412044)]
            get;
            // IDL: HRESULT onstop (VARIANT value);
            // VB6: Sub onstop (ByVal value As Any)
            [DispId(-2147412044)]
            set;
        }

        /// <summary><para><c>parentDocument</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentDocument</c> property was the following:  <c>IHTMLDocument2* parentDocument</c>;</para></remarks>
        // IDL: IHTMLDocument2* parentDocument;
        // VB6: parentDocument As IHTMLDocument2
        IHTMLDocument2 parentDocument
        {
            // IDL: HRESULT parentDocument ([out, retval] IHTMLDocument2** ReturnValue);
            // VB6: Function parentDocument As IHTMLDocument2
            [DispId(1078)]
            get;
        }

        /// <summary><para><c>uniqueID</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>uniqueID</c> property was the following:  <c>BSTR uniqueID</c>;</para></remarks>
        // IDL: BSTR uniqueID;
        // VB6: uniqueID As String
        string uniqueID
        {
            // IDL: HRESULT uniqueID ([out, retval] BSTR* ReturnValue);
            // VB6: Function uniqueID As String
            [DispId(1077)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }
    }
    #endregion
}