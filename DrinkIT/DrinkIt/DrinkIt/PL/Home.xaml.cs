﻿using System.Windows;
using DrinkIt.bll;
using System;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private MenuOfDrinks menu;
        private Setting setting;
        private Statistic statistic;
        private UserService _userService;


        public Home()
        {
            InitializeComponent();
            
            _userService = new UserService();
            
            if (Application.Current.Properties["userId"]!=null)
            {
                int id = (int) Application.Current.Properties["userId"];
                try
                {
                    GoalLabel.Content = _userService.GetUserInfo(id).Goal;
                    WaterNormLabel.Content = _userService.GetUserInfo(id).Weight * 30;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    GoalLabel.Content = 2000;
                }
            }

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
