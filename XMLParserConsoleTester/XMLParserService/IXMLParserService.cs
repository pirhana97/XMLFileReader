using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace XMLParserWCFService
{
    [ServiceContract()]
    public interface IXMLParserService
    {
        [OperationContract]
        string ShowMessage(string filePath);

        [OperationContract]
        string Parser(string filePath);

    }
}
