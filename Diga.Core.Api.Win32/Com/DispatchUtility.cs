using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Diga.Core.Api.Win32.Com
{
    public static class DispatchUtility
    {
        //private const int S_OK = 0; //From WinError.h
        //private const int LOCALE_SYSTEM_DEFAULT = 2 << 10; //From WinNT.h == 2048 == 0x800

        public static bool ImplementsIDispatch(object obj)
        {
            bool result = obj is IDispatchInfo;
            return result;
        }

        public static List<DispatchMemberInfo> GetMembers(object obj, bool throwIfNotFound)
        {
            RequireReference(obj, "obj");
            TestImplementsIDispatch(obj);
            List<DispatchMemberInfo> result = GetMembers((IDispatchInfo)obj, throwIfNotFound);
            return result;
        }

        private static void TestImplementsIDispatch(object obj)
        {
            if (!ImplementsIDispatch(obj))
                throw new InvalidOperationException("The object must implement IDispatch");
        }
        public static bool TryGetDispId(object obj, string name, out int dispId)
        {
            RequireReference(obj, "obj");
            TestImplementsIDispatch(obj);
            bool result = TryGetDispId((IDispatchInfo)obj, name, out dispId);
            return result;
        }

        public static object Invoke(object obj, int dispId, DispatchCallingConventions convention, object[] args)
        {
            RequireReference(obj, "obj");
            TestImplementsIDispatch(obj);
            string memberName = "[DispId=" + dispId + "]";
            object result = Invoke(obj, memberName, convention, args);
            return result;
        }

        //private static int DISPATCH_METHOD = 0x1;
        //private static int DISPATCH_PROPERTYGET = 0x2;
        //private static int DISPATCH_PROPERTYPUT = 0x4;
        //private static int DISPATCH_PROPERTYPUTREF = 0x8;


        public static object Invoke(object obj, string memberName, DispatchCallingConventions convention, object[] args)
        {

            RequireReference(obj, "obj");
            TestImplementsIDispatch(obj);
            Type type = obj.GetType();


            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;

            switch (convention)
            {
                case DispatchCallingConventions.Function:
                    flags |= BindingFlags.InvokeMethod;
                    break;
                case DispatchCallingConventions.PropertyGet:
                    flags |= BindingFlags.GetProperty;
                    break;
                case DispatchCallingConventions.PropertyPut:
                    flags |= BindingFlags.PutDispProperty;
                    break;
                case DispatchCallingConventions.PropertyPutRef:
                    flags |= BindingFlags.PutRefDispProperty;
                    break;
                default:
                    flags |= BindingFlags.SetProperty;
                    break;
            }

            object result = type.InvokeMember(memberName,
                flags, null, obj, args, null);
            return result;
        }

        //public static object InvokeGet(object obj, string memberName)
        //{
        //    RequireReference(obj, "obj");
        //    if (TryGetDispId(obj, memberName, out int dispId))
        //    {
        //        IDispatch disp = (IDispatch)obj;
        //        DISPPARAMS pars = new DISPPARAMS();
        //        pars.cArgs = 0;
        //        pars.cNamedArgs = 0;
        //        EXCEPINFO exInfo = new EXCEPINFO();

        //        IntPtr[] argErr = new IntPtr[1];
        //        Guid g = Guid.Empty;
        //        var varResult = new object[1];

        //        HRESULT i = disp.Invoke(dispId, g, (uint)Thread.CurrentThread.CurrentCulture.LCID, (ushort)DispatchCallType.DISPATCH_PROPERTYGET, pars, varResult, exInfo, argErr);
        //        if (i.Succeeded)
        //        {
        //            return varResult[0];
        //        }

        //        Marshal.ThrowExceptionForHR(i);


        //    }

        //    throw new Exception("Cannot find Property:" + memberName);


        //}

        //public static object InvokeFunc(object obj, string memberName, object[] args)
        //{
        //    RequireReference(obj, "obj");
        //    if (TryGetDispId(obj, memberName, out int dispID))
        //    {
        //        IDispatch disp = (IDispatch)obj;
        //        DISPPARAMS pars = new DISPPARAMS
        //        {
        //            cArgs = args.Length,
        //            rgdispidNamedArgs = IntPtr.Zero,
        //            cNamedArgs = 0
        //        };
        //        IntPtr arrPtr = VariantObject.ObjectArrayToVariantArrayPtr(args);
        //        pars.rgvarg = arrPtr;
        //        Guid g = Guid.Empty;

        //        EXCEPINFO exInfo = new EXCEPINFO();

        //        IntPtr[] argErr = new IntPtr[1];
        //        var varResult = new object[1];
        //        HRESULT hr = disp.Invoke(dispID, g, (uint)Thread.CurrentThread.CurrentCulture.LCID, (ushort)DispatchCallType.DISPATCH_METHOD, pars, varResult, exInfo, argErr);
        //        VariantObject.FreeVariantArrayPtr(arrPtr, args.Length);
        //        if (hr.Succeeded)
        //        {

        //            return varResult;

        //        }
        //        Marshal.ThrowExceptionForHR(hr);


        //    }

        //    throw new InvalidOperationException("Cannot find Function:" + memberName);
        //}
        //public static void InvokeSetOld(object obj, string memberName, object args)
        //{
        //    RequireReference(obj, "obj");


        //    if (TryGetDispId(obj, memberName, out int dispID))
        //    {
        //        IDispatch disp = (IDispatch)obj;
        //        DISPPARAMS pars = new DISPPARAMS();
        //        pars.cArgs = 1;
        //        pars.cNamedArgs = 1;

        //        IntPtr namedArgsPtr = Marshal.AllocCoTaskMem(4);
        //        Marshal.WriteInt32(namedArgsPtr, (int)DispatchCallType.DISPATCH_PROPERTYPUT);


        //        pars.rgdispidNamedArgs = namedArgsPtr;


        //        IntPtr arrPtr = Marshal.AllocCoTaskMem(16);
        //         Marshal.GetNativeVariantForObject(args,arrPtr );

        //        pars.rgvarg = arrPtr;
        //        Guid g = Guid.Empty;

        //        int[] ids = new int[3];
        //        HRESULT v = disp.GetIDsOfNames(g, new string[] { memberName }, 1, (int)Thread.CurrentThread.CurrentCulture.LCID, ids);
        //        if (!v.Failed)
        //        {
        //            EXCEPINFO exInfo = new EXCEPINFO();

        //            IntPtr[] argErr = new IntPtr[1];

        //            HRESULT i = disp.Invoke(dispID, g, (uint)Thread.CurrentThread.CurrentCulture.LCID, (ushort)DispatchCallType.DISPATCH_PROPERTYPUT  , pars, null, exInfo, null );
        //            VariantObject.FreeVariantArrayPtr(arrPtr, 16);
        //            Marshal.FreeCoTaskMem(namedArgsPtr);
        //            if (!i.Failed)
        //            {

        //                return;

        //            }
        //            Marshal.ThrowExceptionForHR(i);

        //        }




        //    }

        //}

        private static void RequireReference<T>(T value, string name) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        private static List<DispatchMemberInfo> GetMembers(IDispatchInfo dispatch, bool throwIfNotFound)
        {
            RequireReference(dispatch, "dispatch");

            List<DispatchMemberInfo> result = new List<DispatchMemberInfo>();
            int hr = dispatch.GetTypeInfoCount(out var typeInfoCount);
            if (hr == HRESULT.S_OK && typeInfoCount > 0)
            {
                dispatch.GetTypeInfo(0, (int)Thread.CurrentThread.CurrentCulture.LCID, out IntPtr p);
                if (p != IntPtr.Zero)
                {
                    ITypeInfo tInfo = (ITypeInfo)Marshal.GetObjectForIUnknown(p);
                
                    tInfo.GetTypeAttr(out IntPtr attr);
                    if (attr != IntPtr.Zero)
                    {

                        System.Runtime.InteropServices.ComTypes.TYPEATTR typeAttr = Marshal.PtrToStructure<System.Runtime.InteropServices.ComTypes.TYPEATTR>(attr);
                        for (int i = 0; i < typeAttr.cFuncs; i++)
                        {
                            tInfo.GetFuncDesc(i, out IntPtr pfuncDesc);
                            if (pfuncDesc != IntPtr.Zero)
                            {
                                System.Runtime.InteropServices.ComTypes.FUNCDESC funcDesc = Marshal.PtrToStructure<System.Runtime.InteropServices.ComTypes.FUNCDESC>(pfuncDesc);

                                tInfo.GetDocumentation(funcDesc.memid, out string name, out string docString, out int helContext, out string helpFile);

                                if (!string.IsNullOrEmpty(name))
                                {
                                    TryGetDispId(dispatch, name, out int dispId);

                                    DispatchMemberInfo memInfo = new DispatchMemberInfo(funcDesc, name, dispId);
                                    result.Add(memInfo);
                                }
                                tInfo.ReleaseFuncDesc(pfuncDesc);
                            }
                        
                        }
                        tInfo.ReleaseTypeAttr(attr);
                    }
                }

            }

            if (result == null && throwIfNotFound)
            {

                Marshal.ThrowExceptionForHR(hr);


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
            HRESULT hr = dispatch.GetDispId(ref iidNull, ref name, 1, (int)Thread.CurrentThread.CurrentCulture.LCID, out dispId);

            const int DISP_E_UNKNOWNNAME = unchecked((int)0x80020006); //From WinError.h
            const int DISPID_UNKNOWN = -1; //From OAIdl.idl
        
            if (hr.Succeeded)
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


    }
}