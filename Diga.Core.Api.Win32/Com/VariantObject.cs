using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class VariantObject
    {
        [MarshalAs(UnmanagedType.I2)]
        public short vt;
        [MarshalAs(UnmanagedType.I2)]
        public short reserved1;
        [MarshalAs(UnmanagedType.I2)]
        public short reserved2;
        [MarshalAs(UnmanagedType.I2)]
        public short reserved3;

        public VariantDataForSet<IntPtr> data1;

        public VariantDataForSet<IntPtr> data2;


        public static IntPtr ObjectArrayToVariantArrayPtr(object[] objects)
        {
            return ArrayToVariantObjectHelper.ArrayToVariantVector(objects);
        }

        public static void FreeVariantArrayPtr(IntPtr ptr, int len)
        {
            ArrayToVariantObjectHelper.FreeVariantVector(ptr, len);
        }
        public bool Byref
        {
            get
            {
                return 0 != (this.vt & (int)VariantTypes.VT_BYREF);
            }
        }

        public void Clear()
        {
            if ((this.vt == (int)VariantTypes.VT_UNKNOWN || this.vt == (int)VariantTypes.VT_DISPATCH) && this.data1.Value != IntPtr.Zero)
            {
                Marshal.Release(this.data1.Value);
            }

            if (this.vt == (int)VariantTypes.VT_BSTR && this.data1.Value != IntPtr.Zero)
            {
                OleAuto32.SysFreeString(this.data1.Value);
            }

            this.data1.Value = this.data2.Value = IntPtr.Zero;
            this.vt = (int)VariantTypes.VT_EMPTY;
        }

        ~VariantObject()
        {
            Clear();
        }

        public void SuppressFinalize()
        {
            // Called if this VARIANT is returned to the caller in native world which is supposed to call
            // VariantClear().
            // GC does not have to clear it.
            GC.SuppressFinalize(this);
        }


        public static VariantObject FromObject(object var)
        {
            VariantObject v = new VariantObject();

            if (var == null)
            {
                v.vt = (int)VariantTypes.VT_EMPTY;
            }
            else if (Convert.IsDBNull(var))
            {
            }
            else
            {
                Type t = var.GetType();

                if (t == typeof(bool))
                {
                    v.vt = (int)VariantTypes.VT_BOOL;
                }
                else if (t == typeof(byte))
                {
                    v.vt = (int)VariantTypes.VT_UI1;
                    v.data1 = (IntPtr)Convert.ToByte(var);
                }
                else if (t == typeof(char))
                {
                    v.vt = (int)VariantTypes.VT_UI2;
                    v.data1 = (IntPtr)Convert.ToChar(var);
                }
                else if (t == typeof(string))
                {
                    v.vt = (int)VariantTypes.VT_BSTR;
                    v.data1 = OleAuto32.SysAllocString(Convert.ToString(var));
                }
                else if (t == typeof(short))
                {
                    v.vt = (int)VariantTypes.VT_I2;
                    v.data1 = (IntPtr)Convert.ToInt16(var);
                }
                else if (t == typeof(int))
                {
                    v.vt = (int)VariantTypes.VT_I4;
                    v.data1 = (IntPtr)Convert.ToInt32(var);
                }
                else if (t == typeof(long))
                {
                    v.vt = (int)VariantTypes.VT_I8;
                    v.SetLong(Convert.ToInt64(var));
                }
                else if (t == typeof(decimal))
                {
                    v.vt = (int)VariantTypes.VT_CY;
                    decimal c = (decimal)var;
                    // SBUrke, it's bizzare that we need to call this as a static!
                    v.SetLong(decimal.ToInt64(c));
                }
                else if (t == typeof(decimal))
                {
                    v.vt = (int)VariantTypes.VT_DECIMAL;
                    decimal d = Convert.ToDecimal(var);
                    v.SetLong(decimal.ToInt64(d));
                }
                else if (t == typeof(double))
                {
                    v.vt = (int)VariantTypes.VT_R8;
                    // how do we handle double?
                }
                else if (t == typeof(float) || t == typeof(float))
                {
                    v.vt = (int)VariantTypes.VT_R4;
                    // how do we handle float?
                }
                else if (t == typeof(DateTime))
                {
                    v.vt = (int)VariantTypes.VT_DATE;
                    v.SetLong(Convert.ToDateTime(var).ToFileTime());
                }
                else if (t == typeof(sbyte))
                {
                    v.vt = (int)VariantTypes.VT_I1;
                    v.data1 = (IntPtr)Convert.ToSByte(var);
                }
                else if (t == typeof(ushort))
                {
                    v.vt = (int)VariantTypes.VT_UI2;
                    v.data1 = (IntPtr)Convert.ToUInt16(var);
                }
                else if (t == typeof(uint))
                {
                    v.vt = (int)VariantTypes.VT_UI4;
                    v.data1 = (IntPtr)Convert.ToUInt32(var);
                }
                else if (t == typeof(ulong))
                {
                    v.vt = (int)VariantTypes.VT_UI8;
                    v.SetLong((long)Convert.ToUInt64(var));
                }
                else if (t == typeof(object) || t == typeof(IDispatch) || t.IsCOMObject)
                {
                    v.vt = (t == typeof(IDispatch) ? (short)VariantTypes.VT_DISPATCH : (short)VariantTypes.VT_UNKNOWN);
#pragma warning disable CA1416
                    v.data1 = Marshal.GetIUnknownForObject(var);
#pragma warning restore CA1416
                }
                else
                {
                    Debug.Assert(false, "Unsupported object type!");
                }
            }
            return v;
        }

      

        public void SetLong(long lVal)
        {
            this.data1.Value = (IntPtr)(lVal & 0xFFFFFFFF);
            this.data2.Value = (IntPtr)((lVal >> 32) & 0xFFFFFFFF);
        }

        public IntPtr ToCoTaskMemPtr()
        {
            IntPtr mem = Marshal.AllocCoTaskMem(16);
            Marshal.WriteInt16(mem, this.vt);
            Marshal.WriteInt16(mem, 2, this.reserved1);
            Marshal.WriteInt16(mem, 4, this.reserved2);
            Marshal.WriteInt16(mem, 6, this.reserved3);
            Marshal.WriteInt32(mem, 8, (int)this.data1.Value);
            Marshal.WriteInt32(mem, 12, (int)this.data2.Value);
            return mem;
        }

        public object ToObject()
        {
            IntPtr val = this.data1.Value;
            long longVal;

            int vtType = this.vt & (short)VariantTypes.VT_TYPEMASK;

            switch (vtType)
            {
                case (int)VariantTypes.VT_EMPTY:
                    return null;
                case (int)VariantTypes.VT_NULL:
                    return Convert.DBNull;

                case (int)VariantTypes.VT_I1:
                    if (this.Byref)
                    {
                        val = (IntPtr)Marshal.ReadByte(val);
                    }
                    return (sbyte)(0xFF & (sbyte)val);

                case (int)VariantTypes.VT_UI1:
                    if (this.Byref)
                    {
                        val = (IntPtr)Marshal.ReadByte(val);
                    }

                    return (byte)(0xFF & (byte)val);

                case (int)VariantTypes.VT_I2:
                    if (this.Byref)
                    {
                        val = (IntPtr)Marshal.ReadInt16(val);
                    }
                    return (short)(0xFFFF & (short)val);

                case (int)VariantTypes.VT_UI2:
                    if (this.Byref)
                    {
                        val = (IntPtr)Marshal.ReadInt16(val);
                    }
                    return (ushort)(0xFFFF & (ushort)val);

                case (int)VariantTypes.VT_I4:
                case (int)VariantTypes.VT_INT:
                    if (this.Byref)
                    {
                        val = (IntPtr)Marshal.ReadInt32(val);
                    }
                    return (int)val;

                case (int)VariantTypes.VT_UI4:
                case (int)VariantTypes.VT_UINT:
                    if (this.Byref)
                    {
                        val = (IntPtr)Marshal.ReadInt32(val);
                    }
                    return (uint)val;

                case (int)VariantTypes.VT_I8:
                case (int)VariantTypes.VT_UI8:
                    if (this.Byref)
                    {
                        longVal = Marshal.ReadInt64(val);
                    }
                    else
                    {
                        longVal = ((uint)this.data1.Value & 0xffffffff) | (uint)this.data2.Value << 32;
                    }

                    if (this.vt == (int)VariantTypes.VT_I8)
                    {
                        return (long)longVal;
                    }
                    else
                    {
                        return (ulong)longVal;
                    }
            }

            if (this.Byref)
            {
                val = GetRefInt(val);
            }

            switch (vtType)
            {
                case (int)VariantTypes.VT_R4:
                case (int)VariantTypes.VT_R8:

                    // can I use unsafe here?
                    throw new FormatException(/*SR.GetString(SR.CannotConvertIntToFloat)*/);

                case (int)VariantTypes.VT_CY:
                    // internally currency is 8-byte int scaled by 10,000
                    longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    return new decimal(longVal);
                case (int)VariantTypes.VT_DATE:
                    throw new FormatException(/*SR.GetString(SR.CannotConvertDoubleToDate)*/);

                case (int)VariantTypes.VT_BSTR:
                case (int)VariantTypes.VT_LPWSTR:
                    return Marshal.PtrToStringUni(val);

                case (int)VariantTypes.VT_LPSTR:
                    return Marshal.PtrToStringAnsi(val);

                case (int)VariantTypes.VT_DISPATCH:
                case (int)VariantTypes.VT_UNKNOWN:
                {
#pragma warning disable CA1416
                    return Marshal.GetObjectForIUnknown(val);
#pragma warning restore CA1416
                }

                case (int)VariantTypes.VT_HRESULT:
                    return val;

                case (int)VariantTypes.VT_DECIMAL:
                    longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    return new decimal(longVal);

                case (int)VariantTypes.VT_BOOL:
                    return (val != IntPtr.Zero);

                case (int)VariantTypes.VT_VARIANT:
                    VariantObject varStruct = (VariantObject)Marshal.PtrToStructure(val, typeof(VariantObject));
                    return varStruct.ToObject();
                case (int)VariantTypes.VT_CLSID:
                    //Debug.Fail("PtrToStructure will not work with System.Guid...");

                    Guid guid = (Guid)Marshal.PtrToStructure(val, typeof(Guid));
                    return guid;

                case (int)VariantTypes.VT_FILETIME:
                    longVal = ((uint)this.data1.Value & 0xffffffff) | ((uint)this.data2.Value << 32);
                    return new DateTime(longVal);

                case (int)VariantTypes.VT_ARRAY:
                //gSAFEARRAY sa = (tagSAFEARRAY)Marshal.PtrToStructure(val), typeof(tagSAFEARRAY));
                //return GetArrayFromSafeArray(sa);

                case (int)VariantTypes.VT_USERDEFINED:
                case (int)VariantTypes.VT_VOID:
                case (int)VariantTypes.VT_PTR:
                case (int)VariantTypes.VT_SAFEARRAY:
                case (int)VariantTypes.VT_CARRAY:

                case (int)VariantTypes.VT_RECORD:
                case (int)VariantTypes.VT_BLOB:
                case (int)VariantTypes.VT_STREAM:
                case (int)VariantTypes.VT_STORAGE:
                case (int)VariantTypes.VT_STREAMED_OBJECT:
                case (int)VariantTypes.VT_STORED_OBJECT:
                case (int)VariantTypes.VT_BLOB_OBJECT:
                case (int)VariantTypes.VT_CF:
                case (int)VariantTypes.VT_BSTR_BLOB:
                case (int)VariantTypes.VT_VECTOR:
                case (int)VariantTypes.VT_BYREF:
                //case (int)tagVT.VT_RESERVED:
                default:
                    return null;
            }
        }
        private static IntPtr GetRefInt(IntPtr value)
        {
            return Marshal.ReadIntPtr(value);
        }
    }
}