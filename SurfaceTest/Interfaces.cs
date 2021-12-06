using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Diga.Core.Api.Win32.Com;
using SurfaceTest;

namespace SurfaceTest
{



    /////////////////////////////////////////////////////////////////////////

    /* 
	 * A good series of articles for working with Scripting Host under .NET
	 * can be found at the DDJ:
	 * http://google.com/search?q=site%3Addj.com+%22.NET+Scripting+Hosts%22
	 * 
	 * Also, the Weblog of Eric Lippert contains good references:
	 * http://blogs.msdn.com/ericlippert
	 * 
	 * Last, the Google group microsoft.public.scripting.hosting contains 
	 * good resources:
	 * http://groups.google.com/group/microsoft.public.scripting.hosting
	 * 
	 * The definitions can also be found at:
	 * http://msdn.microsoft.com/library/en-us/script56/html/f2afee5f-b930-4b32-b903-84ba41eb2d88.asp
	 */

    ///////////////////////////////////////////////////////////////////////////
    ////b54f3741-5b07-11cf-a4b0-00aa004a55e8;
    ///// <summary>
    ///// Interface IActiveScript.
    ///// </summary>
    ///// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/d8acee11-7f0d-4999-b97a-66774af16f71.asp"/>
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    //Guid(@"BB1A2AE1-A4F9-11cf-8F20-00805F2CD064")]
    //public interface IActiveScript
    //{
    //    #region Interface members.
    //    // ------------------------------------------------------------------

    //    /// <summary>
    //    /// Sets the script site.
    //    /// </summary>
    //    /// <param name="site">The site.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/47d94c32-09f8-4539-ac56-0236026f627b.asp"/>
    //    void SetScriptSite(
    //        [In, MarshalAs( UnmanagedType.Interface )]
    //        IActiveScriptSite site);

    //    /// <summary>
    //    /// Gets the script site.
    //    /// </summary>
    //    /// <param name="riid">The riid.</param>
    //    /// <param name="ppvObject">The PPV object.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/83a2a89d-93d0-4cbd-9244-91a730cb406b.asp"/>
    //    void GetScriptSite(
    //        ref Guid riid,
    //        out IntPtr ppvObject);

    //    /// <summary>
    //    /// Sets the state of the script.
    //    /// </summary>
    //    /// <param name="ss">The ss.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/f2b2700c-0c8d-40db-ad84-dc751c5d9bc2.asp"/>
    //    void SetScriptState(
    //        SCRIPTSTATE ss);

    //    /// <summary>
    //    /// Gets the state of the script.
    //    /// </summary>
    //    /// <param name="ss">The ss.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/59837f7c-755d-45c4-8194-bd57638fe2e1.asp"/>
    //    void GetScriptState(
    //        out SCRIPTSTATE ss);

    //    /// <summary>
    //    /// Closes this instance.
    //    /// </summary>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/cc7dd63b-1d7e-410a-857b-09ea3aade275.asp"/>
    //    void Close();

    //    /// <summary>
    //    /// Adds the named item.
    //    /// </summary>
    //    /// <param name="name">The name.</param>
    //    /// <param name="flags">The flags.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/a7c6317d-948f-4bb3-b169-1bbe5b7c7cc5.asp"/>
    //    void AddNamedItem(
    //        [In, MarshalAs( UnmanagedType.BStr )]
    //        string name,
    //        [In, MarshalAs( UnmanagedType.U4 )]
    //        uint flags);

    //    /// <summary>
    //    /// Adds the type lib.
    //    /// </summary>
    //    /// <param name="rguidTypeLib">The rguid type lib.</param>
    //    /// <param name="major">The major.</param>
    //    /// <param name="minor">The minor.</param>
    //    /// <param name="flags">The flags.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/8e507ea8-c80a-471c-b482-ae753c6e8595.asp"/>
    //    void AddTypeLib(
    //        ref Guid rguidTypeLib,
    //        uint major,
    //        uint minor,
    //        uint flags);

    //    /// <summary>
    //    /// Gets the script dispatch.
    //    /// </summary>
    //    /// <param name="itemName">Name of the item.</param>
    //    /// <param name="ppdisp">The ppdisp.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/2092ccd4-1f4c-493a-b5b7-077a70ce95ca.asp"/>
    //    void GetScriptDispatch(
    //        string itemName,
    //        out object ppdisp);

    //    /// <summary>
    //    /// Gets the current script threadi D.
    //    /// </summary>
    //    /// <param name="id">The ID.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/b09e8b48-4209-480e-8b71-e99ee9ae2e17.asp"/>
    //    void GetCurrentScriptThreadiD(
    //        out uint id);

    //    /// <summary>
    //    /// Gets the script thread ID.
    //    /// </summary>
    //    /// <param name="threadID">The thread ID.</param>
    //    /// <param name="id">The ID.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/2595d76e-30b5-429f-88b4-1d026645dd9b.asp"/>
    //    void GetScriptThreadID(
    //        uint threadID,
    //        out uint id);

    //    /// <summary>
    //    /// Gets the state of the script thread.
    //    /// </summary>
    //    /// <param name="id">The ID.</param>
    //    /// <param name="state">The state.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/7cac94d0-436e-4c29-895b-0c4afa0b3ccc.asp"/>
    //    void GetScriptThreadState(
    //        uint id,
    //        out SCRIPTTHREADSTATE state);

    //    /// <summary>
    //    /// Interrupts the script thread.
    //    /// </summary>
    //    /// <param name="id">The ID.</param>
    //    /// <param name="info">The info.</param>
    //    /// <param name="flags">The flags.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/2304d035-6d39-4811-acd3-8a9640fdbef6.asp"/>
    //    void InterruptScriptThread(
    //        uint id,
    //        ref ComTypes.EXCEPINFO info,
    //        uint flags);

    //    /// <summary>
    //    /// Clones the specified item.
    //    /// </summary>
    //    /// <param name="item">The item.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/aa000b2a-7085-448d-a422-f7adac7851cb.asp"/>
    //    void Clone(
    //        out IActiveScript item);

    //    // ------------------------------------------------------------------
    //    #endregion
    //}

    [Guid("BB1A2AE1-A4F9-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScript
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int SetScriptSite([MarshalAs(UnmanagedType.Interface), In] IActiveScriptSite pass);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptSite([In] ref Guid riid, out IntPtr ppvObject);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int SetScriptState([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTSTATE"), In] SCRIPTSTATE ss);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptState([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTSTATE"), MarshalAs(UnmanagedType.LPArray), Out] SCRIPTSTATE[] pssState);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int Close();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddNamedItem([MarshalAs(UnmanagedType.LPWStr), In] string pstrName, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddTypeLib([In] ref Guid rguidTypeLib, [In] uint dwMajor, [In] uint dwMinor, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptDispatch([MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName, [MarshalAs(UnmanagedType.IDispatch)] out object ppdisp);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetCurrentScriptThreadID([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID")] out uint pstidThread);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptThreadID([In] uint dwWin32ThreadId, [ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID")] out uint pstidThread);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptThreadState([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID"), In] uint stidThread, [ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADSTATE"), MarshalAs(UnmanagedType.LPArray), Out] SCRIPTTHREADSTATE[] pstsState);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int InterruptScriptThread([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID"), In] uint stidThread, [MarshalAs(UnmanagedType.LPArray), In] EXCEPINFO[] pexcepinfo, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int Clone([MarshalAs(UnmanagedType.Interface)] out IActiveScript ppscript);
    }

    /////////////////////////////////////////////////////////////////////////

    ///// <summary>
    ///// Interface IActiveScriptParse.
    ///// </summary>
    ///// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/8c967d70-f582-4f64-9e79-49f40c4dcb7c.asp"/>
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    //Guid(@"BB1A2AE2-A4F9-11cf-8F20-00805F2CD064")]
    //public interface IActiveScriptParse
    //{
    //    #region Interface members.
    //    // ------------------------------------------------------------------

    //    /// <summary>
    //    /// Inits the new.
    //    /// </summary>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/3a582bd6-fc0d-43a5-812f-5ea55a8517a1.asp"/>
    //    void InitNew();

    //    /// <summary>
    //    /// Adds the scriptlet.
    //    /// </summary>
    //    /// <param name="defaultName">Name of the default.</param>
    //    /// <param name="code">The code.</param>
    //    /// <param name="itemName">Name of the item.</param>
    //    /// <param name="subItemName">Name of the sub item.</param>
    //    /// <param name="eventName">Name of the event.</param>
    //    /// <param name="delimiter">The delimiter.</param>
    //    /// <param name="sourceContextCookie">The source context cookie.</param>
    //    /// <param name="startingLineNumber">The starting line number.</param>
    //    /// <param name="flags">The flags.</param>
    //    /// <param name="name">The name.</param>
    //    /// <param name="info">The info.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/824929f4-4dd3-473a-92d9-0b96acea2f14.asp"/>
    //    void AddScriptlet(
    //        string defaultName,
    //        string code,
    //        string itemName,
    //        string subItemName,
    //        string eventName,
    //        string delimiter,
    //        uint sourceContextCookie,
    //        uint startingLineNumber,
    //        uint flags,
    //        out string name,
    //        out ComTypes.EXCEPINFO info);

    //    /// <summary>
    //    /// Parses the script text.
    //    /// </summary>
    //    /// <param name="code">LPCOLESTR pstrCode, address of scriptlet text.</param>
    //    /// <param name="itemName">LPCOLESTR pstrItemName, address of item name.</param>
    //    /// <param name="context">IUnknown *punkContext, address of debugging context.</param>
    //    /// <param name="delimiter">LPCOLESTR pstrDelimiter, address of end-of-scriptlet delimiter.</param>
    //    /// <param name="sourceContextCookie">DWORD_PTR dwSourceContextCookie, application-defined value for debugging.</param>
    //    /// <param name="startingLineNumber">ULONG ulStartingLineNumber, starting line number of the script.</param>
    //    /// <param name="flags">int dwFlags, scriptlet flags.</param>
    //    /// <param name="result">VARIANT *pvarResult, address of buffer for results.</param>
    //    /// <param name="info">EXCEPINFO *pexcepinfo, address of buffer for error data.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/2d237d6c-cc65-415b-8808-72791304a136.asp"/>
    //    void ParseScriptText(
    //        string code,
    //        string itemName,
    //        object context,
    //        string delimiter,
    //        uint sourceContextCookie,
    //        uint startingLineNumber,
    //        uint flags,
    //        out object result,
    //        out ComTypes.EXCEPINFO info);

    //    // ------------------------------------------------------------------
    //    #endregion
    //}

    [InterfaceType(1)]
    [Guid("C7EF7658-E1EE-480E-97EA-D52CB4D76D17")]
    [ComImport]
    public interface IActiveScriptParse64
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int InitNew();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddScriptlet(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDefaultName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrSubItemName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrEventName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] ulong dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.BStr)] out string pbstrName,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int ParseScriptText(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.IUnknown), In] object punkContext,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] ulong dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.Struct)] out object pvarResult,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);
    }


    [Guid("BB1A2AE2-A4F9-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptParse32
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int InitNew();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddScriptlet(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDefaultName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrSubItemName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrEventName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] uint dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.BStr)] out string pbstrName,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int ParseScriptText(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.IUnknown), In] object punkContext,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] uint dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.Struct)] out object pvarResult,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);
    }
    /////////////////////////////////////////////////////////////////////////

    ///// <summary>
    ///// Interface IActiveScriptSite.
    ///// </summary>
    ///// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/4d604a11-5365-46cf-ab71-39b3dbbe9f22.asp"/>
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    //Guid(@"DB01A1E3-A42B-11cf-8F20-00805F2CD064")]
    //public interface IActiveScriptSite
    //{
    //    #region Interface members.
    //    // ------------------------------------------------------------------

    //    /// <summary>
    //    /// Gets the LCID.
    //    /// </summary>
    //    /// <param name="id">The ID.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/7b4a2dc1-bcf6-4bbf-884e-97b305a28eb7.asp"/>
    //    void GetLCID(
    //        out uint id);

    //    /// <summary>
    //    /// Gets the item info.
    //    /// </summary>
    //    /// <param name="name">The name.</param>
    //    /// <param name="returnMask">The return mask.</param>
    //    /// <param name="item">The item.</param>
    //    /// <param name="ppti">The ppti.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/f859ed3b-02c1-4924-99f8-5f5bf1bf8405.asp"/>
    //    void GetItemInfo(
    //        [In, MarshalAs(UnmanagedType.BStr)] string name,
    //        [In, MarshalAs(UnmanagedType.U4)] uint returnMask,
    //        [Out, MarshalAs(UnmanagedType.IUnknown)] out object item,
    //        Type ppti);

    //    /// <summary>
    //    /// Gets the doc version string.
    //    /// </summary>
    //    /// <param name="v">The v.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/ab3f892d-06d3-4cb5-9ea5-20c4a1e518cd.asp"/>
    //    void GetDocVersionString(
    //        out string v);

    //    /// <summary>
    //    /// Called when [script terminate].
    //    /// </summary>
    //    /// <param name="result">The result.</param>
    //    /// <param name="info">The info.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/3301ddf4-5929-404c-81d3-1a720e589008.asp"/>
    //    void OnScriptTerminate(
    //        ref object result,
    //        ref ComTypes.EXCEPINFO info);

    //    /// <summary>
    //    /// Called when [state change].
    //    /// </summary>
    //    /// <param name="state">The state.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/3e9c5cbe-ca8e-426a-84fd-04e9c2daac7e.asp"/>
    //    void OnStateChange(
    //        SCRIPTSTATE state);

    //    /// <summary>
    //    /// Called when [script error].
    //    /// </summary>
    //    /// <param name="err">This should be casted to IActiveScriptError in the implementation
    //    /// of this interface. I had errors when changing the parameter here to the
    //    /// IActiveScriptError type.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/5c9c85cc-21ad-4232-be83-a24cc7570108.asp"/>
    //    void OnScriptError(
    //        [In, MarshalAs(UnmanagedType.IUnknown)] object err);

    //    /// <summary>
    //    /// Called when [enter script].
    //    /// </summary>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/1ed9178c-fe80-41c4-b74d-23b85f9cddbf.asp"/>
    //    void OnEnterScript();

    //    /// <summary>
    //    /// Called when [leave script].
    //    /// </summary>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/79af0e22-fbe3-4fae-8a5f-7af8b857678d.asp"/>
    //    void OnLeaveScript();

    //    // ------------------------------------------------------------------
    //    #endregion
    //}
    [Guid("DB01A1E3-A42B-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptSite
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetLCID(out uint plcid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetItemInfo([MarshalAs(UnmanagedType.LPWStr), In] string pstrName, [In] uint dwReturnMask, [MarshalAs(UnmanagedType.IUnknown)] out object ppiunkItem, [MarshalAs(UnmanagedType.Interface)] ITypeInfo ppti);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetDocVersionString([MarshalAs(UnmanagedType.BStr)] out string pbstrVersion);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnScriptTerminate([MarshalAs(UnmanagedType.Struct), In] ref object pvarResult, [MarshalAs(UnmanagedType.LPArray), In] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnStateChange([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTSTATE"), In] SCRIPTSTATE ssScriptState);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnScriptError([MarshalAs(UnmanagedType.Interface), In] IActiveScriptError pscripterror);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnEnterScript();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnLeaveScript();
    }
    /////////////////////////////////////////////////////////////////////////

    ///// <summary>
    ///// Interface IActiveScriptError.
    ///// </summary>
    ///// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/4d604a11-5365-46cf-ab71-39b3dbbe9f22.asp"/>
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    //Guid(@"EAE1BA61-A4ED-11cf-8F20-00805F2CD064")]
    //public interface IActiveScriptError
    //{
    //    #region Interface members.
    //    // ------------------------------------------------------------------

    //    /// <summary>
    //    /// Gets the exception info.
    //    /// </summary>
    //    /// <param name="info">The info.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/528416cc-8468-4ad7-a6c2-fa1daf6ecf33.asp"/>
    //    void GetExceptionInfo(
    //        [Out, MarshalAs(UnmanagedType.Struct)] out ComTypes.EXCEPINFO info);


    //    /// <summary>
    //    /// Gets the source position.
    //    /// </summary>
    //    /// <param name="sourceContext">The source context.</param>
    //    /// <param name="lineNumber">The line number.</param>
    //    /// <param name="characterPosition">"-1" for unknown.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/64f7f37f-7288-4dbe-b626-a35d90897f36.asp"/>
    //    void GetSourcePosition(
    //        [Out, MarshalAs(UnmanagedType.U4)] out uint sourceContext,
    //        [Out, MarshalAs(UnmanagedType.U4)] out uint lineNumber,
    //        [Out, MarshalAs(UnmanagedType.U4)] out int characterPosition);

    //    /// <summary>
    //    /// Gets the source line text.
    //    /// </summary>
    //    /// <param name="sourceLine">The source line.</param>
    //    /// <see cref="http://msdn.microsoft.com/library/en-us/script56/html/ae9b26b1-82a7-4645-9686-3261d8248664.asp"/>
    //    /// <remarks>Throws E_FAIL if the line in the source file was not retrieved.</remarks>
    //    void GetSourceLineText(
    //        out string sourceLine);

    //    // ------------------------------------------------------------------
    //    #endregion
    //}


    [Guid("EAE1BA61-A4ED-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptError
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetExceptionInfo([MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetSourcePosition(
            out uint pdwSourceContext,
            out uint pulLineNumber,
            out int plCharacterPosition);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetSourceLineText([MarshalAs(UnmanagedType.BStr)] out string pbstrSourceLine);
    }

    /////////////////////////////////////////////////////////////////////////

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

    /////////////////////////////////////////////////////////////////////////
    [Flags]
    public enum SCRIPTTEXT : uint
    {
        SCRIPTTEXT_DELAYEXECUTION = 0x00000001,
        SCRIPTTEXT_ISVISIBLE = 0x00000002,
        SCRIPTTEXT_ISEXPRESSION = 0x00000020,
        SCRIPTTEXT_ISPERSISTENT = 0x00000040,
        SCRIPTTEXT_HOSTMANAGESSOURCE = 0x00000080,
        SCRIPTTEXT_ISXDOMAIN = 0x00000100,
        SCRIPTTEXT_ISNONUSERCODE = 0x00000200,
        SCRIPTTEXT_ALL_FLAGS = (SCRIPTTEXT_DELAYEXECUTION | SCRIPTTEXT_ISVISIBLE | SCRIPTTEXT_ISEXPRESSION | SCRIPTTEXT_ISPERSISTENT | SCRIPTTEXT_HOSTMANAGESSOURCE | SCRIPTTEXT_ISXDOMAIN | SCRIPTTEXT_ISNONUSERCODE)
    }

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

    /////////////////////////////////////////////////////////////////////////

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

    /////////////////////////////////////////////////////////////////////////

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

    [ComConversionLoss]
    [InterfaceType(1)]
    [Guid("D10F6761-83E9-11CF-8F20-00805F2CD064")]
    [ComImport]
    public interface IActiveScriptSiteWindow
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetWindow([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.wireHWND")] out IntPtr phwnd);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int EnableModeless([In] int fEnable);
    }

    [ComConversionLoss]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AC206021-8D2D-31D8-8CD1-A5B92AD4A2B6")]
    public interface INameing
    {
        public string Name { get; set; }
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ScriptObj
    {
        public void Log(ref object value)
        {


            Dictionary<int, string> nemese = DispatchUtility.GetType(value, false);
            foreach (var item in nemese)
            {
                if (item.Value == "GetName")
                {
                    object o = DispatchUtility.Invoke(value, item.Value, new object[] { });


                }

                if (item.Value == "SetName")
                {
                    DispatchUtility.InvokeSet(value, item.Value, new object[] { "hallo" });
                }

            }
        }
    }
    public class DefaultScriptSite : IActiveScriptSite, IActiveScriptSiteWindow
    {
        public object RefObj { get; set; }

        private IntPtr _Handle = IntPtr.Zero;

        public DefaultScriptSite(IntPtr handle)
        {
            this._Handle = handle;
        }

        public int GetItemInfo(string pstrName, uint dwReturnMask, out object ppiunkItem, ITypeInfo ppti)
        {

            ppiunkItem = default(object);
            ppti = null;
            if (pstrName == "MyObject")
            {
                ppiunkItem = this.RefObj;
                //IDispatch dp = (IDispatch)this.RefObj;
                //dp.GetTypeInfo(0, 0, out ppti);

                return HRESULT.S_OK;
            }

            return HRESULT.S_FALSE;
        }

        public int GetDocVersionString(out string v)
        {
            v = default(string);
            return HRESULT.S_FALSE;
        }

        public int OnScriptTerminate(ref object pvarResult, EXCEPINFO[] pexcepinfo)
        {
            if (pvarResult != null)
                Debug.Print(pvarResult.ToString());
            if (pexcepinfo != null)
            {
                foreach (var info in pexcepinfo)
                {
                    Debug.Print(info.bstrDescription);
                }
            }


            return HRESULT.S_OK;


        }



        public int GetLCID(out uint id)
        {


            id = default(uint);
            return HRESULT.S_FALSE;
        }

        public int OnScriptError(IActiveScriptError pscripterror)
        {
            IActiveScriptError e = pscripterror;
            if (e != null)
            {
                EXCEPINFO[] errors = new EXCEPINFO[10];

                e.GetExceptionInfo(errors);

                foreach (var info in errors)
                {
                    if (info.bstrDescription != null)
                    {
                        Debug.Print(info.bstrDescription);
                        Debug.Print(info.scode.ToString());
                        e.GetSourcePosition(out uint sourceContext, out uint lineNumber, out int charPos);
                        Debug.Print($"SourceContext={sourceContext}, line={lineNumber}, col={charPos}");
                        Debug.Print(info.bstrSource);
                        try
                        {
                            e.GetSourceLineText(out string errorLineText);
                            Debug.Print(errorLineText);

                        }
                        catch (Exception)
                        {
                        }


                    }
                }


                return HRESULT.S_OK;
            }

            return HRESULT.S_FALSE;
        }

        public int OnEnterScript()
        {
            //OnEnterScript
            Debug.Print("OnEnterScript");
            return HRESULT.S_OK;
        }

        public int OnLeaveScript()
        {
            //OnLeaveScript
            Debug.Print("OnLeaveScript");
            return HRESULT.S_OK;
        }




        public int OnStateChange(SCRIPTSTATE state)
        {
            Debug.Print("STate Change:" + state);
            return HRESULT.S_OK;
        }

        public int GetWindow(out IntPtr phwnd)
        {

            phwnd = this._Handle;
            if (phwnd == IntPtr.Zero)
            {
                return HRESULT.S_FALSE;
            }
            return HRESULT.S_OK;
        }

        public int EnableModeless([In] int fEnable)
        {
            return HRESULT.S_FALSE;
        }
    }




    
}


public static class DispatchUtility
{
    private const int S_OK = 0; //From WinError.h
    private const int LOCALE_SYSTEM_DEFAULT = 2 << 10; //From WinNT.h == 2048 == 0x800

    public static bool ImplementsIDispatch(object obj)
    {
        bool result = obj is IDispatchInfo;
        return result;
    }

    public static Dictionary<int, string> GetType(object obj, bool throwIfNotFound)
    {
        RequireReference(obj, "obj");


        Dictionary<int, string> result = GetType((IDispatchInfo)obj, throwIfNotFound);
        return result;
    }

    public static bool TryGetDispId(object obj, string name, out int dispId)
    {
        RequireReference(obj, "obj");
        bool result = TryGetDispId((IDispatchInfo)obj, name, out dispId);
        return result;
    }

    public static object Invoke(object obj, int dispId, object[] args)
    {
        string memberName = "[DispId=" + dispId + "]";
        object result = Invoke(obj, memberName, args);
        return result;
    }

    private static int DISPATCH_METHOD = 0x1;
    private static int DISPATCH_PROPERTYGET = 0x2;
    private static int DISPATCH_PROPERTYPUT = 0x4;
    private static int DISPATCH_PROPERTYPUTREF = 0x8;


    public static object Invoke(object obj, string memberName, object[] args)
    {
        RequireReference(obj, "obj");
        Type type = obj.GetType();




        object result = type.InvokeMember(memberName,
            BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.GetField, null, obj, args, null);
        return result;
    }

    public static void InvokeSet(object obj, string memberName, object[] args)
    {
        RequireReference(obj, "obj");


        if (TryGetDispId(obj, memberName, out int dispID))
        {
            IDispatch disp = (IDispatch)obj;
            DISPPARAMS pars = new DISPPARAMS();
            pars.cArgs = args.Length;
            
           

            pars.rgdispidNamedArgs = IntPtr.Zero;
            pars.cNamedArgs = 0;
            IntPtr arrPtr = VARIANT.ObjectArrayToVariantArrayPtr(args);

            pars.rgvarg = arrPtr;
            Guid g = Guid.Empty;

            int[] ids = new int[3];
            HRESULT v = disp.GetIDsOfNames(g, new string[] { memberName }, 1, LOCALE_SYSTEM_DEFAULT, ids);
            if (!v.Failed)
            {
                EXCEPINFO exInfo = new EXCEPINFO();
   
                IntPtr[] argErr = new IntPtr[1];

                HRESULT i = disp.Invoke(dispID, g,(uint) Thread.CurrentThread.CurrentCulture.LCID,(ushort)DISPATCH_METHOD, pars, out object pRetVal, exInfo, argErr);

                if (!i.Failed)
                {

                }
            }

            VARIANT.FreeVariantArrayPtr(arrPtr, args.Length );
             

        }

    }

    private static void RequireReference<T>(T value, string name) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(name);
        }
    }

    private static Dictionary<int, string> GetType(IDispatchInfo dispatch, bool throwIfNotFound)
    {
        RequireReference(dispatch, "dispatch");

        Dictionary<int, string> result = new Dictionary<int, string>();
        int typeInfoCount;
        int hr = dispatch.GetTypeInfoCount(out typeInfoCount);
        if (hr == S_OK && typeInfoCount > 0)
        {
            dispatch.GetTypeInfo(0, LOCALE_SYSTEM_DEFAULT, out IntPtr p);
            ITypeInfo tInfo = (ITypeInfo)Marshal.GetObjectForIUnknown(p);
            tInfo.GetTypeAttr(out IntPtr attr);
            TYPEATTR typeAttr = Marshal.PtrToStructure<TYPEATTR>(attr);
            for (int i = 0; i < typeAttr.cFuncs; i++)
            {
                tInfo.GetFuncDesc(i, out IntPtr pfuncDesc);
                if (pfuncDesc != IntPtr.Zero)
                {
                    FUNCDESC funcDesc = Marshal.PtrToStructure<FUNCDESC>(pfuncDesc);

                    tInfo.GetDocumentation(funcDesc.memid, out string name, out string docString, out int helContext, out string helpFile);
                    if (!string.IsNullOrEmpty(name))
                    {
                        result.Add(funcDesc.memid, name);
                    }
                    tInfo.ReleaseFuncDesc(pfuncDesc);
                }
            }

            tInfo.ReleaseTypeAttr(attr);

        }

        if (result == null && throwIfNotFound)
        {
            // If the GetTypeInfoCount called failed, throw an exception for that.
            Marshal.ThrowExceptionForHR(hr);

            // Otherwise, throw the same exception that Type.GetType would throw.
            throw new TypeLoadException();
        }

        return result;
    }

    private static bool TryGetDispId(IDispatchInfo dispatch, string name, out int dispId)
    {
        RequireReference(dispatch, "dispatch");
        RequireReference(name, "name");

        bool result = false;
        Guid iidNull = Guid.Empty;
        int hr = dispatch.GetDispId(ref iidNull, ref name, 1, LOCALE_SYSTEM_DEFAULT, out dispId);

        const int DISP_E_UNKNOWNNAME = unchecked((int)0x80020006); //From WinError.h
        const int DISPID_UNKNOWN = -1; //From OAIdl.idl
        if (hr == S_OK)
        {
            result = true;
        }
        else if (hr == DISP_E_UNKNOWNNAME && dispId == DISPID_UNKNOWN)
        {
            result = false;
        }
        else
        {
            Marshal.ThrowExceptionForHR(hr);
        }

        return result;
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00020400-0000-0000-C000-000000000046")]
    private interface IDispatchInfo
    {
        [PreserveSig]
        int GetTypeInfoCount(out int typeInfoCount);

        void GetTypeInfo(int typeInfoIndex, int lcid, out IntPtr typeInfo);

        [PreserveSig]
        int GetDispId(ref Guid riid, ref string name, int nameCount, int lcid, out int dispId);

        // NOTE: The real IDispatch also has an Invoke method next, but we don't need it.
    }
}
