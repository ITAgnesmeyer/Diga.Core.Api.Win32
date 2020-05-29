using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class ComDlg32
    {
        private const string COMDLG32 = "comdlg32.dll";

        /// Return Type: BOOL->int
        ///param0: LPOPENFILENAMEW->tagOFNW*
        [DllImport(COMDLG32, EntryPoint="GetOpenFileNameW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool GetOpenFileName(ref Ofnw param0) ;


        /// Return Type: BOOL->int
        ///param0: LPOPENFILENAMEW->tagOFNW*
        [DllImport(COMDLG32, EntryPoint="GetSaveFileNameW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool GetSaveFileName(ref Ofnw param0) ;



    }
}