using System;
using System.Windows;
using System.Windows.Media;
using DrinkIt.bll;

namespace DrinkIt
{
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

            if (!IsValidUserName(username))
            {
                InvalidMessageBox.Text = "Username cannot be empty";
                UsernameBox.BorderBrush = Brushes.Red;
                return;
            }

            if (!isValidPassword(password))
            {
                InvalidMessageBox.Text = "Password length should be from 5 to 20 symbols";
                PasswordBox.BorderBrush = Brushes.Red;
                ConfirmPasswordBox.BorderBrush = Brushes.Red;
                return;
            }

            if (password != confirmpassword)
            {
                InvalidMessageBox.Text = "Passwords must match";
                PasswordBox.BorderBrush = Brushes.Red;
                ConfirmPasswordBox.BorderBrush = Brushes.Red;
                return;
            }


            try {
                _userService.Register(username, password);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }


            Close();
            _profile.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}