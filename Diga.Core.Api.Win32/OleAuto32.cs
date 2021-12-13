using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Versioning;

namespace Diga.Core.Api.Win32
{

   



    public static class OleAuto32
    {
        private const string OLEAUTO32 = "oleaut32.dll";
        [DllImport(OLEAUTO32,CharSet=CharSet.Auto)]
        public static extern IntPtr SysAllocString([In, MarshalAs(UnmanagedType.LPWStr)]string s);
 
        [DllImport(OLEAUTO32,CharSet=CharSet.Auto)]
        public static extern void SysFreeString(IntPtr pbstr);
        [DllImport(OLEAUTO32, PreserveSig=true)]
        public static extern int VariantClear(IntPtr pObject);


        [DllImport(OLEAUTO32, ExactSpelling = true, PreserveSig = false)]
        public static extern ITypeLib LoadTypeLib([In, MarshalAs(UnmanagedType.LPWStr)] string typelib);

        [DllImport(OLEAUTO32, ExactSpelling = true, PreserveSig = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern ITypeLib LoadRegTypeLib(ref Guid clsid, short majorVersion, short minorVersion, int lcid);
    }
}