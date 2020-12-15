using System;
using System.Windows;
using System.Windows.Media;
using DrinkIt.bll;
using DrinkIt.Utils;

namespace DrinkIt
{
    /// <summary>
/// This is Home page  class.
/// </summary>
public partial class Register
    {
        private Profile _profile;
        private UserService _userService;
        private MainWindow _mainWindow;

        public Register()
        {
            this.InitializeComponent();
            this._profile = new Profile();
            this._userService = new UserService();
            Logger.InitLogger();
        }

        private static bool IsValidUserName(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
        }

        private bool IsValidPassword(string password)
        {
            return password.Length > 5 && password.Length < 20;
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            string username = this.UsernameBox.Text;
            string password = this.PasswordBox.Password;
            string confirmpassword = this.ConfirmPasswordBox.Password;

            if (!IsValidUserName(username))
            {
                this.InvalidMessageBox.Text = "Username cannot be empty";
                this.UsernameBox.BorderBrush = Brushes.Red;
                return;
            }

            if (!this.IsValidPassword(password))
            {
                this.InvalidMessageBox.Text = "Password length should be from 5 to 20 symbols";
                this.PasswordBox.BorderBrush = Brushes.Red;
                this.ConfirmPasswordBox.BorderBrush = Brushes.Red;
                return;
            }

            if (password != confirmpassword)
            {
                this.InvalidMessageBox.Text = "Passwords must match";
                this.PasswordBox.BorderBrush = Brushes.Red;
                this.ConfirmPasswordBox.BorderBrush = Brushes.Red;
                return;
            }

            try
            {
                this._userService.Register(username, password);

            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception.Message);
                MessageBox.Show(exception.Message);
                return;
            }

            this.Close();
            this._profile.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._mainWindow = new MainWindow();
            this._mainWindow.Show();
        }
    }
}