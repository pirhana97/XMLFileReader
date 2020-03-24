using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace XMLParsing
{
    public class XMLValidator
    {
        public bool XmlValidate(string filePath)
        {
            bool isValid = true;
            try
            {
                XmlReader reader = new XmlTextReader(@"C:\Users\z0045tam\source\repos\XMLParserConsoleApplicationFinal\XMLJobSchema.xsd");
                XmlSchema myXmlSchema = XmlSchema.Read(reader, null);
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(filePath);
                XmlValidatorTestHelper xmlSchemaValidator = new XmlValidatorTestHelper();
                xmlSchemaValidator.ValidXmlDoc(myXmlDocument, myXmlSchema);
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                isValid = false;
            }

            return isValid;
        }
    }
}
