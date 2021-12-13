using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32.Com
{
    public struct DispatchMemberInfo
    {
        public FUNCDESC FunctionDescription { get; }
        public string Name { get; }
        public int DsipId { get; }
        internal DispatchMemberInfo(FUNCDESC funcDesc, string name, int dipId)
        {
            this.FunctionDescription = funcDesc;
            this.Name = name;
            this.DsipId = dipId;
        }




    }
}