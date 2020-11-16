using System.Windows;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для MenuOfDrinks.xaml
    /// </summary>
    public partial class MenuOfDrinks : Window
    {
        private Home home;
        private Calendar calendar;
        private Setting setting;
        private Statistic statistic;

        public MenuOfDrinks()
        {
            InitializeComponent();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            home = new Home();
            this.Close();
            home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            calendar = new Calendar();
            this.Close();
            calendar.Show();
        }

        private void StatisticPageButton_Click(object sender, RoutedEventArgs e)
        {
            statistic = new Statistic();
            this.Close();
            statistic.Show();
        }

        private void NotificationPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            setting = new Setting();
            this.Close();
            setting.Show();
        }
    }
}
