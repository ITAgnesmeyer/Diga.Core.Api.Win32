using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public  class DlgTemplateLoader
    {
        private  DLGTEMPLATEALL _Template;
        private  List<DLGITEMTEMPLATEALL> _Items;

        public DlgTemplateLoader()
        {
            _Template = new DLGTEMPLATEALL();
            _Items = new List<DLGITEMTEMPLATEALL>();
        }

        private  unsafe bool IsDialogEx(DLGTEMPLATE_API* pTemplate)
        {
            return ((DLGTEMPLATEEX_API*)pTemplate)->signature == 0xFFFF;
        }

        private unsafe ushort DlgTemplateItemCount(DLGTEMPLATE_API* pTemplate)
        {
            if (IsDialogEx(pTemplate))
            {
                return ((DLGTEMPLATEEX_API*)pTemplate)->cDlgItems;
            }

            return pTemplate->cdit;
        }


        private unsafe DLGITEMTEMPLATE_API* FindFirstDlgItem(DLGTEMPLATE_API* pTemplate)
        {
            bool isDialogEx = IsDialogEx(pTemplate);
            ushort* pw;
            uint dwStyle;
            if (isDialogEx)
            {
                pw = (ushort*)((DLGTEMPLATEEX_API*)pTemplate + 1);
                dwStyle = ((DLGTEMPLATEEX_API*)pTemplate)->style;
            }
            else
            {
                pw = (ushort*)(pTemplate + 1);
                dwStyle = pTemplate->style;
            }

            //Menu
            if (*pw == 0xFFFF)
            {
                //Is ID
                pw += 2;
            }
            else
            {
                //Is String
                while (*pw != 0)
                {
                    pw++;
                }

                pw += 1;
            }

            //ClassName
            if (*pw == 0xFFFF)
            {
                //is ATOM
                pw += 2;

            }
            else
            {
                while (*pw != 0)
                {
                    pw++;
                }
                pw += 1;
            }

            while (*pw != 0)
            {
                pw++;
            }

            pw += 1;
            if ((dwStyle & DialogBoxStyles.DS_SETFONT) != 0)
            {
                if (isDialogEx)
                {
                    pw += 3;
                }
                else
                {
                    pw += 1;
                }

                while (*pw != 0)
                {
                    pw++;
                }
                pw += 1;


            }
            return (DLGITEMTEMPLATE_API*)(((long)pw + 3) & ~3);
        }

        private unsafe DLGITEMTEMPLATE_API* FindNextDlgItem(DLGITEMTEMPLATE_API* pItem, bool isDialogEx)
        {
            ushort* pw;
            if (isDialogEx)
            {
                pw = (ushort*)((DLGITEMTEMPLATEEX_API*)pItem + 1);
            }
            else
            {
                pw = (ushort*)(pItem + 1);
            }

            //class name or ID
            if (*pw == 0xFFFF)
            {
                pw += 2;
            }
            else
            {
                while (*pw != 0)
                {
                    pw++;
                }

                pw += 1;
            }

            //title
            if (*pw == 0xFFFF)
            {
                pw += 2;
            }
            else
            {
                while (*pw != 0)
                {
                    pw++;
                }

                pw += 1;
            }

            //pw += 1;
            ushort cbExtra = *pw;
            pw++;
            if (cbExtra != 0 && !isDialogEx)
                cbExtra -= 2;
            return (DLGITEMTEMPLATE_API*)(((long)pw + cbExtra + 3) & ~3);
        }

        private unsafe DLGTEMPLATEALL GetTemplateAllFromDlgTemplate(DLGTEMPLATE_API* pTemplate)
        {
            ushort* pw;
            uint dwStyle;
            DLGTEMPLATEALL all  = new DLGTEMPLATEALL();
            bool isEx = IsDialogEx(pTemplate);
            if (isEx)
            {
                DLGTEMPLATEEX_API* exp = (DLGTEMPLATEEX_API*)pTemplate;
                all.Version = exp->dlgVer;
                all.IsExtended = true;
                all.HelpID = exp->helpID;
                all.ExStyle = exp->exStyle;
                all.Style = exp->style;
                all.ItemsCount = exp->cDlgItems;
                all.x = exp->x;
                all.y = exp->y;
                all.cx = exp->cx;
                all.cy = exp->cy;
                pw = (ushort*)((DLGTEMPLATEEX_API*)pTemplate + 1);
                dwStyle = exp->style;
            }
            else
            {
                all.Version = 0;
                all.IsExtended = false;
                all.HelpID = 0;
                all.ExStyle = pTemplate->dwExtendedStyle;
                all.Style = pTemplate->style;
                all.ItemsCount = pTemplate->cdit;
                all.x = pTemplate->x;
                all.y = pTemplate->y;
                all.cx = pTemplate->cx;
                all.cy = pTemplate->cy;
                pw = (ushort*)(pTemplate + 1);
                dwStyle = pTemplate->style;
            }

            if (*pw == 0xFFFF)
            {
                pw += 1;
                all.MenuID = *pw;
                pw += 1;
            }
            else
            {

                List<char> bytesList = new List<char>();

                char* bytes = (char*)pw;

                while (*bytes != 0)
                {
                    bytesList.Add(*bytes);
                    bytes++;
                }

                string str = new string(bytesList.ToArray());
                all.MenuName = str;
                int length = str.Length;
                pw += length + 1;
            }

            if (*pw == 0xFFFF)
            {
                pw += 1;
                all.ClassID = *pw;
                pw += 1;
            }
            else
            {
                List<char> byteList = new List<char>();
                char* bytes = (char*)pw;
                while (*bytes != 0)
                {
                    byteList.Add(*bytes);
                    bytes++;
                }

                string str = new string(byteList.ToArray());
                all.ClassName = str;
                int length = str.Length;
                pw += length + 1;

            }

            // caption
            {
                List<char> byteList = new List<char>();
                char* bytes = (char*)pw;
                while (*bytes != 0)
                {
                    byteList.Add(*bytes);
                    bytes++;
                }

                string str = new string(byteList.ToArray());
                all.Title = str;
                int length = str.Length;
                pw += length + 1;
            }

            if ((dwStyle & DialogBoxStyles.DS_SETFONT) != 0)
            {
                all.PointSize = *pw;
                pw += 1;
                all.Weight = *pw;
                pw += 1;
                all.Italic = ((BYTESPLIT*)pw)->First;
                all.CharSet = ((BYTESPLIT*)pw)->Second;
                pw += 1;
                List<char> byteList = new List<char>();
                char* bytes = (char*)pw;
                while (*bytes != 0)
                {
                    byteList.Add(*bytes);
                    bytes++;
                }

                string str = new string(byteList.ToArray());
                all.TypeFace = str;

            }

            return all;
        }

        private unsafe DLGITEMTEMPLATEALL GetDlgItemTemplateAllForDlgItemTemplate(DLGITEMTEMPLATE_API* pTemplate,
            bool isEx)
        {
            ushort* pw;
            DLGITEMTEMPLATEALL all = new DLGITEMTEMPLATEALL();
            if (isEx)
            {
                DLGITEMTEMPLATEEX_API* ext = (DLGITEMTEMPLATEEX_API*)pTemplate;
                all.HelpID = ext->helpID;
                all.ExStyle = ext->exStyle;
                all.Style = ext->style;
                all.x = ext->x;
                all.y = ext->y;
                all.cx = ext->cx;
                all.cy = ext->cy;
                all.Id = ext->id;
                pw = (ushort*)((DLGITEMTEMPLATEEX_API*)pTemplate +1);

            }
            else
            {
                all.HelpID = 0;
                all.ExStyle = pTemplate->dwExtendedStyle;
                all.Style = pTemplate->style;
                all.x = pTemplate->x;
                all.y = pTemplate->y;
                all.cx = pTemplate->cx;
                all.cy = pTemplate->cy;
                all.Id = pTemplate->id;
                pw = (ushort*)(pTemplate +1);
            }
            //class name or ID
            if (*pw == 0xFFFF)
            {
                pw += 1;
                all.ClassID = *pw;
                pw += 1;
            }
            else
            {
                if (*pw != 0)
                {
                    char* bytes = (char*)pw;
                    List<char> byteList = new List<char>();
                    while (*bytes != 0)
                    {
                        byteList.Add(*bytes);
                        bytes++;
                    }

                    string str = new string(byteList.ToArray());
                    all.ClassName = str;
                    int len = byteList.Count;
                    pw += len + 1;

                }
                else
                {
                    all.ClassName = string.Empty;
                    pw += 1;
                }
            }
            //title Name or ID
            if (*pw == 0xFFFF)
            {
                pw += 1;
                all.TitleID = *pw;
                pw += 1;
            }
            else
            {
                if (*pw != 0)
                {
                    char* bytes = (char*)pw;
                    List<char> bytesList = new List<char>();
                    while (*bytes != 0)
                    {
                        bytesList.Add(*bytes);
                        bytes++;
                    }

                    string str = new string(bytesList.ToArray());
                    all.Title = str;
                    int len = bytesList.Count;
                    pw += len + 1;
                }
                else
                {
                    all.Title = string.Empty;
                    pw += 1;
                }
            }

            ushort cbExtra = *pw;
            if(cbExtra != 0 && !isEx)
                cbExtra = 0;
            all.ExtraCount = cbExtra;

            return all;
        }

        public DLGTEMPLATEALL Template => _Template;
        public List<DLGITEMTEMPLATEALL> Items => _Items;
        public unsafe void LoadTemplates(IntPtr hInstance, int id)
        {
            IntPtr hres = Kernel32.FindResource(hInstance, Win32Api.MakeInterSource(id), ResourceTypes.RT_DIALOG);
            if (hres == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            IntPtr res = Kernel32.LoadResource(hInstance, hres);
            if (res == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            DLGTEMPLATE_API* lockedPtr = (DLGTEMPLATE_API*)Kernel32.LockResource(res);
            DLGTEMPLATEALL tempalte = GetTemplateAllFromDlgTemplate(lockedPtr);
            _Template = tempalte;
            int anz = tempalte.ItemsCount;
            bool isExtended = tempalte.IsExtended;
            DLGITEMTEMPLATE_API* first = FindFirstDlgItem(lockedPtr);
            DLGITEMTEMPLATE_API* pItem = first;
            // ReSharper disable once RedundantAssignment
            DLGITEMTEMPLATE_API* pNextItem = pItem;

            for (int i = 0; i < anz; i++)
            {
                pNextItem = FindNextDlgItem(pItem, isExtended);
                DLGITEMTEMPLATEALL item = GetDlgItemTemplateAllForDlgItemTemplate(pItem, isExtended);
                _Items.Add(item);
                pItem = pNextItem;
            }
        }

    }
}