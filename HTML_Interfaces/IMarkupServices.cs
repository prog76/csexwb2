using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

//Next one IDisplayServices

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f4a0-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IMarkupServices
    {
        //    [] HRESULT CreateMarkupPointer([out] IMarkupPointer** ppPointer);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateMarkupPointer(
           [Out, MarshalAs(UnmanagedType.Interface)] out IMarkupPointer ppPointer
           );

        //    [] HRESULT CreateMarkupContainer([out] IMarkupContainer** ppMarkupContainer);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateMarkupContainer(
           [Out, MarshalAs(UnmanagedType.Interface)] out IMarkupContainer ppMarkupContainer
           );

        //    [] HRESULT CreateElement([in] ELEMENT_TAG_ID tagID,[in] OLECHAR* pchAttributes,[out] IHTMLElement** ppElement);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateElement(
            int /* ELEMENT_TAG_ID */ tagID,
           [MarshalAs(UnmanagedType.LPWStr)] string pchAttributes,
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppElement
           );

        //    [] HRESULT CloneElement([in] IHTMLElement* pElemCloneThis,[out] IHTMLElement** ppElementTheClone);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CloneElement(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElemCloneThis,
           [Out, MarshalAs(UnmanagedType.Interface)] out IHTMLElement ppElementTheClone
           );

        //    [] HRESULT InsertElement([in] IHTMLElement* pElementInsert,[in] IMarkupPointer* pPointerStart,[in] IMarkupPointer* pPointerFinish);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertElement(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElementInsert,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerFinish
           );

        //    [] HRESULT RemoveElement([in] IHTMLElement* pElementRemove);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RemoveElement(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElementRemove
           );

        //    [] HRESULT Remove([in] IMarkupPointer* pPointerStart,[in] IMarkupPointer* pPointerFinish);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Remove(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerFinish
           );

        //    [] HRESULT Copy([in] IMarkupPointer* pPointerSourceStart,[in] IMarkupPointer* pPointerSourceFinish,[in] IMarkupPointer* pPointerTarget);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Copy(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerSourceStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerSourceFinish,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerTarget
           );

        //    [] HRESULT Move([in] IMarkupPointer* pPointerSourceStart,[in] IMarkupPointer* pPointerSourceFinish,[in] IMarkupPointer* pPointerTarget);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Move(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerSourceStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerSourceFinish,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerTarget
           );

        //    [] HRESULT InsertText([in] OLECHAR* pchText,[in] long cch,[in] IMarkupPointer* pPointerTarget);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertText(
           [MarshalAs(UnmanagedType.LPWStr)] string pchText,
           int cch,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerTarget
           );

        //    [] HRESULT ParseString([in] OLECHAR* pchHTML,[in] DWORD dwFlags,[out] IMarkupContainer** ppContainerResult,[in] IMarkupPointer* ppPointerStart,[in] IMarkupPointer* ppPointerFinish);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ParseString(
           [MarshalAs(UnmanagedType.LPWStr)] string pchHTML,
           uint dwFlags,
           [Out, MarshalAs(UnmanagedType.Interface)] out IMarkupContainer ppContainerResult,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer ppPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer ppPointerFinish
           );

        //    [] HRESULT ParseGlobal([in] HGLOBAL hglobalHTML,[in] DWORD dwFlags,[out] IMarkupContainer** ppContainerResult,[in] IMarkupPointer* pPointerStart,[in] IMarkupPointer* pPointerFinish);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ParseGlobal(
           IntPtr hglobalHTML,
           uint dwFlags,
           [Out, MarshalAs(UnmanagedType.Interface)] out IMarkupContainer ppContainerResult,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerFinish
           );

        //    [] HRESULT IsScopedElement([in] IHTMLElement* pElement,[out] BOOL* pfScoped);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsScopedElement(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElement,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfScoped
           );

        //    [] HRESULT GetElementTagId([in] IHTMLElement* pElement,[out] ELEMENT_TAG_ID* ptagId);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetElementTagId(
           [MarshalAs(UnmanagedType.Interface)] IHTMLElement pElement,
           [Out] out int /* ELEMENT_TAG_ID */ ptagId
           );

        //    [] HRESULT GetTagIDForName([in] BSTR bstrName,[out] ELEMENT_TAG_ID* ptagId);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetTagIDForName(
           [MarshalAs(UnmanagedType.BStr)] string bstrName,
           [Out] out int /* ELEMENT_TAG_ID */ ptagId
           );

        //    [] HRESULT GetNameForTagID([in] ELEMENT_TAG_ID tagId,[out] BSTR* pbstrName);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetNameForTagID(
            int /* ELEMENT_TAG_ID */ tagId,
           [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName
           );

        //    [] HRESULT MovePointersToRange([in] IHTMLTxtRange* pIRange,[in] IMarkupPointer* pPointerStart,[in] IMarkupPointer* pPointerFinish);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MovePointersToRange(
           [MarshalAs(UnmanagedType.Interface)] IHTMLTxtRange pIRange,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerFinish
           );

        //    [] HRESULT MoveRangeToPointers([in] IMarkupPointer* pPointerStart,[in] IMarkupPointer* pPointerFinish,[in] IHTMLTxtRange* pIRange);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MoveRangeToPointers(
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerStart,
           [MarshalAs(UnmanagedType.Interface)] IMarkupPointer pPointerFinish,
           [MarshalAs(UnmanagedType.Interface)] IHTMLTxtRange pIRange
           );

        //    [] HRESULT BeginUndoUnit([in] OLECHAR* pchTitle);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int BeginUndoUnit(
           [MarshalAs(UnmanagedType.LPWStr)] string pchTitle
           );

        //    [] HRESULT EndUndoUnit();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EndUndoUnit();

    }

}
