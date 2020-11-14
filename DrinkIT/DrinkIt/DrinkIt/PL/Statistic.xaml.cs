﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {

        private Home home;
        private Calendar calendar;
        private Setting setting;
        private MenuOfDrinks menu;

        public Statistic()
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