using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLOMWindowServices Interface
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f5fc-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLOMWindowServices
    {
        void moveTo([In] int x, [In] int y);
        void moveBy([In] int x, [In] int y);
        void resizeTo([In] int x, [In] int y);
        void resizeBy([In] int x, [In] int y);
    }
    #endregion
}