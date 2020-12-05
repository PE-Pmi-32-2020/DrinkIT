namespace DrinkIt
{
using System;
using System.Linq;
using System.Windows;
using DrinkIt.bll;
using DrinkIt.data;

    /// <summary>
    /// Логіка взаємодії для Setting.xaml
    /// </summary>
public partial class Setting
    {
        private Home _home;
        private MenuOfDrinks _menu;
        private Statistic _statistic;
        private UserService _userService;


        public Setting()
        {
            this.InitializeComponent();

            this._userService = new UserService();

            if (Application.Current.Properties["userId"] != null)
            {
                int id = (int)Application.Current.Properties["userId"];
                try
                {
                    this.IntakeGoal.Text = this._userService.GetUserInfo(id).Goal.ToString();
                    this.Weight.Text = this._userService.GetUserInfo(id).Weight.ToString();
                    this.DateBirthBox.SelectedDate = this._userService.GetUserInfo(id).DateOfBirth;
                    this.SexBoxSettings.Text = "MALE";
                    this.Reminder.Text = "30";
                    this.WakeUpTime.Text = "8:30";
                    this.SleepTime.Text = "22:00";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this.IntakeGoal.Text = "2000";
                    this.Reminder.Text = "30";
                    this.WakeUpTime.Text = "8:30";
                    this.SleepTime.Text = "22:00";
                }
            }
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
        }
    }
}
