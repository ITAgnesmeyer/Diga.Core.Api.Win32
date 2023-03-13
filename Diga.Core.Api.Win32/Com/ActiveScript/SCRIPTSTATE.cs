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
        /// Script has just been created, but has not yet been initialized
        /// using an IPersist* interface and IActiveScript::SetScriptSite .
        /// </summary>
        SCRIPTSTATE_UNINITIALIZED = 0,

        /// <summary>
        /// Script has been initialized, but is not running (connecting to other objects or sinking events)
        /// or executing any code.
        /// Code can be queried for execution by calling the IActiveScriptParse::ParseScriptText method.
        /// </summary>
        SCRIPTSTATE_INITIALIZED = 5,

        /// <summary>
        /// Script can execute code, but is not yet sinking the events of objects added by the IActiveScript::AddNamedItem method.
        /// </summary>
        SCRIPTSTATE_STARTED = 1,

        /// <summary>
        /// Script is loaded and connected for sinking events.
        /// </summary>
        SCRIPTSTATE_CONNECTED = 2,

        /// <summary>
        /// Script is loaded and has a run-time execution state,
        /// but is temporarily disconnected from sinking events. 
        /// </summary>
        SCRIPTSTATE_DISCONNECTED = 3,

        /// <summary>
        ///Script has been closed. The scripting engine no longer works and returns errors for most methods.
        /// </summary>
        SCRIPTSTATE_CLOSED = 4,

        // ------------------------------------------------------------------
        #endregion
    }
}