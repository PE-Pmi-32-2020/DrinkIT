using System;
using System.Windows;
using DrinkIt.bll;
using DrinkIt.Utils;

namespace DrinkIt
{
    /// <summary>
    /// Логіка взаємодії для Setting.xaml
    /// </summary>
public partial class Setting
    {
        private Home _home;
        private MenuOfDrinks _menu;
        private Statistic _statistic;
        private UserService _userService;
        private SettingService _settingService;


        public Setting()
        {
            this.InitializeComponent();
            Logger.InitLogger();

            this._userService = new UserService();
            this._settingService=new SettingService();

            if (Application.Current.Properties["userId"] != null)
            {
                int id = (int)Application.Current.Properties["userId"];
                try
                {
                    this.IntakeGoal.Text = this._userService.GetUserInfo(id).Goal.ToString();
                    this.Weight.Text = this._userService.GetUserInfo(id).Weight.ToString();
                    this.DateBirthBox.SelectedDate = this._userService.GetUserInfo(id).DateOfBirth;
                    this.Reminder.Text = this._userService.GetUserData(id).PeriodOfNotification.ToString();
                    this.WakeUpTime.Text = this._userService.GetUserData(id).WakeUpTime.ToString();
                    this.SleepTime.Text = this._userService.GetUserData(id).SleepTime.ToString();
                    this.SexBoxSettings.Text = "MIXED";
                }
                catch (Exception e)
                {
                    Logger.Log.Error(e.Message);
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateOfBirth = this.DateBirthBox.SelectedDate.Value;
            int weight = int.Parse(this.Weight.Text);
            TimeSpan sleep = TimeSpan.Parse(this.SleepTime.Text);
            TimeSpan wakeUp = TimeSpan.Parse(this.WakeUpTime.Text);
            TimeSpan period = TimeSpan.Parse(this.Reminder.Text);
            int goal = int.Parse(this.IntakeGoal.Text);
            string gender = this.SexBoxSettings.Text;
            this._settingService.UpdateInfo(dateOfBirth, weight, sleep, wakeUp, period, goal, gender);
            
            this._home = new Home();
            this.Close();
            _home.Show();

        }
    }
}
