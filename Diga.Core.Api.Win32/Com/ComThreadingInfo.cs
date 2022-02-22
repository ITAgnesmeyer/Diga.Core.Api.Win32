using System;

namespace Diga.Core.Api.Win32.Com
{
    public class ComThreadingInfo
    {
        public ComThreadingInfo()
        {
            Guid iidUnk = IID.IID_IUnknown;
            IComThreadingInfo info = (IComThreadingInfo)Ole32.CoGetObjectContext(ref iidUnk);
            this.ApartmentType = info.GetCurrentApartmentType();
            this.ThreadType = info.GetCurrentThreadType();
            this.LogicalThreadId = info.GetCurrentLogicalThreadId();
            if (HRESULT.S_OK == Ole32.CoGetCallerTID(out uint lpdwTid))
            {
                this.CallerThreadId = lpdwTid;
            }
            
        }

        public static ComThreadingInfo Current => new ComThreadingInfo();

        public APTTYPE ApartmentType { get; }

        public THDTYPE ThreadType { get; }

        public Guid LogicalThreadId { get; }

        public uint CallerThreadId { get; }

        public override string ToString()
        {
            return $"{{{this.LogicalThreadId}}} - {this.ApartmentType} - {this.ThreadType}";
        }
    }

    
}