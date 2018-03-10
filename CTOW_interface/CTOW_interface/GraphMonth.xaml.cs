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
using System.Windows.Shapes;
using OxyPlot;

namespace CTOW_interface
{
    /// <summary>
    /// Logique d'interaction pour GraphMonth.xaml
    /// </summary>
    public partial class GraphMonth : Window
    {
        public GraphMonth()
        {   
            InitializeComponent();
            TabPollution.InvalidatePlot(true);
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void DetailsPollution(object sender, RoutedEventArgs e)
        {
            Pollution pol = new Pollution();
            this.Close();
            pol.Show();
        }

        private void DetailsBruit(object sender, RoutedEventArgs e)
        {
            Bruit bruit = new Bruit();
            this.Close();
            bruit.Show();
        }

        private void DetailsDebit(object sender, RoutedEventArgs e)
        {
            Debit deb = new Debit();
            this.Close();
            deb.Show();
        }
    }
}
