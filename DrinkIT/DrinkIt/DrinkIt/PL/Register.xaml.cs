using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using DrinkIt.bll;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    /// 
    public partial class Register : Window
    {
        private Profile _profile;
        private UserService _userService;

        public Register()
        {
            InitializeComponent();
            _profile = new Profile();
            _userService = new UserService();
        }
        
        public static bool IsValidUserName(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
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
                        _profile.Show();
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