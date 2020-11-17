using System.Windows;
using System.Windows.Controls;
using DrinkIt;
using DrinkIt.PL;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Register _register;
        private Login _login;
        
        
        public MainWindow()
        {
            InitializeComponent();
            _register = new Register();
            _login = new Login();
        }

        

        private void exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Sign_in_button_click(object sender, RoutedEventArgs e)
        {
            _login.Show();
            this.Close();
        }

        private void Sign_up_button_click(object sender, RoutedEventArgs e)
        {
            _register.Show();
            Close();
        }
    }
}
