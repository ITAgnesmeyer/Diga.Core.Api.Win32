using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FileTime 
    {
    
        /// DWORD->unsigned int
        public uint dwLowDateTime;
    
        /// DWORD->unsigned int
        public uint dwHighDateTime;


#if NETCOREAPP

        public static implicit operator FILETIME(FileTime input)
        {
            FILETIME result = new FILETIME
            {
                dwHighDateTime = (int)input.dwHighDateTime,
                dwLowDateTime = (int)input.dwLowDateTime
            };

            return result;

        }

        public static implicit operator FileTime(FILETIME input)
        {
            FileTime result = new FileTime
            {
                dwHighDateTime = (uint)input.dwHighDateTime,
                dwLowDateTime = (uint)input.dwLowDateTime
            };
            return result;
        }
#endif 
    }
  

}