using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace Diga.Core.Api.Win32
{
    public static class Kernel32
    {
        private const string KERNEL32 = "kernel32.dll";
        private const CharSet CHARSET = CharSet.Auto;
        [DllImport(KERNEL32)]
        public static extern uint GetLastError();


        [DllImport(KERNEL32, EntryPoint = "LoadLibrary", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadLibrary([In] string lpLibFileName);

        [DllImport(KERNEL32, EntryPoint = "LoadLibraryEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadLibraryEx(string libFilename, IntPtr reserved, uint flags);

        [DllImport(KERNEL32, EntryPoint = "GetProcAddress", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr moduleHandle, [MarshalAs(UnmanagedType.LPStr)] string procName);

        [DllImport(KERNEL32, EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport(KERNEL32)]
        public static extern ushort GetSystemDefaultLangID();



        [DllImport(KERNEL32, EntryPoint = "GetProcessId", SetLastError = true)]
        public static extern uint GetProcessId([In] IntPtr Process);


        [DllImport(KERNEL32, EntryPoint = "OpenFile", CharSet = CHARSET, SetLastError = true)]
        public static extern int OpenFile([In] string lpFileName, ref OFSTRUCT lpReOpenBuff, uint uStyle);

        [DllImport(KERNEL32, EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);


        [DllImport(KERNEL32, EntryPoint = "GetModuleHandle", CharSet = CHARSET)]
        public static extern IntPtr GetModuleHandle([In] string lpModuleName);



        [DllImport(KERNEL32, EntryPoint = "lstrlen", CharSet = CHARSET)]
        public static extern int lstrlen([In] string lpString);


        [DllImport(KERNEL32, EntryPoint = "GetSystemDirectory", CharSet = CHARSET, SetLastError = true)]
        public static extern uint GetSystemDirectory([Out]
            StringBuilder lpBuffer, uint uSize);


        [DllImport(KERNEL32, EntryPoint = "ActivateActCtx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ActivateActCtx(IntPtr hActCtx, [Out] out uint lpCookie);


        [DllImport(KERNEL32, EntryPoint = "CreateActCtx", CharSet = CHARSET)]
        public static extern IntPtr CreateActCtx([In] ref ActCtx pActCtx);



        [DllImport(KERNEL32, EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);


        [DllImport(KERNEL32, EntryPoint = "CloseHandle")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle([In] IntPtr hObject);

        public static IntPtr GetProcessHandleFromId(uint dwProcessId)
        {
            return OpenProcess((uint)ProcessAccessTypes.SYNCHRONIZE, true, dwProcessId);
        }

        [DllImport(KERNEL32, EntryPoint = "FreeResource", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeResource([In] IntPtr hResData);

        [DllImport(KERNEL32, EntryPoint = "LoadResource", SetLastError = true)]
        public static extern IntPtr LoadResource([In] IntPtr hModule, [In] IntPtr hResInfo);


        [DllImport(KERNEL32, EntryPoint = "LockResource", SetLastError = true)]
        public static extern IntPtr LockResource([In] IntPtr hResData);

        [DllImport(KERNEL32, EntryPoint = "LockResource", SetLastError = true)]
        public static extern DlgTemplate LockDialogResource([In] IntPtr hResData);

        [DllImport(KERNEL32, EntryPoint = "FindResource", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In] string lpName, [In] string lpType);

        [DllImport(KERNEL32, EntryPoint = "FindResource", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In] IntPtr lpName, [In]IntPtr lpType);

        [DllImport(KERNEL32, EntryPoint = "SizeofResource", SetLastError = true)]
        public static extern uint SizeofResource([In] IntPtr hModule, [In] IntPtr hResInfo);

        [DllImport(KERNEL32, EntryPoint = "FindResourceEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResourceEx([In] IntPtr hModule, [In] string lpType, [In] string lpName, uint wLanguage);


        [DllImport(KERNEL32, EntryPoint = "UpdateResource", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateResource([In] IntPtr hUpdate, [In] string lpType, [In] string lpName, uint wLanguage, [In] IntPtr lpData, uint cb);

        [DllImport(KERNEL32, EntryPoint = "EndUpdateResource", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndUpdateResource([In] IntPtr hUpdate, [MarshalAs(UnmanagedType.Bool)] bool fDiscard);


        [DllImport(KERNEL32, EntryPoint = "EnumResourceNames", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumResourceNames([In] IntPtr hModule, [In] string lpType, EnumResNameProc lpEnumFunc, [MarshalAs(UnmanagedType.SysInt)] int lParam);


        [DllImport(KERNEL32, EntryPoint = "EnumResourceTypes", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumResourceTypes([In] IntPtr hModule, EnumResTypeProc lpEnumFunc, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        [DllImport(KERNEL32, EntryPoint = "BeginUpdateResource", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr BeginUpdateResource([In] string pFileName, [MarshalAs(UnmanagedType.Bool)] bool bDeleteExistingResources);

        [DllImport(KERNEL32, EntryPoint = "EnumResourceLanguages", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumResourceLanguages([In] IntPtr hModule, [In] string lpType, [In] string lpName, EnumResLangProc lpEnumFunc, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        [DllImport(KERNEL32, EntryPoint = "QueryMemoryResourceNotification", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryMemoryResourceNotification([In] IntPtr ResourceNotificationHandle, [Out] out int ResourceState);

        [DllImport(KERNEL32, EntryPoint = "CreateMemoryResourceNotification", SetLastError = true)]
        public static extern IntPtr CreateMemoryResourceNotification(MEMORY_RESOURCE_NOTIFICATION_TYPE NotificationType);


    }
}


