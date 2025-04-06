using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace first
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        String nameOfUser;
        string accNum;
        string bal;
        public Page1(String name, string AccNum, string userBal)
        {
            InitializeComponent();
            MainFrame.Navigate(new Cover());
            nameOfUser = name;
            accNum = AccNum;
            bal= userBal;
        }
        private void depositMoney(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DepositMoney(nameOfUser, accNum, bal));
        }
        private void withdrawMoney(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Withdraw(nameOfUser));
        }
        private void checkBal(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Bal(nameOfUser));
        }
        private void userInfo(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserInfo(nameOfUser));
        }
        private void sanitizeHand(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Sanitize(nameOfUser));
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }
    }
}
