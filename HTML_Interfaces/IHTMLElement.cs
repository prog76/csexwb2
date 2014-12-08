using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLElement Interface
    /// <summary><para><c>IHTMLElement</c> interface.</para></summary>
    [Guid("3050F1FF-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLElement
    {
        /// <summary><para><c>setAttribute</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setAttribute</c> method was the following:  <c>HRESULT setAttribute (BSTR strAttributeName, VARIANT AttributeValue, [optional, defaultvalue(1)] long lFlags)</c>;</para></remarks>
        // IDL: HRESULT setAttribute (BSTR strAttributeName, VARIANT AttributeValue, [optional, defaultvalue(1)] long lFlags);
        // VB6: Sub setAttribute (ByVal strAttributeName As String, ByVal AttributeValue As Any, [ByVal lFlags As Long = 1])
        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENT_SETATTRIBUTE)] // - 2147417611)]
        void setAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, object AttributeValue, int lFlags);

        /// <summary><para><c>getAttribute</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getAttribute</c> method was the following:  <c>HRESULT getAttribute (BSTR strAttributeName, [optional, defaultvalue(0)] long lFlags, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getAttribute (BSTR strAttributeName, [optional, defaultvalue(0)] long lFlags, [out, retval] VARIANT* ReturnValue);
        // VB6: Function getAttribute (ByVal strAttributeName As String, [ByVal lFlags As Long = 0]) As Any
        [DispId(-2147417610)]
        object getAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        /// <summary><para><c>removeAttribute</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeAttribute</c> method was the following:  <c>HRESULT removeAttribute (BSTR strAttributeName, [optional, defaultvalue(1)] long lFlags, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeAttribute (BSTR strAttributeName, [optional, defaultvalue(1)] long lFlags, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeAttribute (ByVal strAttributeName As String, [ByVal lFlags As Long = 1]) As Boolean
        [DispId(-2147417609)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        /// <summary><para><c>scrollIntoView</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollIntoView</c> method was the following:  <c>HRESULT scrollIntoView ([optional] VARIANT varargStart)</c>;</para></remarks>
        // IDL: HRESULT scrollIntoView ([optional] VARIANT varargStart);
        // VB6: Sub scrollIntoView ([ByVal varargStart As Any])
        [DispId(-2147417093)]
        void scrollIntoView(object varargStart);

        /// <summary><para><c>contains</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>contains</c> method was the following:  <c>HRESULT contains (IHTMLElement* pChild, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT contains (IHTMLElement* pChild, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function contains (ByVal pChild As IHTMLElement) As Boolean
        [DispId(-2147417092)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool contains(IHTMLElement pChild);

        /// <summary><para><c>insertAdjacentHTML</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>insertAdjacentHTML</c> method was the following:  <c>HRESULT insertAdjacentHTML (BSTR where, BSTR html)</c>;</para></remarks>
        // IDL: HRESULT insertAdjacentHTML (BSTR where, BSTR html);
        // VB6: Sub insertAdjacentHTML (ByVal where As String, ByVal html As String)
        [DispId(-2147417082)]
        void insertAdjacentHTML([MarshalAs(UnmanagedType.BStr)] string where, [MarshalAs(UnmanagedType.BStr)] string html);

        /// <summary><para><c>insertAdjacentText</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>insertAdjacentText</c> method was the following:  <c>HRESULT insertAdjacentText (BSTR where, BSTR text)</c>;</para></remarks>
        // IDL: HRESULT insertAdjacentText (BSTR where, BSTR text);
        // VB6: Sub insertAdjacentText (ByVal where As String, ByVal text As String)
        [DispId(-2147417081)]
        void insertAdjacentText([MarshalAs(UnmanagedType.BStr)] string where, [MarshalAs(UnmanagedType.BStr)] string text);

        /// <summary><para><c>click</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>click</c> method was the following:  <c>HRESULT click (void)</c>;</para></remarks>
        // IDL: HRESULT click (void);
        // VB6: Sub click
        [DispId(-2147417079)]
        void click();

        /// <summary><para><c>toString</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>toString</c> method was the following:  <c>HRESULT toString ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT toString ([out, retval] BSTR* ReturnValue);
        // VB6: Function toString As String
        [DispId(-2147417076)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        /// <summary><para><c>all</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>all</c> property was the following:  <c>IDispatch* all</c>;</para></remarks>
        // IDL: IDispatch* all;
        // VB6: all As IDispatch
        object all
        {
            // IDL: HRESULT all ([out, retval] IDispatch** ReturnValue);
            // VB6: Function all As IDispatch
            [DispId(-2147417074)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>children</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>children</c> property was the following:  <c>IDispatch* children</c>;</para></remarks>
        // IDL: IDispatch* children;
        // VB6: children As IDispatch
        object children
        {
            // IDL: HRESULT children ([out, retval] IDispatch** ReturnValue);
            // VB6: Function children As IDispatch
            [DispId(-2147417075)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>className</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>className</c> property was the following:  <c>BSTR className</c>;</para></remarks>
        // IDL: BSTR className;
        // VB6: className As String
        string className
        {
            // IDL: HRESULT className ([out, retval] BSTR* ReturnValue);
            // VB6: Function className As String
            [DispId(-2147417111)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT className (BSTR value);
            // VB6: Sub className (ByVal value As String)
            [DispId(-2147417111)]
            set;
        }

        /// <summary><para><c>document</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>document</c> property was the following:  <c>IDispatch* document</c>;</para></remarks>
        // IDL: IDispatch* document;
        // VB6: document As IDispatch
        object document
        {
            // IDL: HRESULT document ([out, retval] IDispatch** ReturnValue);
            // VB6: Function document As IDispatch
            [DispId(-2147417094)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>filters</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>filters</c> property was the following:  <c>IHTMLFiltersCollection* filters</c>;</para></remarks>
        // IDL: IHTMLFiltersCollection* filters;
        // VB6: filters As IHTMLFiltersCollection
        //IHTMLFiltersCollection filters
        object filters
        {
            // IDL: HRESULT filters ([out, retval] IHTMLFiltersCollection** ReturnValue);
            // VB6: Function filters As IHTMLFiltersCollection
            [DispId(-2147417077)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        /// <summary><para><c>id</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>id</c> property was the following:  <c>BSTR id</c>;</para></remarks>
        // IDL: BSTR id;
        // VB6: id As String
        string id
        {
            // IDL: HRESULT id ([out, retval] BSTR* ReturnValue);
            // VB6: Function id As String
            [DispId(-2147417110)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT id (BSTR value);
            // VB6: Sub id (ByVal value As String)
            [DispId(-2147417110)]
            set;
        }

        /// <summary><para><c>innerHTML</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>innerHTML</c> property was the following:  <c>BSTR innerHTML</c>;</para></remarks>
        // IDL: BSTR innerHTML;
        // VB6: innerHTML As String
        string innerHTML
        {
            // IDL: HRESULT innerHTML ([out, retval] BSTR* ReturnValue);
            // VB6: Function innerHTML As String
            [DispId(-2147417086)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT innerHTML (BSTR value);
            // VB6: Sub innerHTML (ByVal value As String)
            [DispId(-2147417086)]
            set;
        }

        /// <summary><para><c>innerText</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>innerText</c> property was the following:  <c>BSTR innerText</c>;</para></remarks>
        // IDL: BSTR innerText;
        // VB6: innerText As String
        string innerText
        {
            // IDL: HRESULT innerText ([out, retval] BSTR* ReturnValue);
            // VB6: Function innerText As String
            [DispId(-2147417085)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT innerText (BSTR value);
            // VB6: Sub innerText (ByVal value As String)
            [DispId(-2147417085)]
            set;
        }

        /// <summary><para><c>isTextEdit</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isTextEdit</c> property was the following:  <c>VARIANT_BOOL isTextEdit</c>;</para></remarks>
        // IDL: VARIANT_BOOL isTextEdit;
        // VB6: isTextEdit As Boolean
        bool isTextEdit
        {
            // IDL: HRESULT isTextEdit ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isTextEdit As Boolean
            [DispId(-2147417078)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>lang</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>lang</c> property was the following:  <c>BSTR lang</c>;</para></remarks>
        // IDL: BSTR lang;
        // VB6: lang As String
        string lang
        {
            // IDL: HRESULT lang ([out, retval] BSTR* ReturnValue);
            // VB6: Function lang As String
            [DispId(-2147413103)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT lang (BSTR value);
            // VB6: Sub lang (ByVal value As String)
            [DispId(-2147413103)]
            set;
        }

        /// <summary><para><c>language</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>language</c> property was the following:  <c>BSTR language</c>;</para></remarks>
        // IDL: BSTR language;
        // VB6: language As String
        string language
        {
            // IDL: HRESULT language ([out, retval] BSTR* ReturnValue);
            // VB6: Function language As String
            [DispId(-2147413012)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT language (BSTR value);
            // VB6: Sub language (ByVal value As String)
            [DispId(-2147413012)]
            set;
        }

        /// <summary><para><c>offsetHeight</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetHeight</c> property was the following:  <c>long offsetHeight</c>;</para></remarks>
        // IDL: long offsetHeight;
        // VB6: offsetHeight As Long
        int offsetHeight
        {
            // IDL: HRESULT offsetHeight ([out, retval] long* ReturnValue);
            // VB6: Function offsetHeight As Long
            [DispId(-2147417101)]
            get;
        }

        /// <summary><para><c>offsetLeft</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetLeft</c> property was the following:  <c>long offsetLeft</c>;</para></remarks>
        // IDL: long offsetLeft;
        // VB6: offsetLeft As Long
        int offsetLeft
        {
            // IDL: HRESULT offsetLeft ([out, retval] long* ReturnValue);
            // VB6: Function offsetLeft As Long
            [DispId(-2147417104)]
            get;
        }

        /// <summary><para><c>offsetParent</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetParent</c> property was the following:  <c>IHTMLElement* offsetParent</c>;</para></remarks>
        // IDL: IHTMLElement* offsetParent;
        // VB6: offsetParent As IHTMLElement
        IHTMLElement offsetParent
        {
            // IDL: HRESULT offsetParent ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function offsetParent As IHTMLElement
            [DispId(-2147417100)]
            get;
        }

        /// <summary><para><c>offsetTop</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetTop</c> property was the following:  <c>long offsetTop</c>;</para></remarks>
        // IDL: long offsetTop;
        // VB6: offsetTop As Long
        int offsetTop
        {
            // IDL: HRESULT offsetTop ([out, retval] long* ReturnValue);
            // VB6: Function offsetTop As Long
            [DispId(-2147417103)]
            get;
        }

        /// <summary><para><c>offsetWidth</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetWidth</c> property was the following:  <c>long offsetWidth</c>;</para></remarks>
        // IDL: long offsetWidth;
        // VB6: offsetWidth As Long
        int offsetWidth
        {
            // IDL: HRESULT offsetWidth ([out, retval] long* ReturnValue);
            // VB6: Function offsetWidth As Long
            [DispId(-2147417102)]
            get;
        }

        /// <summary><para><c>onafterupdate</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onafterupdate</c> property was the following:  <c>VARIANT onafterupdate</c>;</para></remarks>
        // IDL: VARIANT onafterupdate;
        // VB6: onafterupdate As Any
        object onafterupdate
        {
            // IDL: HRESULT onafterupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onafterupdate As Any
            [DispId(-2147412090)]
            get;
            // IDL: HRESULT onafterupdate (VARIANT value);
            // VB6: Sub onafterupdate (ByVal value As Any)
            [DispId(-2147412090)]
            set;
        }

        /// <summary><para><c>onbeforeupdate</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeupdate</c> property was the following:  <c>VARIANT onbeforeupdate</c>;</para></remarks>
        // IDL: VARIANT onbeforeupdate;
        // VB6: onbeforeupdate As Any
        object onbeforeupdate
        {
            // IDL: HRESULT onbeforeupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeupdate As Any
            [DispId(-2147412091)]
            get;
            // IDL: HRESULT onbeforeupdate (VARIANT value);
            // VB6: Sub onbeforeupdate (ByVal value As Any)
            [DispId(-2147412091)]
            set;
        }

        /// <summary><para><c>onclick</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onclick</c> property was the following:  <c>VARIANT onclick</c>;</para></remarks>
        // IDL: VARIANT onclick;
        // VB6: onclick As Any
        object onclick
        {
            // IDL: HRESULT onclick ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onclick As Any
            [DispId(-2147412104)]
            get;
            // IDL: HRESULT onclick (VARIANT value);
            // VB6: Sub onclick (ByVal value As Any)
            [DispId(-2147412104)]
            set;
        }

        /// <summary><para><c>ondataavailable</c> property of <c>IHTMLElement</c> interface.</para></summary>
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

        /// <summary><para><c>ondatasetchanged</c> property of <c>IHTMLElement</c> interface.</para></summary>
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

        /// <summary><para><c>ondatasetcomplete</c> property of <c>IHTMLElement</c> interface.</para></summary>
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

        /// <summary><para><c>ondblclick</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondblclick</c> property was the following:  <c>VARIANT ondblclick</c>;</para></remarks>
        // IDL: VARIANT ondblclick;
        // VB6: ondblclick As Any
        object ondblclick
        {
            // IDL: HRESULT ondblclick ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondblclick As Any
            [DispId(-2147412103)]
            get;
            // IDL: HRESULT ondblclick (VARIANT value);
            // VB6: Sub ondblclick (ByVal value As Any)
            [DispId(-2147412103)]
            set;
        }

        /// <summary><para><c>ondragstart</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragstart</c> property was the following:  <c>VARIANT ondragstart</c>;</para></remarks>
        // IDL: VARIANT ondragstart;
        // VB6: ondragstart As Any
        object ondragstart
        {
            // IDL: HRESULT ondragstart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragstart As Any
            [DispId(-2147412077)]
            get;
            // IDL: HRESULT ondragstart (VARIANT value);
            // VB6: Sub ondragstart (ByVal value As Any)
            [DispId(-2147412077)]
            set;
        }

        /// <summary><para><c>onerrorupdate</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onerrorupdate</c> property was the following:  <c>VARIANT onerrorupdate</c>;</para></remarks>
        // IDL: VARIANT onerrorupdate;
        // VB6: onerrorupdate As Any
        object onerrorupdate
        {
            // IDL: HRESULT onerrorupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onerrorupdate As Any
            [DispId(-2147412074)]
            get;
            // IDL: HRESULT onerrorupdate (VARIANT value);
            // VB6: Sub onerrorupdate (ByVal value As Any)
            [DispId(-2147412074)]
            set;
        }

        /// <summary><para><c>onfilterchange</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onfilterchange</c> property was the following:  <c>VARIANT onfilterchange</c>;</para></remarks>
        // IDL: VARIANT onfilterchange;
        // VB6: onfilterchange As Any
        object onfilterchange
        {
            // IDL: HRESULT onfilterchange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onfilterchange As Any
            [DispId(-2147412069)]
            get;
            // IDL: HRESULT onfilterchange (VARIANT value);
            // VB6: Sub onfilterchange (ByVal value As Any)
            [DispId(-2147412069)]
            set;
        }

        /// <summary><para><c>onhelp</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onhelp</c> property was the following:  <c>VARIANT onhelp</c>;</para></remarks>
        // IDL: VARIANT onhelp;
        // VB6: onhelp As Any
        object onhelp
        {
            // IDL: HRESULT onhelp ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onhelp As Any
            [DispId(-2147412099)]
            get;
            // IDL: HRESULT onhelp (VARIANT value);
            // VB6: Sub onhelp (ByVal value As Any)
            [DispId(-2147412099)]
            set;
        }

        /// <summary><para><c>onkeydown</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeydown</c> property was the following:  <c>VARIANT onkeydown</c>;</para></remarks>
        // IDL: VARIANT onkeydown;
        // VB6: onkeydown As Any
        object onkeydown
        {
            // IDL: HRESULT onkeydown ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeydown As Any
            [DispId(-2147412107)]
            get;
            // IDL: HRESULT onkeydown (VARIANT value);
            // VB6: Sub onkeydown (ByVal value As Any)
            [DispId(-2147412107)]
            set;
        }

        /// <summary><para><c>onkeypress</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeypress</c> property was the following:  <c>VARIANT onkeypress</c>;</para></remarks>
        // IDL: VARIANT onkeypress;
        // VB6: onkeypress As Any
        object onkeypress
        {
            // IDL: HRESULT onkeypress ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeypress As Any
            [DispId(-2147412105)]
            get;
            // IDL: HRESULT onkeypress (VARIANT value);
            // VB6: Sub onkeypress (ByVal value As Any)
            [DispId(-2147412105)]
            set;
        }

        /// <summary><para><c>onkeyup</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeyup</c> property was the following:  <c>VARIANT onkeyup</c>;</para></remarks>
        // IDL: VARIANT onkeyup;
        // VB6: onkeyup As Any
        object onkeyup
        {
            // IDL: HRESULT onkeyup ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeyup As Any
            [DispId(-2147412106)]
            get;
            // IDL: HRESULT onkeyup (VARIANT value);
            // VB6: Sub onkeyup (ByVal value As Any)
            [DispId(-2147412106)]
            set;
        }

        /// <summary><para><c>onmousedown</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmousedown</c> property was the following:  <c>VARIANT onmousedown</c>;</para></remarks>
        // IDL: VARIANT onmousedown;
        // VB6: onmousedown As Any
        object onmousedown
        {
            // IDL: HRESULT onmousedown ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmousedown As Any
            [DispId(-2147412110)]
            get;
            // IDL: HRESULT onmousedown (VARIANT value);
            // VB6: Sub onmousedown (ByVal value As Any)
            [DispId(-2147412110)]
            set;
        }

        /// <summary><para><c>onmousemove</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmousemove</c> property was the following:  <c>VARIANT onmousemove</c>;</para></remarks>
        // IDL: VARIANT onmousemove;
        // VB6: onmousemove As Any
        object onmousemove
        {
            // IDL: HRESULT onmousemove ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmousemove As Any
            [DispId(-2147412108)]
            get;
            // IDL: HRESULT onmousemove (VARIANT value);
            // VB6: Sub onmousemove (ByVal value As Any)
            [DispId(-2147412108)]
            set;
        }

        /// <summary><para><c>onmouseout</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseout</c> property was the following:  <c>VARIANT onmouseout</c>;</para></remarks>
        // IDL: VARIANT onmouseout;
        // VB6: onmouseout As Any
        object onmouseout
        {
            // IDL: HRESULT onmouseout ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseout As Any
            [DispId(-2147412111)]
            get;
            // IDL: HRESULT onmouseout (VARIANT value);
            // VB6: Sub onmouseout (ByVal value As Any)
            [DispId(-2147412111)]
            set;
        }

        /// <summary><para><c>onmouseover</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseover</c> property was the following:  <c>VARIANT onmouseover</c>;</para></remarks>
        // IDL: VARIANT onmouseover;
        // VB6: onmouseover As Any
        object onmouseover
        {
            // IDL: HRESULT onmouseover ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseover As Any
            [DispId(-2147412112)]
            get;
            // IDL: HRESULT onmouseover (VARIANT value);
            // VB6: Sub onmouseover (ByVal value As Any)
            [DispId(-2147412112)]
            set;
        }

        /// <summary><para><c>onmouseup</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseup</c> property was the following:  <c>VARIANT onmouseup</c>;</para></remarks>
        // IDL: VARIANT onmouseup;
        // VB6: onmouseup As Any
        object onmouseup
        {
            // IDL: HRESULT onmouseup ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseup As Any
            [DispId(-2147412109)]
            get;
            // IDL: HRESULT onmouseup (VARIANT value);
            // VB6: Sub onmouseup (ByVal value As Any)
            [DispId(-2147412109)]
            set;
        }

        /// <summary><para><c>onrowenter</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowenter</c> property was the following:  <c>VARIANT onrowenter</c>;</para></remarks>
        // IDL: VARIANT onrowenter;
        // VB6: onrowenter As Any
        object onrowenter
        {
            // IDL: HRESULT onrowenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowenter As Any
            [DispId(-2147412093)]
            get;
            // IDL: HRESULT onrowenter (VARIANT value);
            // VB6: Sub onrowenter (ByVal value As Any)
            [DispId(-2147412093)]
            set;
        }

        /// <summary><para><c>onrowexit</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowexit</c> property was the following:  <c>VARIANT onrowexit</c>;</para></remarks>
        // IDL: VARIANT onrowexit;
        // VB6: onrowexit As Any
        object onrowexit
        {
            // IDL: HRESULT onrowexit ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowexit As Any
            [DispId(-2147412094)]
            get;
            // IDL: HRESULT onrowexit (VARIANT value);
            // VB6: Sub onrowexit (ByVal value As Any)
            [DispId(-2147412094)]
            set;
        }

        /// <summary><para><c>onselectstart</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onselectstart</c> property was the following:  <c>VARIANT onselectstart</c>;</para></remarks>
        // IDL: VARIANT onselectstart;
        // VB6: onselectstart As Any
        object onselectstart
        {
            // IDL: HRESULT onselectstart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onselectstart As Any
            [DispId(-2147412075)]
            get;
            // IDL: HRESULT onselectstart (VARIANT value);
            // VB6: Sub onselectstart (ByVal value As Any)
            [DispId(-2147412075)]
            set;
        }

        /// <summary><para><c>outerHTML</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>outerHTML</c> property was the following:  <c>BSTR outerHTML</c>;</para></remarks>
        // IDL: BSTR outerHTML;
        // VB6: outerHTML As String
        string outerHTML
        {
            // IDL: HRESULT outerHTML ([out, retval] BSTR* ReturnValue);
            // VB6: Function outerHTML As String
            [DispId(-2147417084)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT outerHTML (BSTR value);
            // VB6: Sub outerHTML (ByVal value As String)
            [DispId(-2147417084)]
            set;
        }

        /// <summary><para><c>outerText</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>outerText</c> property was the following:  <c>BSTR outerText</c>;</para></remarks>
        // IDL: BSTR outerText;
        // VB6: outerText As String
        string outerText
        {
            // IDL: HRESULT outerText ([out, retval] BSTR* ReturnValue);
            // VB6: Function outerText As String
            [DispId(-2147417083)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT outerText (BSTR value);
            // VB6: Sub outerText (ByVal value As String)
            [DispId(-2147417083)]
            set;
        }

        /// <summary><para><c>parentElement</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentElement</c> property was the following:  <c>IHTMLElement* parentElement</c>;</para></remarks>
        // IDL: IHTMLElement* parentElement;
        // VB6: parentElement As IHTMLElement
        IHTMLElement parentElement
        {
            // IDL: HRESULT parentElement ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function parentElement As IHTMLElement
            [DispId(-2147418104)]
            get;
        }

        /// <summary><para><c>parentTextEdit</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentTextEdit</c> property was the following:  <c>IHTMLElement* parentTextEdit</c>;</para></remarks>
        // IDL: IHTMLElement* parentTextEdit;
        // VB6: parentTextEdit As IHTMLElement
        IHTMLElement parentTextEdit
        {
            // IDL: HRESULT parentTextEdit ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function parentTextEdit As IHTMLElement
            [DispId(-2147417080)]
            get;
        }

        /// <summary><para><c>recordNumber</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>recordNumber</c> property was the following:  <c>VARIANT recordNumber</c>;</para></remarks>
        // IDL: VARIANT recordNumber;
        // VB6: recordNumber As Any
        object recordNumber
        {
            // IDL: HRESULT recordNumber ([out, retval] VARIANT* ReturnValue);
            // VB6: Function recordNumber As Any
            [DispId(-2147417087)]
            get;
        }

        /// <summary><para><c>sourceIndex</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>sourceIndex</c> property was the following:  <c>long sourceIndex</c>;</para></remarks>
        // IDL: long sourceIndex;
        // VB6: sourceIndex As Long
        int sourceIndex
        {
            // IDL: HRESULT sourceIndex ([out, retval] long* ReturnValue);
            // VB6: Function sourceIndex As Long
            [DispId(-2147417088)]
            get;
        }

        /// <summary><para><c>style</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>style</c> property was the following:  <c>IHTMLStyle* style</c>;</para></remarks>
        // IDL: IHTMLStyle* style;
        // VB6: style As IHTMLStyle
        IHTMLStyle style
        {
            // IDL: HRESULT style ([out, retval] IHTMLStyle** ReturnValue);
            // VB6: Function style As IHTMLStyle
            [DispId(-2147418038)]
            get;
        }

        /// <summary><para><c>tagName</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>tagName</c> property was the following:  <c>BSTR tagName</c>;</para></remarks>
        // IDL: BSTR tagName;
        // VB6: tagName As String
        string tagName
        {
            // IDL: HRESULT tagName ([out, retval] BSTR* ReturnValue);
            // VB6: Function tagName As String
            [DispId(-2147417108)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>title</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>title</c> property was the following:  <c>BSTR title</c>;</para></remarks>
        // IDL: BSTR title;
        // VB6: title As String
        string title
        {
            // IDL: HRESULT title ([out, retval] BSTR* ReturnValue);
            // VB6: Function title As String
            [DispId(-2147418043)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT title (BSTR value);
            // VB6: Sub title (ByVal value As String)
            [DispId(-2147418043)]
            set;
        }
    }
    #endregion
}