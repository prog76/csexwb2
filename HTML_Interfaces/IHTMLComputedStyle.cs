using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f6c3-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLComputedStyle
    {
        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_BOLD)] HRESULT bold([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_BOLD)]
        bool bold { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_ITALIC)] HRESULT italic([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_ITALIC)]
        bool italic { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_UNDERLINE)] HRESULT underline([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_UNDERLINE)]
        bool underline { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_OVERLINE)] HRESULT overline([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_OVERLINE)]
        bool overline { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_STRIKEOUT)] HRESULT strikeOut([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_STRIKEOUT)]
        bool strikeOut { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_SUBSCRIPT)] HRESULT subScript([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_SUBSCRIPT)]
        bool subScript { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_SUPERSCRIPT)] HRESULT superScript([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_SUPERSCRIPT)]
        bool superScript { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_EXPLICITFACE)] HRESULT explicitFace([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_EXPLICITFACE)]
        bool explicitFace { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_FONTWEIGHT)] HRESULT fontWeight([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_FONTWEIGHT)]
        int fontWeight { get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_FONTSIZE)] HRESULT fontSize([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_FONTSIZE)]
        int fontSize { get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_FONTNAME)] HRESULT fontName([retval, out] TCHAR * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_FONTNAME)]
        IntPtr fontName { get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_HASBGCOLOR)] HRESULT hasBgColor([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_HASBGCOLOR)]
        bool hasBgColor { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_TEXTCOLOR)] HRESULT textColor([retval, out] DWORD * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_TEXTCOLOR)]
        uint textColor { get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_BACKGROUNDCOLOR)] HRESULT backgroundColor([retval, out] DWORD * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_BACKGROUNDCOLOR)]
        uint backgroundColor { get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_PREFORMATTED)] HRESULT preFormatted([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_PREFORMATTED)]
        bool preFormatted { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_DIRECTION)] HRESULT direction([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_DIRECTION)]
        bool direction { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_BLOCKDIRECTION)] HRESULT blockDirection([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_BLOCKDIRECTION)]
        bool blockDirection { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IHTMLCOMPUTEDSTYLE_OL)] HRESULT OL([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMPUTEDSTYLE_OL)]
        bool OL { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [] HRESULT IsEqual([in] IHTMLComputedStyle* pComputedStyle,[out] VARIANT_BOOL* pfEqual);
        void IsEqual(
           [In, MarshalAs(UnmanagedType.Interface)] IHTMLComputedStyle pComputedStyle,
           [Out, MarshalAs(UnmanagedType.VariantBool)] out bool pfEqual
           );

    }

}
