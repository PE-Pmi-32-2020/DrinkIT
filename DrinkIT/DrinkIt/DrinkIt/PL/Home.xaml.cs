using System.Collections.Generic;
using System.Data;
using System.Linq;
using DrinkIt.data;
using DrinkIt.models;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using System;
using System.Windows;
using DrinkIt.bll;
using Npgsql;

namespace DrinkIt
{
    using DrinkIt.PL;

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
        private Notification _notification;
       
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
            double percent = CurrentlyPercent();
            DailyInTake2.Text = percent.ToString() + "%";
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

        

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void ShowHistory()
        {
            this._context = new Context();
            List<DrunkDrinks> drunksdrinks = new List<DrunkDrinks>();
            string username = (string)Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            drunksdrinks = this._context.DrunkDrinks.Where(d => d.User.Id == (int)user.Id && d.Time.Date == DateTime.Today.Date).ToList();
            DataTable dt = new DataTable("history");
            DataColumn dc1 = new DataColumn("beverage", typeof(string));
            DataColumn dc2 = new DataColumn("volume", typeof(int));
            DataColumn dc3 = new DataColumn("time", typeof(DateTime));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dataGrid1.ItemsSource = dt.DefaultView;
            NpgsqlConnection conn = new NpgsqlConnection(_context.connectionString);
            conn.Open();
            
            DataRow dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM beverage WHERE id = beverage_id) FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1) and date(time) = current_date",conn);
            command.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            for (int i = 0; i < drunksdrinks.Count() ; i++)
            {
                dataReader.Read();
                dr = dt.NewRow();
                dr["beverage"] = dataReader[0].ToString();
                dr["volume"] = Convert.ToString(drunksdrinks[i].Volume);
                dr["time"] = drunksdrinks[i].Time;
                dt.Rows.Add(dr);
            }
            DataView view;
            view = new DataView(dt);

            dataGrid1.ItemsSource = view;
        }

        private double CurrentlyPercent()
        {
            this._context = new Context();
            List<DrunkDrinks> drunksdrinks = new List<DrunkDrinks>();

            string username = (string)Application.Current.Properties["username"];
            double percent = 0;
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            drunksdrinks = this._context.DrunkDrinks.Where(d => d.User.Id == (int)user.Id && d.Time.Date == DateTime.Today.Date).ToList();
            double goal = this._context.UserInfos.Where(d => d.User.Id == (int)user.Id).Select(x=>x.Goal).SingleOrDefault();
            double current_drunk = 0;
            for (int i = 0; i < drunksdrinks.Count(); i++)
            {
                current_drunk += drunksdrinks[i].Volume;
            }
            percent = current_drunk / goal;
            return percent * 100;
        }
        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._setting = new Setting();
            this.Close();
            this._setting.Show();
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            double percent = CurrentlyPercent();
            DailyInTake2.Text = percent.ToString() + "%";
            ShowHistory();
        }

        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
