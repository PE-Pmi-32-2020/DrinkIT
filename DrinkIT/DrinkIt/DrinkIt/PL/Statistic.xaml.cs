namespace DrinkIt
{
using System.Windows;

    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
public partial class Statistic
    {
        private Home _home;
        private Setting _setting;
        private MenuOfDrinks _menu;
        private Statistic _statistic;

        public Statistic()
        {
            this.InitializeComponent();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this._home = new Home();
            this.Close();
            this._home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._menu = new MenuOfDrinks();
            this.Close();
            this._menu.Show();
        }

        private void StatisticPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._statistic = new Statistic();
            this.Close();
            this._statistic.Show();
        }

        private void NotificationPageButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._setting = new Setting();
            this.Close();
            this._setting.Show();
        }
    }
}
