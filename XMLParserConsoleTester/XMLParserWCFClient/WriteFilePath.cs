using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLParserWCFClient
{
    class WriteFilePath
    {
        public string writeFilePath()
        {
            string filename = null;
            System.Windows.Forms.OpenFileDialog browseFile = new System.Windows.Forms.OpenFileDialog();

            if (browseFile.ShowDialog() ==DialogResult.OK)
            {
                filename = browseFile.FileName;

            }
            return filename;
        }
    }
}
