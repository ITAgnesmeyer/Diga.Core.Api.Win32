using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public  class DlgTemplateLoader
    {
        private  DlgTemplateAll _Head;
        private  List<DlgItemTemplateAll> _Items;
        private ResourceLoader _ResourceLoader;

        public DlgTemplateLoader()
        {
            _Head = new DlgTemplateAll();
            _Items = new List<DlgItemTemplateAll>();
            _ResourceLoader = null;
        }

        public DlgTemplateLoader(ResourceLoader resourceLoader)
        {
            _Head = new DlgTemplateAll();
            _Items = new List<DlgItemTemplateAll>();
            _ResourceLoader = resourceLoader;
        }

        private  unsafe bool IsDialogEx(DlgTemplate* pTemplate)
        {
            return ((DlgTemplateEx*)pTemplate)->signature == 0xFFFF;
        }

        private unsafe ushort DlgTemplateItemCount(DlgTemplate* pTemplate)
        {
            if (IsDialogEx(pTemplate))
            {
                return ((DlgTemplateEx*)pTemplate)->cDlgItems;
            }

            return pTemplate->cdit;
        }


        private unsafe DlgItemTemplate* FindFirstDlgItem(DlgTemplate* pTemplate)
        {
            bool isDialogEx = IsDialogEx(pTemplate);
            ushort* pw;
            uint dwStyle;
            if (isDialogEx)
            {
                pw = (ushort*)((DlgTemplateEx*)pTemplate + 1);
                dwStyle = ((DlgTemplateEx*)pTemplate)->style;
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
            return (DlgItemTemplate*)(((long)pw + 3) & ~3);
        }

        private unsafe DlgItemTemplate* FindNextDlgItem(DlgItemTemplate* pItem, bool isDialogEx)
        {
            ushort* pw;
            if (isDialogEx)
            {
                pw = (ushort*)((DlgItemTemplateEx*)pItem + 1);
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
            return (DlgItemTemplate*)(((long)pw + cbExtra + 3) & ~3);
        }

        private unsafe DlgTemplateAll GetTemplateAllFromDlgTemplate(DlgTemplate* pTemplate)
        {
            ushort* pw;
            uint dwStyle;
            DlgTemplateAll all  = new DlgTemplateAll();
            bool isEx = IsDialogEx(pTemplate);
            if (isEx)
            {
                DlgTemplateEx* exp = (DlgTemplateEx*)pTemplate;
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
                pw = (ushort*)((DlgTemplateEx*)pTemplate + 1);
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

        private string ExtractClassNameFromClassId(ushort classId)
        {
            switch (classId)
            {
                case 0x0080:
                    return "Button";
                case 0x0081:
                    return "Edit";
                case 0x0082:
                    return "Static";
                case 0x0083:
                    return "ListBox";
                case 0x0084:
                    return "ScrollBar";
                case 0x0085:
                    return "ComboBox";
                default:
                    return null;
            }

        }
        private unsafe DlgItemTemplateAll GetDlgItemTemplateAllForDlgItemTemplate(DlgItemTemplate* pTemplate,
            bool isEx)
        {
            ushort* pw;
            DlgItemTemplateAll all = new DlgItemTemplateAll();
            if (isEx)
            {
                DlgItemTemplateEx* ext = (DlgItemTemplateEx*)pTemplate;
                all.HelpID = ext->helpID;
                all.ExStyle = ext->exStyle;
                all.Style = ext->style;
                all.x = ext->x;
                all.y = ext->y;
                all.cx = ext->cx;
                all.cy = ext->cy;
                all.Id = ext->id;
                pw = (ushort*)((DlgItemTemplateEx*)pTemplate +1);

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
                all.ClassName = ExtractClassNameFromClassId(all.ClassID);
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

        public DlgTemplateAll Head => _Head;
        public List<DlgItemTemplateAll> Items => _Items;

        public unsafe void LoadTemplates(IntPtr hRes)
        {
            DlgTemplate* lockedPtr = (DlgTemplate*)hRes;
            _Head = GetTemplateAllFromDlgTemplate(lockedPtr);

            int anz = _Head.ItemsCount;
            bool isExtended = _Head.IsExtended;
            DlgItemTemplate* first = FindFirstDlgItem(lockedPtr);
            DlgItemTemplate* pItem = first;
            // ReSharper disable once RedundantAssignment
            DlgItemTemplate* pNextItem = pItem;

            for (int i = 0; i < anz; i++)
            {
                pNextItem = FindNextDlgItem(pItem, isExtended);
                DlgItemTemplateAll item = GetDlgItemTemplateAllForDlgItemTemplate(pItem, isExtended);
                _Items.Add(item);
                pItem = pNextItem;
            }
        }
        public void LoadTemplates(IntPtr hInstance, int id)
        {
            ResourceLoader resLoader = new ResourceLoader(hInstance);
            
            IntPtr lockedPtr = resLoader.LoadResource(Win32Api.MakeInterSource(id), ResourceTypes.RT_DIALOG); //(DLGTEMPLATE_API*)Kernel32.LockResource(res);
            LoadTemplates(lockedPtr);
            
        }

        public void LoadTemplates(int id)
        {
            if (_ResourceLoader == null)
                throw new Exception("No ResourceLoader available");

            IntPtr lockedPtr = _ResourceLoader.LoadResource(Win32Api.MakeInterSource(id), ResourceTypes.RT_DIALOG);
            LoadTemplates(lockedPtr);
        }


    }
}