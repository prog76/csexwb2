using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f699-98b5-11cf-bb82-00aa00bdce0b")]
    public interface ISelectionServicesListener
    {
        //    [] HRESULT BeginSelectionUndo();
        void BeginSelectionUndo();

        //    [] HRESULT EndSelectionUndo();
        void EndSelectionUndo();

        //    [] HRESULT OnSelectedElementExit([in] IMarkupPointer* pIElementStart,[in] IMarkupPointer* pIElementEnd,[in] IMarkupPointer* pIElementContentStart,[in] IMarkupPointer* pIElementContentEnd);
        void OnSelectedElementExit(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIElementStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIElementEnd,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIElementContentStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIElementContentEnd
           );

        //    [] HRESULT OnChangeType([in] SELECTION_TYPE eType,[in] ISelectionServicesListener* pIListener);
        void OnChangeType(
            int /* SELECTION_TYPE */ eType,
           [MarshalAs(UnmanagedType.Interface)] ISelectionServicesListener pIListener
           );

        //    [] HRESULT GetTypeDetail([out] BSTR* pTypeDetail);
        void GetTypeDetail(
           [Out, MarshalAs(UnmanagedType.BStr)] out string pTypeDetail
           );

    }

}
