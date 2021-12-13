namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    /// <summary>
    /// The script state.
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/5f5deb05-c4bb-4964-8077-e624c6b2a14e.asp"/>
    public enum SCRIPTSTATE : uint
    {
        #region Enum members.
        // ------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        SCRIPTSTATE_UNINITIALIZED = 0,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTSTATE_INITIALIZED = 5,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTSTATE_STARTED = 1,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTSTATE_CONNECTED = 2,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTSTATE_DISCONNECTED = 3,

        /// <summary>
        /// 
        /// </summary>
        SCRIPTSTATE_CLOSED = 4,

        // ------------------------------------------------------------------
        #endregion
    }
}