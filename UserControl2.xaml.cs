using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Serialization;
using Firebase.Database;
using Firebase.Database.Query;
namespace first
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : Page
    {
        private static string firebaseUrl = "https://bankmanagement-23640-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public UserControl2()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient(firebaseUrl);
        }



        private async void gen_AccNum(object sender, RoutedEventArgs e)
        {

                    if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(pass.Password) || string.IsNullOrWhiteSpace(Bal.Text))
                    {
                
                        MessageBox.Show("fill all the required fileds");
            
                    }
                    else
                    {
                    
                    Random random = new Random();
                    int randomNumber = random.Next(10000, 100000);
                    Debug.WriteLine(randomNumber);
                    Debug.WriteLine(random);
                    accNum.Text = randomNumber.ToString();
                    


                    Clipboard.SetText(accNum.Text);
                    var user = new User
                    {
                        Name = name.Text,
                        Email = email.Text,
                        Pass = pass.Password,
                        AccNum = accNum.Text,
                        Bal = Bal.Text,
                    };
                    await firebaseClient.Child("Users").Child(accNum.Text).PutAsync(user);
                    name.Clear();
                    email.Clear();
                    pass.Clear();
                    Bal.Clear();
                    }
                

        }
        public void checkForBal(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[0-9]+$") || e.Text.Contains(" "))  // No spaces allowed
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Double x = buttonImage.ActualWidth;
            Double y = buttonImage.ActualHeight;

            buttonImage.Height = y;
            buttonImage.Width = x;

            buttonImage.Source = new BitmapImage(new Uri("./Images/check.png", UriKind.Relative));

        }
        private void signIn(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("UserControl1.xaml", UriKind.Relative));
        }
    }
}
public class User
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Pass { get; set; } = string.Empty;
    public string AccNum { get; set; } = string.Empty;
    public string Bal { get; set; } = string.Empty;

}
