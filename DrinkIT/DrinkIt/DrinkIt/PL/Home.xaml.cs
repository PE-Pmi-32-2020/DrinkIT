using System.Windows;
using DrinkIt.bll;
using System;
using System.Collections.Generic;
using DrinkIt.models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Runtime.Remoting.Messaging;
using Npgsql;

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
            Show();
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
            string username = (string) Application.Current.Properties["username"];
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;"+"Password=q111;Database=postgres;");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM beverage WHERE id = beverage_id),volume,time,user_id FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1)",conn);
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
                view=new DataView(dt);

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
            string username = (string) Application.Current.Properties["username"];
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;"+"Password=q111;Database=postgres;");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM beverage WHERE id = beverage_id),volume,time,user_id FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1)",conn);
            command.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            
            DataRow dr;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    if (dataReader[3] != null)
                    {
                        dr = dt.NewRow();
                        dr["beverage"] = dataReader[0];
                        dr["volume"] = dataReader[1];
                        dr["time"] = dataReader[2];
                        dt.Rows.Add(dr);
                    }
                }

                DataView view;
                view=new DataView(dt);

                dataGrid1.ItemsSource = view;
            }
        }
    }
    public class TableDataRow
    {
        public TableDataRow(List<string> cells)
        {
            Cells = cells;
        }
        public List<string> Cells { get; }
    }
}
