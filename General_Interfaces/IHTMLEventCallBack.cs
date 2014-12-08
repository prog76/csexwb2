using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLEventCallBack Interface
    /// <summary>
    /// Simple interface used as a callback implemented by the main control
    /// GUID generated using PSDK GUID generator
    /// </summary>
    [ComVisible(true), Guid("9995A2E0-CD26-4f3a-87FD-0E2B9B1F4648")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLEventCallBack
    {
        bool HandleHTMLEvent([In] HTMLEventType EventType, [In] HTMLEventDispIds EventDispId, [In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }
    #endregion
}