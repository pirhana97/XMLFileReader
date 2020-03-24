using NUnit.Framework;
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using XMLParsing;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using XMLParserData;
using syngo.XMLParser.Runtime;

namespace XMLParsing_uTest
{
    [TestFixture]
    public class XMLParserTests
    {

        [TestCase]
        public void ParseXML_NullValue_ValidationAreEqual()
        {
            var sut = new XMLParser();
            Assert.AreEqual(null, sut.ParseXML(It.IsAny<string>()));

        }   

        [TestCase]
        public void ParseXML_XMLFile_ThrowsNotSuportedException()
        {
           
            Assert.Throws<NotSupportedException>(()=>
            { 
                var sut = new Mock<XMLValidator>();
                sut.Setup(x => x.XmlValidate(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\test.u\Data\AiScheduler1.xml")).Returns(true);
                Assert.AreEqual(true, sut.Object.XmlValidate(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\test.u\Data\AiScheduler1.xml"));
            });
         
        }
        
        


    }
}

















































//List<string> attributeList = new List<string> { "TotalSize", "ClockRate", "ExecutionTime", "Cached", "CPUUtilization" };
//XmlDocument doc = new XmlDocument();
//doc.Load(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\test.u\Data\AiScheduler.xml");
//var jobNodes = doc.SelectNodes("/AiScheduler/Job");


//foreach (XmlNode itemNode in jobNodes)
//{


//    List<string> jobList = new List<string>();
//    for (int attributeNumber = 0; attributeNumber < itemNode.ChildNodes.Count; attributeNumber++)
//    {
//        jobList.Add(itemNode.ChildNodes[attributeNumber].Name);

//    }
//    IEnumerable<string> DifferenceInAttributes = attributeList.Except(jobList);
//    Assert.AreNotEqual(attributeList, DifferenceInAttributes);

//} 




//List<string> attributeList = new List<string> { "TotalSize", "ClockRate", "ExecutionTime", "Cached", "CPUUtilization" };
//XmlDocument doc = new XmlDocument();
//doc.Load(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\test.u\Data\AiScheduler1.xml");
//var jobNodes = doc.SelectNodes("/AiScheduler/Job");

//foreach (XmlNode itemNode in jobNodes)
//{


//    List<string> jobList = new List<string>();
//    for (int attributeNumber = 0; attributeNumber < itemNode.ChildNodes.Count; attributeNumber++)
//    {
//        jobList.Add(itemNode.ChildNodes[attributeNumber].Name);

//    }
//    Assert.AreEqual(attributeList, jobList);

//}


//XmlValidatorTestHelper xmlSchemaValidator = new XmlValidatorTestHelper();
//XmlReader reader = new XmlTextReader(@"C:\Users\z0045tam\source\repos\XMLParserConsoleApplicationFinal\XMLJobSchema.xsd");
//XmlSchema myXmlSchema = XmlSchema.Read(reader, null);
//XmlDocument myXmlDocument = new XmlDocument();
//myXmlDocument.Load(@"C:\Users\z0045tam\source\repos\Project1\AiScheduler1.xml");
//xmlSchemaValidator.ValidXmlDoc(myXmlDocument, myXmlSchema); xmlSchemaValidator.ValidXmlDoc(myXmlDocument, myXmlSchema);

//Assert.IsTrue(xmlSchemaValidator.IsValidXml, "XML does not match Schema: " + xmlSchemaValidator.ValidationError);