using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceObject;
using WCFService2Controller.ServiceReference1;
using WCFService2Controller.Interceptor;
using Common.Logging;
using System.ServiceModel;
using Castle.DynamicProxy;

namespace WCFService2Controller
{
    public class WCFServer2Controller
    {
        IService1 client;
        ILog log = LogManager.GetLogger("Service2");

        public WCFServer2Controller()
        {
            ProxyGenerator generator = new ProxyGenerator();

            client = (IService1)generator.CreateInterfaceProxyWithTarget(
                typeof(IService1), new Service1Client(new BasicHttpBinding(), new EndpointAddress("http://localhost:52252/Service1.svc")), new LogInterceptor());
            //client = new Service1Client(new BasicHttpBinding(), new EndpointAddress("http://localhost:52252/Service1.svc"));
        }

        public string GetData(int value)
        {
            log.Info("Calling GetData from wcf service 2 controller.");
            return client.GetData(value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            log.Info("Calling GetDataUsingDataContract from wcf service 2 controller.");
            return client.GetDataUsingDataContract(composite);
        }
    }
}
