// ReSharper disable IdentifierTypo

using System;
using System.Text;

namespace Diga.Core.Api.Win32.Dlg
{
    //public interface IDlg : IWnd
    //{
    //    int Id { get; }
    //    DlgTemplateAll Tempale { get; }
    //}

    //public class Dlg : IDlg
    //{
    //    private IntPtr _hWnd;
    //    private DlgTemplateAll _DlgTemplateAll;
    //    private int _Id;
    //    public IntPtr Handle => this._hWnd;
    //    public int Id => this._Id;
    //    public DlgTemplateAll Tempale => this._DlgTemplateAll;

    //    public Dlg(int id)
    //    {
    //        this._Id = id;
    //    }
    //    public Dlg(DlgTemplateAll template)
    //    {
    //        this._DlgTemplateAll = template;
            
    //    }
    //    public Dlg(IntPtr hWnd)
    //    {
    //        this._hWnd = hWnd;

    //    }
    //    public int GetDlgCtrlID(IntPtr hWnd)
    //    {
    //        return User32.GetDlgCtrlID(hWnd);
    //    }
    //    public IntPtr GetDlgItem(int id)
    //    {
    //        return User32.GetDlgItem(this.Handle, id);

    //    }

    //    public string GetDlgItemText(int id)
    //    {
    //        StringBuilder sb = new StringBuilder(1024);
    //        uint r = User32.GetDlgItemText(this.Handle, id, sb, 1024);
    //        if(r > 0)
    //        {
    //            return sb.ToString();
    //        }
    //        return "";
    //    }
       
    //    public string GetText()
    //    {
    //        return User32.GetWindowTextRaw(this.Handle);
    //    }

    //    public bool SetText(string text)
    //    {
    //        return User32.SetWindowText(this.Handle, text);
    //    }

    //    public bool GetClientRect(out Rect rect)
    //    {
    //        return User32.GetClientRect(this.Handle, out rect);
    //    }

    //    public bool GetWindowsRect(out Rect rect)
    //    {
    //       return User32.GetWindowRect(this.Handle, out rect);
    //    }

        

    //}
}