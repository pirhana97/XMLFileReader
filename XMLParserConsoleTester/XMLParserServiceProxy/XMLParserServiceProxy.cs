using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using XMLParserWCFService;

namespace XMLParserServiceProxy
{
    public class XMLParserServiceProxy : ClientBase<IXMLParserService>, IXMLParserService
    {
        public string Parser(string filePath)
        {
            return base.Channel.Parser(filePath);
        }

        public string ShowMessage(string filePath)
        {
            return base.Channel.ShowMessage(filePath);
        }
    }
}
