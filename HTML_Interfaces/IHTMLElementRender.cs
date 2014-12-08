using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLElementRender Interface

    /*
        IHTMLDocument3 doc = (IHTMLDocument3)wb.Document;
        IHTMLElement3 el = (IHTMLElement3)doc.documentElement;
        Graphics g = Graphics.FromImage(bm); // your bitmap
        IntPtr hdc = g.GetHdc();
        IHTMLElementRender render = (IHTMLElementRender)el;
        render.DrawToDC(hdc);
        g.ReleaseHdc(hdc);
        g.Dispose();
        }
        ...
        save bitmap as bitmap, gif, tiff, etc.
     */

    [Guid("3050f669-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true), ComImport]
    public interface IHTMLElementRender
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DrawToDC([In] int hDC);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetDocumentPrinter([In, MarshalAs(UnmanagedType.BStr)] string
        bstrPrinterName, [In] IntPtr hDC);
    }
    #endregion
}