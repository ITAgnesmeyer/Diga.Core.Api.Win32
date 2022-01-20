using System;
using System.Collections.Generic;

namespace Diga.Core.Api.Win32.Tools
{
    public static class WindowInfo
    {
      

        public static IDictionary<IntPtr, string> GetTopLevelWindows()
        {

            IntPtr shellWindow = User32.GetShellWindow();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            User32.EnumWindows((hWnd, lParam) =>
            {
                if (hWnd == shellWindow) return (ApiBool)true;
                
                string className = User32.GetClassName(hWnd);
                windows.Add(hWnd, className);
                return (ApiBool)true;
            },0);
            return windows;
        }
    }
}