using System;
using System.Collections.Generic;
using System.Text;
using XMLParsing;
using NUnit.Framework;
using System.IO;
using Moq;
using syngo.XMLParser.Runtime;
using XMLParserData;

namespace XMLParsing_uTest
{
    class XMLDeserializerTests
    {
        [TestCase]
        public void XMLDeserializer_NullValues_ThrowsFileNotFoundException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                XMLDeserializer sut = new XMLDeserializer();

                var result = sut.Deserialize(null) ;
            }, "ArgumentNullException Thrown");
        }

    }
}
