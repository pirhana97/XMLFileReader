using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace XMLParserWCFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnClick_Browse(object sender, EventArgs e)
        {

            WriteFilePath filePath = new WriteFilePath();
            string filename = filePath.writeFilePath();
            FilePath.Text = filename;
        }


        private void OnClick_Refresh(object sender, RoutedEventArgs e)
        {
            FilePath.Text = "Enter File path here";
            Attributes_Display.Text = "File Attributes shown here";

        }

        private void OnClick_GetParameters(object sender, RoutedEventArgs e)
        {
            XMLParser parser = new XMLParser();
            Attributes_Display.Text = parser.parserReturn(FilePath.Text);


        }

    }
}
