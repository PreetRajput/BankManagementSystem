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
using Firebase.Database;
using Firebase.Database.Query;

namespace first
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class DepositMoney : Page
    {
        string name;
        string useraccNum;
        string balance;
        private static string firebaseUrl = "https://bankmanagement-23640-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public  DepositMoney(string nameOfUser, string AccNum, string bal)
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient(firebaseUrl);
            name = nameOfUser;
            useraccNum = AccNum;
            Debug.WriteLine(name);
            Header.Text = name;
            var mine = firebaseClient.Child("Users").Child(useraccNum).OnceSingleAsync<User>();
            this.balance = bal;
            Balance.Text = balance;
        }
        private void checkAccNum(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[0-9]+$") || e.Text.Contains(" "))  // No spaces allowed
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void checkBal(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[0-9]+$") || e.Text.Contains(" "))  // No spaces allowed
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            string stringOfOtherAccNum = otherAccNum.Text;
            int otheraccNum = int.Parse(otherAccNum.Text);

            if (otherAccNum.Text==useraccNum )
            {
                MessageBox.Show("Only trasnfer to different accounter holders are allowed!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                
            if (otheraccNum > 0)
            {
            int trash = int.Parse(this.balance) - int.Parse(balVal.Text);
            this.balance = trash.ToString();
            Balance.Text = this.balance;
                var user = await firebaseClient.Child("Users").Child(stringOfOtherAccNum).OnceSingleAsync<User>();
                var mine = await firebaseClient.Child("Users").Child(useraccNum).OnceSingleAsync<User>();
                int balance = int.Parse(user.Bal);
                int myBalance = int.Parse(mine.Bal);
                await firebaseClient.Child("Users").Child(stringOfOtherAccNum).PatchAsync(new { Bal = balance + int.Parse(balVal.Text) });
                await firebaseClient.Child("Users").Child(useraccNum).PatchAsync(new { Bal = myBalance - int.Parse(balVal.Text) });

                balVal.Clear();
                otherAccNum.Clear();
                remarks.Clear();


            }
                else
                {
                         MessageBox.Show("Please enter a valid amount", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            }

            
        }
    }
}
