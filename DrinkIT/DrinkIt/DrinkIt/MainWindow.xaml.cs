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
using DrinkIt.bll;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Register register;
        private Home home;

        private string username;
        private string password;
        public MainWindow()
        {
            InitializeComponent();
            home = new Home();
            register = new Register();
        }

        private bool isValidUsernameAndPassword(string username, string password)
        {
            bool validation = false;

            if (username.Length > 5 && username.Length < 20 && password.Length > 5 && password.Length < 20)
                validation = true;


            return validation;
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            int records = 5;
            
            DataGenerator.Generate(records);
            
            DataView dv = new DataView();
            
            dv.PrintUsers();
            
            Application.Current.Shutdown();
        }

        private void Sign_in_button_click(object sender, RoutedEventArgs e)
        {
            username = UsernameBox.Text;
            password = PasswordBox.Password;

            if (isValidUsernameAndPassword(username, password))
            {
                this.Close();
                home.Show();
            }
            else
            {
                UsernameBox.Text = "";
                PasswordBox.Password = "";
                UsernameBox.BorderBrush = Brushes.Red;
                PasswordBox.BorderBrush = Brushes.Red;
                InvalidMessageBox.Text = "Username and password length should be from 5 to 20 symbols";
            }

        }

        private void Sign_up_button_click(object sender, RoutedEventArgs e)
        {
            register.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
