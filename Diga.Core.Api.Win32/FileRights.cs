namespace Diga.Core.Api.Win32
{
    public  enum FileRights : uint
    {
        Read = 4,
        Write = 2,
        ReadWrite = Read + Write
    }
}