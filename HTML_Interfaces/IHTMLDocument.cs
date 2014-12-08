using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDocument Interface
    /// <summary><para><c>IHTMLDocument</c> interface.</para></summary>
    [Guid("626FC520-A41E-11CF-A731-00A0C9082637")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDocument
    {
        /// <summary><para><c>Script</c> property of <c>IHTMLDocument</c> interface.</para></summary>
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
    }
    #endregion
}