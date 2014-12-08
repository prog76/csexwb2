using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLElement2 Interface
    /// <summary><para><c>IHTMLElement2</c> interface.</para></summary>
    [Guid("3050F434-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLElement2
    {
        /// <summary><para><c>setCapture</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setCapture</c> method was the following:  <c>HRESULT setCapture ([optional, defaultvalue(-1)] VARIANT_BOOL containerCapture)</c>;</para></remarks>
        // IDL: HRESULT setCapture ([optional, defaultvalue(-1)] VARIANT_BOOL containerCapture);
        // VB6: Sub setCapture ([ByVal containerCapture As Boolean = True])
        [DispId(-2147417072)]
        void setCapture([MarshalAs(UnmanagedType.VariantBool)] bool containerCapture);

        /// <summary><para><c>releaseCapture</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>releaseCapture</c> method was the following:  <c>HRESULT releaseCapture (void)</c>;</para></remarks>
        // IDL: HRESULT releaseCapture (void);
        // VB6: Sub releaseCapture
        [DispId(-2147417071)]
        void releaseCapture();

        /// <summary><para><c>componentFromPoint</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>componentFromPoint</c> method was the following:  <c>HRESULT componentFromPoint (long x, long y, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT componentFromPoint (long x, long y, [out, retval] BSTR* ReturnValue);
        // VB6: Function componentFromPoint (ByVal x As Long, ByVal y As Long) As String
        [DispId(-2147417070)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string componentFromPoint(int x, int y);

        /// <summary><para><c>doScroll</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>doScroll</c> method was the following:  <c>HRESULT doScroll ([optional] VARIANT component)</c>;</para></remarks>
        // IDL: HRESULT doScroll ([optional] VARIANT component);
        // VB6: Sub doScroll ([ByVal component As Any])
        [DispId(-2147417069)]
        void doScroll(object component);

        /// <summary><para><c>getClientRects</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getClientRects</c> method was the following:  <c>HRESULT getClientRects ([out, retval] IHTMLRectCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getClientRects ([out, retval] IHTMLRectCollection** ReturnValue);
        // VB6: Function getClientRects As IHTMLRectCollection
        [DispId(-2147417068)]
        IHTMLRectCollection getClientRects();

        /// <summary><para><c>getBoundingClientRect</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getBoundingClientRect</c> method was the following:  <c>HRESULT getBoundingClientRect ([out, retval] IHTMLRect** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getBoundingClientRect ([out, retval] IHTMLRect** ReturnValue);
        // VB6: Function getBoundingClientRect As IHTMLRect
        [DispId(-2147417067)]
        IHTMLRect getBoundingClientRect();

        /// <summary><para><c>setExpression</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setExpression</c> method was the following:  <c>HRESULT setExpression (BSTR propname, BSTR expression, [optional, defaultvalue("")] BSTR language)</c>;</para></remarks>
        // IDL: HRESULT setExpression (BSTR propname, BSTR expression, [optional, defaultvalue("")] BSTR language);
        // VB6: Sub setExpression (ByVal propname As String, ByVal expression As String, [ByVal language As String = ""])
        [DispId(-2147417608)]
        void setExpression([MarshalAs(UnmanagedType.BStr)] string propname, [MarshalAs(UnmanagedType.BStr)] string expression, [MarshalAs(UnmanagedType.BStr)] string language);

        /// <summary><para><c>getExpression</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getExpression</c> method was the following:  <c>HRESULT getExpression (BSTR propname, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getExpression (BSTR propname, [out, retval] VARIANT* ReturnValue);
        // VB6: Function getExpression (ByVal propname As String) As Any
        [DispId(-2147417607)]
        object getExpression([MarshalAs(UnmanagedType.BStr)] string propname);

        /// <summary><para><c>removeExpression</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeExpression</c> method was the following:  <c>HRESULT removeExpression (BSTR propname, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeExpression (BSTR propname, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeExpression (ByVal propname As String) As Boolean
        [DispId(-2147417606)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeExpression([MarshalAs(UnmanagedType.BStr)] string propname);

        /// <summary><para><c>focus</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>focus</c> method was the following:  <c>HRESULT focus (void)</c>;</para></remarks>
        // IDL: HRESULT focus (void);
        // VB6: Sub focus
        [DispId(-2147416112)]
        void focus();

        /// <summary><para><c>blur</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>blur</c> method was the following:  <c>HRESULT blur (void)</c>;</para></remarks>
        // IDL: HRESULT blur (void);
        // VB6: Sub blur
        [DispId(-2147416110)]
        void blur();

        /// <summary><para><c>addFilter</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>addFilter</c> method was the following:  <c>HRESULT addFilter (IUnknown* pUnk)</c>;</para></remarks>
        // IDL: HRESULT addFilter (IUnknown* pUnk);
        // VB6: Sub addFilter (ByVal pUnk As IUnknown)
        [DispId(-2147416095)]
        void addFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);

        /// <summary><para><c>removeFilter</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeFilter</c> method was the following:  <c>HRESULT removeFilter (IUnknown* pUnk)</c>;</para></remarks>
        // IDL: HRESULT removeFilter (IUnknown* pUnk);
        // VB6: Sub removeFilter (ByVal pUnk As IUnknown)
        [DispId(-2147416094)]
        void removeFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);

        /// <summary><para><c>attachEvent</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>attachEvent</c> method was the following:  <c>HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function attachEvent (ByVal event As String, ByVal pdisp As IDispatch) As Boolean
        [DispId(-2147417605)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool attachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>detachEvent</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>detachEvent</c> method was the following:  <c>HRESULT detachEvent (BSTR event, IDispatch* pdisp)</c>;</para></remarks>
        // IDL: HRESULT detachEvent (BSTR event, IDispatch* pdisp);
        // VB6: Sub detachEvent (ByVal event As String, ByVal pdisp As IDispatch)
        [DispId(-2147417604)]
        void detachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>createControlRange</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createControlRange</c> method was the following:  <c>HRESULT createControlRange ([out, retval] IDispatch** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createControlRange ([out, retval] IDispatch** ReturnValue);
        // VB6: Function createControlRange As IDispatch
        [DispId(-2147417056)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object createControlRange();

        /// <summary><para><c>clearAttributes</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clearAttributes</c> method was the following:  <c>HRESULT clearAttributes (void)</c>;</para></remarks>
        // IDL: HRESULT clearAttributes (void);
        // VB6: Sub clearAttributes
        [DispId(-2147417050)]
        void clearAttributes();

        /// <summary><para><c>mergeAttributes</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>mergeAttributes</c> method was the following:  <c>HRESULT mergeAttributes (IHTMLElement* mergeThis)</c>;</para></remarks>
        // IDL: HRESULT mergeAttributes (IHTMLElement* mergeThis);
        // VB6: Sub mergeAttributes (ByVal mergeThis As IHTMLElement)
        [DispId(-2147417049)]
        void mergeAttributes(IHTMLElement mergeThis);

        /// <summary><para><c>insertAdjacentElement</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>insertAdjacentElement</c> method was the following:  <c>HRESULT insertAdjacentElement (BSTR where, IHTMLElement* insertedElement, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT insertAdjacentElement (BSTR where, IHTMLElement* insertedElement, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function insertAdjacentElement (ByVal where As String, ByVal insertedElement As IHTMLElement) As IHTMLElement
        [DispId(-2147417043)]
        IHTMLElement insertAdjacentElement([MarshalAs(UnmanagedType.BStr)] string where, IHTMLElement insertedElement);

        /// <summary><para><c>applyElement</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>applyElement</c> method was the following:  <c>HRESULT applyElement (IHTMLElement* apply, BSTR where, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT applyElement (IHTMLElement* apply, BSTR where, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function applyElement (ByVal apply As IHTMLElement, ByVal where As String) As IHTMLElement
        [DispId(-2147417047)]
        IHTMLElement applyElement(IHTMLElement apply, [MarshalAs(UnmanagedType.BStr)] string where);

        /// <summary><para><c>getAdjacentText</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getAdjacentText</c> method was the following:  <c>HRESULT getAdjacentText (BSTR where, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getAdjacentText (BSTR where, [out, retval] BSTR* ReturnValue);
        // VB6: Function getAdjacentText (ByVal where As String) As String
        [DispId(-2147417042)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string getAdjacentText([MarshalAs(UnmanagedType.BStr)] string where);

        /// <summary><para><c>replaceAdjacentText</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>replaceAdjacentText</c> method was the following:  <c>HRESULT replaceAdjacentText (BSTR where, BSTR newText, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT replaceAdjacentText (BSTR where, BSTR newText, [out, retval] BSTR* ReturnValue);
        // VB6: Function replaceAdjacentText (ByVal where As String, ByVal newText As String) As String
        [DispId(-2147417041)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string replaceAdjacentText([MarshalAs(UnmanagedType.BStr)] string where, [MarshalAs(UnmanagedType.BStr)] string newText);

        /// <summary><para><c>addBehavior</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>addBehavior</c> method was the following:  <c>HRESULT addBehavior (BSTR bstrUrl, [in, optional] VARIANT* pvarFactory, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT addBehavior (BSTR bstrUrl, [in, optional] VARIANT* pvarFactory, [out, retval] long* ReturnValue);
        // VB6: Function addBehavior (ByVal bstrUrl As String, [pvarFactory As Any]) As Long
        [DispId(-2147417032)]
        int addBehavior([MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] ref object pvarFactory);

        /// <summary><para><c>removeBehavior</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeBehavior</c> method was the following:  <c>HRESULT removeBehavior (long cookie, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeBehavior (long cookie, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeBehavior (ByVal cookie As Long) As Boolean
        [DispId(-2147417031)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeBehavior(int cookie);

        /// <summary><para><c>getElementsByTagName</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementsByTagName</c> method was the following:  <c>HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue);
        // VB6: Function getElementsByTagName (ByVal v As String) As IHTMLElementCollection
        [DispId(-2147417027)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
        object getElementsByTagName([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>accessKey</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>accessKey</c> property was the following:  <c>BSTR accessKey</c>;</para></remarks>
        // IDL: BSTR accessKey;
        // VB6: accessKey As String
        string accessKey
        {
            // IDL: HRESULT accessKey ([out, retval] BSTR* ReturnValue);
            // VB6: Function accessKey As String
            [DispId(-2147416107)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT accessKey (BSTR value);
            // VB6: Sub accessKey (ByVal value As String)
            [DispId(-2147416107)]
            set;
        }

        /// <summary><para><c>behaviorUrns</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>behaviorUrns</c> property was the following:  <c>IDispatch* behaviorUrns</c>;</para></remarks>
        // IDL: IDispatch* behaviorUrns;
        // VB6: behaviorUrns As IDispatch
        object behaviorUrns
        {
            // IDL: HRESULT behaviorUrns ([out, retval] IDispatch** ReturnValue);
            // VB6: Function behaviorUrns As IDispatch
            [DispId(-2147417030)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>canHaveChildren</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>canHaveChildren</c> property was the following:  <c>VARIANT_BOOL canHaveChildren</c>;</para></remarks>
        // IDL: VARIANT_BOOL canHaveChildren;
        // VB6: canHaveChildren As Boolean
        bool canHaveChildren
        {
            // IDL: HRESULT canHaveChildren ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function canHaveChildren As Boolean
            [DispId(-2147417040)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>clientHeight</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientHeight</c> property was the following:  <c>long clientHeight</c>;</para></remarks>
        // IDL: long clientHeight;
        // VB6: clientHeight As Long
        int clientHeight
        {
            // IDL: HRESULT clientHeight ([out, retval] long* ReturnValue);
            // VB6: Function clientHeight As Long
            [DispId(-2147416093)]
            get;
        }

        /// <summary><para><c>clientLeft</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientLeft</c> property was the following:  <c>long clientLeft</c>;</para></remarks>
        // IDL: long clientLeft;
        // VB6: clientLeft As Long
        int clientLeft
        {
            // IDL: HRESULT clientLeft ([out, retval] long* ReturnValue);
            // VB6: Function clientLeft As Long
            [DispId(-2147416090)]
            get;
        }

        /// <summary><para><c>clientTop</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientTop</c> property was the following:  <c>long clientTop</c>;</para></remarks>
        // IDL: long clientTop;
        // VB6: clientTop As Long
        int clientTop
        {
            // IDL: HRESULT clientTop ([out, retval] long* ReturnValue);
            // VB6: Function clientTop As Long
            [DispId(-2147416091)]
            get;
        }

        /// <summary><para><c>clientWidth</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientWidth</c> property was the following:  <c>long clientWidth</c>;</para></remarks>
        // IDL: long clientWidth;
        // VB6: clientWidth As Long
        int clientWidth
        {
            // IDL: HRESULT clientWidth ([out, retval] long* ReturnValue);
            // VB6: Function clientWidth As Long
            [DispId(-2147416092)]
            get;
        }

        /// <summary><para><c>currentStyle</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>currentStyle</c> property was the following:  <c>IHTMLCurrentStyle* currentStyle</c>;</para></remarks>
        // IDL: IHTMLCurrentStyle* currentStyle;
        // VB6: currentStyle As IHTMLCurrentStyle
        object currentStyle
        {
            // IDL: HRESULT currentStyle ([out, retval] IHTMLCurrentStyle** ReturnValue);
            // VB6: Function currentStyle As IHTMLCurrentStyle
            [DispId(-2147417105)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLCurrentStyle
            get;
        }

        /// <summary><para><c>dir</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>onbeforecopy</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforecopy</c> property was the following:  <c>VARIANT onbeforecopy</c>;</para></remarks>
        // IDL: VARIANT onbeforecopy;
        // VB6: onbeforecopy As Any
        object onbeforecopy
        {
            // IDL: HRESULT onbeforecopy ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforecopy As Any
            [DispId(-2147412053)]
            get;
            // IDL: HRESULT onbeforecopy (VARIANT value);
            // VB6: Sub onbeforecopy (ByVal value As Any)
            [DispId(-2147412053)]
            set;
        }

        /// <summary><para><c>onbeforecut</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforecut</c> property was the following:  <c>VARIANT onbeforecut</c>;</para></remarks>
        // IDL: VARIANT onbeforecut;
        // VB6: onbeforecut As Any
        object onbeforecut
        {
            // IDL: HRESULT onbeforecut ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforecut As Any
            [DispId(-2147412054)]
            get;
            // IDL: HRESULT onbeforecut (VARIANT value);
            // VB6: Sub onbeforecut (ByVal value As Any)
            [DispId(-2147412054)]
            set;
        }

        /// <summary><para><c>onbeforeeditfocus</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>onbeforepaste</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforepaste</c> property was the following:  <c>VARIANT onbeforepaste</c>;</para></remarks>
        // IDL: VARIANT onbeforepaste;
        // VB6: onbeforepaste As Any
        object onbeforepaste
        {
            // IDL: HRESULT onbeforepaste ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforepaste As Any
            [DispId(-2147412052)]
            get;
            // IDL: HRESULT onbeforepaste (VARIANT value);
            // VB6: Sub onbeforepaste (ByVal value As Any)
            [DispId(-2147412052)]
            set;
        }

        /// <summary><para><c>onblur</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onblur</c> property was the following:  <c>VARIANT onblur</c>;</para></remarks>
        // IDL: VARIANT onblur;
        // VB6: onblur As Any
        object onblur
        {
            // IDL: HRESULT onblur ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onblur As Any
            [DispId(-2147412097)]
            get;
            // IDL: HRESULT onblur (VARIANT value);
            // VB6: Sub onblur (ByVal value As Any)
            [DispId(-2147412097)]
            set;
        }

        /// <summary><para><c>oncellchange</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>oncontextmenu</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>oncopy</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncopy</c> property was the following:  <c>VARIANT oncopy</c>;</para></remarks>
        // IDL: VARIANT oncopy;
        // VB6: oncopy As Any
        object oncopy
        {
            // IDL: HRESULT oncopy ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncopy As Any
            [DispId(-2147412056)]
            get;
            // IDL: HRESULT oncopy (VARIANT value);
            // VB6: Sub oncopy (ByVal value As Any)
            [DispId(-2147412056)]
            set;
        }

        /// <summary><para><c>oncut</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncut</c> property was the following:  <c>VARIANT oncut</c>;</para></remarks>
        // IDL: VARIANT oncut;
        // VB6: oncut As Any
        object oncut
        {
            // IDL: HRESULT oncut ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncut As Any
            [DispId(-2147412057)]
            get;
            // IDL: HRESULT oncut (VARIANT value);
            // VB6: Sub oncut (ByVal value As Any)
            [DispId(-2147412057)]
            set;
        }

        /// <summary><para><c>ondrag</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondrag</c> property was the following:  <c>VARIANT ondrag</c>;</para></remarks>
        // IDL: VARIANT ondrag;
        // VB6: ondrag As Any
        object ondrag
        {
            // IDL: HRESULT ondrag ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondrag As Any
            [DispId(-2147412063)]
            get;
            // IDL: HRESULT ondrag (VARIANT value);
            // VB6: Sub ondrag (ByVal value As Any)
            [DispId(-2147412063)]
            set;
        }

        /// <summary><para><c>ondragend</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragend</c> property was the following:  <c>VARIANT ondragend</c>;</para></remarks>
        // IDL: VARIANT ondragend;
        // VB6: ondragend As Any
        object ondragend
        {
            // IDL: HRESULT ondragend ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragend As Any
            [DispId(-2147412062)]
            get;
            // IDL: HRESULT ondragend (VARIANT value);
            // VB6: Sub ondragend (ByVal value As Any)
            [DispId(-2147412062)]
            set;
        }

        /// <summary><para><c>ondragenter</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragenter</c> property was the following:  <c>VARIANT ondragenter</c>;</para></remarks>
        // IDL: VARIANT ondragenter;
        // VB6: ondragenter As Any
        object ondragenter
        {
            // IDL: HRESULT ondragenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragenter As Any
            [DispId(-2147412061)]
            get;
            // IDL: HRESULT ondragenter (VARIANT value);
            // VB6: Sub ondragenter (ByVal value As Any)
            [DispId(-2147412061)]
            set;
        }

        /// <summary><para><c>ondragleave</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragleave</c> property was the following:  <c>VARIANT ondragleave</c>;</para></remarks>
        // IDL: VARIANT ondragleave;
        // VB6: ondragleave As Any
        object ondragleave
        {
            // IDL: HRESULT ondragleave ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragleave As Any
            [DispId(-2147412059)]
            get;
            // IDL: HRESULT ondragleave (VARIANT value);
            // VB6: Sub ondragleave (ByVal value As Any)
            [DispId(-2147412059)]
            set;
        }

        /// <summary><para><c>ondragover</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragover</c> property was the following:  <c>VARIANT ondragover</c>;</para></remarks>
        // IDL: VARIANT ondragover;
        // VB6: ondragover As Any
        object ondragover
        {
            // IDL: HRESULT ondragover ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragover As Any
            [DispId(-2147412060)]
            get;
            // IDL: HRESULT ondragover (VARIANT value);
            // VB6: Sub ondragover (ByVal value As Any)
            [DispId(-2147412060)]
            set;
        }

        /// <summary><para><c>ondrop</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondrop</c> property was the following:  <c>VARIANT ondrop</c>;</para></remarks>
        // IDL: VARIANT ondrop;
        // VB6: ondrop As Any
        object ondrop
        {
            // IDL: HRESULT ondrop ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondrop As Any
            [DispId(-2147412058)]
            get;
            // IDL: HRESULT ondrop (VARIANT value);
            // VB6: Sub ondrop (ByVal value As Any)
            [DispId(-2147412058)]
            set;
        }

        /// <summary><para><c>onfocus</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onfocus</c> property was the following:  <c>VARIANT onfocus</c>;</para></remarks>
        // IDL: VARIANT onfocus;
        // VB6: onfocus As Any
        object onfocus
        {
            // IDL: HRESULT onfocus ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onfocus As Any
            [DispId(-2147412098)]
            get;
            // IDL: HRESULT onfocus (VARIANT value);
            // VB6: Sub onfocus (ByVal value As Any)
            [DispId(-2147412098)]
            set;
        }

        /// <summary><para><c>onlosecapture</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onlosecapture</c> property was the following:  <c>VARIANT onlosecapture</c>;</para></remarks>
        // IDL: VARIANT onlosecapture;
        // VB6: onlosecapture As Any
        object onlosecapture
        {
            // IDL: HRESULT onlosecapture ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onlosecapture As Any
            [DispId(-2147412066)]
            get;
            // IDL: HRESULT onlosecapture (VARIANT value);
            // VB6: Sub onlosecapture (ByVal value As Any)
            [DispId(-2147412066)]
            set;
        }

        /// <summary><para><c>onpaste</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpaste</c> property was the following:  <c>VARIANT onpaste</c>;</para></remarks>
        // IDL: VARIANT onpaste;
        // VB6: onpaste As Any
        object onpaste
        {
            // IDL: HRESULT onpaste ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpaste As Any
            [DispId(-2147412055)]
            get;
            // IDL: HRESULT onpaste (VARIANT value);
            // VB6: Sub onpaste (ByVal value As Any)
            [DispId(-2147412055)]
            set;
        }

        /// <summary><para><c>onpropertychange</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>onreadystatechange</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onreadystatechange</c> property was the following:  <c>VARIANT onreadystatechange</c>;</para></remarks>
        // IDL: VARIANT onreadystatechange;
        // VB6: onreadystatechange As Any
        object onreadystatechange
        {
            // IDL: HRESULT onreadystatechange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onreadystatechange As Any
            [DispId(-2147412087)]
            get;
            // IDL: HRESULT onreadystatechange (VARIANT value);
            // VB6: Sub onreadystatechange (ByVal value As Any)
            [DispId(-2147412087)]
            set;
        }

        /// <summary><para><c>onresize</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onresize</c> property was the following:  <c>VARIANT onresize</c>;</para></remarks>
        // IDL: VARIANT onresize;
        // VB6: onresize As Any
        object onresize
        {
            // IDL: HRESULT onresize ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onresize As Any
            [DispId(-2147412076)]
            get;
            // IDL: HRESULT onresize (VARIANT value);
            // VB6: Sub onresize (ByVal value As Any)
            [DispId(-2147412076)]
            set;
        }

        /// <summary><para><c>onrowsdelete</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>onrowsinserted</c> property of <c>IHTMLElement2</c> interface.</para></summary>
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

        /// <summary><para><c>onscroll</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onscroll</c> property was the following:  <c>VARIANT onscroll</c>;</para></remarks>
        // IDL: VARIANT onscroll;
        // VB6: onscroll As Any
        object onscroll
        {
            // IDL: HRESULT onscroll ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onscroll As Any
            [DispId(-2147412081)]
            get;
            // IDL: HRESULT onscroll (VARIANT value);
            // VB6: Sub onscroll (ByVal value As Any)
            [DispId(-2147412081)]
            set;
        }

        /// <summary><para><c>readyState</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>readyState</c> property was the following:  <c>VARIANT readyState</c>;</para></remarks>
        // IDL: VARIANT readyState;
        // VB6: readyState As Any
        object readyState
        {
            // IDL: HRESULT readyState ([out, retval] VARIANT* ReturnValue);
            // VB6: Function readyState As Any
            [DispId(-2147412996)]
            get;
        }

        /// <summary><para><c>readyStateValue</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>readyStateValue</c> property was the following:  <c>long readyStateValue</c>;</para></remarks>
        // IDL: long readyStateValue;
        // VB6: readyStateValue As Long
        int readyStateValue
        {
            // IDL: HRESULT readyStateValue ([out, retval] long* ReturnValue);
            // VB6: Function readyStateValue As Long
            [DispId(-2147417028)]
            get;
        }

        /// <summary><para><c>runtimeStyle</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>runtimeStyle</c> property was the following:  <c>IHTMLStyle* runtimeStyle</c>;</para></remarks>
        // IDL: IHTMLStyle* runtimeStyle;
        // VB6: runtimeStyle As IHTMLStyle
        IHTMLStyle runtimeStyle
        {
            // IDL: HRESULT runtimeStyle ([out, retval] IHTMLStyle** ReturnValue);
            // VB6: Function runtimeStyle As IHTMLStyle
            [DispId(-2147417048)]
            get;
        }

        /// <summary><para><c>scopeName</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scopeName</c> property was the following:  <c>BSTR scopeName</c>;</para></remarks>
        // IDL: BSTR scopeName;
        // VB6: scopeName As String
        string scopeName
        {
            // IDL: HRESULT scopeName ([out, retval] BSTR* ReturnValue);
            // VB6: Function scopeName As String
            [DispId(-2147417073)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>scrollHeight</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollHeight</c> property was the following:  <c>long scrollHeight</c>;</para></remarks>
        // IDL: long scrollHeight;
        // VB6: scrollHeight As Long
        int scrollHeight
        {
            // IDL: HRESULT scrollHeight ([out, retval] long* ReturnValue);
            // VB6: Function scrollHeight As Long
            [DispId(-2147417055)]
            get;
        }

        /// <summary><para><c>scrollLeft</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollLeft</c> property was the following:  <c>long scrollLeft</c>;</para></remarks>
        // IDL: long scrollLeft;
        // VB6: scrollLeft As Long
        int scrollLeft
        {
            // IDL: HRESULT scrollLeft ([out, retval] long* ReturnValue);
            // VB6: Function scrollLeft As Long
            [DispId(-2147417052)]
            get;
            // IDL: HRESULT scrollLeft (long value);
            // VB6: Sub scrollLeft (ByVal value As Long)
            [DispId(-2147417052)]
            set;
        }

        /// <summary><para><c>scrollTop</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollTop</c> property was the following:  <c>long scrollTop</c>;</para></remarks>
        // IDL: long scrollTop;
        // VB6: scrollTop As Long
        int scrollTop
        {
            // IDL: HRESULT scrollTop ([out, retval] long* ReturnValue);
            // VB6: Function scrollTop As Long
            [DispId(-2147417053)]
            get;
            // IDL: HRESULT scrollTop (long value);
            // VB6: Sub scrollTop (ByVal value As Long)
            [DispId(-2147417053)]
            set;
        }

        /// <summary><para><c>scrollWidth</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollWidth</c> property was the following:  <c>long scrollWidth</c>;</para></remarks>
        // IDL: long scrollWidth;
        // VB6: scrollWidth As Long
        int scrollWidth
        {
            // IDL: HRESULT scrollWidth ([out, retval] long* ReturnValue);
            // VB6: Function scrollWidth As Long
            [DispId(-2147417054)]
            get;
        }

        /// <summary><para><c>tabIndex</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>tabIndex</c> property was the following:  <c>short tabIndex</c>;</para></remarks>
        // IDL: short tabIndex;
        // VB6: tabIndex As Integer
        short tabIndex
        {
            // IDL: HRESULT tabIndex ([out, retval] short* ReturnValue);
            // VB6: Function tabIndex As Integer
            [DispId(-2147418097)]
            get;
            // IDL: HRESULT tabIndex (short value);
            // VB6: Sub tabIndex (ByVal value As Integer)
            [DispId(-2147418097)]
            set;
        }

        /// <summary><para><c>tagUrn</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>tagUrn</c> property was the following:  <c>BSTR tagUrn</c>;</para></remarks>
        // IDL: BSTR tagUrn;
        // VB6: tagUrn As String
        string tagUrn
        {
            // IDL: HRESULT tagUrn ([out, retval] BSTR* ReturnValue);
            // VB6: Function tagUrn As String
            [DispId(-2147417029)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT tagUrn (BSTR value);
            // VB6: Sub tagUrn (ByVal value As String)
            [DispId(-2147417029)]
            set;
        }
    }
    #endregion
}