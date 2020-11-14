using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private MenuOfDrinks menu;
        private Calendar calendar;
        private Setting setting;
        private Statistic statistic;


        public Home()
        {
            InitializeComponent();
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            menu = new MenuOfDrinks();

            this.Close();
            menu.Show();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            menu = new MenuOfDrinks();
            this.Close();
            menu.Show();
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
