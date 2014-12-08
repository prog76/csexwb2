using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IHostDialogHelper Interface
    /// <summary>
    /// Creates a trusted, modal dialog box that displays HTML.
    /// Dialog boxes created with this method are trusted and do not have 
    /// a user interface that identifies them as Internet Explorer dialog boxes.
    /// The name on the title bar for the dialog box is taken from the title element
    /// in the HTML source specified by pMk. If there is no title element,
    /// the title bar name is blank.
    /// <code>
    /// object onull = null;
    /// string url = "C:\\Test.htm";
    /// string options = "dialogHeight:30;dialogWidth:40;help:no;status:yes";
    /// Type thtmlDialoghelper = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_HostDialogHelper, true);
    /// IHostDialogHelper dialoghelper = System.Activator.CreateInstance(thtmlDialoghelper) as IHostDialogHelper;
    /// if (dialoghelper != null)
    /// {
    ///     System.Runtime.InteropServices.ComTypes.IMoniker moniker = null;
    ///     WinApis.CreateURLMoniker(null, url, out moniker);
    ///     if (moniker != null)
    ///     {
    ///         dialoghelper.ShowHTMLDialog(this.Handle, moniker, ref onull , options, ref onull, null);
    ///     }
    /// }
    /// </code>
    /// </summary>
    [ComImport, ComVisible(true)]
    [Guid("53DEC138-A51E-11d2-861E-00C04FA35C89")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHostDialogHelper
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowHTMLDialog(
            [In] IntPtr hwndParent,
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pMk,
            [In] ref object pvarArgIn,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pchOptions,
            [In, Out] ref object pvarArgOut,
            [In, MarshalAs(UnmanagedType.IUnknown)] object punkHost);
    }
    #endregion
}