using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //Attributes
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)//invocation çalıştırmak istediğimiz metoddur. Add gibi
        {

        }
    }
}
