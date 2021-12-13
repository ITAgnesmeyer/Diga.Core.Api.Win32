using System;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    /// <summary>
    /// The IActiveScriptSite.GetItemInfo() input flags.
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/f859ed3b-02c1-4924-99f8-5f5bf1bf8405.asp"/>
    [Flags]
    public enum SCRIPTINFOFLAGS : uint
    {
        #region Enum members.
        // ------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        SCRIPTINFO_IUNKNOWN = 0x00000001,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTINFO_ITYPEINFO = 0x00000002,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTINFO_ALL_FLAGS =
            SCRIPTINFO_IUNKNOWN |
            SCRIPTINFO_ITYPEINFO

        // ------------------------------------------------------------------
        #endregion
    }
}