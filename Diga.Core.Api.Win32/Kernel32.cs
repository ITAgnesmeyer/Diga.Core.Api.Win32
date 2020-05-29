using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public static class Kernel32
    {
        private const string KERNEL32 = "kernel32.dll";
             
        [DllImport(KERNEL32)]
        public static extern uint GetLastError();


        [DllImport(KERNEL32)]
        public static extern ushort GetSystemDefaultLangID();
      
        /// Return Type: DWORD->unsigned int
        ///Process: HANDLE->void*
        [DllImport(KERNEL32, EntryPoint="GetProcessId")]
        public static extern  uint GetProcessId([In] IntPtr Process) ;

          
        /// Return Type: HMODULE->HINSTANCE->HINSTANCE__*
        ///lpLibFileName: LPCSTR->CHAR*
        [DllImport(KERNEL32, EntryPoint="LoadLibraryW")]
        public static extern  IntPtr LoadLibrary([In, MarshalAs(UnmanagedType.LPWStr)]  string lpLibFileName) ;

           
        /// Return Type: HFILE->int
        ///lpFileName: LPCSTR->CHAR*
        ///lpReOpenBuff: LPOFSTRUCT->_OFSTRUCT*
        ///uStyle: UINT->unsigned int
        [DllImport(KERNEL32, EntryPoint="OpenFile")]
        public static extern  int OpenFile([In, MarshalAs(UnmanagedType.LPStr)]  string lpFileName, ref OfStruct lpReOpenBuff, uint uStyle) ;


            
        [DllImport(KERNEL32, EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

            
        /// Return Type: int
        ///lpString: LPCWSTR->WCHAR*
        [DllImport(KERNEL32, EntryPoint="lstrlenW")]
        public static extern  int lstrlenW([In, MarshalAs(UnmanagedType.LPWStr)]  string lpString) ;

        /// Return Type: UINT->unsigned int
        ///lpBuffer: LPWSTR->WCHAR*
        ///uSize: UINT->unsigned int
        [DllImport(KERNEL32, EntryPoint="GetSystemDirectoryW")]
        public static extern  uint GetSystemDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] 
            StringBuilder lpBuffer, uint uSize) ;
        /// Return Type: BOOL->int
        ///hActCtx: HANDLE->void*
        ///lpCookie: ULONG_PTR*
        [DllImport(KERNEL32, EntryPoint="ActivateActCtx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool ActivateActCtx(IntPtr hActCtx, [Out] out uint lpCookie) ;

        /// Return Type: HANDLE->void*
        ///pActCtx: PCACTCTXW->ACTCTXW*
        [DllImport(KERNEL32, EntryPoint="CreateActCtxW")]
        public static extern  IntPtr CreateActCtx([In] ref ActCtx pActCtx) ;


        /// Return Type: HANDLE->void*
        ///dwDesiredAccess: DWORD->unsigned int
        ///bInheritHandle: BOOL->int
        ///dwProcessId: DWORD->unsigned int
        [DllImport(KERNEL32, EntryPoint="OpenProcess")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        /// Return Type: BOOL->int
        ///hObject: HANDLE->void*
        [DllImport(KERNEL32, EntryPoint="CloseHandle")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool CloseHandle([In] IntPtr hObject) ;

        public static IntPtr GetProcessHandleFromId(uint dwProcessId)
        {
            return OpenProcess((uint) ProcessAccessTypes.SYNCHRONIZE, true, dwProcessId);
        }

        public static  uint EnableVisualStyles()
        {
            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location;;
            
            ActCtx actCtx = new ActCtx()
            {
                cbSize = Marshal.SizeOf(typeof(ActCtx)), 
                dwFlags = ActCtx_FLags.ACTCTX_FLAG_RESOURCE_NAME_VALID , 
                lpSource=  dir, 
                wLangId = 0,
                lpResourceName =new IntPtr(101)

            };

            IntPtr hActCtx = CreateActCtx(ref actCtx);
            bool contextCreationSucceeded = (hActCtx != new IntPtr(-1));

            if (!contextCreationSucceeded)
            {
                actCtx.lpResourceName =(IntPtr) ActCtx_FLags.ISOLATIONAWARE_NOSTATICIMPORT_MANIFEST_RESOURCE_ID;
                hActCtx = CreateActCtx(ref actCtx);
                contextCreationSucceeded = (hActCtx != new IntPtr(-1));
            }

            if (!contextCreationSucceeded)
            {
                actCtx.lpResourceName = (IntPtr) ActCtx_FLags.CREATEPROCESS_MANIFEST_RESOURCE_ID;
                hActCtx = CreateActCtx(ref actCtx);
                contextCreationSucceeded = (hActCtx != new IntPtr(-1));
            }

            ActivateActCtx(hActCtx,out var ulpActivationCookie);
            return ulpActivationCookie;
        }

    }
}