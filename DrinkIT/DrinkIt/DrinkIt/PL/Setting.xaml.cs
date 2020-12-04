using DrinkIt.bll;
using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        private Home home;
        private MenuOfDrinks menu;
        private Statistic statistic;
        private UserService _userService;
        private readonly Context _context;


        public Setting()
        {
            InitializeComponent();
            

            _userService = new UserService();

            if (Application.Current.Properties["userId"] != null)
            {
                int id = (int)Application.Current.Properties["userId"];
                try
                {
                    IntakeGoal.Text = _userService.GetUserInfo(id).Goal.ToString();
                    Weight.Text = _userService.GetUserInfo(id).Weight.ToString();
                    DateBirthBox.SelectedDate = _userService.GetUserInfo(id).DateOfBirth;
                    SexBoxSettings.Text = "MALE";
                    Reminder.Text = "30";
                    WakeUpTime.Text = "8:30";
                    SleepTime.Text = "22:00";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    IntakeGoal.Text = "2000";
                    Reminder.Text = "30";
                    WakeUpTime.Text = "8:30";
                    SleepTime.Text = "22:00";
                }
            }
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            home = new Home();
            this.Close();
            home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            menu = new MenuOfDrinks();
            this.Close();
            menu.Show();
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

        }
    }
}
