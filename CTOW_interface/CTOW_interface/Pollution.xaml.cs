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

namespace CTOW_interface
{
    /// <summary>
    /// Logique d'interaction pour Pollution.xaml
    /// </summary>
    public partial class Pollution : Window
    {
        public Pollution()
        {
            InitializeComponent();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            GraphMonth graphique = new GraphMonth();
            this.Close();
            graphique.Show();
        }
    }
}
