using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTxtRange Interface
    /// <summary><para><c>IHTMLTxtRange</c> interface.</para></summary>
    [Guid("3050F220-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLTxtRange
    {
        /// <summary><para><c>parentElement</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentElement</c> method was the following:  <c>HRESULT parentElement ([out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT parentElement ([out, retval] IHTMLElement** ReturnValue);
        // VB6: Function parentElement As IHTMLElement
        [DispId(1006)]
        IHTMLElement parentElement();

        /// <summary><para><c>duplicate</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>duplicate</c> method was the following:  <c>HRESULT duplicate ([out, retval] IHTMLTxtRange** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT duplicate ([out, retval] IHTMLTxtRange** ReturnValue);
        // VB6: Function duplicate As IHTMLTxtRange
        [DispId(1008)]
        IHTMLTxtRange duplicate();

        /// <summary><para><c>inRange</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>inRange</c> method was the following:  <c>HRESULT inRange (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT inRange (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function inRange (ByVal range As IHTMLTxtRange) As Boolean
        [DispId(1010)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool inRange(IHTMLTxtRange range);

        /// <summary><para><c>isEqual</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isEqual</c> method was the following:  <c>HRESULT isEqual (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT isEqual (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function isEqual (ByVal range As IHTMLTxtRange) As Boolean
        [DispId(1011)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool isEqual(IHTMLTxtRange range);

        /// <summary><para><c>scrollIntoView</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollIntoView</c> method was the following:  <c>HRESULT scrollIntoView ([optional, defaultvalue(-1)] VARIANT_BOOL fStart)</c>;</para></remarks>
        // IDL: HRESULT scrollIntoView ([optional, defaultvalue(-1)] VARIANT_BOOL fStart);
        // VB6: Sub scrollIntoView ([ByVal fStart As Boolean = True])
        [DispId(1012)]
        void scrollIntoView([MarshalAs(UnmanagedType.VariantBool)] bool fStart);

        /// <summary><para><c>collapse</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>collapse</c> method was the following:  <c>HRESULT collapse ([optional, defaultvalue(-1)] VARIANT_BOOL Start)</c>;</para></remarks>
        // IDL: HRESULT collapse ([optional, defaultvalue(-1)] VARIANT_BOOL Start);
        // VB6: Sub collapse ([ByVal Start As Boolean = True])
        [DispId(1013)]
        void collapse([MarshalAs(UnmanagedType.VariantBool)] bool Start);

        /// <summary><para><c>expand</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>expand</c> method was the following:  <c>HRESULT expand (BSTR Unit, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT expand (BSTR Unit, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function expand (ByVal Unit As String) As Boolean
        [DispId(1014)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool expand([MarshalAs(UnmanagedType.BStr)] string Unit);

        /// <summary><para><c>move</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>move</c> method was the following:  <c>HRESULT move (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT move (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue);
        // VB6: Function move (ByVal Unit As String, [ByVal Count As Long = 1]) As Long
        [DispId(1015)]
        int move([MarshalAs(UnmanagedType.BStr)] string Unit, int Count);

        /// <summary><para><c>moveStart</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveStart</c> method was the following:  <c>HRESULT moveStart (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT moveStart (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue);
        // VB6: Function moveStart (ByVal Unit As String, [ByVal Count As Long = 1]) As Long
        [DispId(1016)]
        int moveStart([MarshalAs(UnmanagedType.BStr)] string Unit, int Count);

        /// <summary><para><c>moveEnd</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveEnd</c> method was the following:  <c>HRESULT moveEnd (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT moveEnd (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue);
        // VB6: Function moveEnd (ByVal Unit As String, [ByVal Count As Long = 1]) As Long
        [DispId(1017)]
        int moveEnd([MarshalAs(UnmanagedType.BStr)] string Unit, int Count);

        /// <summary><para><c>select</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>select</c> method was the following:  <c>HRESULT select (void)</c>;</para></remarks>
        // IDL: HRESULT select (void);
        // VB6: Sub select
        [DispId(1024)]
        void select();

        /// <summary><para><c>pasteHTML</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pasteHTML</c> method was the following:  <c>HRESULT pasteHTML (BSTR html)</c>;</para></remarks>
        // IDL: HRESULT pasteHTML (BSTR html);
        // VB6: Sub pasteHTML (ByVal html As String)
        [DispId(1026)]
        void pasteHTML([MarshalAs(UnmanagedType.BStr)] string html);

        /// <summary><para><c>moveToElementText</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveToElementText</c> method was the following:  <c>HRESULT moveToElementText (IHTMLElement* element)</c>;</para></remarks>
        // IDL: HRESULT moveToElementText (IHTMLElement* element);
        // VB6: Sub moveToElementText (ByVal element As IHTMLElement)
        [DispId(1001)]
        void moveToElementText(IHTMLElement element);

        /// <summary><para><c>setEndPoint</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setEndPoint</c> method was the following:  <c>HRESULT setEndPoint (BSTR how, IHTMLTxtRange* SourceRange)</c>;</para></remarks>
        // IDL: HRESULT setEndPoint (BSTR how, IHTMLTxtRange* SourceRange);
        // VB6: Sub setEndPoint (ByVal how As String, ByVal SourceRange As IHTMLTxtRange)
        [DispId(1025)]
        void setEndPoint([MarshalAs(UnmanagedType.BStr)] string how, IHTMLTxtRange SourceRange);

        /// <summary><para><c>compareEndPoints</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>compareEndPoints</c> method was the following:  <c>HRESULT compareEndPoints (BSTR how, IHTMLTxtRange* SourceRange, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT compareEndPoints (BSTR how, IHTMLTxtRange* SourceRange, [out, retval] long* ReturnValue);
        // VB6: Function compareEndPoints (ByVal how As String, ByVal SourceRange As IHTMLTxtRange) As Long
        [DispId(1018)]
        int compareEndPoints([MarshalAs(UnmanagedType.BStr)] string how, IHTMLTxtRange SourceRange);

        /// <summary><para><c>findText</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>findText</c> method was the following:  <c>HRESULT findText (BSTR String, [optional, defaultvalue(1073741823)] long Count, [optional, defaultvalue(0)] long Flags, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT findText (BSTR String, [optional, defaultvalue(1073741823)] long Count, [optional, defaultvalue(0)] long Flags, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function findText (ByVal String As String, [ByVal Count As Long = 1073741823], [ByVal Flags As Long = 0]) As Boolean
        [DispId(1019)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool findText([MarshalAs(UnmanagedType.BStr)] string String, int Count, int Flags);

        /// <summary><para><c>moveToPoint</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveToPoint</c> method was the following:  <c>HRESULT moveToPoint (long x, long y)</c>;</para></remarks>
        // IDL: HRESULT moveToPoint (long x, long y);
        // VB6: Sub moveToPoint (ByVal x As Long, ByVal y As Long)
        [DispId(1020)]
        void moveToPoint(int x, int y);

        /// <summary><para><c>getBookmark</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getBookmark</c> method was the following:  <c>HRESULT getBookmark ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getBookmark ([out, retval] BSTR* ReturnValue);
        // VB6: Function getBookmark As String
        [DispId(1021)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string getBookmark();

        /// <summary><para><c>moveToBookmark</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveToBookmark</c> method was the following:  <c>HRESULT moveToBookmark (BSTR Bookmark, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT moveToBookmark (BSTR Bookmark, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function moveToBookmark (ByVal Bookmark As String) As Boolean
        [DispId(1009)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool moveToBookmark([MarshalAs(UnmanagedType.BStr)] string Bookmark);

        /// <summary><para><c>queryCommandSupported</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandSupported</c> method was the following:  <c>HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandSupported (ByVal cmdID As String) As Boolean
        [DispId(1027)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandSupported([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandEnabled</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandEnabled</c> method was the following:  <c>HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandEnabled (ByVal cmdID As String) As Boolean
        [DispId(1028)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandEnabled([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandState</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandState</c> method was the following:  <c>HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandState (ByVal cmdID As String) As Boolean
        [DispId(1029)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandState([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandIndeterm</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandIndeterm</c> method was the following:  <c>HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandIndeterm (ByVal cmdID As String) As Boolean
        [DispId(1030)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandIndeterm([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandText</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandText</c> method was the following:  <c>HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue);
        // VB6: Function queryCommandText (ByVal cmdID As String) As String
        [DispId(1031)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string queryCommandText([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandValue</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandValue</c> method was the following:  <c>HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue);
        // VB6: Function queryCommandValue (ByVal cmdID As String) As Any
        [DispId(1032)]
        object queryCommandValue([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>execCommand</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommand</c> method was the following:  <c>HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommand (ByVal cmdID As String, [ByVal showUI As Boolean = False], [ByVal value As Any]) As Boolean
        [DispId(1033)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommand([MarshalAs(UnmanagedType.BStr)] string cmdID, [MarshalAs(UnmanagedType.VariantBool)] bool showUI, object value);

        /// <summary><para><c>execCommandShowHelp</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommandShowHelp</c> method was the following:  <c>HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommandShowHelp (ByVal cmdID As String) As Boolean
        [DispId(1034)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommandShowHelp([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>htmlText</c> property of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>htmlText</c> property was the following:  <c>BSTR htmlText</c>;</para></remarks>
        // IDL: BSTR htmlText;
        // VB6: htmlText As String
        string htmlText
        {
            // IDL: HRESULT htmlText ([out, retval] BSTR* ReturnValue);
            // VB6: Function htmlText As String
            [DispId(1003)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>text</c> property of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>text</c> property was the following:  <c>BSTR text</c>;</para></remarks>
        // IDL: BSTR text;
        // VB6: text As String
        string text
        {
            // IDL: HRESULT text ([out, retval] BSTR* ReturnValue);
            // VB6: Function text As String
            [DispId(1004)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT text (BSTR value);
            // VB6: Sub text (ByVal value As String)
            [DispId(1004)]
            set;
        }
    }
    #endregion
}