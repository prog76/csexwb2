using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IAsyncMoniker Interface
    /// <summary>
    /// Helper interface to indicate to MSHTML that
    /// LoadHTMLMoniker class is capable of Async operations
    /// </summary>
    [ComVisible(true), ComImport(),
    Guid("79EAC9D3-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAsyncMoniker
    {
    }
    #endregion
}