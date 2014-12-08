using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLRect Interface
    /// <summary><para><c>IHTMLRect</c> interface.</para></summary>
    [Guid("3050F4A3-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLRect
    {
        /// <summary><para><c>bottom</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bottom</c> property was the following:  <c>long bottom</c>;</para></remarks>
        // IDL: long bottom;
        // VB6: bottom As Long
        int bottom
        {
            // IDL: HRESULT bottom ([out, retval] long* ReturnValue);
            // VB6: Function bottom As Long
            [DispId(1004)]
            get;
            // IDL: HRESULT bottom (long value);
            // VB6: Sub bottom (ByVal value As Long)
            [DispId(1004)]
            set;
        }

        /// <summary><para><c>left</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>left</c> property was the following:  <c>long left</c>;</para></remarks>
        // IDL: long left;
        // VB6: left As Long
        int left
        {
            // IDL: HRESULT left ([out, retval] long* ReturnValue);
            // VB6: Function left As Long
            [DispId(1001)]
            get;
            // IDL: HRESULT left (long value);
            // VB6: Sub left (ByVal value As Long)
            [DispId(1001)]
            set;
        }

        /// <summary><para><c>right</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>right</c> property was the following:  <c>long right</c>;</para></remarks>
        // IDL: long right;
        // VB6: right As Long
        int right
        {
            // IDL: HRESULT right ([out, retval] long* ReturnValue);
            // VB6: Function right As Long
            [DispId(1003)]
            get;
            // IDL: HRESULT right (long value);
            // VB6: Sub right (ByVal value As Long)
            [DispId(1003)]
            set;
        }

        /// <summary><para><c>top</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>top</c> property was the following:  <c>long top</c>;</para></remarks>
        // IDL: long top;
        // VB6: top As Long
        int top
        {
            // IDL: HRESULT top ([out, retval] long* ReturnValue);
            // VB6: Function top As Long
            [DispId(1002)]
            get;
            // IDL: HRESULT top (long value);
            // VB6: Sub top (ByVal value As Long)
            [DispId(1002)]
            set;
        }
    }
    #endregion
}