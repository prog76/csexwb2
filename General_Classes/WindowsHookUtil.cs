using System;
using System.Runtime.InteropServices;

namespace IfacesEnumsStructsClasses
{
    public sealed class WindowsHookUtil
    {
        public struct HookInfo
        {
            //This is a Unique MsgID which is registered by the DLL
            //and passed to the client when hooking starts, each hook
            //has it's own MsgID. Used in WndProc to capture hook notifications
            public int UniqueMsgID;
            public CSEXWBDLMANLib.WINDOWSHOOK_TYPES HookType;
            public bool IsHooked;
            public HookInfo(CSEXWBDLMANLib.WINDOWSHOOK_TYPES _HookType)
            {
                this.HookType = _HookType;
                UniqueMsgID = 0;
                this.IsHooked = false;
            }
        }

        //
        //LL Keyboard hook
        //
        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            [MarshalAs(UnmanagedType.I4)]
            public int vkCode = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int scanCode = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int flags = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int time = 0;
            public IntPtr dwExtraInfo = IntPtr.Zero;

            public void Reset()
            {
                this.vkCode = 0;
                this.flags = 0;
                this.scanCode = 0;
                this.time = 0;
                this.dwExtraInfo = IntPtr.Zero;
            }
        }

        //
        //CBT hook
        //
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class CREATESTRUCT
        {
            public IntPtr lpCreateParams;
            public IntPtr hInstance;
            public IntPtr hMenu;
            public IntPtr hwndParent;
            public int cy;
            public int cx;
            public int y;
            public int x;
            public int style;
            public IntPtr lpszName;
            public IntPtr lpszClass;
            public int dwExStyle;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class CBT_CREATEWND
        {
            public IntPtr lpcs; //CREATESTRUCT
            public IntPtr hwndInsertAfter;
        }
        //nCode
        public const int HCBT_MOVESIZE = 0;
        public const int HCBT_MINMAX = 1;
        public const int HCBT_QS = 2;
        public const int HCBT_CREATEWND = 3;
        public const int HCBT_DESTROYWND = 4;
        public const int HCBT_ACTIVATE = 5;
        public const int HCBT_CLICKSKIPPED = 6;
        public const int HCBT_KEYSKIPPED = 7;
        public const int HCBT_SYSCOMMAND = 8;
        public const int HCBT_SETFOCUS = 9;
    }
}
