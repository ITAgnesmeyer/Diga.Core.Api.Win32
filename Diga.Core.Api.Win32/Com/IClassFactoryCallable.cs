using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate uint DllGetClassObjectDelegate(
        [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
        [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
        [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object pUnknown);

    public struct ComCallingInfo
    {
        public string DllPath { get; set; }
        public IntPtr ModuleHandle
        {
            get;
            set;
        }

        public DllGetClassObjectDelegate DllGetClassObject { get; set; }


    }


    public static class ComLoader
    {
        public static object GetObject(ComCallingInfo info, Guid iidClass, Guid iidInterface)
        {
            if (string.IsNullOrEmpty(info.DllPath))
                throw new ArgumentException("info.DllPath must be filled");


            var module = Kernel32.LoadLibrary(info.DllPath);
            if (module == IntPtr.Zero)
                throw new IOException("Cannot load COM-Dll:" + info.DllPath);

            var proc = Kernel32.GetProcAddress(module, "DllGetClassObject");
            if (proc == IntPtr.Zero)
                throw new IOException("Cannot find method DllGetClassObject in " + info.DllPath);

            info.DllGetClassObject = Marshal.GetDelegateForFunctionPointer<DllGetClassObjectDelegate>(proc);
            info.ModuleHandle = module;

            HRESULT hr = (int)info.DllGetClassObject(iidClass, iidInterface, out object unknown);
            if (hr.Failed)
                throw new COMException("Cannot create Object", hr);

            IClassFactoryCallable cf = unknown as IClassFactoryCallable;
            if (cf == null)
                throw new COMException("Cannot get IClassFactory from IUnknown");

            var ifac = cf.CreateInstance(null, ref iidInterface);



            return ifac;


        }
    }

    [ComImport]
    [Guid("00000001-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClassFactoryCallable
    {
        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
        object CreateInstance(
            [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
            [In] ref Guid riid);

        void LockServer(
            [MarshalAs(UnmanagedType.Bool)] bool fLock);
    }
}