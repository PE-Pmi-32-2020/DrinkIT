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
    class DrunkDrinkService
    {
        private readonly Context _context;

        public DrunkDrinkService()
        {
            this._context = new Context();
        }

        public bool AddDrink(string beverageName, int volume)
        {
            if (beverageName == null || volume == 0)
            {
                return false;
            }

            string username = (string) Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);

            Beverage beverage = this._context.Beverages.SingleOrDefault(g => g.Name == beverageName);

            DrunkDrinks drink = new DrunkDrinks(volume, DateTime.Now, beverage, user);
            this._context.DrunkDrinks.Add(drink);
            this._context.SaveChanges();

            this._context.Users.Update(user);
            this._context.SaveChanges();
            return true;
        }

        public void ShowHistory(DataGrid dataGrid1)
        {
            List<DrunkDrinks> drunksdrinks = new List<DrunkDrinks>();
            string username = (string) Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            drunksdrinks = this._context.DrunkDrinks
                .Where(d => d.User.Id == (int) user.Id && d.Time.Date == DateTime.Today.Date).ToList();
            DataTable dt = new DataTable("history");
            DataColumn dc1 = new DataColumn("beverage", typeof(string));
            DataColumn dc2 = new DataColumn("volume", typeof(int));
            DataColumn dc3 = new DataColumn("time", typeof(string));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dataGrid1.ItemsSource = dt.DefaultView;
            NpgsqlConnection conn = new NpgsqlConnection(_context.connectionString);
            conn.Open();

            DataRow dr;
            NpgsqlCommand command =
                new NpgsqlCommand(
                    "SELECT (SELECT name FROM beverage WHERE id = beverage_id) FROM drunkdrinks WHERE user_id = (SELECT id FROM users WHERE username = @param1) and date(time) = current_date",
                    conn);
            command.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            for (int i = 0; i < drunksdrinks.Count(); i++)
            {
                dataReader.Read();
                dr = dt.NewRow();
                dr["beverage"] = dataReader[0].ToString();
                dr["volume"] = Convert.ToString(drunksdrinks[i].Volume);
                dr["time"] = dr["time"] = drunksdrinks[i].Time.ToString("hh:mm:ss");
                dt.Rows.Add(dr);
            }

            DataView view;
            view = new DataView(dt);

            dataGrid1.ItemsSource = view;
        }
        
        public int CurrentlyPercent()
        {
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
            return Convert.ToInt32(percent * 100);
        }
    }
}