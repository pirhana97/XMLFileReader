using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParserData
{/// <summary>
/// Class for Deserialization of string/XML file
/// </summary>
/// 
    public interface IJob
    {
        string TotalSize { get; set; }
        string ClockRate { get; set; }
        string ExecutionTime { get; set; }
        string Cached { get; set; }
        string CPUUtilization { get; set; }

    }
    public class Job : IJob
    {

        public string TotalSize { get; set; }
        public string ClockRate { get; set; }
        public string ExecutionTime { get; set; }
        public string Cached { get; set; }
        public string CPUUtilization { get; set; }
    }

}
