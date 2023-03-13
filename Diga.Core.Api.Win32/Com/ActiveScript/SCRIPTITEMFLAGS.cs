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
        ///Indicates that the item's name is available in the name space of the script,
        /// allowing access to the properties, methods, and events of the item.
        /// By convention the properties of the item include the item's children;
        /// therefore, all child object properties and methods (and their children, recursively) will be accessible.
        /// </summary>
        SCRIPTITEM_ISVISIBLE = 0x00000002,

        /// <summary>
        ///Indicates that the item sources events that the script can sink.
        /// Child objects (properties of the object that are in themselves objects) can also source events to the script.
        /// This is not recursive, but it provides a convenient mechanism for the common case,
        /// for example, of creating a container and all of its member controls.
        /// </summary>
        SCRIPTITEM_ISSOURCE = 0x00000004,

        /// <summary>
        /// Indicates that the item is a collection of global properties and methods associated with the script.
        /// Normally, a scripting engine would ignore the object name (other than for the purpose of using it as a
        /// cookie for the IActiveScriptSite::GetItemInfo method, or for resolving explicit scoping)
        /// and expose its members as global variables and methods.
        /// This allows the host to extend the library (run-time functions and so on) available to the script.
        /// It is left to the scripting engine to deal with name conflicts
        /// (for example, when two SCRIPTITEM_GLOBALMEMBERS items have methods of the same name),
        /// although an error should not be returned because of this situation. 
        /// </summary>
        SCRIPTITEM_GLOBALMEMBERS = 0x00000008,

        /// <summary>
        ///Indicates that the item should be saved if the scripting engine is saved.
        /// Similarly, setting this flag indicates that a transition back to the initialized state
        /// should retain the item's name and type information
        /// (the scripting engine must, however, release all pointers to interfaces on the actual object). 
        /// </summary>
        SCRIPTITEM_ISPERSISTENT = 0x00000040,

        /// <summary>
        /// Indicates that the named item represents a code-only object, and that the host has no IUnknown
        /// to be associated with this code-only object. The host only has a name for this object.
        /// In object-oriented languages such as C++, this flag would create a class. Not all languages support this flag. 
        /// </summary>
        SCRIPTITEM_CODEONLY = 0x00000200,

        /// <summary>
        /// Indicates that the item is simply a name being added to the script's name space,
        /// and should not be treated as an item for which code should be associated.
        /// For example, without this flag being set, VBScript will create a separate module for the named item,
        /// and C++ might create a separate wrapper class for the named item.
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