using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public class NmLink
    {
        public NmHdr hdr = new NmHdr();
        public LItem item = new LItem();
    }
}