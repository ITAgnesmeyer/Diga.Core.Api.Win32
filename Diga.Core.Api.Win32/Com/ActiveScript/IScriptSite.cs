using System.Collections.Generic;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public interface IScriptSite : IActiveScriptSite, IActiveScriptSiteWindow
    {
        Dictionary<string, object> RefObj { get; }
    }
}