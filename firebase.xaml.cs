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

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace TeaPad
{


    /// <summary>
    /// Interaction logic for firebase.xaml
    /// </summary>
    public partial class firebase : Window

    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "juB2PLWgrL6W0HQ8gSzviLwVq6lzNS77XCEj4oei",
            BasePath = "https://fir-2be7c.firebaseio.com/"
        };

        IFirebaseClient client;
        private string ID;
        private string Area;
        private string Num_of_workers;
        private string Date;

        public firebase()
        {
            InitializeComponent();
           


        }

        private void firebase_load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show(" connection is established");
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = new Data
            {
                ID = txt_1.Text,
                Area = txt_2.Text,
                Num_of_workers = txt_3.Text,
                Date = Datepicker1.Text,

               

            };

            
            SetResponse response = await client.SetTaskAsync("Details/"+txt_1.Text,data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted"+ result.ID);
        }

        private async void btn2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Data
            {
                ID = txt_1.Text,
                Area = txt_2.Text,
                Num_of_workers = txt_3.Text,
                Date = Datepicker1.Text,

            };

            FirebaseResponse response = await client.UpdateTaskAsync("Details/" + txt_1.Text, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Updated at ID :"+ result.ID);

        }
        private async void btn3_Click(object sender, RoutedEventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Details/" + txt_1.Text);
            MessageBox.Show("Data Deleted at ID :" + txt_1.Text);


        }
    }

    
}
