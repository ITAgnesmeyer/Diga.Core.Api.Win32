using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32.Com
{
    public class DispatchObjectWrapper
    {
        private readonly object _DispatchObject;

        public DispatchObjectWrapper(object dispObject)
        {
            if (!DispatchUtility.ImplementsIDispatch(dispObject))
                throw new InvalidOperationException("The Object must implement IDispatch");
            this._DispatchObject = dispObject;
            this._DispatchMembers = DispatchUtility.GetMembers(this._DispatchObject, false);
        }
        private readonly List<DispatchMemberInfo> _DispatchMembers;

        public List<DispatchMemberInfo> Members
        {
            get => this._DispatchMembers;
        }

        public DispatchMemberInfo GetMember(string name)
        {
            foreach (DispatchMemberInfo dispatchMemberInfo in this.Members)
            {
                if (dispatchMemberInfo.Name == name)
                {
                    return dispatchMemberInfo;
                }
            }

            throw new MissingMemberException("Cannot find Member:" + name);
        }

        public object Invoke(string name, DispatchCallingConventions convention,params object[] args)
        {
            return DispatchUtility.Invoke(this._DispatchObject, name,convention, args);
        }

        public object InvokeGet(string name)
        {
            DispatchMemberInfo info = GetMember(name);
            if (info.FunctionDescription.invkind != INVOKEKIND.INVOKE_PROPERTYGET)
            {

            }
            return this.Invoke(name, DispatchCallingConventions.PropertyGet);
        }

        public void InvokePut(string name, object value)
        {
            
            this.Invoke(name, DispatchCallingConventions.PropertyPut, value );
        }

        public void InvokeSet(string name, object value)
        {
            this.Invoke(name, DispatchCallingConventions.PropertyPutRef, value );
        }

        public void InvokeAction(string name, params object[] args)
        {
            this.Invoke(name, DispatchCallingConventions.Function, args);
        }

        public object InvokeFunction(string name, params object[] args)
        {
            return this.Invoke(name, DispatchCallingConventions.Function, args);
        }

    }
}