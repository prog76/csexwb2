using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f6a6-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLPainter
    {
        //    [] HRESULT Draw([in] RECT rcBounds,[in] RECT rcUpdate,[in] LONG lDrawFlags,[in] HDC hdc,[in] LPVOID pvDrawObject);
        void Draw(
           tagRECT rcBounds,
           tagRECT rcUpdate,
           int lDrawFlags,
           int hdc, //IntPtr
           IntPtr pvDrawObject
           );

        //    [] HRESULT OnResize([in] SIZE size);
        void OnResize(
           tagSIZE size
           );

        //    [] HRESULT GetPainterInfo([out] HTML_PAINTER_INFO* pInfo);
        void GetPainterInfo(
           [Out] out HTML_PAINTER_INFO pInfo
           );

        //    [] HRESULT HitTestPoint([in] POINT pt,[out] BOOL* pbHit,[out] LONG* plPartID);
        void HitTestPoint(
           tagPOINT pt,
           [Out, MarshalAs(UnmanagedType.Bool)] out bool pbHit,
           [Out] out int plPartID
           );

    }

}
