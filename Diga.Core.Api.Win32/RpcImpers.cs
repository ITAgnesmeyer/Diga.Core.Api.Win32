namespace Diga.Core.Api.Win32
{
    public enum RpcImpers
    {                                // RPC_C_IMP_LEVEL_xxx
        Default = 0,
        Anonymous = 1,
        Identify = 2,
        Impersonate = 3,
        Delegate = 4
    }
}