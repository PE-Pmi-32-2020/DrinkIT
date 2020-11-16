using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DrinkIt.bll;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Register _register;
        private Home _home;
        private AuthService _authService;
        
        public MainWindow()
        {
            InitializeComponent();
            _home = new Home();
            _register = new Register();
            _authService = new AuthService();
        }

        private bool isValidUsernameAndPassword(string username, string password)
        {
            return username.Length > 5 && username.Length < 20 && password.Length > 5 && password.Length < 20;
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Sign_in_button_click(object sender, RoutedEventArgs e)
        {
            String username = UsernameBox.Text;
            String password = PasswordBox.Password;

            if (isValidUsernameAndPassword(username, password))
            {

                _authService.Login(username, password);
                
                Close();
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

        private void Sign_up_button_click(object sender, RoutedEventArgs e)
        {
            _register.Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
