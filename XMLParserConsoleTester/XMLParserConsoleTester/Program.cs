using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using XMLParsing;
using syngo.XMLParser.Runtime;

namespace XMLParserClient
{/// <summary>
/// Main Program which implements and brings all classes together to generate output
/// </summary>
    class Program
    {
        public static object MessageBox { get; private set; }
        public static string Errorlog { get; private set; }

        static void Main(string[] args)
        {
            bool flag = true; 
            while (flag)
            {
                //Enter file name
                ConsoleLogger CL = new ConsoleLogger();
                CL.Print_Enter_Path();

                var filePath = "";
                try
                {

                    filePath = Console.ReadLine();

                    // Naming the object as scheduler
                    XMLParser sc = new XMLParser();
                    //Printing Job Scheduler
                    sc.ParseXML(filePath);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                   flag = false;
                }
                catch (FileNotFoundException)
                {
                    ConsoleLogger cl = new ConsoleLogger();
                    cl.Print_FileNotFound_Exception();
                }
                catch (DirectoryNotFoundException)
                {
                    ConsoleLogger cl = new ConsoleLogger();
                    cl.Print_Directory_Not_Found_Exception();
                }

           }



        }
    }
}

