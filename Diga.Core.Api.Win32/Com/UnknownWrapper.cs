using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Diga.Core.Api.Win32.Com
{
    internal static class ArrayToVARIANTHelper
        {
            static ArrayToVARIANTHelper()
            {
                VariantSize = (int)Marshal.OffsetOf(typeof(FindSizeOfVariant), "b");
            }
 
            // Convert a object[] into an array of VARIANT, allocated with CoTask allocators.
            public unsafe static IntPtr ArrayToVARIANTVector(object[] args)
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
                        FreeVARIANTVector(mem, i);
                    }
                    throw;
                }
                return mem;
            }
 
            // Free a Variant array created with the above function
            /// <param name="mem">The allocated memory to be freed.</param>
            /// <param name="len">The length of the Variant vector to be cleared.</param>
            public unsafe static void FreeVARIANTVector(IntPtr mem, int len)
            {
                int hr = HRESULT.S_OK;
                byte* a = (byte*)(void*)mem;
 
                for (int i = 0; i < len; ++i)
                {
                    int hrcurrent = HRESULT.S_OK;
                    checked
                    {
                        hrcurrent = OleAuto32.VariantClear((IntPtr)(a + VariantSize * i));
                    }
 
                    // save the first error and throw after we finish all VariantClear.
                    if (HRESULT.SUCCEEDED(hrcurrent) && HRESULT.FAILED(hrcurrent))
                    {
                        hr = hrcurrent;
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


    [Serializable]
    public struct SecurityCriticalDataForSet<T>
    {
        internal SecurityCriticalDataForSet(T value)
        {
            this._value = value; 
        }
 
        internal T Value 
        {
#if DEBUG
            [System.Diagnostics.DebuggerStepThrough]
#endif
            get
            {
                return this._value;
            }
 
#if DEBUG
            [System.Diagnostics.DebuggerStepThrough]
#endif
            set
            {
                this._value = value;
            }
        }
 
        private T _value;

        public static implicit operator T(SecurityCriticalDataForSet<T> input)
        {
            return input.Value;
        }

        public static implicit operator SecurityCriticalDataForSet<T>(T input)
        {
            return new SecurityCriticalDataForSet<T>(input);
        }
    }
    public enum  tagVT {
        VT_EMPTY = 0,
        VT_NULL = 1,
        VT_I2 = 2,
        VT_I4 = 3,
        VT_R4 = 4,
        VT_R8 = 5,
        VT_CY = 6,
        VT_DATE = 7,
        VT_BSTR = 8,
        VT_DISPATCH = 9,
        VT_ERROR = 10,
        VT_BOOL = 11,
        VT_VARIANT = 12,
        VT_UNKNOWN = 13,
        VT_DECIMAL = 14,
        VT_I1 = 16,
        VT_UI1 = 17,
        VT_UI2 = 18,
        VT_UI4 = 19,
        VT_I8 = 20,
        VT_UI8 = 21,
        VT_INT = 22,
        VT_UINT = 23,
        VT_VOID = 24,
        VT_HRESULT = 25,
        VT_PTR = 26,
        VT_SAFEARRAY = 27,
        VT_CARRAY = 28,
        VT_USERDEFINED = 29,
        VT_LPSTR = 30,
        VT_LPWSTR = 31,
        VT_RECORD = 36,
        VT_FILETIME = 64,
        VT_BLOB = 65,
        VT_STREAM = 66,
        VT_STORAGE = 67,
        VT_STREAMED_OBJECT = 68,
        VT_STORED_OBJECT = 69,
        VT_BLOB_OBJECT = 70,
        VT_CF = 71,
        VT_CLSID = 72,
        VT_BSTR_BLOB = 4095,
        VT_VECTOR = 4096,
        VT_ARRAY = 8192,
        VT_BYREF = 16384,
        VT_RESERVED = 32768,
        VT_ILLEGAL = 65535,
        VT_ILLEGALMASKED = 4095,
        VT_TYPEMASK = 4095
    }

         [StructLayout(LayoutKind.Sequential)]
        public sealed class VARIANT {
            [MarshalAs(UnmanagedType.I2)]
            public short vt;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved1;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved2;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved3;
 
            public SecurityCriticalDataForSet<IntPtr> data1;
 
            public SecurityCriticalDataForSet<IntPtr> data2;


            public static IntPtr ObjectArrayToVariantArrayPtr(object[] objects)
            {
                return ArrayToVARIANTHelper.ArrayToVARIANTVector(objects);
            }

            public static void FreeVariantArrayPtr(IntPtr ptr, int len)
            {
                ArrayToVARIANTHelper.FreeVARIANTVector(ptr,len);
            }
            public bool Byref{
                get{
                    return 0 != (this.vt & (int)tagVT.VT_BYREF);
                }
            }
 
            public void Clear() {
                if ((this.vt == (int)tagVT.VT_UNKNOWN || this.vt == (int)tagVT.VT_DISPATCH) && this.data1.Value != IntPtr.Zero) {
                    Marshal.Release(this.data1.Value);
                }
 
                if (this.vt == (int)tagVT.VT_BSTR && this.data1.Value != IntPtr.Zero) {
                    OleAuto32.SysFreeString(this.data1.Value);
                }
 
                this.data1.Value = this.data2.Value = IntPtr.Zero;
                this.vt = (int)tagVT.VT_EMPTY;
            }
 
            ~VARIANT() {
                Clear();
            }
 
            public void SuppressFinalize()
            {
                // Called if this VARIANT is returned to the caller in native world which is supposed to call
                // VariantClear().
                // GC does not have to clear it.
                GC.SuppressFinalize(this);
            }
 

            public static VARIANT FromObject(Object var) {
                VARIANT v = new VARIANT();
 
                if (var == null) {
                    v.vt = (int)tagVT.VT_EMPTY;
                }
                else if (Convert.IsDBNull(var)) {
                }
                else {
                    Type t = var.GetType();
 
                    if (t == typeof(bool)) {
                        v.vt = (int)tagVT.VT_BOOL;
                    }
                    else if (t == typeof(byte)) {
                        v.vt = (int)tagVT.VT_UI1;
                        v.data1 = (IntPtr)Convert.ToByte(var);
                    }
                    else if (t == typeof(char)) {
                        v.vt = (int)tagVT.VT_UI2;
                        v.data1 = (IntPtr)Convert.ToChar(var);
                    }
                    else if (t == typeof(string)) {
                        v.vt = (int)tagVT.VT_BSTR;
                        v.data1 = OleAuto32.SysAllocString(Convert.ToString(var));
                    }
                    else if (t == typeof(short)) {
                        v.vt = (int)tagVT.VT_I2;
                        v.data1 = (IntPtr)Convert.ToInt16(var);
                    }
                    else if (t == typeof(int)) {
                        v.vt = (int)tagVT.VT_I4;
                        v.data1 = (IntPtr)Convert.ToInt32(var);
                    }
                    else if (t == typeof(long)) {
                        v.vt = (int)tagVT.VT_I8;
                        v.SetLong(Convert.ToInt64(var));
                    }
                    else if (t == typeof(Decimal)) {
                        v.vt = (int)tagVT.VT_CY;
                        Decimal c = (Decimal)var;
                        // SBUrke, it's bizzare that we need to call this as a static!
                        v.SetLong(Decimal.ToInt64(c));
                    }
                    else if (t == typeof(decimal)) {
                        v.vt = (int)tagVT.VT_DECIMAL;
                        Decimal d = Convert.ToDecimal(var);
                        v.SetLong(Decimal.ToInt64(d));
                    }
                    else if (t == typeof(double)) {
                        v.vt = (int)tagVT.VT_R8;
                        // how do we handle double?
                    }
                    else if (t == typeof(float) || t == typeof(Single)) {
                        v.vt = (int)tagVT.VT_R4;
                        // how do we handle float?
                    }
                    else if (t == typeof(DateTime)) {
                        v.vt = (int)tagVT.VT_DATE;
                        v.SetLong(Convert.ToDateTime(var).ToFileTime());
                    }
                    else if (t == typeof(SByte)) {
                        v.vt = (int)tagVT.VT_I1;
                        v.data1 = (IntPtr)Convert.ToSByte(var);
                    }
                    else if (t == typeof(UInt16)) {
                        v.vt = (int)tagVT.VT_UI2;
                        v.data1 = (IntPtr)Convert.ToUInt16(var);
                    }
                    else if (t == typeof(UInt32)) {
                        v.vt = (int)tagVT.VT_UI4;
                        v.data1 = (IntPtr)Convert.ToUInt32(var);
                    }
                    else if (t == typeof(UInt64)) {
                        v.vt = (int)tagVT.VT_UI8;
                        v.SetLong((long)Convert.ToUInt64(var));
                    }
                    else if (t == typeof(object) || t == typeof(IDispatch) || t.IsCOMObject) {
                        v.vt = (t == typeof(IDispatch) ? (short)tagVT.VT_DISPATCH : (short)tagVT.VT_UNKNOWN);
                        v.data1 = Marshal.GetIUnknownForObject(var);
                    }
                    else {
                        Debug.Assert(false, "Unsupported object type!");
                    }
                }
                return v;
            }

            [StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Auto)]
            private struct GUID {
    
                /// unsigned int
                public uint Data1;
    
                /// unsigned short
                public ushort Data2;
    
                /// unsigned short
                public ushort Data3;
    
                /// unsigned char[8]
                [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=8)]
                public byte[] Data4;
            }

          
            public void SetLong(long lVal) {
                this.data1.Value = (IntPtr)(lVal & 0xFFFFFFFF);
                this.data2.Value = (IntPtr)((lVal >> 32) & 0xFFFFFFFF);
            }
 
            public IntPtr ToCoTaskMemPtr() {
                IntPtr mem = Marshal.AllocCoTaskMem(16);
                Marshal.WriteInt16(mem, this.vt);
                Marshal.WriteInt16(mem, 2, this.reserved1);
                Marshal.WriteInt16(mem, 4, this.reserved2);
                Marshal.WriteInt16(mem, 6, this.reserved3);
                Marshal.WriteInt32(mem, 8, (int)this.data1.Value);
                Marshal.WriteInt32(mem, 12, (int)this.data2.Value);
                return mem;
            }
 
            public object ToObject() {
                IntPtr val = this.data1.Value;
                long longVal;
 
                int vtType = (int)(this.vt & (short)tagVT.VT_TYPEMASK);
 
                switch (vtType) {
                case (int)tagVT.VT_EMPTY:
                    return null;
                case (int)tagVT.VT_NULL:
                    return Convert.DBNull;
 
                case (int)tagVT.VT_I1:
                    if (this.Byref) {
                        val = (IntPtr) Marshal.ReadByte(val);
                    }
                    return (SByte) (0xFF & (SByte) val);
 
                case (int)tagVT.VT_UI1:
                    if (this.Byref) {
                        val = (IntPtr) Marshal.ReadByte(val);
                    }
 
                    return (byte) (0xFF & (byte) val);
 
                case (int)tagVT.VT_I2:
                    if (this.Byref) {
                        val = (IntPtr) Marshal.ReadInt16(val);
                    }
                    return (short)(0xFFFF & (short) val);
 
                case (int)tagVT.VT_UI2:
                    if (this.Byref) {
                        val = (IntPtr) Marshal.ReadInt16(val);
                    }
                    return (UInt16)(0xFFFF & (UInt16) val);
 
                case (int)tagVT.VT_I4:
                case (int)tagVT.VT_INT:
                    if (this.Byref) {
                        val = (IntPtr) Marshal.ReadInt32(val);
                    }
                    return (int)val;
 
                case (int)tagVT.VT_UI4:
                case (int)tagVT.VT_UINT:
                    if (this.Byref) {
                        val = (IntPtr) Marshal.ReadInt32(val);
                    }
                    return (UInt32)val;
 
                case (int)tagVT.VT_I8:
                case (int)tagVT.VT_UI8:
                    if (this.Byref) {
                        longVal = Marshal.ReadInt64(val);
                    }
                    else {
                        longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    }
 
                    if (this.vt == (int)tagVT.VT_I8) {
                        return (long)longVal;
                    }
                    else {
                        return (UInt64)longVal;
                    }
                }
 
                if (this.Byref) {
                    val = GetRefInt(val);
                }
 
                switch (vtType) {
                case (int)tagVT.VT_R4:
                case (int)tagVT.VT_R8:
 
                    // can I use unsafe here?
                    throw new FormatException(/*SR.GetString(SR.CannotConvertIntToFloat)*/);
 
                case (int)tagVT.VT_CY:
                    // internally currency is 8-byte int scaled by 10,000
                    longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    return new Decimal(longVal);
                case (int)tagVT.VT_DATE:
                    throw new FormatException(/*SR.GetString(SR.CannotConvertDoubleToDate)*/);
 
                case (int)tagVT.VT_BSTR:
                case (int)tagVT.VT_LPWSTR:
                    return Marshal.PtrToStringUni(val);
 
                case (int)tagVT.VT_LPSTR:
                    return Marshal.PtrToStringAnsi(val);
 
                case (int)tagVT.VT_DISPATCH:
                case (int)tagVT.VT_UNKNOWN:
                    {
                        return Marshal.GetObjectForIUnknown(val);
                    }
 
                case (int)tagVT.VT_HRESULT:
                    return val;
 
                case (int)tagVT.VT_DECIMAL:
                    longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    return new Decimal(longVal);
 
                case (int)tagVT.VT_BOOL:
                    return (val != IntPtr.Zero);
 
                case (int)tagVT.VT_VARIANT:
                    VARIANT varStruct = (VARIANT)Marshal.PtrToStructure(val, typeof(VARIANT));
                    return varStruct.ToObject();
                case (int)tagVT.VT_CLSID:
                    //Debug.Fail("PtrToStructure will not work with System.Guid...");
                    
                    GUID g =(GUID)Marshal.PtrToStructure(val, typeof(GUID));

                    Guid guid = new Guid((int)g.Data1, (short)g.Data2, (short)g.Data3, g.Data4);
                    return guid;
 
                case (int)tagVT.VT_FILETIME:
                    longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    return new DateTime(longVal);
 
                case (int)tagVT.VT_ARRAY:
                    //gSAFEARRAY sa = (tagSAFEARRAY)Marshal.PtrToStructure(val), typeof(tagSAFEARRAY));
                    //return GetArrayFromSafeArray(sa);
 
                case (int)tagVT.VT_USERDEFINED:
                case (int)tagVT.VT_VOID:
                case (int)tagVT.VT_PTR:
                case (int)tagVT.VT_SAFEARRAY:
                case (int)tagVT.VT_CARRAY:
 
                case (int)tagVT.VT_RECORD:
                case (int)tagVT.VT_BLOB:
                case (int)tagVT.VT_STREAM:
                case (int)tagVT.VT_STORAGE:
                case (int)tagVT.VT_STREAMED_OBJECT:
                case (int)tagVT.VT_STORED_OBJECT:
                case (int)tagVT.VT_BLOB_OBJECT:
                case (int)tagVT.VT_CF:
                case (int)tagVT.VT_BSTR_BLOB:
                case (int)tagVT.VT_VECTOR:
                case (int)tagVT.VT_BYREF:
                    //case (int)tagVT.VT_RESERVED:
                default:
                    return null;
            }
            }
            private static IntPtr GetRefInt(IntPtr value) {
                return Marshal.ReadIntPtr(value);
            }
        }


    public class UnknownWrapper : IUnkCaller, IClassFactory
    {
        private ApiHandleRef ThisPtr;

        public UnknownWrapper(IntPtr ptr)
        {
            this.ThisPtr = ptr;
        }
        int IUnkCaller.QueryInterface(IntPtr thisPtr, ref Guid riid, out IntPtr ppvObject)
        {
            if(Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                ppvObject = IntPtr.Zero;
                return -1;
            }
                

            return Marshal.QueryInterface(thisPtr, ref riid, out ppvObject);
        }

        int IUnkCaller.AddRef(IntPtr thisPtr)
        {
            if(Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
               return -1;
            }
            return Marshal.AddRef(thisPtr);
        }

        int IUnkCaller.Release(IntPtr thisPtr)
        {
            if(Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                return -1;
            }
            return Marshal.Release(thisPtr);
        }

        int IClassFactory.CreateInstance(IntPtr pUnkOuter, Guid riid, out IntPtr ppvObject)
        {
            return ((IUnkCaller) this).QueryInterface(pUnkOuter, ref riid, out ppvObject);
        }

        int IClassFactory.LockServer( bool fLock)
        {
            return Ole32.CoLockObjectExternal(this.ThisPtr, fLock, true);
        }

        
    }
}