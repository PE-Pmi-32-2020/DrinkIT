namespace DrinkIt
{
using System.Windows;
using DrinkIt.PL;

public partial class MainWindow
    {
        private Register _register;
        private Login _login;

        public MainWindow()
        {
            this.InitializeComponent();
            this._register = new Register();
            this._login = new Login();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Sign_in_button_click(object sender, RoutedEventArgs e)
        {
            this._login.Show();
            this.Close();
        }

        private void Sign_up_button_click(object sender, RoutedEventArgs e)
        {
            this._register.Show();
            this.Close();
        }
    }
}
