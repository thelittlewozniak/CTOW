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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
        }
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            Audite a = new Audite();
            this.Close();
            a.Show();
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            MainWindow service = new MainWindow();
            this.Close();
            service.Show();
        }
    }
}
