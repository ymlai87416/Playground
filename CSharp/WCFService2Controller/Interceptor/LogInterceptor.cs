using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Common.Logging;

namespace WCFService2Controller.Interceptor
{
    class LogInterceptor : IInterceptor
    {
        static ILog log = LogManager.GetLogger("Interceptor");

        public void Intercept(IInvocation invocation)
        {
            log.Info("Before invoke.");

            invocation.Proceed();

            log.Info("After invoke.");
        }
    }
}
