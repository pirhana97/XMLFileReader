using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XMLParserData;
using XMLParsing;

namespace XMLParserWCFService
{
    public class XMLParserService : IXMLParserService
    {
        public string Parser(string filePath)
        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            String xmlJobString = doc.OuterXml;

            XMLValidator validator = new XMLValidator();
            bool isValidXML = validator.XmlValidate(filePath);

            string message = "";

            if (isValidXML)
            {
              
                StringReader stringReader = new StringReader(xmlJobString);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Job>), new XmlRootAttribute("AiScheduler"));
                List<Job> jobList = (List<Job>)serializer.Deserialize(stringReader);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Number of jobs :" + jobList.Count);
                jobList.ForEach(item => stringBuilder.AppendLine("Total Size: " + item.TotalSize + " CPUUtilization: " + item.CPUUtilization + " ExecutionTime: " + item.ExecutionTime + " ClockRate: " + item.ClockRate + " Cached: " + item.Cached));

                message = stringBuilder.ToString();

                
            }
            else
            {
                message = "XML File not valid";

            }


            return message;
        }

        public string ShowMessage(string filePath)
        {
            return "Message recieved from client :" + filePath;
        }
    }
}
