using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    public class IFileOpenDialogNativeClass:IFileOpenDialog
    {
        private IFileOpenDialog _FileDialog;
 

        public IFileOpenDialogNativeClass()
        {
            Guid iid = typeof(IFileOpenDialog).GUID;
            Ole32.CoCreateInstance(ref CLSID.FileOpenDialog, IntPtr.Zero,
                (int)(CLSCTX.CLSCTX_INPROC_SERVER | CLSCTX.CLSCTX_LOCAL_SERVER | CLSCTX.CLSCTX_REMOTE_SERVER),
                ref iid, out object o);

            this._FileDialog = (IFileOpenDialog)o;

        }


        public int Show(IntPtr parent)
        {
            return _FileDialog.Show(parent);
        }

        public void SetFileTypes(uint cFileTypes, COMDLG_FILTERSPEC[] rgFilterSpec)
        {
            _FileDialog.SetFileTypes(cFileTypes, rgFilterSpec);
        }

        public void SetFileTypeIndex(uint iFileType)
        {
            _FileDialog.SetFileTypeIndex(iFileType);
        }

        public void GetFileTypeIndex(out uint piFileType)
        {
            _FileDialog.GetFileTypeIndex(out piFileType);
        }

        public void Advise(IFileDialogEvents pfde, out uint pdwCookie)
        {
            _FileDialog.Advise(pfde, out pdwCookie);
        }

        public void Unadvise(uint dwCookie)
        {
            _FileDialog.Unadvise(dwCookie);
        }

        public void SetOptions(FOS fos)
        {
            _FileDialog.SetOptions(fos);
        }

        public void GetOptions(out FOS pfos)
        {
            _FileDialog.GetOptions(out pfos);
        }

        public void SetDefaultFolder(IShellItem psi)
        {
            _FileDialog.SetDefaultFolder(psi);
        }

        public void SetFolder(IShellItem psi)
        {
            _FileDialog.SetFolder(psi);
        }

        public void GetFolder(out IShellItem ppsi)
        {
            _FileDialog.GetFolder(out ppsi);
        }

        public void GetCurrentSelection(out IShellItem ppsi)
        {
            _FileDialog.GetCurrentSelection(out ppsi);
        }

        public void SetFileName(string pszName)
        {
            _FileDialog.SetFileName(pszName);
        }

        public void GetFileName(out string pszName)
        {
            _FileDialog.GetFileName(out pszName);
        }

        public void SetTitle(string pszTitle)
        {
            _FileDialog.SetTitle(pszTitle);
        }

        public void SetOkButtonLabel(string pszText)
        {
            _FileDialog.SetOkButtonLabel(pszText);
        }

        public void SetFileNameLabel(string pszLabel)
        {
            _FileDialog.SetFileNameLabel(pszLabel);
        }

        public void GetResult(out IShellItem ppsi)
        {
            _FileDialog.GetResult(out ppsi);
        }

        public void AddPlace(IShellItem psi, int alignment)
        {
            _FileDialog.AddPlace(psi, alignment);
        }

        public void SetDefaultExtension(string pszDefaultExtension)
        {
            _FileDialog.SetDefaultExtension(pszDefaultExtension);
        }

        public void Close(int hr)
        {
            _FileDialog.Close(hr);
        }

        public void SetClientGuid(ref Guid guid)
        {
            _FileDialog.SetClientGuid(ref guid);
        }

        public void ClearClientData()
        {
            _FileDialog.ClearClientData();
        }

        public void SetFilter(IntPtr pFilter)
        {
            _FileDialog.SetFilter(pFilter);
        }

        public void GetResults(out IShellItemArray ppenum)
        {
            _FileDialog.GetResults(out ppenum);
        }

        public void GetSelectedItems(out IShellItemArray ppsai)
        {
            _FileDialog.GetSelectedItems(out ppsai);
        }



        
    }

    [ComImport]
    [Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
    [CoClass(typeof(FileOpenDialogRCW))]
    public interface NativeFileOpenDialog : IFileOpenDialog
    { }

    [ComImport]
    [Guid("84bccd23-5fde-4cdb-aea4-af64b83d78ab")]
    [CoClass(typeof(FileSaveDialogRCW))]
    public interface NativeFileSaveDialog : IFileSaveDialog
    { }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
#if NETCOREAPP2_1_OR_GREATER
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
#endif
    [Guid("dc1c5a9c-e88a-4dde-a5a1-60f82a20aef7")]
    public class FileOpenDialogRCW
    { }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
#if NETCOREAPP2_1_OR_GREATER
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
#endif
    [Guid("C0B4E2F3-BA21-4773-8DBA-335EC946EB8B")]
    public class FileSaveDialogRCW
    { }

    [
        ComImport,
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
        Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802"),
    ]
    public interface IModalWindow
    {
        [PreserveSig]
        int Show(IntPtr parent);
    }


    [ComImport]
    [Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialog:IModalWindow
    {
        [PreserveSig]
        new int Show([In] IntPtr parent);

        void SetFileTypes([In] uint cFileTypes, [In][MarshalAs(UnmanagedType.LPArray)] COMDLG_FILTERSPEC[] rgFilterSpec);

        void SetFileTypeIndex([In] uint iFileType);

        void GetFileTypeIndex(out uint piFileType);

        void Advise([In, MarshalAs(UnmanagedType.Interface)] IFileDialogEvents pfde, out uint pdwCookie);

        void Unadvise([In] uint dwCookie);

        void SetOptions([In] FOS fos);

        void GetOptions(out FOS pfos);

        void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

        void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

        void SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void AddPlace([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, int alignment);

        void SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

        void Close([MarshalAs(UnmanagedType.Error)] int hr);

        void SetClientGuid([In] ref Guid guid);

        void ClearClientData();

        void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
    }
}