using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Collections;
using System.Text;

namespace IfacesEnumsStructsClasses
{
    #region IShellLinkW Interface
    [ComVisible(true), ComImport(),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214F9-0000-0000-C000-000000000046")]
    public interface IShellLinkW
    {
        /// <summary>Retrieves the path and file name of a Shell link object</summary>
        int GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out WIN32_FIND_DATAW pfd, SLGP_FLAGS fFlags);
        /// <summary>Retrieves the list of item identifiers for a Shell link object</summary>
        int GetIDList(out IntPtr ppidl);
        /// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object.</summary>
        int SetIDList(IntPtr pidl);
        /// <summary>Retrieves the description string for a Shell link object</summary>
        int GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        /// <summary>Sets the description for a Shell link object. The description can be any application-defined string</summary>
        int SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        /// <summary>Retrieves the name of the working directory for a Shell link object</summary>
        int GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        /// <summary>Sets the name of the working directory for a Shell link object</summary>
        int SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        /// <summary>Retrieves the command-line arguments associated with a Shell link object</summary>
        int GetArguments([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        /// <summary>Sets the command-line arguments for a Shell link object</summary>
        int SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        /// <summary>Retrieves the hot key for a Shell link object</summary>
        int GetHotkey(out short pwHotkey);
        /// <summary>Sets a hot key for a Shell link object</summary>
        int SetHotkey(short wHotkey);
        /// <summary>Retrieves the show command for a Shell link object</summary>
        int GetShowCmd(out int piShowCmd);
        /// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
        int SetShowCmd(int iShowCmd);
        /// <summary>Retrieves the location (path and index) of the icon for a Shell link object</summary>
        int GetIconLocation([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
            int cchIconPath, out int piIcon);
        /// <summary>Sets the location (path and index) of the icon for a Shell link object</summary>
        int SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        /// <summary>Sets the relative path to the Shell link object</summary>
        int SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        /// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed</summary>
        int Resolve(IntPtr hwnd, SLR_FLAGS fFlags);
        /// <summary>Sets the path and file name of a Shell link object</summary>
        int SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }
    #endregion
}