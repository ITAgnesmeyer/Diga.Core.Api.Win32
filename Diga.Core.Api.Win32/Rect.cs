using System.Drawing;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Rect(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Rect(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
        {
        }

        public int X
        {
            get => this.Left;
            set
            {
                this.Right -= (this.Left - value);
                this.Left = value;
            }
        }

        public int Y
        {
            get => this.Top;
            set
            {
                this.Bottom -= (this.Top - value);
                this.Top = value;
            }
        }

        public int Height
        {
            get => this.Bottom - this.Top;
            set => this.Bottom = value + this.Top;
        }

        public int Width
        {
            get => this.Right - this.Left;
            set => this.Right = value + this.Left;
        }

        public System.Drawing.Point Location
        {
            get => new System.Drawing.Point(this.Left, this.Top);
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public System.Drawing.Size Size
        {
            get => new System.Drawing.Size(this.Width, this.Height);
            set
            {
                this.Width = value.Width;
                this.Height = value.Height;
            }
        }

       

        public static implicit operator System.Drawing.Rectangle(Rect r)
        {
            return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
        }

        public static implicit operator Rect(System.Drawing.Rectangle r)
        {
            return new Rect(r);
        }

        public static bool operator ==(Rect r1, Rect r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Rect r1, Rect r2)
        {
            return !r1.Equals(r2);
        }

        public bool Equals(Rect r)
        {
            return r.Left == this.Left && r.Top == this.Top && r.Right == this.Right && r.Bottom == this.Bottom;
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Rect rect:
                    return Equals(rect);
                case Rectangle rectangle:
                    return Equals(new Rect(rectangle));
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return ((System.Drawing.Rectangle) this).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture,
                "{{Left={0},Top={1},Right={2},Bottom={3}}}", this.Left, this.Top, this.Right, this.Bottom);
        }
    }
}