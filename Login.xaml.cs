using System;
using System.Collections.Generic;
using System.IO;
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
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TeaPad_Predict
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CkscA67g0zNM8fUtPFzQvIgUZjRFz2GDl5ISwlgM",
            BasePath = "https://teapadsendtonotification.firebaseio.com/"

        };
        IFirebaseClient client;
        public Login()
        {
            InitializeComponent();
            client = new FirebaseClient(config);
            if (client != null)
            {
                 MessageBox.Show("Connectiion is established");
            }
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if ((string.IsNullOrEmpty(Password.Password))||(string.IsNullOrEmpty(Username.Text)))
            {
                MessageBox.Show("Password or username is incorrect");

            }else if((Username.Text == "Rusiru")&&(Password.Password =="1234"))
            {
                MessageBox.Show("Logged in");
                Openning op = new Openning();
                op.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password or username is incorrect");
              
            }
            //else
            //{
               // FirebaseResponse response = client.Get("User/");
                

              //  foreach( var get in result)
                //{
                  //  var userresult = get.Value.Username;
                    //var passresult = get.Value.Password;
                    
                    //if(Username.Text == userresult)
                    //{
                      //  if(Password.Password == passresult)
                        //{
                          //  MessageBox.Show("Welcome " +Username.Text);
                           // Username = Username.Text;
                            //MainWindow md = new MainWindow();
                            //this.Hide();
                            //md.ShowDialog();

                        //}

                    //}


                //}
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
