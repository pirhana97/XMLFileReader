using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XMLParsing;

namespace XMLParserWCFClient
{
    class XMLParser
    {
        public string parserReturn(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            String xmlJobString = doc.OuterXml;

            XMLValidator validator = new XMLValidator();
            validator.XmlValidate(filePath);

            XMLDeserializer serializer = new XMLDeserializer();
            serializer.Deserialize(xmlJobString.ToString());


            return null;
        }
    }
}
