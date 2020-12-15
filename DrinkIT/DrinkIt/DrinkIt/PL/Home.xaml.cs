using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using DrinkIt.data;
using DrinkIt.models;
using DrinkIt.Utils;

namespace DrinkIt
{
using System;
using System.Windows;
using DrinkIt.bll;
    using Npgsql;

    /// <summary>
    /// This is Home page  class.
    /// </summary>
    public partial class Home
    {
        private MenuOfDrinks _menu;
        private Setting _setting;
        private Statistic _statistic;
        private UserService _userService;
        private DrunkDrinkService _drunkDrinksService;
        private StatisticService _statisticService;
        private Context _context;
        
        public Home()
        {
            this.InitializeComponent();
            Logger.InitLogger();

            this._userService = new UserService();
            this._drunkDrinksService = new DrunkDrinkService();
            this._statisticService = new StatisticService();
            

            if (Application.Current.Properties["userId"] != null)
            {
                int id = (int)Application.Current.Properties["userId"];
                try
                {
                    this.GoalLabel.Content = this._userService.GetUserInfo(id).Goal;
                    this.WaterNormLabel.Content = this._userService.GetUserData(id).WaterNorm;
                }
                catch (Exception e)
                {
                    Logger.Log.Error(e.Message);
                    this.GoalLabel.Content = 2000;
                }
            }


            ShowHistory();

            int percent = _drunkDrinksService.CurrentlyPercent();
            DailyInTake2.Text = percent + "%";
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            this._menu = new MenuOfDrinks();
            this.Close();
            this._menu.Show();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
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

        private void ShowHistory()
        {

            try
            {
                _drunkDrinksService.ShowHistory(dataGrid1);
            }
            catch (Exception e)
            {
                Logger.Log.Info(e.Message);
                throw;
            }

        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._setting = new Setting();
            this.Close();
            this._setting.Show();
        }
        
        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
