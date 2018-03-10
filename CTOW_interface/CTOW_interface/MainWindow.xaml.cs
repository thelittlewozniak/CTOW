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

namespace CTOW_interface
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AffichDetail(object sender, RoutedEventArgs e)
        {
            GraphMonth graphique = new GraphMonth();
            graphique.Show();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
