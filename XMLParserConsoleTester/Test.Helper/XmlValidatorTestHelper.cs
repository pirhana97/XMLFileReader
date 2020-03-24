using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace XMLValidatorTestHelper
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
        public void ValidXmlDoc(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            validateParameters(xmlDocument, xmlSchema);
            XmlReader xmlReader = createXmlReader(xmlDocument, xmlSchema);

            try
            {
                // validate        
                using (xmlReader)
                {
                    while (xmlReader.Read())
                    { }
                }
                isValidXml = true;
            }
            catch (Exception ex)
            {
                ValidationError = ex.Message;
                isValidXml = false;
            }
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

        private static XmlReader createXmlReader(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            StringReader xmlStringReader = convertXmlDocumentToStringReader(xmlDocument);
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            xmlReaderSettings.Schemas.Add(xmlSchema);
            return XmlReader.Create(xmlStringReader, xmlReaderSettings);
        }

        private static StringReader convertXmlDocumentToStringReader(XmlDocument xmlDocument)
        {
            StringWriter sw = new StringWriter();
            xmlDocument.WriteTo(new XmlTextWriter(sw));
            return new StringReader(sw.ToString());
        }
    }
}
