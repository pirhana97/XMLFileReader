using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using syngo.XMLParser.Runtime;

namespace XMLParsing
{
    public class XMLFileLoader
    {
        public string LoadXML(string filePath)
        {
            ConsoleLogger cl = new ConsoleLogger();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                String jobString = xmlDoc.OuterXml;


                return jobString;
            }
            catch (XmlException)
            {
                
                cl.Print_Xml_Exception();


            }
            catch (FileLoadException)
            {
               
                cl.File_Load_Exception();
            }
            return filePath;
        }
    }
}

