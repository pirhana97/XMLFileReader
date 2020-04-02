using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace XMLParserServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8090/XMLParserWCFService/XMLParserWCFService");


            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(XMLParserWCFService.XMLParserService), httpUrl);

            //Add a service endpoint
            //   host.AddServiceEndpoint(typeof(FileReaderWCFService.IFileReaderService), new WSHttpBinding(), "");


            //Start the Service
            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
            host.Close();
        }
    }
}
