using System;
using System.Collections.Generic;
using System.Text;
using XMLParsing;
using NUnit.Framework;
using System.IO;

namespace XMLParsing_uTest
{
    class XMLValidatorTests
    {
        [TestCase]
        public void XMLValidator_Valid_isTrue()
        {

            XMLValidator sut = new XMLValidator();
            var validate = sut.XmlValidate(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\test.u\Data\InvalidXML.xml");
            Assert.AreEqual(false, validate);
        }

        [TestCase]
        public void Test()
        {
            XMLValidator sut = new XMLValidator();
            var Validate = sut.XmlValidate(@"C:\Users\z0045tam\source\repos\XMLParserConsoleTester\XMLParsing_UTest\test.u\Data\AiScheduler1.xml");
            Assert.AreEqual(true, Validate);
        }
    }
}
