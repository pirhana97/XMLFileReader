using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLParserData;
using System.Xml.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
//using XMLParsing;

namespace syngo.XMLParser.Runtime
{
    public class ConsoleLogger
    {
        public void Print_AIScheduler()
        {
            Console.WriteLine("AI Scheduler");
        }

        public void Print_Xml_Exception()
        {
            Console.WriteLine("XML Exception thrown");
        }
        public void Print_ArgumentNull_Exception()
        {
            Console.WriteLine("Input argument is null.");

        }
        public void Print_FileNotFound_Exception()
        {
            Console.WriteLine("File not found.");
        }

        public void Print_Argument_Exception()
        {
            Console.WriteLine("File cannot contain whitespace.");
        }

        public void Print_Directory_Not_Found_Exception()
        {
            Console.WriteLine("The directory cannot be found!!!");
        }
        public void Print_Enter_Path()
        {
            Console.WriteLine("Please enter the path");
        }

        public void File_Load_Exception()
        {
            Console.WriteLine("File cannot be loaded");
        }

       

        public void PrintJobList(List<Job> jobs)
        {
            //prints jobs
            try
            {
                Console.WriteLine("Number of Jobs: " + jobs.Count);
                jobs.ForEach(item => Console.WriteLine("Total Size: " + item.TotalSize + " CPUUtilization: " + item.CPUUtilization + " ExecutionTime: " + item.ExecutionTime + " ClockRate: " + item.ClockRate + " Cached: " + item.Cached));
            }

            catch (NullReferenceException)
            {
                Console.WriteLine(" ");
            }


        }
    }
}









//public void Deserializer(StringReader stringReader)
//{

//    XmlSerializer serializer = new XmlSerializer(typeof(List<Job>), new XmlRootAttribute("AiScheduler"));
//    List<Job> jobList = (List<Job>)serializer.Deserialize(stringReader);
//    Console.WriteLine("Number of Jobs: " + jobList.Count);
//    jobList.ForEach(item => Console.WriteLine("Total Size: " + item.TotalSize + " CPUUtilization: " + item.CPUUtilization + " ExecutionTime: " + item.ExecutionTime + " ClockRate: " + item.ClockRate + " Cached: " + item.Cached));

//}