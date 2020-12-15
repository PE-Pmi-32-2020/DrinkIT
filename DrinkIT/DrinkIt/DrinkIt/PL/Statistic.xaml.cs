using System;
using System.Windows;
using System.Windows.Controls;
using DrinkIt.bll;
using DrinkIt.Utils;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic
    {
        private Home _home;
        private Setting _setting;
        private MenuOfDrinks _menu;
        private Statistic _statistic;
        private StatisticService _statisticService;

        public Statistic()
        {
            this.InitializeComponent();
            _statisticService = new StatisticService();
            datePicker1.DisplayDateEnd = DateTime.Today.Date;
            
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

        private void ShowStatistics()
        {
            if (datePicker1.SelectedDate != null)
            {
                try
                {
                    _statisticService.ShowStatistic(dataGrid1, datePicker1, DailyInTake2);
                }
                catch (Exception e)
                {
                    Logger.Log.Info(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Select Date");
            }

        }

       

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            ShowStatistics();
        }
    }
}