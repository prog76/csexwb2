using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLBodyElement Interface
    /// <summary><para><c>IHTMLBodyElement</c> interface.</para></summary>
    [Guid("3050F1D8-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLBodyElement
    {
        /// <summary><para><c>createTextRange</c> method of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createTextRange</c> method was the following:  <c>HRESULT createTextRange ([out, retval] IHTMLTxtRange** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createTextRange ([out, retval] IHTMLTxtRange** ReturnValue);
        // VB6: Function createTextRange As IHTMLTxtRange
        [DispId(2013)]
        IHTMLTxtRange createTextRange();

        /// <summary><para><c>aLink</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>aLink</c> property was the following:  <c>VARIANT aLink</c>;</para></remarks>
        // IDL: VARIANT aLink;
        // VB6: aLink As Any
        object aLink
        {
            // IDL: HRESULT aLink ([out, retval] VARIANT* ReturnValue);
            // VB6: Function aLink As Any
            [DispId(2011)]
            get;
            // IDL: HRESULT aLink (VARIANT value);
            // VB6: Sub aLink (ByVal value As Any)
            [DispId(2011)]
            set;
        }

        /// <summary><para><c>background</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>background</c> property was the following:  <c>BSTR background</c>;</para></remarks>
        // IDL: BSTR background;
        // VB6: background As String
        string background
        {
            // IDL: HRESULT background ([out, retval] BSTR* ReturnValue);
            // VB6: Function background As String
            [DispId(-2147413111)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT background (BSTR value);
            // VB6: Sub background (ByVal value As String)
            [DispId(-2147413111)]
            set;
        }

        /// <summary><para><c>bgColor</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bgColor</c> property was the following:  <c>VARIANT bgColor</c>;</para></remarks>
        // IDL: VARIANT bgColor;
        // VB6: bgColor As Any
        object bgColor
        {
            // IDL: HRESULT bgColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function bgColor As Any
            [DispId(-501)]
            get;
            // IDL: HRESULT bgColor (VARIANT value);
            // VB6: Sub bgColor (ByVal value As Any)
            [DispId(-501)]
            set;
        }

        /// <summary><para><c>bgProperties</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bgProperties</c> property was the following:  <c>BSTR bgProperties</c>;</para></remarks>
        // IDL: BSTR bgProperties;
        // VB6: bgProperties As String
        string bgProperties
        {
            // IDL: HRESULT bgProperties ([out, retval] BSTR* ReturnValue);
            // VB6: Function bgProperties As String
            [DispId(-2147413067)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT bgProperties (BSTR value);
            // VB6: Sub bgProperties (ByVal value As String)
            [DispId(-2147413067)]
            set;
        }

        /// <summary><para><c>bottomMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bottomMargin</c> property was the following:  <c>VARIANT bottomMargin</c>;</para></remarks>
        // IDL: VARIANT bottomMargin;
        // VB6: bottomMargin As Any
        object bottomMargin
        {
            // IDL: HRESULT bottomMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function bottomMargin As Any
            [DispId(-2147413073)]
            get;
            // IDL: HRESULT bottomMargin (VARIANT value);
            // VB6: Sub bottomMargin (ByVal value As Any)
            [DispId(-2147413073)]
            set;
        }

        /// <summary><para><c>leftMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>leftMargin</c> property was the following:  <c>VARIANT leftMargin</c>;</para></remarks>
        // IDL: VARIANT leftMargin;
        // VB6: leftMargin As Any
        object leftMargin
        {
            // IDL: HRESULT leftMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function leftMargin As Any
            [DispId(-2147413072)]
            get;
            // IDL: HRESULT leftMargin (VARIANT value);
            // VB6: Sub leftMargin (ByVal value As Any)
            [DispId(-2147413072)]
            set;
        }

        /// <summary><para><c>link</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>link</c> property was the following:  <c>VARIANT link</c>;</para></remarks>
        // IDL: VARIANT link;
        // VB6: link As Any
        object link
        {
            // IDL: HRESULT link ([out, retval] VARIANT* ReturnValue);
            // VB6: Function link As Any
            [DispId(2010)]
            get;
            // IDL: HRESULT link (VARIANT value);
            // VB6: Sub link (ByVal value As Any)
            [DispId(2010)]
            set;
        }

        /// <summary><para><c>noWrap</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>noWrap</c> property was the following:  <c>VARIANT_BOOL noWrap</c>;</para></remarks>
        // IDL: VARIANT_BOOL noWrap;
        // VB6: noWrap As Boolean
        bool noWrap
        {
            // IDL: HRESULT noWrap ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function noWrap As Boolean
            [DispId(-2147413107)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT noWrap (VARIANT_BOOL value);
            // VB6: Sub noWrap (ByVal value As Boolean)
            [DispId(-2147413107)]
            set;
        }

        /// <summary><para><c>onbeforeunload</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeunload</c> property was the following:  <c>VARIANT onbeforeunload</c>;</para></remarks>
        // IDL: VARIANT onbeforeunload;
        // VB6: onbeforeunload As Any
        object onbeforeunload
        {
            // IDL: HRESULT onbeforeunload ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeunload As Any
            [DispId(-2147412073)]
            get;
            // IDL: HRESULT onbeforeunload (VARIANT value);
            // VB6: Sub onbeforeunload (ByVal value As Any)
            [DispId(-2147412073)]
            set;
        }

        /// <summary><para><c>onload</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onload</c> property was the following:  <c>VARIANT onload</c>;</para></remarks>
        // IDL: VARIANT onload;
        // VB6: onload As Any
        object onload
        {
            // IDL: HRESULT onload ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onload As Any
            [DispId(-2147412080)]
            get;
            // IDL: HRESULT onload (VARIANT value);
            // VB6: Sub onload (ByVal value As Any)
            [DispId(-2147412080)]
            set;
        }

        /// <summary><para><c>onselect</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onselect</c> property was the following:  <c>VARIANT onselect</c>;</para></remarks>
        // IDL: VARIANT onselect;
        // VB6: onselect As Any
        object onselect
        {
            // IDL: HRESULT onselect ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onselect As Any
            [DispId(-2147412102)]
            get;
            // IDL: HRESULT onselect (VARIANT value);
            // VB6: Sub onselect (ByVal value As Any)
            [DispId(-2147412102)]
            set;
        }

        /// <summary><para><c>onunload</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onunload</c> property was the following:  <c>VARIANT onunload</c>;</para></remarks>
        // IDL: VARIANT onunload;
        // VB6: onunload As Any
        object onunload
        {
            // IDL: HRESULT onunload ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onunload As Any
            [DispId(-2147412079)]
            get;
            // IDL: HRESULT onunload (VARIANT value);
            // VB6: Sub onunload (ByVal value As Any)
            [DispId(-2147412079)]
            set;
        }

        /// <summary><para><c>rightMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>rightMargin</c> property was the following:  <c>VARIANT rightMargin</c>;</para></remarks>
        // IDL: VARIANT rightMargin;
        // VB6: rightMargin As Any
        object rightMargin
        {
            // IDL: HRESULT rightMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function rightMargin As Any
            [DispId(-2147413074)]
            get;
            // IDL: HRESULT rightMargin (VARIANT value);
            // VB6: Sub rightMargin (ByVal value As Any)
            [DispId(-2147413074)]
            set;
        }

        /// <summary><para><c>scroll</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scroll</c> property was the following:  <c>BSTR scroll</c>;</para></remarks>
        // IDL: BSTR scroll;
        // VB6: scroll As String
        string scroll
        {
            // IDL: HRESULT scroll ([out, retval] BSTR* ReturnValue);
            // VB6: Function scroll As String
            [DispId(-2147413033)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT scroll (BSTR value);
            // VB6: Sub scroll (ByVal value As String)
            [DispId(-2147413033)]
            set;
        }

        /// <summary><para><c>text</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>text</c> property was the following:  <c>VARIANT text</c>;</para></remarks>
        // IDL: VARIANT text;
        // VB6: text As Any
        object text
        {
            // IDL: HRESULT text ([out, retval] VARIANT* ReturnValue);
            // VB6: Function text As Any
            [DispId(-2147413110)]
            get;
            // IDL: HRESULT text (VARIANT value);
            // VB6: Sub text (ByVal value As Any)
            [DispId(-2147413110)]
            set;
        }

        /// <summary><para><c>topMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>topMargin</c> property was the following:  <c>VARIANT topMargin</c>;</para></remarks>
        // IDL: VARIANT topMargin;
        // VB6: topMargin As Any
        object topMargin
        {
            // IDL: HRESULT topMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function topMargin As Any
            [DispId(-2147413075)]
            get;
            // IDL: HRESULT topMargin (VARIANT value);
            // VB6: Sub topMargin (ByVal value As Any)
            [DispId(-2147413075)]
            set;
        }

        /// <summary><para><c>vLink</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>vLink</c> property was the following:  <c>VARIANT vLink</c>;</para></remarks>
        // IDL: VARIANT vLink;
        // VB6: vLink As Any
        object vLink
        {
            // IDL: HRESULT vLink ([out, retval] VARIANT* ReturnValue);
            // VB6: Function vLink As Any
            [DispId(2012)]
            get;
            // IDL: HRESULT vLink (VARIANT value);
            // VB6: Sub vLink (ByVal value As Any)
            [DispId(2012)]
            set;
        }
    }
    #endregion
}