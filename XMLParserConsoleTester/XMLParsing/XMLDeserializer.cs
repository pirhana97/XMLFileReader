using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using XMLParserData;
using syngo.XMLParser.Runtime;

namespace XMLParsing
{/// <summary>
/// Deserializes job and prints it in a particular manner
/// <return>Output on the console</return>
/// </summary>
    public class XMLDeserializer
    {
        
        public List<Job> Deserialize(string xmlJobString)
        {
            
           StringReader stringReader = new StringReader(xmlJobString);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Job>), new XmlRootAttribute("AiScheduler"));
           List<Job> jobList = (List<Job>)serializer.Deserialize(stringReader);


            ConsoleLogger printJobList = new ConsoleLogger();
            printJobList.PrintJobList(jobList);


            return null;
        }
    }
}













//    Console.WriteLine("Number of Jobs: " + jobList.Count);
//    jobList.ForEach(item => Console.WriteLine("Total Size: " + item.TotalSize + " CPUUtilization: " + item.CPUUtilization + " ExecutionTime: " + item.ExecutionTime + " ClockRate: " + item.ClockRate + " Cached: " + item.Cached));