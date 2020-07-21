using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential , CharSet = CharSet.Auto)]
    public struct DialogTemplate
    {
        public DlgTemplate header;
        [MarshalAs(UnmanagedType.ByValArray)]
        public   DlgItemTemplate[] items;

        public DialogTemplate(DlgTemplate header, DlgItemTemplate[] items)
        {
            this.header = header;
            this.items = items ?? throw new ArgumentNullException(nameof(items));
        }
    }
}