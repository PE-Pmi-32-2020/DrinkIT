namespace DrinkIt.PL
{
using System;
using System.Windows;
using System.Windows.Media;
using DrinkIt.bll;
using DrinkIt.BLL;

    /// <summary>
    /// This is Login page  class.
    /// </summary>
    public partial class Login
    {
        private Home _home;
        private AuthService authService;
<<<<<<< HEAD
        private NotificationService notification;
=======
        private MainWindow _mainWindow;
>>>>>>> master

        public Login()
        {
            this.InitializeComponent();
            this.authService = new AuthService();
        }

        private bool IsValidUsernameAndPassword(string username, string password)
        {
            return username.Length > 5 && username.Length < 20 && password.Length > 5 && password.Length < 20;
        }

        private void Sign_in_button_click(object sender, RoutedEventArgs e)
        {
            string username = this.UsernameBox.Text;
            string password = this.PasswordBox.Password;

            if (this.IsValidUsernameAndPassword(username, password))
            {
                try
                {
                    this.authService.Login(username, password);
                    this.notification = new NotificationService();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }

                this.Close();
                this._home = new Home();
                this._home.Show();
            }
            else
            {
                this.UsernameBox.Text = string.Empty;
                this.PasswordBox.Password = string.Empty;
                this.UsernameBox.BorderBrush = Brushes.Red;
                this.PasswordBox.BorderBrush = Brushes.Red;
                this.InvalidMessageBox.Text = "Username and password length should be from 5 to 20 symbols";
            }
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._mainWindow = new MainWindow();
            _mainWindow.Show();
            
        }
    }
}