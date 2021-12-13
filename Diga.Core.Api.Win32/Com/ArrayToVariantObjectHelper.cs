using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    public static class ArrayToVariantObjectHelper
    {
        static ArrayToVariantObjectHelper()
        {
            VariantSize = (int)Marshal.OffsetOf(typeof(FindSizeOfVariant), "b");
        }

        // Convert a object[] into an array of VARIANT, allocated with CoTask allocators.
        public static unsafe IntPtr ArrayToVariantVector(object[] args)
        {
            IntPtr mem = IntPtr.Zero;
            int i = 0;
            try
            {
                checked
                {
                    int len = args.Length;
                    mem = Marshal.AllocCoTaskMem(len * VariantSize);
                    byte* a = (byte*)(void*)mem;
                    for (i = 0; i < len; ++i)
                    {
                        Marshal.GetNativeVariantForObject(args[i], (IntPtr)(a + VariantSize * i));
                    }
                }
            }
            catch
            {
                if (mem != IntPtr.Zero)
                {
                    FreeVariantVector(mem, i);
                }
                throw;
            }
            return mem;
        }

        // Free a Variant array created with the above function
        /// <param name="mem">The allocated memory to be freed.</param>
        /// <param name="len">The length of the Variant vector to be cleared.</param>
        public static unsafe void FreeVariantVector(IntPtr mem, int len)
        {
            int hr = HRESULT.S_OK;
            byte* a = (byte*)(void*)mem;

            for (int i = 0; i < len; ++i)
            {
                int hrCurrent = HRESULT.S_OK;
                checked
                {
                    hrCurrent = OleAuto32.VariantClear((IntPtr)(a + VariantSize * i));
                }

                // save the first error and throw after we finish all VariantClear.
                if (HRESULT.SUCCEEDED(hrCurrent) && HRESULT.FAILED(hrCurrent))
                {
                    hr = hrCurrent;
                }
            }
            Marshal.FreeCoTaskMem(mem);

            if (HRESULT.FAILED(hr))
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct FindSizeOfVariant
        {
            [MarshalAs(UnmanagedType.Struct)]
            public object var;
            public byte b;
        }

        private static readonly int VariantSize;
    }
}