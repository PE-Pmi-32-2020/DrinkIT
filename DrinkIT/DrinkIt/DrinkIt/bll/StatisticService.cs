using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DrinkIt.data;
using DrinkIt.models;
using Npgsql;

namespace DrinkIt.bll
{
    public class StatisticService
    {
        private readonly Context _context;

        public StatisticService()
        {
            _context = new Context();
        }

        public void ShowStatistic(DataGrid dataGrid1, DatePicker datePicker1, TextBlock DailyInTake2)
        {
            datePicker1.DisplayDateEnd = DateTime.Today.Date;
            DateTime dateTimePicker = datePicker1.SelectedDate.Value.Date.Date;
            List<DrunkDrinks> drunksdrinks = new List<DrunkDrinks>();
            string username = (string) Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            drunksdrinks = this._context.DrunkDrinks
                .Where(d => d.User.Id == (int) user.Id && d.Time.Date == dateTimePicker).ToList();
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
            NpgsqlCommand command =
                new NpgsqlCommand(
                    "SELECT (SELECT name FROM beverage WHERE id = beverage_id) FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1) and date(time) = @param2",
                    conn);
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
        
        public int CurrentlyPercent(List<DrunkDrinks> drunkdrinks, User user)
        {
            double percent = 0;
            double goal = this._context.UserInfos.Where(d => d.User.Id == (int) user.Id).Select(x => x.Goal)
                .SingleOrDefault();
            double current_drunk = 0;
            for (int i = 0; i < drunkdrinks.Count(); i++)
            {
                current_drunk += drunkdrinks[i].Volume;
            }

            percent = current_drunk / goal;
            return Convert.ToInt32(percent * 100);
        }
    }
}