using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;


namespace XMLParsing
{/// <summary>
/// Validates the xml document
/// <returns>Whether the XML is validated against the schema given</returns>
/// </summary>
    public class XMLSchemaValidator
    {
        public void ValidateXmlTest(string filePath)
        {
            ValidateXml(filePath, @"C:\Users\Priyanka\Downloads\XMLParserConsoleTester\XMLParserConsoleTester\XMLParsing_UTest\XMLJobSchema.xsd"); // Change in filepath as to where schema is stored in the user's PC
        }

        public void ValidateXml(string xmlFilePath, string xsdFilePath)
        {
            if (string.IsNullOrWhiteSpace(xmlFilePath)) { throw new ArgumentNullException("xmlFilePath"); }
            if (string.IsNullOrWhiteSpace(xsdFilePath)) { throw new ArgumentNullException("xsdFilePath"); }
            if (!File.Exists(xmlFilePath))
            {
                throw new ArgumentException(string.Format("File [{0}] not found.", xmlFilePath));
            }
            if (!File.Exists(xsdFilePath))
            {
                throw new ArgumentException(string.Format("File [{0}] not found.", xsdFilePath));
            }

            var schemas = new XmlSchemaSet();

            // Use the target namespace specified in the XSD file. 
            schemas.Add(null, xsdFilePath);

            var readerSettings = new XmlReaderSettings();

            // Validate the xml file to an XSD file not an DTD or XDR.
            readerSettings.ValidationType = ValidationType.Schema;

            // Include schemas referenced by the given xsd file (recursively) in the validation proces.
            readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            // Warnings will fire the ValidationEventHandler function.
            readerSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            readerSettings.Schemas.Add(schemas);

            // The function [ValidationEventHandler] will be used to handle all validation errors / warnings.
            readerSettings.ValidationEventHandler += ValidationEventHandler;

            using (var xmlReader = XmlReader.Create(xmlFilePath, readerSettings))
            {
                while (xmlReader.Read()) { }    // Validate XML file.
            }
        }
        /// <summary>
        /// This event will fire on every XML validation error / warning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            Console.WriteLine(string.Format("",
                new object[] { args.Exception, args.Exception.LineNumber, args.Exception.LinePosition }));
        }


    }
}

