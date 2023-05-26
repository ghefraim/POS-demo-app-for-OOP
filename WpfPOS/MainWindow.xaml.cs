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

using App1;

using Entitati;

namespace WpfPOS
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
        private void getProduseFromXmlButton_Click(object sender, RoutedEventArgs e)
        {
            ProdusManager produsManager = new ProdusManager();
            List<ProdusAbstract> elemente = produsManager.GetListFromXML();
            
            string textContent = "";

            foreach (ProdusAbstract elem in elemente)
            {
                textContent += elem.ToString();
            }

            textBox.Text = textContent;
        }
        private void getServiciiFromXmlButton_Click(object sender, RoutedEventArgs e)
        {
            ServiciuManager serviciuManager = new ServiciuManager();
            List<ProdusAbstract> elemente = serviciuManager.GetListFromXML();

            string textContent = "";
            foreach (ProdusAbstract elem in elemente)
            {
                textContent += elem.ToString();
            }

            textBox.Text = textContent;
        }
        private void getPacheteFromXmlButton_Click(object sender, RoutedEventArgs e)
        {
            PachetManager pachetManager = new PachetManager();
            List<ProdusAbstract> elemente = pachetManager.GetListFromXML();

            string textContent = "";

            foreach (ProdusAbstract elem in elemente)
            {
                textContent += elem.ToString();
            }

            textBox.Text = textContent;
        }
    }
}
