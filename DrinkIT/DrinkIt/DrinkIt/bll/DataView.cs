using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DrinkIt.bll
{
    public class DataView
    {
        private  NpgsqlConnection Connection { get; set; }

        public DataView()
        {
            string conStr = "Host=localhost;Username=postgres;Password=1111;Database=postgres";
            Connection = new NpgsqlConnection(conStr);
            Connection.Open();
        }
        ~DataView()
        {
            Connection.Close();
        }
        

        public  void PrintUsers()
        {
            Print("Select * FROM users;", "users");
        }

        public  void PrintUsersData()
        {
            Print("Select * FROM usersdata;", "usersdata");
        }

        public  void PrintUsersInfo()
        {
            Print("Select * FROM usersinfo;", "usersinfo");
        }

        public  void PrintDrunkDrinks()
        {
            Print("Select * FROM drunkdrinks;", "drunkdrinks");
        }

        public  void PrintUserAchievements()
        {
            Print("Select * FROM user_achievements;", "user_achievements");
        }

        private  void Print(String query, String table)
        {
            NpgsqlCommand com = new NpgsqlCommand(query, Connection);
            NpgsqlDataAdapter ad = new NpgsqlDataAdapter(com);
            DataTable dt = new DataTable();

            ad.Fill(dt);
            NpgsqlDataReader dRead = com.ExecuteReader();

            try
            {
                Console.WriteLine(table);
                foreach (var column in dt.Columns)
                {
                    Console.Write(column + "\t");
                }

                Console.WriteLine();
                while (dRead.Read())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", row[0], row[1], row[2]);
                    }
                }
            }
            catch (NpgsqlException ne)
            {
                Console.WriteLine("Problem connecting to server, Error details {0}", ne.ToString());
            }
            finally
            {
                Console.WriteLine("Closing connections");
                dRead.Close();
                dRead = null;

                com.Dispose();
                com = null;
            }
            
           
        }
    }
}