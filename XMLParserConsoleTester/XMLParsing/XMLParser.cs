using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using syngo.XMLParser.Runtime;


namespace XMLParsing
{/// <summary>
/// Calls all the methods in the classes, finally used as the parser
/// <returns>Throws exception for invalid file and formatted xml file in console version</returns>
/// </summary>
/// 
    public interface IXMLParser
    {
        string filePath { get; set; }
        string ParseXML(string filePath);
    }
    public class XMLParser
    {

        public string ParseXML(string filePath)
        {
            ConsoleLogger cl = new ConsoleLogger();
            try
            {
                //   Console.WriteLine($"Input argument is null. {nameof(filePath)}");
                if (string.IsNullOrEmpty(filePath)) { throw new ArgumentNullException(nameof(filePath)); }

                //Loading the document in the Parser

                // directly get string from here doc.OuterXml;

                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                String xmlJobString = doc.OuterXml;

               
                cl.Print_AIScheduler();

                XMLValidator validator = new XMLValidator();
                bool isValidXML = validator.XmlValidate(filePath);

                if (isValidXML)
                {
                    XMLDeserializer serializer = new XMLDeserializer();
                    var jobs = serializer.Deserialize(xmlJobString.ToString());
                    cl.PrintJobList(jobs);
                }
                else
                {
                    cl.Print_Xml_Exception();
                }

            }

            catch (XmlException)
            {
                
                cl.Print_Xml_Exception();
            }
            catch (ArgumentNullException)
            {
              
                cl.Print_ArgumentNull_Exception();
            }
            catch (FileNotFoundException)
            {
               
                cl.Print_FileNotFound_Exception();
            }

            catch (ArgumentException)
            {
                
                cl.Print_Argument_Exception();
            }

            return null;
        }
    }
}

//IsNullOrWhiteSpace
