using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;

namespace XMLParsing
{
    public class XmlValidatorTestHelper
    {
        private bool isValidXml = true;
        private string validationError = "";

        public String ValidationError
        {
            get { return "Validation Error: " + validationError; }
            set { validationError = value; }
        }

        public bool IsValidXml
        {
            get { return isValidXml; }
        }

        /// 
        /// Validate an xml document against an xml schema.
        /// 
        public bool ValidXmlDoc(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\XMLJobSchema.xsd");
                xmlSchema = XmlSchema.Read(reader, ValidationCallback);
                validateParameters(xmlDocument, xmlSchema);
                XmlReader xmlReader = createXmlReader(xmlDocument, xmlSchema);
                FileStream file = new FileStream("new.xsd", FileMode.Create, FileAccess.ReadWrite);
                XmlTextWriter xwriter = new XmlTextWriter(file, new UTF8Encoding());
                xwriter.Formatting = Formatting.Indented;
                xmlSchema.Write(xwriter);
                isValidXml = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                isValidXml = false;
            }

            //try
            //{
            //    // validate        
            //    using (xmlReader)
            //    {
            //        while (xmlReader.Read())
            //        { }
            //    }
            //    isValidXml = true;
            //}
            //catch (Exception ex)
            //{
            //    ValidationError = ex.Message;
            //    isValidXml = false;
            //}



            return isValidXml;
        }

       public static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }

        public static void validateParameters(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
           
            if (xmlDocument == null)
            {
                new ArgumentNullException("ValidXmlDoc() - Argument NULL: XmlDocument");
            }
            if (xmlSchema == null)
            {
                new ArgumentNullException("ValidXmlDoc() - Argument NULL: XmlSchema");
            }
        }

        public static XmlReader createXmlReader(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            StringReader xmlStringReader = convertXmlDocumentToStringReader(xmlDocument);
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
              xmlReaderSettings.Schemas.Add(xmlSchema);
         //   xmlReaderSettings.Schemas.Add("http://www.w3.org/2001/XMLSchema",@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\XMLJobSchema.xsd");
            return XmlReader.Create(xmlStringReader, xmlReaderSettings);
        }

        public static StringReader convertXmlDocumentToStringReader(XmlDocument xmlDocument)
        {
            StringWriter sw = new StringWriter();
            xmlDocument.WriteTo(new XmlTextWriter(sw));
            return new StringReader(sw.ToString());
        }

        
    }
}
