using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLDataTransfer interface
    [ComImport, ComVisible(true), Guid("3050f4b3-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDataTransfer
    {
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool setData([In, MarshalAs(UnmanagedType.BStr)] string format, [In] object data);

        [return: MarshalAs(UnmanagedType.BStr)]
        string getData([In, MarshalAs(UnmanagedType.BStr)] string format);

        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool clearData([In, MarshalAs(UnmanagedType.BStr)] string format);

        string dropEffect { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        string effectAllowed { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}