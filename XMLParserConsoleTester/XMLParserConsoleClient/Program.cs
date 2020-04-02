using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParserConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLParserServiceProxy.XMLParserServiceProxy proxy = new XMLParserServiceProxy.XMLParserServiceProxy();

            Console.WriteLine("Client is running at " + DateTime.Now.ToString());
            Console.WriteLine("Enter the filepath: ");
            string filePath = Console.ReadLine();
            Console.WriteLine(proxy.ShowMessage(filePath));
            Console.WriteLine(proxy.Parser(filePath));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
