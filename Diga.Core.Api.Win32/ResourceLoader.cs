using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Diga.Core.Api.Win32.GDI;

namespace Diga.Core.Api.Win32
{
    public class ResourceLoader
    {
        private readonly IntPtr _hInstance;
        private static ResourceLoader _Loader = null;

        public static ResourceLoader Loader => _Loader ?? (_Loader = new ResourceLoader());

        public ResourceLoader()
        {
            this._hInstance = Kernel32.GetModuleHandle(null);
        }
        public ResourceLoader(IntPtr hInstance)
        {
            this._hInstance = hInstance;
        }

        public IntPtr FindResource(string resId, string type)
        {
            IntPtr hRes = Kernel32.FindResource(this._hInstance, resId, type);
            
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;

            
        }

        public IntPtr FindResource(IntPtr resId, IntPtr type, ushort language)
        {
            IntPtr hRes = Kernel32.FindResourceEx(this._hInstance, type, resId, language);
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;
        }

        public IntPtr FindResource(string resId, string type, ushort language)
        {
            IntPtr hRes = Kernel32.FindResourceEx(this._hInstance, type, resId, language);
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hRes;
        }
        public IntPtr FindResource(IntPtr resId, IntPtr type)
        {
            
            IntPtr hRes = Kernel32.FindResource(this._hInstance, resId, type);
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;
        }

        public IntPtr FindResource(int resId, int type)
        {
            IntPtr hRes = Kernel32.FindResource(this._hInstance, Win32Api.MakeInterSource(resId),
                Win32Api.MakeInterSource(type));
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;
        }
        public uint GetResourceSize(int resId, int type)
        {
            IntPtr hRes = FindResource(resId, type);
            return Kernel32.SizeofResource(this._hInstance, hRes);

        }

        public uint GetResourceSize(IntPtr hRes)
        {
            return Kernel32.SizeofResource(this._hInstance, hRes);
        }
        public byte[] LoadRTData(int resId)
        {
            IntPtr hRes = FindResource(Win32Api.MakeInterSourceString(resId), "RT_DATA");
            uint size = GetResourceSize(hRes);
            byte[] arr = new byte[size];
            IntPtr hGlobal = LoadResource(hRes);
            //IntPtr loced = LoadResource(hGlobal);
            Marshal.Copy(hGlobal, arr, 0, (int)size);
            
            return arr;

        }
        public IntPtr LoadResource(IntPtr hRes)
        {
            IntPtr res = Kernel32.LoadResource(this._hInstance, hRes);
            if (res == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return res;
        }

        public IntPtr LockResource(IntPtr resHGlobal)
        {
            return Kernel32.LockResource(resHGlobal);
        }

        public IntPtr LoadResource(IntPtr resId, IntPtr type)
        {
            IntPtr hRes = FindResource(resId, type);
            IntPtr resHGlobal = LoadResource(hRes);
            return LockResource(resHGlobal);
        }
        public IntPtr LoadResource(int resId, int type)
        {
            IntPtr hRes = FindResource(resId, type);
            IntPtr resHGlobal = LoadResource(hRes);
            return LockResource(resHGlobal);
            
        }

        public IntPtr LoadResource(string resId, string type)
        {
            IntPtr hRes = FindResource(resId, type);
            IntPtr resHGlobal = LoadResource(hRes);
            return LockResource(resHGlobal);
        }

        public string LoadString(int id)
        {
            const int MAX_RES_SRING = 65535;
            StringBuilder sb = new StringBuilder(MAX_RES_SRING);
            int len = User32.LoadString(this._hInstance, id, sb, MAX_RES_SRING);
            if (len == 0)
                Debug.Print("no data");
            return sb.ToString();
        }

        public string LoadString(int id, int maxLen)
        {
            StringBuilder sb = new StringBuilder(maxLen);
            int len = User32.LoadString(this._hInstance, id, sb, maxLen);
            if (len == 0)
                Debug.Print("no data");
            return sb.ToString();
        }
        public IntPtr LoadAccelerator(int id)
        {
            IntPtr hAccel = User32.LoadAccelerators(this._hInstance, Win32Api.MakeInterSource(id));
            if (hAccel == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hAccel;
        }

        public IntPtr LoadIcon(int id)
        {
            IntPtr hIcon = User32.LoadIcon(this._hInstance, Win32Api.MakeInterSource(id));
            if (hIcon == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hIcon;
        }

        public IntPtr LoadStdIcon(StdIcons stdIcons)
        {
            IntPtr hIcon = User32.LoadIcon(IntPtr.Zero, Win32Api.MakeInterSource((int)stdIcons));
            return hIcon;
        }
        public IntPtr LoadCursor(int id)
        {
            IntPtr hCursor = User32.LoadCursor(this._hInstance, Win32Api.MakeInterSource(id));
            if (hCursor == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hCursor;
        }

        public IntPtr LoadCursorGlobal(int id)
        {
            IntPtr hCursor = User32.LoadCursor(IntPtr.Zero, id);
            if (hCursor == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hCursor;
        }

        public IntPtr LoadBitmap(int id)
        {
            IntPtr hBmp = User32.LoadBitmap(this._hInstance, Win32Api.MakeInterSource(id));
            if (hBmp == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hBmp;
        }

        public IntPtr LoadImage(int id, uint type,int cx, int cy, uint fuLoad = 0 )
        {
            IntPtr hImage = User32.LoadImage(this._hInstance, Win32Api.MakeInterSource(id), type, cx, cy, fuLoad);
            if (hImage == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hImage;
        }
        public bool DeleteBitmap(IntPtr hBitmap)
        {
            return Gdi32.DeleteObject(hBitmap);
        }


    }
}