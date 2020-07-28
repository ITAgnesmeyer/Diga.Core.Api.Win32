using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DateTimePickerInfo 
    {
        public uint cbSize;
        public Rect rcCheck;
        public uint stateCheck;
        public Rect rcButton;
        public uint stateButton;
        public IntPtr hwndEdit;
        public IntPtr hwndUD;
        public IntPtr hwndDropDown;
    }
}