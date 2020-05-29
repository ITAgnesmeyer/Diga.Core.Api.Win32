﻿using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TbButton {
        public int iBitmap;
        public int idCommand;
        [StructLayout(LayoutKind.Explicit)]
        private struct TbButton_u {
            [FieldOffset(0)] public byte fsState;
            [FieldOffset(1)] public byte fsStyle;
            [FieldOffset(0)] private IntPtr bReserved;
        }
        private TbButton_u union;
        public byte fsState { get { return this.union.fsState; } set { this.union.fsState = value; } }
        public byte fsStyle { get { return this.union.fsStyle; } set { this.union.fsStyle = value; } }
        public UIntPtr dwData;
        public IntPtr iString;
    }
}