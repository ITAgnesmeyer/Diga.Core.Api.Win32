
using Diga.Core.Api.Win32.Tools;
using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    public class ApiGuid
    {
        private GUID _Guid;
        public ApiGuid(GUID guid)
        {
             this._Guid = guid;
        }
        public ApiGuid()
        {
             this._Guid = new GUID();   
        }
        public static implicit operator Guid(ApiGuid input)
        {
            return new Guid(input._Guid.Data1, 
                input._Guid.Data2, 
                input._Guid.Data3, 
                input._Guid.Data4_0, 
                input._Guid.Data4_1,
                input._Guid.Data4_2, 
                input._Guid.Data4_3, 
                input._Guid.Data4_4, 
                input._Guid.Data4_5, 
                input._Guid.Data4_6, 
                input._Guid.Data4_7);


        }
        public static implicit operator ApiGuid(Guid input)
        {
            
            byte[] arr = input.ToByteArray();
            IntPtr ptr = Marshal.AllocHGlobal(arr.Length);
            Marshal.Copy(ptr, arr, 0, arr.Length);
            ByteReader reader = new ByteReader(ptr);
            GUID guid = new GUID();
            guid.Data1 = reader.GetNextUInt();
            guid.Data2 = reader.GetNextUShort();
            guid.Data3 = reader.GetNextUShort();
            guid.Data4_0 = reader.GetNextByte();
            guid.Data4_1 = reader.GetNextByte();
            guid.Data4_2 = reader.GetNextByte();
            guid.Data4_3 = reader.GetNextByte();
            guid.Data4_4 = reader.GetNextByte();
            guid.Data4_5 = reader.GetNextByte();
            guid.Data4_6 = reader.GetNextByte();
            guid.Data4_7 = reader.GetNextByte();
            Marshal.FreeHGlobal(ptr);
            return new ApiGuid(guid);
            
        }
        public static implicit operator GUID(ApiGuid input)
        {
            return input._Guid;
        }
    }
}