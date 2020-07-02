using Avito_Parser.Avito;
using Avito_Parser.Core;
using System;
using System.Collections.Generic;
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

namespace Avito_Parser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParserWorker<AvitoNote[]> parser;
        public MainWindow()
        {
            InitializeComponent();
            parser = new ParserWorker<AvitoNote[]>(new AvitoParser());

            parser.OnComleted += Parser_OnComleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, AvitoNote[] arg2)
        {
            foreach (var st in arg2)
                listBox.Items.Add(st);
        }

        private void Parser_OnComleted(object obj)
        {
            MessageBox.Show("Completed!");
        }

        private void buttonParse_Click(object sender, RoutedEventArgs e)
        {
            int firstPage;
            int lastPage;
            try
            {
                firstPage = int.Parse(tbFirstPage.Text);
                lastPage = int.Parse(tbLastPage.Text);
            }
            catch
            {
                firstPage = lastPage = 1;
            }
            parser.ParserSettings = new AvitoSettings(firstPage, lastPage);
            parser.Start();
            
        }

        private void buttonAbort_Click(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }
    }
}
