﻿using DrinkIt.enums;
using DrinkIt.models;

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
        private SettingService _settingService;
        private Context _context;


        public Setting()
        {
            this.InitializeComponent();

            this._userService = new UserService();
            this._settingService=new SettingService();
            this._context = new Context();
            if (Application.Current.Properties["userId"] != null)
            {
                int id = (int)Application.Current.Properties["userId"];
                try
                {
                    string username = (string)Application.Current.Properties["username"];
                    User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
                    string gender = this._context.UserInfos.Where(d => d.User.Id == (int)user.Id).Select(x => x.Gender).SingleOrDefault().ToString();
                    this.IntakeSex.Text = gender;
                    this.IntakeGoal.Text = this._userService.GetUserInfo(id).Goal.ToString();
                    this.Weight.Text = this._userService.GetUserInfo(id).Weight.ToString();
                    this.DateBirthBox.SelectedDate = this._userService.GetUserInfo(id).DateOfBirth;
                    this.Reminder.Text = this._userService.GetUserData(id).PeriodOfNotification.ToString();
                    this.WakeUpTime.Text = this._userService.GetUserData(id).WakeUpTime.ToString();
                    this.SleepTime.Text = this._userService.GetUserData(id).SleepTime.ToString();
                    

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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateOfBirth = this.DateBirthBox.SelectedDate.Value;
            int weight = int.Parse(this.Weight.Text);
            TimeSpan sleep = TimeSpan.Parse(this.SleepTime.Text);
            TimeSpan wakeUp = TimeSpan.Parse(this.WakeUpTime.Text);
            TimeSpan period = TimeSpan.Parse(this.Reminder.Text);
            int goal = int.Parse(this.IntakeGoal.Text);
            string gender = this.IntakeSex.Text;
            this._settingService.UpdateInfo(dateOfBirth, weight, sleep, wakeUp, period, goal, gender);

        }

        
    }
}
