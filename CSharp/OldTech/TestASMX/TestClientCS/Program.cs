using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestClientCS
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWS.WebService1 service = new TestWS.WebService1();
            
            service.Url = "http://192.168.0.182/TestAsmx/WebService1.asmx";
            int result = 0;

            service.Add2(10, 2, ref result);

            Console.WriteLine(result);

        }
    }
}
