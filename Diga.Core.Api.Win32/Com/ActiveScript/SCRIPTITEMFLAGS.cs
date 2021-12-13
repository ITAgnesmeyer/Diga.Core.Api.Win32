using System;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    /// <summary>
    /// The script item flags when adding.
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/a7c6317d-948f-4bb3-b169-1bbe5b7c7cc5.asp"/>
    [Flags]
    public enum SCRIPTITEMFLAGS : uint
    {
        #region Enum members.
        // ------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_ISVISIBLE = 0x00000002,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_ISSOURCE = 0x00000004,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_GLOBALMEMBERS = 0x00000008,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_ISPERSISTENT = 0x00000040,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_CODEONLY = 0x00000200,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_NOCODE = 0x00000400,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTITEM_ALL_FLAGS =
            SCRIPTITEM_ISSOURCE |
            SCRIPTITEM_ISVISIBLE |
            SCRIPTITEM_ISPERSISTENT |
            SCRIPTITEM_GLOBALMEMBERS |
            SCRIPTITEM_NOCODE |
            SCRIPTITEM_CODEONLY

        // ------------------------------------------------------------------
        #endregion
    }
}