using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("FECEAAA5-8405-11cf-8BA1-00AA00476DA6")]
    public interface IOmNavigator
    {
        //    [propget, id(DISPID_IOMNAVIGATOR_APPCODENAME)] HRESULT appCodeName([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_APPCODENAME)]
        string appCodeName { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_APPNAME)] HRESULT appName([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_APPNAME)]
        string appName { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_APPVERSION)] HRESULT appVersion([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_APPVERSION)]
        string appVersion { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_USERAGENT)] HRESULT userAgent([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_USERAGENT)]
        string userAgent { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [id(DISPID_IOMNAVIGATOR_JAVAENABLED)] HRESULT javaEnabled([retval, out] VARIANT_BOOL* enabled);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_JAVAENABLED)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool javaEnabled();

        //    [id(DISPID_IOMNAVIGATOR_TAINTENABLED)] HRESULT taintEnabled([retval, out] VARIANT_BOOL* enabled);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_TAINTENABLED)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool taintEnabled();

        //    [propget, id(DISPID_IOMNAVIGATOR_MIMETYPES)] HRESULT mimeTypes([retval, out] IHTMLMimeTypesCollection* * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_MIMETYPES)]
        /*IHTMLMimeTypesCollection*/ object mimeTypes { [return: MarshalAs(UnmanagedType.Interface)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_PLUGINS)] HRESULT plugins([retval, out] IHTMLPluginsCollection* * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_PLUGINS)]
        /*IHTMLPluginsCollection*/ object plugins { [return: MarshalAs(UnmanagedType.Interface)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_COOKIEENABLED)] HRESULT cookieEnabled([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_COOKIEENABLED)]
        bool cookieEnabled { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_OPSPROFILE)] HRESULT opsProfile([retval, out] IHTMLOpsProfile* * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_OPSPROFILE)]
        /*IHTMLOpsProfile*/ object opsProfile { [return: MarshalAs(UnmanagedType.Interface)] get;}

        //    [id(DISPID_IOMNAVIGATOR_TOSTRING)] HRESULT toString([retval, out] BSTR* string);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_TOSTRING)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        //    [propget, id(DISPID_IOMNAVIGATOR_CPUCLASS)] HRESULT cpuClass([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_CPUCLASS)]
        string cpuClass { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_SYSTEMLANGUAGE)] HRESULT systemLanguage([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_SYSTEMLANGUAGE)]
        string systemLanguage { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_BROWSERLANGUAGE), hidden] HRESULT browserLanguage([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_BROWSERLANGUAGE)]
        string browserLanguage { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_USERLANGUAGE)] HRESULT userLanguage([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_USERLANGUAGE)]
        string userLanguage { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_PLATFORM)] HRESULT platform([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_PLATFORM)]
        string platform { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_APPMINORVERSION)] HRESULT appMinorVersion([retval, out] BSTR * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_APPMINORVERSION)]
        string appMinorVersion { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_CONNECTIONSPEED), hidden] HRESULT connectionSpeed([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_CONNECTIONSPEED)]
        int connectionSpeed { get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_ONLINE)] HRESULT onLine([retval, out] VARIANT_BOOL * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_ONLINE)]
        bool onLine { [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        //    [propget, id(DISPID_IOMNAVIGATOR_USERPROFILE)] HRESULT userProfile([retval, out] IHTMLOpsProfile* * p);
        [DispId(HTMLDispIDs.DISPID_IOMNAVIGATOR_USERPROFILE)]
        /*IHTMLOpsProfile*/ object userProfile { [return: MarshalAs(UnmanagedType.Interface)] get;}

    }

}
