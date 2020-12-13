using System.Collections.Generic;
using System.Data;
using System.Linq;
using DrinkIt.data;
using DrinkIt.models;

namespace DrinkIt
{
using System;
using System.Windows;
using DrinkIt.bll;

/// <summary>
/// This is Home page  class.
/// </summary>
public partial class Home
    {
        private MenuOfDrinks _menu;
        private Setting _setting;
        private Statistic _statistic;
        private UserService _userService;
        private Context _context;
        public Home()
        {
            this.InitializeComponent();

            this._userService = new UserService();

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
                    Console.WriteLine(e);
                    this.GoalLabel.Content = 2000;
                }
            }
            ShowHistory();
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
            this._context = new Context();
            List<DrunkDrinks> drunksdrinks = new List<DrunkDrinks>();
            string username = (string)Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            drunksdrinks = this._context.DrunkDrinks.Where(d => d.User.Id == (int)user.Id).ToList();
            DataTable dt = new DataTable("history");
            DataColumn dc1 = new DataColumn("beverage", typeof(string));
            DataColumn dc2 = new DataColumn("volume", typeof(int));
            DataColumn dc3 = new DataColumn("time", typeof(DateTime));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dataGrid1.ItemsSource = dt.DefaultView;
            DataRow dr;
            for (int i = 0; i < drunksdrinks.Count(); i++)
            {
                dr = dt.NewRow();
                dr["beverage"] = drunksdrinks[i].Beverage.Id.ToString();
                dr["volume"] = drunksdrinks[i].Volume;
                dr["time"] = drunksdrinks[i].Time;
                dt.Rows.Add(dr);
            }
            DataView view;
            view = new DataView(dt);

            dataGrid1.ItemsSource = view;
        }
        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._setting = new Setting();
            this.Close();
            this._setting.Show();
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            ShowHistory();
        }

        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
