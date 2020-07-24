using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Diga.Core.Api.Win32.Tools;

namespace Diga.Core.Api.Win32
{
    public static class DlgTemplateExLoader
    {
        public static DlgTemplateEx LoadDialog(IntPtr hInstance,int id)
        {
            IntPtr hres = Kernel32.FindResource(hInstance, Win32Api.MakeInterSource(101), ResourceTypes.RT_DIALOG);
            if(hres == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IntPtr res = Kernel32.LoadResource(hInstance, hres);
            if (res == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IntPtr lockedPtr = Kernel32.LockResource(res);
            ByteReader reader = new ByteReader(lockedPtr);
            DlgTemplateEx templateEx = new DlgTemplateEx(reader);
            templateEx.Read();
            return templateEx;
        }
    }
}