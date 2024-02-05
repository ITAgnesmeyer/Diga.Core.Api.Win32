using System;
using Diga.Core.Api.Win32.Tools;

namespace Diga.Core.Api.Win32
{
    [Obsolete("do not use this class Will be removed=> use DlgTemplateLoader and Template and items property")]
    public class DlgItemTemplateEx
    {
        private ByteReader Reader{get;set;}
        public uint HelpId{get;set;}
        public uint ExStyle{get;set;}
        public uint Style{get;set;}
        public short X{get;set;}
        public short Y{get;set;}
        public short Cx{get;set;}
        public short Cy{get;set;}
        public uint Id{get;set;}

        public ushort IsWindowClass{get;set;}
        public string WindowClass{get;set;}
        public ushort WindowClassId{get;set;}

        public ushort IsTitle{get;set;}
        public string Title{get;set;}
        public ushort TitleId{get;set;}
        public ushort ExtraCount{get;set;}
        public byte[] ExtraData{get;set;}
        public int LastPosition{get;private set;}
        
        
        public DlgItemTemplateEx(ByteReader reader)
        {
            this.Reader = reader;
        }

        public DlgItemTemplateEx(IntPtr ptr, int position)
        {
            this.Reader = new ByteReader(ptr, position);
        }

        public void Read()
        {

            this.HelpId = this.Reader.GetNextDWordAsUint();
            this.ExStyle = this.Reader.GetNextDWordAsUint();
            this.Style = this.Reader.GetNextDWordAsUint();
            this.X = this.Reader.GetNextWordAsShort();
            this.Y = this.Reader.GetNextWordAsShort();
            this.Cx = this.Reader.GetNextWordAsShort();
            this.Cy = this.Reader.GetNextWordAsShort();
            this.Id = this.Reader.GetNextDWordAsUint();

            this.IsWindowClass = this.Reader.GetNextWordAsUShort();
            if (this.IsWindowClass == 0xFFFF)
            {
                this.WindowClassId = this.Reader.GetNextWordAsUShort();
            }
            else
            {
                this.Reader.MoveBack(2);
                this.WindowClass = this.Reader.ReadWCharUpToNts();
            
            }

            this.IsTitle = this.Reader.GetNextWordAsUShort();
            if (this.IsTitle == 0xFFFF)
            {
                this.TitleId = this.Reader.GetNextWordAsUShort();
            }
            else
            {
                this.Reader.MoveBack(2);
                this.Title = this.Reader.ReadWCharUpToNts();
            }

            this.ExtraCount = this.Reader.GetNextWordAsUShort();


            this.Reader.Positon += this.ExtraCount;

            this.Reader.DWordAlign();
            int endPos = this.Reader.Positon;
            if (this.ExtraCount > 0)
            {

                this.Reader.MoveBack(this.ExtraCount);
                this.ExtraData = this.Reader.GetBytes(this.ExtraCount);
                this.Reader.Positon = endPos;
            }

            this.LastPosition = this.Reader.Positon;
        }

        
    }
}