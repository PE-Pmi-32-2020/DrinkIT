using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Text.RegularExpressions;
using System.Globalization;
using Npgsql;
using System.Diagnostics;
using DrinkIt.bll;
using DrinkIt.data;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    /// 
    public partial class Register : Window
    {
        private Profile profile;
        private UserService _userService;

        public Register()
        {
            InitializeComponent();
            profile = new Profile();

            _userService = new UserService();
        }
        
        public static bool IsValidUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            Regex rgx = new Regex("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$");

            return !rgx.IsMatch(username);
        }

        private bool isValidPassword(string password)
        {
            return password.Length > 5 && password.Length < 20;
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            string confirmpassword = ConfirmPasswordBox.Password;


            if (IsValidUserName(username) && isValidPassword(password) && password == confirmpassword)
            {
                if (isValidPassword(password) && isValidPassword(confirmpassword))
                {
                    if (password == confirmpassword)
                    {
                        try
                        {
                            _userService.Register(username, password);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                            throw;
                        }
                        
                        this.Close();
                        profile.Show();
                    }
                    else
                    {
                        InvalidMessageBox.Text = "Passwords must match";
                        PasswordBox.BorderBrush = Brushes.Red;
                        ConfirmPasswordBox.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    InvalidMessageBox.Text = "Password length should be from 5 to 20 symbols";
                    PasswordBox.BorderBrush = Brushes.Red;
                    ConfirmPasswordBox.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                InvalidMessageBox.Text = "Email should be like example@example.com";
                UsernameBox.BorderBrush = Brushes.Red;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    internal class MassageBox
    {
    }
}