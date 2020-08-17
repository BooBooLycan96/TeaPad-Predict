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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using System.Reflection.Emit;

namespace TeaPad_Predict
{
    /// <summary>
    /// Interaction logic for Harvest.xaml
    /// </summary>
    /// 
    public partial class Harvest : Window
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CkscA67g0zNM8fUtPFzQvIgUZjRFz2GDl5ISwlgM",
            BasePath = "https://teapadsendtonotification.firebaseio.com/"

        };
        IFirebaseClient client;
        public DrawingImage Source { get; private set; }

        public Harvest()
        {
            InitializeComponent();
            client = new FirebaseClient(config);
        }

        private string run_cmd(String output1)//  \\new_color_test.py
        {

            string fileName = @"D:\ImageProcessor-release-3.0.0\new_color_test\new_color_test.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\abans\AppData\Local\Programs\Python\Python38\Python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false
               // CreateNoWindow = true
            };
            p.Start();

              output1 = p.StandardOutput.ReadToEnd();

            p.WaitForExit();
            Console.WriteLine(output1);
            
            Console.ReadLine();
            lbl1.Content = output1;
            return output1;
        }
        private string run_cmd2(String output2) // text.p
        {
            string fileName = @"D:\ImageProcessor-release-3.0.0\test\test.py";

            Process p1 = new Process();
            p1.StartInfo = new ProcessStartInfo(@"C:\Users\abans\AppData\Local\Programs\Python\Python38\Python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
               // CreateNoWindow = true,
            };
            p1.Start();

            output2 = p1.StandardOutput.ReadToEnd();

            p1.WaitForExit();
            Console.WriteLine(output2);

            Console.ReadLine();
            lbl1.Content = output2;
            return output2;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            run_cmd("output1");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                string selectedFileName = op.FileName;
                FileNameLabel.Content = selectedFileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
               

                FormatConvertedBitmap grayBitmapSource = new FormatConvertedBitmap();
                grayBitmapSource.BeginInit();
                grayBitmapSource.Source = bitmap;
                grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
                
                grayBitmapSource.EndInit();
                Image grayImage = new Image();
           
                grayImage.Width = 300; 
                grayImage.Source = grayBitmapSource;
                LayoutRoot.Source = grayBitmapSource;

                grayBitmapSource.DestinationFormat = PixelFormats.Bgr101010;
             

            }

            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var Data = new Data 
            {
                
                Notification_Status = TextBox1.Text,
                Date = TextBox2.Text,
            };
            SetResponse response = await client.SetTaskAsync("Production/"+TextBox2.Text,Data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted" + result.Date);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            run_cmd2("output2");
        }
    }   
    
}
