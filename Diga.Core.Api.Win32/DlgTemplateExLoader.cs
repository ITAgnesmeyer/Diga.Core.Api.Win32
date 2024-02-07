using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Diga.Core.Api.Win32.Tools;

namespace Diga.Core.Api.Win32
{
    [Obsolete("do not use this class Will be removed=> use DlgTemplateLoader and Template and items property")]
    public static class DlgTemplateExLoader
    {
        public static DlgTemplateExOld LoadDialog(IntPtr hInstance, int id)
        {
            IntPtr hres = Kernel32.FindResource(hInstance, Win32Api.MakeInterSource(id), ResourceTypes.RT_DIALOG);
            if (hres == IntPtr.Zero)
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
            DlgTemplateExOld templateEx = new DlgTemplateExOld(reader);
            templateEx.Read();
            return templateEx;
        }
    }
}