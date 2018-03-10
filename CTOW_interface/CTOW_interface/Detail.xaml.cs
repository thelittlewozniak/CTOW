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
    /// Logique d'interaction pour Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        public Detail()
        {
            InitializeComponent();
            tabDetail.InvalidatePlot(true);
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            GraphMonth graph = new GraphMonth();
            this.Close();
            graph.Show();
        }
    }
}
