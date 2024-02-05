using System;
using System.Collections.Generic;
using Diga.Core.Api.Win32.Tools;

namespace Diga.Core.Api.Win32
{
    [Obsolete("do not use this class Will be removed=> use DlgTemplateLoader and Template and items property")]
    public class DlgTemplateEx
    {
     
        private ByteReader _Reader;
        public ushort DlgVer{get;set;}
        public ushort Signature{get;set;}
        public uint HelpId{get;set;}
        public uint ExStyle{get;set;}
        public uint Style{get;set;}
        public ushort CDlgItems{get;set;}
        public short X{get;set;}
        public short Y{get;set;}
        public short Cx{get;set;}
        public short Cy{get;set;}


        public ushort IsMenu{get;set;}
        public ushort MenuId{get;set;}
        public string MenuName{get;set;}

        public ushort IsWindowClass{get;set;}
        public string WindClassName{get;set;}
        public ushort WindClassId{get;set;}
        public ushort IsTitle{get;set;}

        public string Title{get;set;}

        public ushort Pointsize{get;set;}
        public ushort Weight{get;set;}
        public byte Italic{get;set;}
        public byte Charset{get;set;}

        public string Typeface{get;set;}
        public int LastPosition{get;private set;}

        public List<DlgItemTemplateEx> Items { get; } = new List<DlgItemTemplateEx>();

        public bool IsDialogEx()
        {
            return this.Signature == 0xFFFF;
        }
        public DlgTemplateEx(IntPtr ptr)
        {
          
            this._Reader = new ByteReader(ptr);

        }

        public DlgTemplateEx(ByteReader reader)
        {
            this._Reader = reader;
            
        }

        public void Read()
        {
            this.DlgVer = this._Reader.GetNextWordAsUShort();
            this.Signature = this._Reader.GetNextWordAsUShort();
            if (!IsDialogEx())
            {
                throw new InvalidOperationException("this is no DialogEx");
            }
            this.HelpId = this._Reader.GetNextDWordAsUint();
            this.ExStyle = this._Reader.GetNextDWordAsUint();
            this.Style = this._Reader.GetNextDWordAsUint();
            this.CDlgItems = this._Reader.GetNextWordAsUShort();
            this.X = this._Reader.GetNextWordAsShort();
            this.Y = this._Reader.GetNextWordAsShort();
            this.Cx = this._Reader.GetNextWordAsShort();
            this.Cy = this._Reader.GetNextWordAsShort();
            this.IsMenu = this._Reader.GetNextWordAsUShort();
            
            if (this.IsMenu != 0x0000)
            {
                if (this.IsMenu == 0xFFFF)
                {
                    this.MenuId = this._Reader.GetNextWordAsUShort();
                }
                else
                {
                    this._Reader.MoveBack(2);
                    this.MenuName = this._Reader.ReadWCharUpToNts();
      
                }
            }

            this.IsWindowClass = this._Reader.GetNextWordAsUShort();
            if (this.IsWindowClass != 0x0000)
            {
                if (this.IsWindowClass == 0xFFFF)
                {
                    this.WindClassId = this._Reader.GetNextWordAsUShort();
                }
                else
                {
                    this._Reader.MoveBack<ushort>();
                    this.WindClassName = this._Reader.ReadWCharUpToNts();
           
                }
            }

            this.IsTitle = this._Reader.GetNextWordAsUShort();
            if (this.IsTitle != 0x0000)
            {
                this._Reader.MoveBack(2);
                this.Title = this._Reader.ReadWCharUpToNts();
              
            }

            if ((this.Style & DialogBoxStyles.DS_SETFONT) != 0 || (this.Style & DialogBoxStyles.DS_SHELLFONT) != 0)
            {
                this.Pointsize = this._Reader.GetNextWordAsUShort();
                this.Weight = this._Reader.GetNextWordAsUShort();
                this.Italic = this._Reader.GetNextByte();
                this.Charset = this._Reader.GetNextByte();
                this.Typeface = this._Reader.ReadWCharUpToNts();
                
            }


            this._Reader.DWordAlign();
            this.LastPosition = this._Reader.Positon;
            ReadItems();
        }
        private void ReadItems()
        {
            for (int i = 0; i < this.CDlgItems; i++)
            {
                DlgItemTemplateEx tItem = new DlgItemTemplateEx(this._Reader);
                tItem.Read();
                this.Items.Add(tItem);
            }
        }
    }
}