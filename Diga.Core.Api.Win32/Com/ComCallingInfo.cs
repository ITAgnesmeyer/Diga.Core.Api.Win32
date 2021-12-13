using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate uint DllGetClassObjectDelegate(
        [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
        [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
        [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object pUnknown);


    public struct ComDirectCallingInfo
    {
        public string DllPath { get; set; }
        public IntPtr ModuleHandle
        {
            get;
            set;
        }

        public DllGetClassObjectDelegate DllGetClassObject { get; set; }


    }
}