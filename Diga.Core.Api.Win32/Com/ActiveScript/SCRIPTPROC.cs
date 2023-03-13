namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public enum SCRIPTPROC : uint
    {
        /// <summary>
        ///  	Indicates that the code in pstrCode is an expression that represents the return value of the procedure. By default, the code can contain an expression, a list of statements, or anything else allowed in a procedure by the script language.
        /// </summary>
        SCRIPTPROC_ISEXPRESSION = 0x00000020,
        /// <summary>
        /// 
        /// </summary>
        SCRIPTPROC_HOSTMANAGESSOURCE = 0x00000080,
        /// <summary>
        /// Indicates that the this pointer is included in the scope of the procedure.
        /// </summary>
        SCRIPTPROC_IMPLICIT_THIS =0x00000100,
        /// <summary>
        /// Indicates that the parents of the this pointer are included in the scope of the procedure.
        /// </summary>
        SCRIPTPROC_IMPLICIT_PARENTS = 0x00000200,
        /// <summary>
        /// 
        /// </summary>
        SCRIPTPROC_ISXDOMAIN = 0x00000400,
        SCRIPTPROC_ALL_FLAGS = (SCRIPTPROC_HOSTMANAGESSOURCE | 
                                SCRIPTPROC_ISEXPRESSION | 
                                SCRIPTPROC_IMPLICIT_THIS | 
                                SCRIPTPROC_IMPLICIT_PARENTS | 
                                SCRIPTPROC_ISXDOMAIN)
    }
}