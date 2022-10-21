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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double sunPower = 0;
        private double charged = 0;
        private bool isOnCharger = false;
        private bool doWeWantCharging = false;
        SHES.SHES shes;

        public MainWindow()
        {
            InitializeComponent();

            SHES.SHES shes = new SHES.SHES();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shes.SunPower = double.Parse(txtSunPower.Text);
            shes.Charged = double.Parse(txtCharged.Text);
            shes.IsOnCharger = chbIsOnCharger.IsChecked.Value;
            shes.DoWeWantCharging = chbWeWantCharging.IsChecked.Value;
        }
    }
}
