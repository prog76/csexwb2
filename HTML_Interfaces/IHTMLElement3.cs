using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLElement3 Interface
    /// <summary><para><c>IHTMLElement3</c> interface.</para></summary>
    [Guid("3050F673-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLElement3
    {
        /// <summary><para><c>mergeAttributes</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>mergeAttributes</c> method was the following:  <c>HRESULT mergeAttributes (IHTMLElement* mergeThis, [in, optional] VARIANT* pvarFlags)</c>;</para></remarks>
        // IDL: HRESULT mergeAttributes (IHTMLElement* mergeThis, [in, optional] VARIANT* pvarFlags);
        // VB6: Sub mergeAttributes (ByVal mergeThis As IHTMLElement, [pvarFlags As Any])
        [DispId(-2147417016)]
        void mergeAttributes(IHTMLElement mergeThis, [In] ref object pvarFlags);

        /// <summary><para><c>setActive</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setActive</c> method was the following:  <c>HRESULT setActive (void)</c>;</para></remarks>
        // IDL: HRESULT setActive (void);
        // VB6: Sub setActive
        [DispId(-2147417011)]
        void setActive();

        /// <summary><para><c>FireEvent</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>FireEvent</c> method was the following:  <c>HRESULT FireEvent (BSTR bstrEventName, [in, optional] VARIANT* pvarEventObject, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT FireEvent (BSTR bstrEventName, [in, optional] VARIANT* pvarEventObject, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function FireEvent (ByVal bstrEventName As String, [pvarEventObject As Any]) As Boolean
        [DispId(-2147417006)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool FireEvent([MarshalAs(UnmanagedType.BStr)] string bstrEventName, [In] ref object pvarEventObject);

        /// <summary><para><c>dragDrop</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>dragDrop</c> method was the following:  <c>HRESULT dragDrop ([out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT dragDrop ([out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function dragDrop As Boolean
        [DispId(-2147417005)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool dragDrop();

        /// <summary><para><c>canHaveHTML</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>canHaveHTML</c> property was the following:  <c>VARIANT_BOOL canHaveHTML</c>;</para></remarks>
        // IDL: VARIANT_BOOL canHaveHTML;
        // VB6: canHaveHTML As Boolean
        bool canHaveHTML
        {
            // IDL: HRESULT canHaveHTML ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function canHaveHTML As Boolean
            [DispId(-2147417014)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>contentEditable</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>contentEditable</c> property was the following:  <c>BSTR contentEditable</c>;</para></remarks>
        // IDL: BSTR contentEditable;
        // VB6: contentEditable As String
        string contentEditable
        {
            // IDL: HRESULT contentEditable ([out, retval] BSTR* ReturnValue);
            // VB6: Function contentEditable As String
            [DispId(-2147412950)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT contentEditable (BSTR value);
            // VB6: Sub contentEditable (ByVal value As String)
            [DispId(-2147412950)]
            set;
        }

        /// <summary><para><c>disabled</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>disabled</c> property was the following:  <c>VARIANT_BOOL disabled</c>;</para></remarks>
        // IDL: VARIANT_BOOL disabled;
        // VB6: disabled As Boolean
        bool disabled
        {
            // IDL: HRESULT disabled ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function disabled As Boolean
            [DispId(-2147418036)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT disabled (VARIANT_BOOL value);
            // VB6: Sub disabled (ByVal value As Boolean)
            [DispId(-2147418036)]
            set;
        }

        /// <summary><para><c>glyphMode</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>glyphMode</c> property was the following:  <c>long glyphMode</c>;</para></remarks>
        // IDL: long glyphMode;
        // VB6: glyphMode As Long
        int glyphMode
        {
            // IDL: HRESULT glyphMode ([out, retval] long* ReturnValue);
            // VB6: Function glyphMode As Long
            [DispId(-2147417004)]
            get;
        }

        /// <summary><para><c>hideFocus</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>hideFocus</c> property was the following:  <c>VARIANT_BOOL hideFocus</c>;</para></remarks>
        // IDL: VARIANT_BOOL hideFocus;
        // VB6: hideFocus As Boolean
        bool hideFocus
        {
            // IDL: HRESULT hideFocus ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function hideFocus As Boolean
            [DispId(-2147412949)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT hideFocus (VARIANT_BOOL value);
            // VB6: Sub hideFocus (ByVal value As Boolean)
            [DispId(-2147412949)]
            set;
        }

        /// <summary><para><c>inflateBlock</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>inflateBlock</c> property was the following:  <c>VARIANT_BOOL inflateBlock</c>;</para></remarks>
        // IDL: VARIANT_BOOL inflateBlock;
        // VB6: inflateBlock As Boolean
        bool inflateBlock
        {
            // IDL: HRESULT inflateBlock ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function inflateBlock As Boolean
            [DispId(-2147417012)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT inflateBlock (VARIANT_BOOL value);
            // VB6: Sub inflateBlock (ByVal value As Boolean)
            [DispId(-2147417012)]
            set;
        }

        /// <summary><para><c>isContentEditable</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isContentEditable</c> property was the following:  <c>VARIANT_BOOL isContentEditable</c>;</para></remarks>
        // IDL: VARIANT_BOOL isContentEditable;
        // VB6: isContentEditable As Boolean
        bool isContentEditable
        {
            // IDL: HRESULT isContentEditable ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isContentEditable As Boolean
            [DispId(-2147417010)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>isDisabled</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isDisabled</c> property was the following:  <c>VARIANT_BOOL isDisabled</c>;</para></remarks>
        // IDL: VARIANT_BOOL isDisabled;
        // VB6: isDisabled As Boolean
        bool isDisabled
        {
            // IDL: HRESULT isDisabled ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isDisabled As Boolean
            [DispId(-2147417007)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>isMultiLine</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isMultiLine</c> property was the following:  <c>VARIANT_BOOL isMultiLine</c>;</para></remarks>
        // IDL: VARIANT_BOOL isMultiLine;
        // VB6: isMultiLine As Boolean
        bool isMultiLine
        {
            // IDL: HRESULT isMultiLine ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isMultiLine As Boolean
            [DispId(-2147417015)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>onactivate</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onactivate</c> property was the following:  <c>VARIANT onactivate</c>;</para></remarks>
        // IDL: VARIANT onactivate;
        // VB6: onactivate As Any
        object onactivate
        {
            // IDL: HRESULT onactivate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onactivate As Any
            [DispId(-2147412025)]
            get;
            // IDL: HRESULT onactivate (VARIANT value);
            // VB6: Sub onactivate (ByVal value As Any)
            [DispId(-2147412025)]
            set;
        }

        /// <summary><para><c>onbeforedeactivate</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforedeactivate</c> property was the following:  <c>VARIANT onbeforedeactivate</c>;</para></remarks>
        // IDL: VARIANT onbeforedeactivate;
        // VB6: onbeforedeactivate As Any
        object onbeforedeactivate
        {
            // IDL: HRESULT onbeforedeactivate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforedeactivate As Any
            [DispId(-2147412035)]
            get;
            // IDL: HRESULT onbeforedeactivate (VARIANT value);
            // VB6: Sub onbeforedeactivate (ByVal value As Any)
            [DispId(-2147412035)]
            set;
        }

        /// <summary><para><c>oncontrolselect</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncontrolselect</c> property was the following:  <c>VARIANT oncontrolselect</c>;</para></remarks>
        // IDL: VARIANT oncontrolselect;
        // VB6: oncontrolselect As Any
        object oncontrolselect
        {
            // IDL: HRESULT oncontrolselect ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncontrolselect As Any
            [DispId(-2147412033)]
            get;
            // IDL: HRESULT oncontrolselect (VARIANT value);
            // VB6: Sub oncontrolselect (ByVal value As Any)
            [DispId(-2147412033)]
            set;
        }

        /// <summary><para><c>ondeactivate</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondeactivate</c> property was the following:  <c>VARIANT ondeactivate</c>;</para></remarks>
        // IDL: VARIANT ondeactivate;
        // VB6: ondeactivate As Any
        object ondeactivate
        {
            // IDL: HRESULT ondeactivate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondeactivate As Any
            [DispId(-2147412024)]
            get;
            // IDL: HRESULT ondeactivate (VARIANT value);
            // VB6: Sub ondeactivate (ByVal value As Any)
            [DispId(-2147412024)]
            set;
        }

        /// <summary><para><c>onlayoutcomplete</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onlayoutcomplete</c> property was the following:  <c>VARIANT onlayoutcomplete</c>;</para></remarks>
        // IDL: VARIANT onlayoutcomplete;
        // VB6: onlayoutcomplete As Any
        object onlayoutcomplete
        {
            // IDL: HRESULT onlayoutcomplete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onlayoutcomplete As Any
            [DispId(-2147412039)]
            get;
            // IDL: HRESULT onlayoutcomplete (VARIANT value);
            // VB6: Sub onlayoutcomplete (ByVal value As Any)
            [DispId(-2147412039)]
            set;
        }

        /// <summary><para><c>onmouseenter</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseenter</c> property was the following:  <c>VARIANT onmouseenter</c>;</para></remarks>
        // IDL: VARIANT onmouseenter;
        // VB6: onmouseenter As Any
        object onmouseenter
        {
            // IDL: HRESULT onmouseenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseenter As Any
            [DispId(-2147412027)]
            get;
            // IDL: HRESULT onmouseenter (VARIANT value);
            // VB6: Sub onmouseenter (ByVal value As Any)
            [DispId(-2147412027)]
            set;
        }

        /// <summary><para><c>onmouseleave</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseleave</c> property was the following:  <c>VARIANT onmouseleave</c>;</para></remarks>
        // IDL: VARIANT onmouseleave;
        // VB6: onmouseleave As Any
        object onmouseleave
        {
            // IDL: HRESULT onmouseleave ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseleave As Any
            [DispId(-2147412026)]
            get;
            // IDL: HRESULT onmouseleave (VARIANT value);
            // VB6: Sub onmouseleave (ByVal value As Any)
            [DispId(-2147412026)]
            set;
        }

        /// <summary><para><c>onmove</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmove</c> property was the following:  <c>VARIANT onmove</c>;</para></remarks>
        // IDL: VARIANT onmove;
        // VB6: onmove As Any
        object onmove
        {
            // IDL: HRESULT onmove ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmove As Any
            [DispId(-2147412034)]
            get;
            // IDL: HRESULT onmove (VARIANT value);
            // VB6: Sub onmove (ByVal value As Any)
            [DispId(-2147412034)]
            set;
        }

        /// <summary><para><c>onmoveend</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmoveend</c> property was the following:  <c>VARIANT onmoveend</c>;</para></remarks>
        // IDL: VARIANT onmoveend;
        // VB6: onmoveend As Any
        object onmoveend
        {
            // IDL: HRESULT onmoveend ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmoveend As Any
            [DispId(-2147412030)]
            get;
            // IDL: HRESULT onmoveend (VARIANT value);
            // VB6: Sub onmoveend (ByVal value As Any)
            [DispId(-2147412030)]
            set;
        }

        /// <summary><para><c>onmovestart</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmovestart</c> property was the following:  <c>VARIANT onmovestart</c>;</para></remarks>
        // IDL: VARIANT onmovestart;
        // VB6: onmovestart As Any
        object onmovestart
        {
            // IDL: HRESULT onmovestart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmovestart As Any
            [DispId(-2147412031)]
            get;
            // IDL: HRESULT onmovestart (VARIANT value);
            // VB6: Sub onmovestart (ByVal value As Any)
            [DispId(-2147412031)]
            set;
        }

        /// <summary><para><c>onpage</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpage</c> property was the following:  <c>VARIANT onpage</c>;</para></remarks>
        // IDL: VARIANT onpage;
        // VB6: onpage As Any
        object onpage
        {
            // IDL: HRESULT onpage ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpage As Any
            [DispId(-2147412038)]
            get;
            // IDL: HRESULT onpage (VARIANT value);
            // VB6: Sub onpage (ByVal value As Any)
            [DispId(-2147412038)]
            set;
        }

        /// <summary><para><c>onresizeend</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onresizeend</c> property was the following:  <c>VARIANT onresizeend</c>;</para></remarks>
        // IDL: VARIANT onresizeend;
        // VB6: onresizeend As Any
        object onresizeend
        {
            // IDL: HRESULT onresizeend ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onresizeend As Any
            [DispId(-2147412028)]
            get;
            // IDL: HRESULT onresizeend (VARIANT value);
            // VB6: Sub onresizeend (ByVal value As Any)
            [DispId(-2147412028)]
            set;
        }

        /// <summary><para><c>onresizestart</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onresizestart</c> property was the following:  <c>VARIANT onresizestart</c>;</para></remarks>
        // IDL: VARIANT onresizestart;
        // VB6: onresizestart As Any
        object onresizestart
        {
            // IDL: HRESULT onresizestart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onresizestart As Any
            [DispId(-2147412029)]
            get;
            // IDL: HRESULT onresizestart (VARIANT value);
            // VB6: Sub onresizestart (ByVal value As Any)
            [DispId(-2147412029)]
            set;
        }
    }
    #endregion
}