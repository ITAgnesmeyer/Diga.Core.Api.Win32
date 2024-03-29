﻿using System;
using System.Diagnostics;
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
        
        public static readonly IntPtr NoFileHandle = new IntPtr(-1);
        
        [DllImport(KERNEL32)]
        public static extern uint GetLastError();


        [DllImport(KERNEL32, EntryPoint = "LoadLibrary", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadLibrary([In] string lpLibFileName);

        [DllImport(KERNEL32, EntryPoint = "LoadLibraryEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadLibraryEx(string libFilename, IntPtr reserved, uint flags);

        [DllImport(KERNEL32, EntryPoint = "GetProcAddress", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr moduleHandle, [MarshalAs(UnmanagedType.LPStr)] string procName);

        [DllImport(KERNEL32, EntryPoint = "GetProcAddress", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr moduleHandle, IntPtr procName);

        [DllImport(KERNEL32, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport(KERNEL32, EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport(KERNEL32)]
        public static extern ushort GetSystemDefaultLangID();



        [DllImport(KERNEL32, EntryPoint = "GetProcessId", SetLastError = true)]
        public static extern uint GetProcessId([In] IntPtr Process);

        [DllImport(KERNEL32, EntryPoint = "GetCurrentThreadId", ExactSpelling = true, CharSet = CHARSET)]
        public static extern int GetCurrentThreadId();

        [DllImport(KERNEL32, EntryPoint = "GetExitCodeThread", ExactSpelling = true, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeThread(IntPtr hWnd, out int lpdwExitCode);

        [DllImport(KERNEL32, EntryPoint = "OpenFile", CharSet = CHARSET, SetLastError = true)]
        public static extern int OpenFile([In] string lpFileName, ref OFSTRUCT lpReOpenBuff, uint uStyle);

        [DllImport(KERNEL32, EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);


        [DllImport(KERNEL32, SetLastError = true, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Auto)]
        public static extern void RtlMoveMemory(IntPtr destData, IntPtr srcData, int size);

        [DllImport(KERNEL32, ExactSpelling = true, EntryPoint = "RtlMoveMemory")]
        public static extern void RtlMoveMemory(IntPtr pdst, byte[] psrc, int cb);

        [DllImport(KERNEL32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Unicode)]
        public static extern void RtlMoveMemoryW(IntPtr pdst, string psrc, int cb);

        [DllImport(KERNEL32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Unicode)]
        public static extern void RtlMoveMemoryW(IntPtr pdst, char[] psrc, int cb);


        [DllImport(KERNEL32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi)]
        public static extern void RtlMoveMemoryA(IntPtr pdst, string psrc, int cb);

        [DllImport(KERNEL32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi)]
        public static extern void RtlMoveMemoryA(IntPtr pdst, char[] psrc, int cb);



        [DllImport(KERNEL32, EntryPoint = "GetModuleHandle", CharSet = CHARSET)]
        public static extern IntPtr GetModuleHandle([In] string lpModuleName);



        [DllImport(KERNEL32, EntryPoint = "lstrlen", CharSet = CHARSET)]
        public static extern int lstrlen([In] string lpString);


        [DllImport(KERNEL32, EntryPoint = "GetSystemDirectory", CharSet = CHARSET, SetLastError = true)]
        public static extern uint GetSystemDirectory([Out]
            StringBuilder lpBuffer, uint uSize);

        [DllImport(KERNEL32, EntryPoint = "GetCurrentDirectory", CharSet = CHARSET, SetLastError = true)]
        public static extern uint GetCurrentDirectory(uint nBufffLen, [Out] StringBuilder lpBuffer);

        public static string GetCurrentDirectory()
        {
            int maxPath = 32000;
            StringBuilder lpBuffer = new StringBuilder(maxPath);
            uint len = GetCurrentDirectory((uint)maxPath, lpBuffer);
            return lpBuffer.ToString();
        }

        [DllImport(KERNEL32, EntryPoint = "ActivateActCtx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ActivateActCtx(IntPtr hActCtx, [Out] out uint lpCookie);


        [DllImport(KERNEL32, EntryPoint = "CreateActCtx", CharSet = CHARSET)]
        public static extern IntPtr CreateActCtx([In] ref ActCtx pActCtx);



        [DllImport(KERNEL32, EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [DllImport(KERNEL32, EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();
        public static IntPtr GetCurrentProcessHandle()
        {
            return Process.GetCurrentProcess().Handle;
        }


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


        [DllImport(KERNEL32, CharSet = CharSet.None, ExactSpelling = false)]
        internal static extern IntPtr LocalFree(ref object obj);

        [DllImport(KERNEL32, EntryPoint = "LockResource", SetLastError = true)]
        public static extern IntPtr LockResource([In] IntPtr hResData);

        [DllImport(KERNEL32, EntryPoint = "LockResource", SetLastError = true)]
        public static extern DlgTemplate LockDialogResource([In] IntPtr hResData);

        [DllImport(KERNEL32, EntryPoint = "FindResource", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In] string lpName, [In] string lpType);

        [DllImport(KERNEL32, EntryPoint = "FindResource", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In] IntPtr lpName, [In] IntPtr lpType);

        [DllImport(KERNEL32, EntryPoint = "SizeofResource", SetLastError = true)]
        public static extern uint SizeofResource([In] IntPtr hModule, [In] IntPtr hResInfo);

        [DllImport(KERNEL32, EntryPoint = "FindResourceEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResourceEx([In] IntPtr hModule, [In] string lpType, [In] string lpName, uint wLanguage);

        [DllImport(KERNEL32, EntryPoint = "FindResourceEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindResourceEx([In] IntPtr hModule, [In] IntPtr lpType, [In] IntPtr lpName, uint wLanguage);


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

        [DllImport(KERNEL32, EntryPoint = "Wow64DisableWow64FsRedirection", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr oldValue);

        [DllImport(KERNEL32, EntryPoint = "Wow64RevertWow64FsRedirection", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Wow64RevertWow64FsRedirection([In] IntPtr oldValue);

        [DllImport(KERNEL32, EntryPoint = "FileTimeToSystemTime")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileTimeToSystemTime([In] ref FileTime lpFileTime, [Out] out SystemTime lpSystemTime);

        
        [DllImport(KERNEL32, EntryPoint="MapViewOfFile",SetLastError = true)]
        public static extern  IntPtr MapViewOfFile([In] IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap) ;

        [DllImport(KERNEL32, EntryPoint="UnmapViewOfFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool UnmapViewOfFile([In] IntPtr lpBaseAddress) ;


      
        [DllImport(KERNEL32,EntryPoint = "CreateFileMapping", CharSet= CharSet.Auto,SetLastError = true)]
        public  static extern IntPtr CreateFileMapping(IntPtr hFile,
            int lpAttributes,
            FileProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenFileMapping(FileRights dwDesiredAccess,
            bool bInheritHandle,
            string lpName);
    }
}


