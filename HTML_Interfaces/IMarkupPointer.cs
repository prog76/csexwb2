using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f49f-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IMarkupPointer
    {
        //    [] HRESULT OwningDoc([out] IHTMLDocument2** ppDoc);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OwningDoc(
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLDocument2 ppDoc
           );

        //    [] HRESULT Gravity([out] POINTER_GRAVITY* pGravity);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Gravity(
           [Out] out int /* POINTER_GRAVITY */ pGravity
           );

        //    [] HRESULT SetGravity([in] POINTER_GRAVITY Gravity);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetGravity(
            int /* POINTER_GRAVITY */ Gravity
           );

        //    [] HRESULT Cling([out] BOOL* pfCling);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Cling(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfCling
           );

        //    [] HRESULT SetCling([in] BOOL fCLing);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetCling(
           [MarshalAs(UnmanagedType.Bool)] bool fCLing
           );

        //    [] HRESULT Unposition();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Unposition();

        //    [] HRESULT IsPositioned([out] BOOL* pfPositioned);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsPositioned(
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfPositioned
           );

        //    [] HRESULT GetContainer([out] IMarkupContainer** ppContainer);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetContainer(
           [Out, MarshalAs(UnmanagedType.Interface)] out IMarkupContainer ppContainer
           );

        //    [] HRESULT MoveAdjacentToElement([in] IHTMLElement* pElement,[in] ELEMENT_ADJACENCY eAdj);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveAdjacentToElement(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElement,
            int /* ELEMENT_ADJACENCY */ eAdj
           );

        //    [] HRESULT MoveToPointer([in] IMarkupPointer* pPointer);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveToPointer(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointer
           );

        //    [] HRESULT MoveToContainer([in] IMarkupContainer* pContainer,[in] BOOL fAtStart);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveToContainer(
           [MarshalAs(UnmanagedType.Interface)] IMarkupContainer pContainer,
           [MarshalAs(UnmanagedType.Bool)] bool fAtStart
           );

        //    [] HRESULT Left([in] BOOL fMove,[out] MARKUP_CONTEXT_TYPE* pContext,[out] IHTMLElement** ppElement,[in, out] long* pcch,[out] OLECHAR* pchText);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Left(
           [MarshalAs(UnmanagedType.Bool)] bool fMove,
           [Out] out int /* MARKUP_CONTEXT_TYPE */ pContext,
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppElement,
           [Out] out int pcch,
           [Out, MarshalAs(UnmanagedType.LPWStr)] out string pchText
           );

        //    [] HRESULT Right([in] BOOL fMove,[out] MARKUP_CONTEXT_TYPE* pContext,[out] IHTMLElement** ppElement,[in, out] long* pcch,[out] OLECHAR* pchText);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Right(
           [MarshalAs(UnmanagedType.Bool)] bool fMove,
           [Out] out int /* MARKUP_CONTEXT_TYPE */ pContext,
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppElement,
           [Out] out int pcch,
           [Out, MarshalAs(UnmanagedType.LPWStr)] out string pchText
           );

        //    [] HRESULT CurrentScope([out] IHTMLElement** ppElemCurrent);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CurrentScope(
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppElemCurrent
           );

        //    [] HRESULT IsLeftOf([in] IMarkupPointer* pPointerThat,[out] BOOL* pfResult);
        void IsLeftOf(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerThat,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfResult
           );

        //    [] HRESULT IsLeftOfOrEqualTo([in] IMarkupPointer* pPointerThat,[out] BOOL* pfResult);
        void IsLeftOfOrEqualTo(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerThat,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfResult
           );

        //    [] HRESULT IsRightOf([in] IMarkupPointer* pPointerThat,[out] BOOL* pfResult);
        void IsRightOf(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerThat,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfResult
           );

        //    [] HRESULT IsRightOfOrEqualTo([in] IMarkupPointer* pPointerThat,[out] BOOL* pfResult);
        void IsRightOfOrEqualTo(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerThat,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfResult
           );

        //    [] HRESULT IsEqualTo([in] IMarkupPointer* pPointerThat,[out] BOOL* pfAreEqual);
        void IsEqualTo(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerThat,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAreEqual
           );

        //    [] HRESULT MoveUnit([in] MOVEUNIT_ACTION muAction);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveUnit(
            int /* MOVEUNIT_ACTION */ muAction
           );

        //    [] HRESULT FindText([in] OLECHAR* pchFindText,[in] DWORD dwFlags,[in] IMarkupPointer* pIEndMatch,[in] IMarkupPointer* pIEndSearch);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int FindText(
           [MarshalAs(UnmanagedType.LPWStr)] string pchFindText,
           uint dwFlags,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIEndMatch,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pIEndSearch
           );

    }

}
