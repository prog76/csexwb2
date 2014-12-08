using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDocument2 Interface
    /// <summary><para><c>IHTMLDocument2</c> interface.</para></summary>
    [Guid("332C4425-26CB-11D0-B483-00C04FD90119")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDocument2
    {
        /// <summary><para><c>write</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>write</c> method was the following:  <c>HRESULT write (SAFEARRAY() psarray)</c>;</para></remarks>
        // IDL: HRESULT write (SAFEARRAY() psarray);
        // VB6: Sub write (ByVal psarray() As Any)
        [DispId(1054)]
        void write([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] object psarray);

        /// <summary><para><c>writeln</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>writeln</c> method was the following:  <c>HRESULT writeln (SAFEARRAY() psarray)</c>;</para></remarks>
        // IDL: HRESULT writeln (SAFEARRAY() psarray);
        // VB6: Sub writeln (ByVal psarray() As Any)
        [DispId(1055)] //VarEnum.VT_VARIANT
        void writeln([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] object psarray);

        /// <summary><para><c>open</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>open</c> method was the following:  <c>HRESULT open ([optional, defaultvalue("text/html")] BSTR url, [optional] VARIANT name, [optional] VARIANT features, [optional] VARIANT replace, [out, retval] IDispatch** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT open ([optional, defaultvalue("text/html")] BSTR url, [optional] VARIANT name, [optional] VARIANT features, [optional] VARIANT replace, [out, retval] IDispatch** ReturnValue);
        // VB6: Function open ([ByVal url As String = "text/html"], [ByVal name As Any], [ByVal features As Any], [ByVal replace As Any]) As IDispatch
        [DispId(1056)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object open([MarshalAs(UnmanagedType.BStr)] string url, object name, object features, object replace);

        /// <summary><para><c>close</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>close</c> method was the following:  <c>HRESULT close (void)</c>;</para></remarks>
        // IDL: HRESULT close (void);
        // VB6: Sub close
        [DispId(1057)]
        void close();

        /// <summary><para><c>clear</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clear</c> method was the following:  <c>HRESULT clear (void)</c>;</para></remarks>
        // IDL: HRESULT clear (void);
        // VB6: Sub clear
        [DispId(1058)]
        void clear();

        /// <summary><para><c>queryCommandSupported</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandSupported</c> method was the following:  <c>HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandSupported (ByVal cmdID As String) As Boolean
        [DispId(1059)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandSupported([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandEnabled</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandEnabled</c> method was the following:  <c>HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandEnabled (ByVal cmdID As String) As Boolean
        [DispId(1060)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandEnabled([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandState</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandState</c> method was the following:  <c>HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandState (ByVal cmdID As String) As Boolean
        [DispId(1061)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandState([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandIndeterm</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandIndeterm</c> method was the following:  <c>HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandIndeterm (ByVal cmdID As String) As Boolean
        [DispId(1062)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandIndeterm([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandText</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandText</c> method was the following:  <c>HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue);
        // VB6: Function queryCommandText (ByVal cmdID As String) As String
        [DispId(1063)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string queryCommandText([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandValue</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandValue</c> method was the following:  <c>HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue);
        // VB6: Function queryCommandValue (ByVal cmdID As String) As Any
        [DispId(1064)]
        object queryCommandValue([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>execCommand</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommand</c> method was the following:  <c>HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommand (ByVal cmdID As String, [ByVal showUI As Boolean = False], [ByVal value As Any]) As Boolean
        [DispId(1065)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommand([MarshalAs(UnmanagedType.BStr)] string cmdID, [MarshalAs(UnmanagedType.VariantBool)] bool showUI, object value);

        /// <summary><para><c>execCommandShowHelp</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommandShowHelp</c> method was the following:  <c>HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommandShowHelp (ByVal cmdID As String) As Boolean
        [DispId(1066)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommandShowHelp([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>createElement</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createElement</c> method was the following:  <c>HRESULT createElement (BSTR eTag, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createElement (BSTR eTag, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function createElement (ByVal eTag As String) As IHTMLElement
        [DispId(1067)]
        IHTMLElement createElement([MarshalAs(UnmanagedType.BStr)] string eTag);

        /// <summary><para><c>elementFromPoint</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>elementFromPoint</c> method was the following:  <c>HRESULT elementFromPoint (long x, long y, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT elementFromPoint (long x, long y, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function elementFromPoint (ByVal x As Long, ByVal y As Long) As IHTMLElement
        [DispId(1068)]
        IHTMLElement elementFromPoint(int x, int y);

        /// <summary><para><c>toString</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>toString</c> method was the following:  <c>HRESULT toString ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT toString ([out, retval] BSTR* ReturnValue);
        // VB6: Function toString As String
        [DispId(1070)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        /// <summary><para><c>createStyleSheet</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createStyleSheet</c> method was the following:  <c>HRESULT createStyleSheet ([optional, defaultvalue("")] BSTR bstrHref, [optional, defaultvalue(-1)] long lIndex, [out, retval] IHTMLStyleSheet** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createStyleSheet ([optional, defaultvalue("")] BSTR bstrHref, [optional, defaultvalue(-1)] long lIndex, [out, retval] IHTMLStyleSheet** ReturnValue);
        // VB6: Function createStyleSheet ([ByVal bstrHref As String = ""], [ByVal lIndex As Long = -1]) As IHTMLStyleSheet
        [DispId(1071)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLStyleSheet
        object createStyleSheet([MarshalAs(UnmanagedType.BStr)] string bstrHref, int lIndex);

        /// <summary><para><c>activeElement</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>activeElement</c> property was the following:  <c>IHTMLElement* activeElement</c>;</para></remarks>
        // IDL: IHTMLElement* activeElement;
        // VB6: activeElement As IHTMLElement
        IHTMLElement activeElement
        {
            // IDL: HRESULT activeElement ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function activeElement As IHTMLElement
            [DispId(1005)]
            get;
        }

        /// <summary><para><c>alinkColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>alinkColor</c> property was the following:  <c>VARIANT alinkColor</c>;</para></remarks>
        // IDL: VARIANT alinkColor;
        // VB6: alinkColor As Any
        object alinkColor
        {
            // IDL: HRESULT alinkColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function alinkColor As Any
            [DispId(1022)]
            get;
            // IDL: HRESULT alinkColor (VARIANT value);
            // VB6: Sub alinkColor (ByVal value As Any)
            [DispId(1022)]
            set;
        }

        /// <summary><para><c>all</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>all</c> property was the following:  <c>IHTMLElementCollection* all</c>;</para></remarks>
        // IDL: IHTMLElementCollection* all;
        // VB6: all As IHTMLElementCollection
        object all
        {
            // IDL: HRESULT all ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function all As IHTMLElementCollection
            [DispId(1003)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>anchors</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>anchors</c> property was the following:  <c>IHTMLElementCollection* anchors</c>;</para></remarks>
        // IDL: IHTMLElementCollection* anchors;
        // VB6: anchors As IHTMLElementCollection
        object anchors
        {
            // IDL: HRESULT anchors ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function anchors As IHTMLElementCollection
            [DispId(1007)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>applets</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>applets</c> property was the following:  <c>IHTMLElementCollection* applets</c>;</para></remarks>
        // IDL: IHTMLElementCollection* applets;
        // VB6: applets As IHTMLElementCollection
        object applets
        {
            // IDL: HRESULT applets ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function applets As IHTMLElementCollection
            [DispId(1008)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>bgColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>body</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>body</c> property was the following:  <c>IHTMLElement* body</c>;</para></remarks>
        // IDL: IHTMLElement* body;
        // VB6: body As IHTMLElement
        IHTMLElement body
        {
            // IDL: HRESULT body ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function body As IHTMLElement
            [DispId(1004)]
            get;
        }

        /// <summary><para><c>charset</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>charset</c> property was the following:  <c>BSTR charset</c>;</para></remarks>
        // IDL: BSTR charset;
        // VB6: charset As String
        string charset
        {
            // IDL: HRESULT charset ([out, retval] BSTR* ReturnValue);
            // VB6: Function charset As String
            [DispId(1032)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT charset (BSTR value);
            // VB6: Sub charset (ByVal value As String)
            [DispId(1032)]
            set;
        }

        /// <summary><para><c>cookie</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>cookie</c> property was the following:  <c>BSTR cookie</c>;</para></remarks>
        // IDL: BSTR cookie;
        // VB6: cookie As String
        string cookie
        {
            // IDL: HRESULT cookie ([out, retval] BSTR* ReturnValue);
            // VB6: Function cookie As String
            [DispId(1030)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT cookie (BSTR value);
            // VB6: Sub cookie (ByVal value As String)
            [DispId(1030)]
            set;
        }

        /// <summary><para><c>defaultCharset</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>defaultCharset</c> property was the following:  <c>BSTR defaultCharset</c>;</para></remarks>
        // IDL: BSTR defaultCharset;
        // VB6: defaultCharset As String
        string defaultCharset
        {
            // IDL: HRESULT defaultCharset ([out, retval] BSTR* ReturnValue);
            // VB6: Function defaultCharset As String
            [DispId(1033)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT defaultCharset (BSTR value);
            // VB6: Sub defaultCharset (ByVal value As String)
            [DispId(1033)]
            set;
        }

        /// <summary><para><c>designMode</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>designMode</c> property was the following:  <c>BSTR designMode</c>;</para></remarks>
        // IDL: BSTR designMode;
        // VB6: designMode As String
        string designMode
        {
            // IDL: HRESULT designMode ([out, retval] BSTR* ReturnValue);
            // VB6: Function designMode As String
            [DispId(1014)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT designMode (BSTR value);
            // VB6: Sub designMode (ByVal value As String)
            [DispId(1014)]
            set;
        }

        /// <summary><para><c>domain</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>domain</c> property was the following:  <c>BSTR domain</c>;</para></remarks>
        // IDL: BSTR domain;
        // VB6: domain As String
        string domain
        {
            // IDL: HRESULT domain ([out, retval] BSTR* ReturnValue);
            // VB6: Function domain As String
            [DispId(1029)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT domain (BSTR value);
            // VB6: Sub domain (ByVal value As String)
            [DispId(1029)]
            set;
        }

        /// <summary><para><c>embeds</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>embeds</c> property was the following:  <c>IHTMLElementCollection* embeds</c>;</para></remarks>
        // IDL: IHTMLElementCollection* embeds;
        // VB6: embeds As IHTMLElementCollection
        object embeds
        {
            // IDL: HRESULT embeds ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function embeds As IHTMLElementCollection
            [DispId(1015)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>expando</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>expando</c> property was the following:  <c>VARIANT_BOOL expando</c>;</para></remarks>
        // IDL: VARIANT_BOOL expando;
        // VB6: expando As Boolean
        bool expando
        {
            // IDL: HRESULT expando ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function expando As Boolean
            [DispId(1031)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT expando (VARIANT_BOOL value);
            // VB6: Sub expando (ByVal value As Boolean)
            [DispId(1031)]
            set;
        }

        /// <summary><para><c>fgColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fgColor</c> property was the following:  <c>VARIANT fgColor</c>;</para></remarks>
        // IDL: VARIANT fgColor;
        // VB6: fgColor As Any
        object fgColor
        {
            // IDL: HRESULT fgColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function fgColor As Any
            [DispId(-2147413110)]
            get;
            // IDL: HRESULT fgColor (VARIANT value);
            // VB6: Sub fgColor (ByVal value As Any)
            [DispId(-2147413110)]
            set;
        }

        /// <summary><para><c>fileCreatedDate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileCreatedDate</c> property was the following:  <c>BSTR fileCreatedDate</c>;</para></remarks>
        // IDL: BSTR fileCreatedDate;
        // VB6: fileCreatedDate As String
        string fileCreatedDate
        {
            // IDL: HRESULT fileCreatedDate ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileCreatedDate As String
            [DispId(1043)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>fileModifiedDate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileModifiedDate</c> property was the following:  <c>BSTR fileModifiedDate</c>;</para></remarks>
        // IDL: BSTR fileModifiedDate;
        // VB6: fileModifiedDate As String
        string fileModifiedDate
        {
            // IDL: HRESULT fileModifiedDate ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileModifiedDate As String
            [DispId(1044)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>fileSize</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileSize</c> property was the following:  <c>BSTR fileSize</c>;</para></remarks>
        // IDL: BSTR fileSize;
        // VB6: fileSize As String
        string fileSize
        {
            // IDL: HRESULT fileSize ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileSize As String
            [DispId(1042)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>fileUpdatedDate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileUpdatedDate</c> property was the following:  <c>BSTR fileUpdatedDate</c>;</para></remarks>
        // IDL: BSTR fileUpdatedDate;
        // VB6: fileUpdatedDate As String
        string fileUpdatedDate
        {
            // IDL: HRESULT fileUpdatedDate ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileUpdatedDate As String
            [DispId(1045)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>forms</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>forms</c> property was the following:  <c>IHTMLElementCollection* forms</c>;</para></remarks>
        // IDL: IHTMLElementCollection* forms;
        // VB6: forms As IHTMLElementCollection
        object forms
        {
            // IDL: HRESULT forms ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function forms As IHTMLElementCollection
            [DispId(1010)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>frames</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>frames</c> property was the following:  <c>IHTMLFramesCollection2* frames</c>;</para></remarks>
        // IDL: IHTMLFramesCollection2* frames;
        // VB6: frames As IHTMLFramesCollection2
        object frames
        {
            // IDL: HRESULT frames ([out, retval] IHTMLFramesCollection2** ReturnValue);
            // VB6: Function frames As IHTMLFramesCollection2
            [DispId(1019)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLFramesCollection2
            get;
        }

        /// <summary><para><c>images</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>images</c> property was the following:  <c>IHTMLElementCollection* images</c>;</para></remarks>
        // IDL: IHTMLElementCollection* images;
        // VB6: images As IHTMLElementCollection
        object images
        {
            // IDL: HRESULT images ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function images As IHTMLElementCollection
            [DispId(1011)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>lastModified</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>lastModified</c> property was the following:  <c>BSTR lastModified</c>;</para></remarks>
        // IDL: BSTR lastModified;
        // VB6: lastModified As String
        string lastModified
        {
            // IDL: HRESULT lastModified ([out, retval] BSTR* ReturnValue);
            // VB6: Function lastModified As String
            [DispId(1028)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>linkColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>linkColor</c> property was the following:  <c>VARIANT linkColor</c>;</para></remarks>
        // IDL: VARIANT linkColor;
        // VB6: linkColor As Any
        object linkColor
        {
            // IDL: HRESULT linkColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function linkColor As Any
            [DispId(1024)]
            get;
            // IDL: HRESULT linkColor (VARIANT value);
            // VB6: Sub linkColor (ByVal value As Any)
            [DispId(1024)]
            set;
        }

        /// <summary><para><c>links</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>links</c> property was the following:  <c>IHTMLElementCollection* links</c>;</para></remarks>
        // IDL: IHTMLElementCollection* links;
        // VB6: links As IHTMLElementCollection
        object links
        {
            // IDL: HRESULT links ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function links As IHTMLElementCollection
            [DispId(1009)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>location</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>location</c> property was the following:  <c>IHTMLLocation* location</c>;</para></remarks>
        // IDL: IHTMLLocation* location;
        // VB6: location As IHTMLLocation
        object location
        {
            // IDL: HRESULT location ([out, retval] IHTMLLocation** ReturnValue);
            // VB6: Function location As IHTMLLocation
            [DispId(1026)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLLocation
            get;
        }

        /// <summary><para><c>mimeType</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>mimeType</c> property was the following:  <c>BSTR mimeType</c>;</para></remarks>
        // IDL: BSTR mimeType;
        // VB6: mimeType As String
        string mimeType
        {
            // IDL: HRESULT mimeType ([out, retval] BSTR* ReturnValue);
            // VB6: Function mimeType As String
            [DispId(1041)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>nameProp</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>nameProp</c> property was the following:  <c>BSTR nameProp</c>;</para></remarks>
        // IDL: BSTR nameProp;
        // VB6: nameProp As String
        string nameProp
        {
            // IDL: HRESULT nameProp ([out, retval] BSTR* ReturnValue);
            // VB6: Function nameProp As String
            [DispId(1048)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>onafterupdate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onbeforeupdate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onclick</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>ondblclick</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>ondragstart</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onerrorupdate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onhelp</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onkeydown</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onkeypress</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onkeyup</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onmousedown</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onmousemove</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onmouseout</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onmouseover</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onmouseup</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onreadystatechange</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onrowenter</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onrowexit</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>onselectstart</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
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

        /// <summary><para><c>parentWindow</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentWindow</c> property was the following:  <c>IHTMLWindow2* parentWindow</c>;</para></remarks>
        // IDL: IHTMLWindow2* parentWindow;
        // VB6: parentWindow As IHTMLWindow2
        object parentWindow
        {
            // IDL: HRESULT parentWindow ([out, retval] IHTMLWindow2** ReturnValue);
            // VB6: Function parentWindow As IHTMLWindow2
            [DispId(1034)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLWindow2
            get;
        }

        /// <summary><para><c>plugins</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>plugins</c> property was the following:  <c>IHTMLElementCollection* plugins</c>;</para></remarks>
        // IDL: IHTMLElementCollection* plugins;
        // VB6: plugins As IHTMLElementCollection
        object plugins
        {
            // IDL: HRESULT plugins ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function plugins As IHTMLElementCollection
            [DispId(1021)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>protocol</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>protocol</c> property was the following:  <c>BSTR protocol</c>;</para></remarks>
        // IDL: BSTR protocol;
        // VB6: protocol As String
        string protocol
        {
            // IDL: HRESULT protocol ([out, retval] BSTR* ReturnValue);
            // VB6: Function protocol As String
            [DispId(1047)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>readyState</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>readyState</c> property was the following:  <c>BSTR readyState</c>;</para></remarks>
        // IDL: BSTR readyState;
        // VB6: readyState As String
        string readyState
        {
            // IDL: HRESULT readyState ([out, retval] BSTR* ReturnValue);
            // VB6: Function readyState As String
            [DispId(1018)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>referrer</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>referrer</c> property was the following:  <c>BSTR referrer</c>;</para></remarks>
        // IDL: BSTR referrer;
        // VB6: referrer As String
        string referrer
        {
            // IDL: HRESULT referrer ([out, retval] BSTR* ReturnValue);
            // VB6: Function referrer As String
            [DispId(1027)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>Script</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>Script</c> property was the following:  <c>IDispatch* Script</c>;</para></remarks>
        // IDL: IDispatch* Script;
        // VB6: Script As IDispatch
        object Script
        {
            // IDL: HRESULT Script ([out, retval] IDispatch** ReturnValue);
            // VB6: Function Script As IDispatch
            [DispId(1001)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>scripts</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scripts</c> property was the following:  <c>IHTMLElementCollection* scripts</c>;</para></remarks>
        // IDL: IHTMLElementCollection* scripts;
        // VB6: scripts As IHTMLElementCollection
        object scripts
        {
            // IDL: HRESULT scripts ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function scripts As IHTMLElementCollection
            [DispId(1013)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>security</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>security</c> property was the following:  <c>BSTR security</c>;</para></remarks>
        // IDL: BSTR security;
        // VB6: security As String
        string security
        {
            // IDL: HRESULT security ([out, retval] BSTR* ReturnValue);
            // VB6: Function security As String
            [DispId(1046)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>selection</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>selection</c> property was the following:  <c>IHTMLSelectionObject* selection</c>;</para></remarks>
        // IDL: IHTMLSelectionObject* selection;
        // VB6: selection As IHTMLSelectionObject
        object selection
        {
            // IDL: HRESULT selection ([out, retval] IHTMLSelectionObject** ReturnValue);
            // VB6: Function selection As IHTMLSelectionObject
            [DispId(1017)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLSelectionObject
            get;
        }

        /// <summary><para><c>styleSheets</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>styleSheets</c> property was the following:  <c>IHTMLStyleSheetsCollection* styleSheets</c>;</para></remarks>
        // IDL: IHTMLStyleSheetsCollection* styleSheets;
        // VB6: styleSheets As IHTMLStyleSheetsCollection
        object styleSheets
        {
            // IDL: HRESULT styleSheets ([out, retval] IHTMLStyleSheetsCollection** ReturnValue);
            // VB6: Function styleSheets As IHTMLStyleSheetsCollection
            [DispId(1069)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLStyleSheetsCollection
            get;
        }

        /// <summary><para><c>title</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>title</c> property was the following:  <c>BSTR title</c>;</para></remarks>
        // IDL: BSTR title;
        // VB6: title As String
        string title
        {
            // IDL: HRESULT title ([out, retval] BSTR* ReturnValue);
            // VB6: Function title As String
            [DispId(1012)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT title (BSTR value);
            // VB6: Sub title (ByVal value As String)
            [DispId(1012)]
            set;
        }

        /// <summary><para><c>url</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>url</c> property was the following:  <c>BSTR url</c>;</para></remarks>
        // IDL: BSTR url;
        // VB6: url As String
        string url
        {
            // IDL: HRESULT url ([out, retval] BSTR* ReturnValue);
            // VB6: Function url As String
            [DispId(1025)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT url (BSTR value);
            // VB6: Sub url (ByVal value As String)
            [DispId(1025)]
            set;
        }

        /// <summary><para><c>vlinkColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>vlinkColor</c> property was the following:  <c>VARIANT vlinkColor</c>;</para></remarks>
        // IDL: VARIANT vlinkColor;
        // VB6: vlinkColor As Any
        object vlinkColor
        {
            // IDL: HRESULT vlinkColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function vlinkColor As Any
            [DispId(1023)]
            get;
            // IDL: HRESULT vlinkColor (VARIANT value);
            // VB6: Sub vlinkColor (ByVal value As Any)
            [DispId(1023)]
            set;
        }
    }
    #endregion
}