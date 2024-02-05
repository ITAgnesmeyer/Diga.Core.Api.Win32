using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public class ResourceLoader
    {
        private IntPtr _HInstance;

        public ResourceLoader(IntPtr hInstance)
        {
            this._HInstance = hInstance;
        }

        public IntPtr FindResource(string resId, string type)
        {
            IntPtr hRes = Kernel32.FindResource(this._HInstance, resId, type);
            
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;

            
        }

        public IntPtr FindResource(IntPtr resId, IntPtr type)
        {
            IntPtr hRes = Kernel32.FindResource(this._HInstance, resId, type);
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;
        }

        public IntPtr FindResource(int resId, int type)
        {
            IntPtr hRes = Kernel32.FindResource(this._HInstance, Win32Api.MakeInterSource(resId),
                Win32Api.MakeInterSource(type));
            if (hRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return hRes;
        }

        public IntPtr LoadResource(IntPtr hRes)
        {
            IntPtr res = Kernel32.LoadResource(this._HInstance, hRes);
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
            StringBuilder sb = new StringBuilder(5000);
            int len = User32.LoadString(this._HInstance, id, sb, sb.Length);
            if (len == 0)
                Debug.Print("no data");
            return sb.ToString();
        }

        public IntPtr LoadAccelerator(int id)
        {
            IntPtr hAccel = User32.LoadAccelerators(this._HInstance, Win32Api.MakeInterSource(id));
            if (hAccel == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hAccel;
        }

        public IntPtr LoadIcon(int id)
        {
            IntPtr hIcon = User32.LoadIcon(this._HInstance, Win32Api.MakeInterSource(id));
            if (hIcon == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return hIcon;
        }

        public IntPtr LoadCursor(int id)
        {
            IntPtr hCursor = User32.LoadCursor(this._HInstance, Win32Api.MakeInterSource(id));
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

    }
}