namespace Diga.Core.Api.Win32
{
    public enum RpcLevel
    {                                // RPC_C_AUTHN_LEVEL_xxx
        Default = 0,
        None = 1,
        Connect = 2,
        Call = 3,
        Pkt = 4,
        PktIntegrity = 5,
        PktPrivacy = 6
    }
}