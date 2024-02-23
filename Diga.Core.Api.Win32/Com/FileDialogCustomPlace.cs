using System;
using System.Text;

namespace Diga.Core.Api.Win32.Com
{
    public class FileDialogCustomPlace
    {
        private string _path = "";
        private Guid   _knownFolderGuid = Guid.Empty;
 
        public FileDialogCustomPlace(string path)
        {
            this.Path = path;
        }
 
        public FileDialogCustomPlace(Guid knownFolderGuid)
        {
            this.KnownFolderGuid = knownFolderGuid; 
        }
 
        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(this._path))
                {
                    return String.Empty;
                }
                return this._path;
            }
            set
            {
                this._path = value ?? "";
                this._knownFolderGuid = Guid.Empty;
            }
        }
 
        public Guid KnownFolderGuid
        {
            get
            {
                return this._knownFolderGuid;
            }
            set
            {
                this._path = String.Empty;
                this._knownFolderGuid = value;
            }
        }
 
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} Path: {1} KnownFolderGuid: {2}", base.ToString(), this.Path, this.KnownFolderGuid);
        }
 
        internal IShellItem GetNativePath()
        {
            //This can throw in a multitude of ways if the path or Guid doesn't correspond
            //to an actual filesystem directory.  Caller is responsible for handling these situations.
            string filePathString = "";
            if (!string.IsNullOrEmpty(this._path))
            {
                filePathString = this._path;
            }
            else
            {
                filePathString = GetFolderLocation(this._knownFolderGuid);
            }
 
            if (string.IsNullOrEmpty(filePathString))
            {
                return null;
            }
            else
            {
                return GetShellItemForPath(filePathString);
            }
        }
        internal static IShellItem GetShellItemForPath(string path)
        {
            IShellItem ret = null;
            IntPtr pidl = IntPtr.Zero;
            uint zero = 0;
            if (0 <= Shell32.SHILCreateFromPath(path, out pidl, ref zero))
            {
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
                if (0 <= Shell32.SHCreateShellItem(
                    IntPtr.Zero, //No parent specified
                    IntPtr.Zero,
                    pidl,
                    out ret))
                {
                    return ret;
                }
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
            }
            throw new System.IO.FileNotFoundException();
        }

        private static string GetFolderLocation(Guid folderGuid)
        {
            //returns a null string if the path can't be found
 
            //SECURITY: This exposes the filesystem path of the GUID.  The returned value
            // must not be made available to user code.
 
            if (!EnvironmentExtension.IsVista)
            { 
                return null;
            }
 
            StringBuilder path = new StringBuilder();
 
            int result = Shell32.SHGetFolderPathEx(ref folderGuid, 0, IntPtr.Zero, path);
            if (HRESULT.S_OK == result) 
            {
                string ret = path.ToString();
                return ret;
            }
            else
            {
                // 0x80070002 is an explicit FileNotFound error.
                return null;
            }
        }
    }
}