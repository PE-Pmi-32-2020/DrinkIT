using Npgsql;

namespace DrinkIt
{
    using DrinkIt.data;
    using DrinkIt.models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
public partial class Statistic
    {
        private Home _home;
        private Setting _setting;
        private MenuOfDrinks _menu;
        private Statistic _statistic;
        private Context _context;

        public Statistic()
        {
            this.InitializeComponent();
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
            if (datePicker1!=null)
            {
                DateTime dateTimePicker = datePicker1.SelectedDate.Value.Date.Date;
                this._context = new Context();
                List<DrunkDrinks> drunksdrinks = new List<DrunkDrinks>();
                string username = (string)Application.Current.Properties["username"];
                User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
                drunksdrinks = this._context.DrunkDrinks.Where(d => d.User.Id == (int)user.Id && d.Time.Date == dateTimePicker).ToList();
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
                NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM beverage WHERE id = beverage_id) FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1) and date(time) = @param2",conn);
                command.Parameters.Add(new NpgsqlParameter("@param1", username));
                command.Parameters.Add(new NpgsqlParameter("@param2", dateTimePicker));

                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; i < drunksdrinks.Count; i++)
                {
                    dataReader.Read();
                    dr = dt.NewRow();
                    dr["beverage"] = dataReader[0].ToString();
                    dr["volume"] = drunksdrinks[i].Volume;
                    dr["time"] = drunksdrinks[i].Time;
                    dt.Rows.Add(dr);
                }
                DataView view;
                view = new DataView(dt);
                dataGrid1.ItemsSource = view;

                int percent = CurrentlyPercent(drunksdrinks, user);

                DailyInTake2.Text = percent + "%";
            }
        }

        private int CurrentlyPercent(List<DrunkDrinks> drunkdrinks, User user)
        {
            double percent = 0;
            double goal = this._context.UserInfos.Where(d => d.User.Id == (int)user.Id).Select(x => x.Goal).SingleOrDefault();
            double current_drunk = 0;
            for (int i = 0; i < drunkdrinks.Count(); i++)
            {
                current_drunk += drunkdrinks[i].Volume;
            }
            percent = current_drunk / goal;
            return Convert.ToInt32(percent * 100);
        }
        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            ShowStatistics();
        }
    }
}
