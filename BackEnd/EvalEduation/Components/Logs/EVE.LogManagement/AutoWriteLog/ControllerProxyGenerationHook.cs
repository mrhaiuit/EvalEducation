using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Castle.DynamicProxy;

namespace EVE.LogManagement.AutoWriteLog
{
    public class ControllerProxyGenerationHook : IProxyGenerationHook
    {
        readonly List<string> _ignoreMethods = new List<string>
                                               {
                                                       "Dispose",
                                                       "Initialize"
                                               };

        #region IProxyGenerationHook Members

        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type,
                                                   MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type,
                                          MethodInfo methodInfo)
        {
            return type == typeof(ApiController) && _ignoreMethods.Contains(methodInfo.Name);
        }

        #endregion
    }
}
