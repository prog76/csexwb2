using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f38e-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLImageElementFactory
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLIMAGEELEMENTFACTORY_CREATE)]
        IHTMLImgElement create(object width, object height);
    }
}
