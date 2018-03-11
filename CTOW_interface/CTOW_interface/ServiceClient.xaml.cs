using CTOW_interface.Backend;
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
        BddConnection bddConnection;
        List<Home> listHome;
        public MainWindow()
        {
            InitializeComponent();
            bddConnection = new BddConnection();
            listHome = new List<Home>();
        }

        private void AffichDetail(object sender, RoutedEventArgs e)
        {
            GraphMonth graphique = new GraphMonth();
            this.Close();
            graphique.Show();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void SliderPollution_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelSliderPollution.Content = (bddConnection.GetMaxPollution()/10)*SliderPollution.Value;
        }

        private void SliderBruit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelSliderBruit.Content = (bddConnection.GetMaxSonor()/10)*SliderBruit.Value;
        }

        private void SliderDebit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelSliderInternet.Content = (bddConnection.GetMaxInternet() / 10) * SliderBruit.Value;
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            listHome = bddConnection.GetHome(Convert.ToDouble(LabelSliderPollution.Content), Convert.ToDouble(LabelSliderBruit.Content), Convert.ToDouble(LabelSliderInternet.Content));
            ListBoxHome.ItemsSource = listHome;
        }

        private void ListBoxHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double poll;
            double sonor;
            double vitesse;
            Home newHome = (Home)ListBoxHome.SelectedItem;
            foreach(Device device in newHome.HomeDeviceGet)
            {
                switch(device.DescriptionGet)
                {
                    case "air quality":
                        poll= bddConnection.GetAvgDataDevice(device.GuidGet);
                        break;
                    case "sonor":
                        sonor= bddConnection.GetAvgDataDevice(device.GuidGet);
                        break;
                    case "internet":
                        vitesse= bddConnection.GetAvgDataDevice(device.GuidGet);
                        break;
                }
            }
            bddConnection.ge
        }
    }
}
