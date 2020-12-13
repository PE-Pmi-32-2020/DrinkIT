namespace DrinkIt
{
using System;
using System.Windows;
using DrinkIt.bll;
using System.Collections.Generic;
using DrinkIt.models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Runtime.Remoting.Messaging;
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

            this.Show();
            double percent = CurrentlyDrunkPercent();
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

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._setting = new Setting();
            this.Close();
            this._setting.Show();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Show()
        {
            DataTable dt = new DataTable("history");
            DataColumn dc1 = new DataColumn("beverage", typeof(string));
            DataColumn dc2 = new DataColumn("volume", typeof(int));
            DataColumn dc3 = new DataColumn("time", typeof(DateTime));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dataGrid1.ItemsSource = dt.DefaultView;
            string username = (string)Application.Current.Properties["username"];
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" + "Password=q111;Database=postgres;");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM beverage WHERE id = beverage_id),volume,time,user_id FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1)", conn);
            command.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader dataReader = command.ExecuteReader();



            DataRow dr;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {

                    dr = dt.NewRow();
                    dr["beverage"] = dataReader[0];
                    dr["volume"] = dataReader[1];
                    dr["time"] = dataReader[2];
                    dt.Rows.Add(dr);

                }
                DataView view;
                view = new DataView(dt);

                dataGrid1.ItemsSource = view;
            }
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable("history");
            DataColumn dc1 = new DataColumn("beverage", typeof(string));
            DataColumn dc2 = new DataColumn("volume", typeof(int));
            DataColumn dc3 = new DataColumn("time", typeof(DateTime));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dataGrid1.ItemsSource = dt.DefaultView;
            string username = (string)Application.Current.Properties["username"];
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" + "Password=q111;Database=postgres;");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM beverage WHERE id = beverage_id),volume,time,user_id FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1)", conn);
            command.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader dataReader = command.ExecuteReader();


            DataRow dr;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    
                        dr = dt.NewRow();
                        dr["beverage"] = dataReader[0];
                        dr["volume"] = dataReader[1];
                        dr["time"] = dataReader[2];
                        dt.Rows.Add(dr);
                    
                }

                DataView view;
                view = new DataView(dt);

                dataGrid1.ItemsSource = view;
            }
        }
        private double CurrentlyDrunkPercent()
        {
            string username = (string)Application.Current.Properties["username"];
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" + "Password=q111;Database=postgres;");
            conn.Open();
            NpgsqlCommand command_get_goal = new NpgsqlCommand("SELECT goal FROM usersinfo WHERE user_id = (SELECT id FROM users WHERE username = @param1)", conn);
            command_get_goal.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader goalReader = command_get_goal.ExecuteReader();

            NpgsqlConnection conn2 = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" + "Password=q111;Database=postgres;");
            conn2.Open();

            NpgsqlCommand command_det_volume = new NpgsqlCommand("SELECT sum(volume) FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1)", conn2);
            command_det_volume.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader volumeReader = command_det_volume.ExecuteReader();

            double percent = 0;
            if (goalReader!=null)
            {
                while (goalReader.Read()&&volumeReader.Read())
                {
                    double a = Convert.ToDouble(volumeReader[0]);
                    double b = Convert.ToDouble(goalReader[0]);
                    percent = a / b;
                }
            }
            return percent * 100;
        }
    }
    
}
