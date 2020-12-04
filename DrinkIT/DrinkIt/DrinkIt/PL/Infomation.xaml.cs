namespace DrinkIt
{
using System.Windows;

/// <summary>
/// This is Information page  class.
/// </summary>
public partial class Infomation
    {
        private MenuOfDrinks _menuOfDrinks;
        private Home _home;
        private Statistic _statistic;
        private Setting _setting;

        public Infomation()
        {
            this.InitializeComponent();
            this._menuOfDrinks = new MenuOfDrinks();
            this._home = new Home();
            this._statistic = new Statistic();
            this._setting = new Setting();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._menuOfDrinks.Show();
        }

        private void StatisticPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._statistic.Show();
        }

        private void NotificationPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._setting.Show();
        }
    }
}
