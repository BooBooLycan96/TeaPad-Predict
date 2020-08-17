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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace TeaPad_Predict
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

        private void Drone_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainWindow N = new Navigation.MainWindow();
            N.Show();
        }

        private void Harvest_Click(object sender, RoutedEventArgs e)
        {
            Harvest H = new Harvest();
            H.Show();
        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            TeaPad.MainWindow W = new TeaPad.MainWindow();
            W.Show();
        }

     
    }
}
