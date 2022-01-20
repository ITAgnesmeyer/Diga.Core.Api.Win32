using System;
using System.Collections.Generic;

namespace Diga.Core.Api.Win32.Tools
{
    public static class WindowInfo
    {
      
        private static Dictionary<IntPtr, string> _windows = new Dictionary<IntPtr, string>();
        private static IntPtr shellWindow;
        public static IDictionary<IntPtr, string> GetTopLevelWindows()
        {
            _windows.Clear();

            shellWindow = User32.GetShellWindow();
            
            WndEumProc proc = EnumProc; 
            User32.EnumWindows(proc,IntPtr.Zero);
            return _windows;
        }

        private static int EnumProc(IntPtr hwnd, IntPtr lparam)
        {
            
            if (hwnd == shellWindow) return (ApiBool)true;
                
            string className = User32.GetClassName(hwnd);
            _windows.Add(hwnd, className);
            return (ApiBool)true;
        }
    }
}