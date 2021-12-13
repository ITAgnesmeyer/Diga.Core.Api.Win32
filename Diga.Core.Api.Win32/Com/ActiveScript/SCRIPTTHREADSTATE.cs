namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    /// <summary>
    /// The script thread state.
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/975ec66b-c095-40ac-8ba9-631adb97b589.asp"/>
    public enum SCRIPTTHREADSTATE : uint
    {
        #region Enum members.
        // ------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        SCRIPTTHREADSTATE_NOTINSCRIPT = 0,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTTHREADSTATE_RUNNING = 1,

        // ------------------------------------------------------------------
        #endregion
    }
}