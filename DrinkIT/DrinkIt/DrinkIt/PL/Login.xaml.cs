using System;
using System.Windows;
using System.Windows.Media;
using DrinkIt.bll;

namespace DrinkIt.PL
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Home _home;
        private AuthService authService;
        public Login()
        {
            InitializeComponent();
            authService = new AuthService();
        }
        private bool isValidUsernameAndPassword(string username, string password)
        {
            return username.Length > 5 && username.Length < 20 && password.Length > 5 && password.Length < 20;
        }
        private void Sign_in_button_click(object sender, RoutedEventArgs e)
        {
            String username = UsernameBox.Text;
            String password = PasswordBox.Password;

            if (isValidUsernameAndPassword(username, password))
            {

                authService.Login(username, password);

                Close();
                _home = new Home();
                _home.Show();
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

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
