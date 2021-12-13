using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    public static class ComDirectLoader
    {
        public static object GetObject(ComDirectCallingInfo info, Guid iidClass, Guid iidInterface)
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
}