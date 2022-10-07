using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32.Com
{
    public enum RotDisplayNameSearchType
    {
        Exact,
        Contains,
        StartsWith,
        EndsWith
    }
    public static class RunningObjectTableUtility
    {
        public static IBindCtx GetBindContext()
        {
            Ole32.CreateBindCtx(0, out var bindContext);
            return bindContext;

        }

        public static IRunningObjectTable GetRunningObjectTable(IBindCtx context)
        {
            context.GetRunningObjectTable(out IRunningObjectTable rotTable);
            return rotTable;
        }

        public static IEnumMoniker GetMonikerEnumerator(IRunningObjectTable rotTable)
        {
            rotTable.EnumRunning(out IEnumMoniker enumMoniker);
            return enumMoniker;

        }

        public static List<MonikerInfo> GetMonikerInfos(IBindCtx context, IEnumMoniker monikerEnumerator)
        {
            List<MonikerInfo> infos = new List<MonikerInfo>();

            IMoniker[] monikers = new IMoniker[1];
            IntPtr numberFetched = IntPtr.Zero;
            while (monikerEnumerator.Next(1, monikers, numberFetched) == HRESULT.S_OK)
            {
                IMoniker moniker = monikers[0];
                MonikerInfo monikerInfo = new MonikerInfo(context, moniker);
                infos.Add(monikerInfo);
            }

            return infos;
        }

        public static MonikerInfo GetMonikerInfoByDisplayName(List<MonikerInfo> monikInfos,string displayName, RotDisplayNameSearchType searchType = RotDisplayNameSearchType.Exact)
        {
            MonikerInfo infoToReturn = null;
            foreach (MonikerInfo monikerInfo in monikInfos)
            {
                bool wasFound = false;
                string monDispName = monikerInfo.GetDisplayName;

                if ( searchType == RotDisplayNameSearchType.Exact)
                {
                    wasFound = monDispName == displayName;
                }
                else
                {
                    if (!string.IsNullOrEmpty(monDispName))
                    {
                        switch (searchType)
                        {
                            case RotDisplayNameSearchType.Contains:
                                wasFound = monDispName.Contains(displayName);
                                break;
                            case RotDisplayNameSearchType.EndsWith:
                                wasFound = monDispName.EndsWith(displayName);
                                break;
                            case RotDisplayNameSearchType.StartsWith:
                                wasFound = monDispName.StartsWith(displayName);
                                break;
                        }
                        
                    }
                    
                }

                if (wasFound)
                {
                    infoToReturn =  monikerInfo;
                    break;
                }
                    
            }

            return infoToReturn;
        }

        public static MonikerInfo GetMonikerInfoByClassId(List<MonikerInfo> monikerInfos,Guid classId)
        {
            return monikerInfos.FirstOrDefault(monikerInfo => monikerInfo.ClassId.Equals(classId));
        }
        public static object GetRotObject(IRunningObjectTable rotTable, MonikerInfo monikerInfo)
        {
            rotTable.GetObject(monikerInfo.Moniker, out object rotObj);
            if (rotObj == null)
            {
                throw new InvalidOperationException("Failed to get running object");
            }
            return rotObj;
        }

        public static object GetRotObject(Guid classId)
        {
            IBindCtx context = GetBindContext();
            IRunningObjectTable rotTable = GetRunningObjectTable(context);
            IEnumMoniker enumerator = GetMonikerEnumerator(rotTable);
            List<MonikerInfo> infos = GetMonikerInfos(context, enumerator);
            MonikerInfo info = GetMonikerInfoByClassId(infos,classId);
            if(info == null)
                return null;
            object rotObj = GetRotObject(rotTable, info);
            return rotObj;
        }

        public static object GetRotObject(string dipslayName, RotDisplayNameSearchType searchType = RotDisplayNameSearchType.Exact)
        {
            IBindCtx context = GetBindContext();
            IRunningObjectTable rotTable = GetRunningObjectTable(context);
            IEnumMoniker enumerator = GetMonikerEnumerator(rotTable);
            List<MonikerInfo> infos = GetMonikerInfos(context, enumerator);
            MonikerInfo info = GetMonikerInfoByDisplayName(infos, dipslayName, searchType);
            if (info == null)
                return null;
            object rotObj = GetRotObject(rotTable, info);
            return rotObj;

        }
    }
}