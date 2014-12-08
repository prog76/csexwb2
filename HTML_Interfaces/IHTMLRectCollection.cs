using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLRectCollection Interface
    /// <summary><para><c>IHTMLRectCollection</c> interface.</para></summary>
    [Guid("3050F4A4-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLRectCollection : System.Collections.IEnumerable
    {
        /// <summary><para><c>item</c> method of <c>IHTMLRectCollection</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>item</c> method was the following:  <c>HRESULT item ([in] VARIANT* pvarIndex, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT item ([in] VARIANT* pvarIndex, [out, retval] VARIANT* ReturnValue);
        // VB6: Function item (pvarIndex As Any) As Any
        [DispId(0)]
        object item([In] ref object pvarIndex);

        /// <summary><para><c>_newEnum</c> property of <c>IHTMLRectCollection</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>_newEnum</c> property was the following:  <c>IUnknown* _newEnum</c>;</para></remarks>
        // IDL: IUnknown* _newEnum;
        // VB6: _newEnum As IUnknown
        object _newEnum
        {
            // IDL: HRESULT _newEnum ([out, retval] IUnknown** ReturnValue);
            // VB6: Function _newEnum As IUnknown
            [DispId(-4)]
            [return: MarshalAs(UnmanagedType.IUnknown)]
            get;
        }

        /// <summary><para><c>length</c> property of <c>IHTMLRectCollection</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>length</c> property was the following:  <c>long length</c>;</para></remarks>
        // IDL: long length;
        // VB6: length As Long
        int length
        {
            // IDL: HRESULT length ([out, retval] long* ReturnValue);
            // VB6: Function length As Long
            [DispId(1500)]
            get;
        }
    }
    #endregion
}