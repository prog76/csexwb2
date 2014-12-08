using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLBodyElement2 Interface
    /// <summary><para><c>IHTMLBodyElement2</c> interface.</para></summary>
    [Guid("3050F5C5-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLBodyElement2
    {
        /// <summary><para><c>onafterprint</c> property of <c>IHTMLBodyElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onafterprint</c> property was the following:  <c>VARIANT onafterprint</c>;</para></remarks>
        // IDL: VARIANT onafterprint;
        // VB6: onafterprint As Any
        object onafterprint
        {
            // IDL: HRESULT onafterprint ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onafterprint As Any
            [DispId(-2147412045)]
            get;
            // IDL: HRESULT onafterprint (VARIANT value);
            // VB6: Sub onafterprint (ByVal value As Any)
            [DispId(-2147412045)]
            set;
        }

        /// <summary><para><c>onbeforeprint</c> property of <c>IHTMLBodyElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeprint</c> property was the following:  <c>VARIANT onbeforeprint</c>;</para></remarks>
        // IDL: VARIANT onbeforeprint;
        // VB6: onbeforeprint As Any
        object onbeforeprint
        {
            // IDL: HRESULT onbeforeprint ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeprint As Any
            [DispId(-2147412046)]
            get;
            // IDL: HRESULT onbeforeprint (VARIANT value);
            // VB6: Sub onbeforeprint (ByVal value As Any)
            [DispId(-2147412046)]
            set;
        }
    }
    #endregion
}