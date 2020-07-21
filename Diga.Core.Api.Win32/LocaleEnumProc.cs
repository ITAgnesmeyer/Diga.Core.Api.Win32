using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    ///param0: LPWSTR->WCHAR*
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int LocaleEnumProc([MarshalAs(UnmanagedType.LPWStr)] StringBuilder param0);
}