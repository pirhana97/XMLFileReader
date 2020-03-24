using System;
using System.Collections.Generic;
using System.Text;
using XMLParsing;
using NUnit.Framework;
using System.IO;

namespace XMLParsing_uTest
{
    class XMLFileLoadTests
    {
        [TestCase]
        public void LoadXML_InvalidFile_ThrowsDirectoryNotFoundException()
        {
            Assert.Throws<DirectoryNotFoundException>(() =>
            {
                XMLFileLoader sut = new XMLFileLoader();
                string filePath = @"C:\Users\z0045tam\source\repos\Projec\AiScheduler3.xml";
                var result = sut.LoadXML(filePath);
            }, "DirectoryNotFoundException Thrown");
        }

        [TestCase]
        public void LoadXML_NullFile_ThrowsArgumentNullException()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                XMLFileLoader sut = new XMLFileLoader();
                string filePath = null;
                var result = sut.LoadXML(filePath);

            }, "XmlException not thrown when XML is invalid");
        }

        [TestCase]
        public void LoadXML_FileNotFound_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                XMLFileLoader sut = new XMLFileLoader();
                string filePath = @"C:\Users\z0045tam\source\repos\Project1\AiScheduler31.xml";
                var result = sut.LoadXML(filePath);
            }, "FileNotFoundException Thrown");
        }


    }
}
