using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Linq;
using System.Xml;

namespace Core.Aspects.Autofac.Logging
{
    public class LoggingAspect : MethodInterception
    {
        private Type _loggerType;

        public LoggingAspect(Type loggerType)
        {

            if (!typeof(ILoggerService).IsAssignableFrom(loggerType))
            {
                throw new System.Exception("Bu bir loglama sınıfı değildir.");
            }

            _loggerType = loggerType;
        }

        protected override void OnBefore(IInvocation invocation)
        {


            var logDetail = getLogDetail(invocation);
            ILoggerService logger = (ILoggerService)Activator.CreateInstance(_loggerType);
            logger.Log(logDetail);
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            var logDetail = getLogDetail(invocation);
            ILoggerService logger = (ILoggerService)Activator.CreateInstance(_loggerType);
            logDetail.ExceptionMessage = e.Message;
            logger.Log(logDetail);
        }


        private LogDetail getLogDetail(IInvocation invocation)
        {
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                Parameters = invocation.Arguments
                    .Select((a, i) => new LogParameter
                    {
                        Name = invocation.Method.GetParameters()[i].Name,
                        Value = a,
                        Type = a?.GetType().Name
                    }).ToList()
            };
            return logDetail;
        }
    }
}
