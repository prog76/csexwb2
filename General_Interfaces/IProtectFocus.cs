using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IProtectFocus Interface - IE7+Vista
    [ComImport, ComVisible(true)]
    [Guid("D81F90A3-8156-44F7-AD28-5ABB87003274")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProtectFocus
    {
        void AllowFocusChange([In, Out] ref bool pfAllow);
    }
    #endregion
}