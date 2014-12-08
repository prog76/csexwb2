using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f604-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLCaret
    {
        //    [] HRESULT MoveCaretToPointer([in] IDisplayPointer* pDispPointer,[in] BOOL fScrollIntoView,[in] CARET_DIRECTION eDir);
        void MoveCaretToPointer(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer,
           [MarshalAs(UnmanagedType.Bool)] bool fScrollIntoView,
            int /* CARET_DIRECTION */ eDir
           );

        //    [] HRESULT MoveCaretToPointerEx([in] IDisplayPointer* pDispPointer,[in] BOOL fVisible,[in] BOOL fScrollIntoView,[in] CARET_DIRECTION eDir);
        void MoveCaretToPointerEx(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer,
           [MarshalAs(UnmanagedType.Bool)] bool fVisible,
           [MarshalAs(UnmanagedType.Bool)] bool fScrollIntoView,
            int /* CARET_DIRECTION */ eDir
           );

        //    [] HRESULT MoveMarkupPointerToCaret([in] IMarkupPointer* pIMarkupPointer);
        void MoveMarkupPointerToCaret(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIMarkupPointer
           );

        //    [] HRESULT MoveDisplayPointerToCaret([in] IDisplayPointer* pDispPointer);
        void MoveDisplayPointerToCaret(
           [MarshalAs(UnmanagedType.Interface)] IDisplayPointer pDispPointer
           );

        //    [] HRESULT IsVisible([out] BOOL* pIsVisible);
        void IsVisible(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pIsVisible
           );

        //    [] HRESULT Show([in] BOOL fScrollIntoView);
        void Show(
           [MarshalAs(UnmanagedType.Bool)] bool fScrollIntoView
           );

        //    [] HRESULT Hide();
        void Hide();

        //    [] HRESULT InsertText([in] OLECHAR* pText,[in] LONG lLen);
        void InsertText(
           [MarshalAs(UnmanagedType.LPWStr)] string pText,
            //[in] LONG that specifies the number of characters to insert from pText. Setting this parameter to -1 inserts the whole string.
           int lLen
           );

        //    [] HRESULT ScrollIntoView();
        void ScrollIntoView();

        //    [] HRESULT GetLocation([out] POINT* pPoint,[in] BOOL fTranslate);
        void GetLocation(
           [Out] out tagPOINT pPoint,
           [MarshalAs(UnmanagedType.Bool)] bool fTranslate
           );

        //    [] HRESULT GetCaretDirection([out] CARET_DIRECTION* peDir);
        void GetCaretDirection(
           [Out] out int /* CARET_DIRECTION */ peDir
           );

        //    [] HRESULT SetCaretDirection([in] CARET_DIRECTION eDir);
        void SetCaretDirection(
            int /* CARET_DIRECTION */ eDir
           );

    }

}
