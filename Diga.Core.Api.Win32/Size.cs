using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {

        /// LONG->int
        public int cx;

        /// LONG->int
        public int cy;

        public Size(int width, int height)
        {
            this.cx = width;
            this.cy = height;
        }

        public static implicit operator  System.Drawing.Size(Size input)
        {
            return new System.Drawing.Size(input.cx, input.cy);
        }

        public static implicit operator Size(System.Drawing.Size input)
        {
            return new Size(input.Width, input.Height);
        }
    }
}