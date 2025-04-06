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
using System.Xml.Linq;
using Firebase.Database;
using Firebase.Database.Query;
namespace first
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : Page
    {

        private static string firebaseUrl = "https://bankmanagement-23640-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public UserControl1()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient(firebaseUrl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("UserControl2.xaml", UriKind.Relative));

        }
        private async void lobby(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(accNum.Text) || string.IsNullOrWhiteSpace(pass.Password))
            {
                MessageBox.Show("Fill Out All The Required Fields");
            }
            else
            {
                var user = await firebaseClient.Child("Users").Child(accNum.Text).OnceSingleAsync<User>();

                if (user != null)
                {
                    if (user.Pass==pass.Password)
                    {
                        this.NavigationService.Navigate(new Page1(user.Name, user.AccNum, user.Bal));
                    }
                    else
                        MessageBox.Show("Wrong Pass");
                }
                else
                    MessageBox.Show("User not found!");
                
            }
        }

    }
}


