using System;
using Npgsql;

namespace DrinkIt.dao

{
    public class Connection
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=andriypyzh;Password=11111111;Database=postgres;SearchPath=drink_it;Port=5432";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "select * from users";

            using var cmd = new NpgsqlCommand(sql, con);

            var version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"PostgreSQL: {version}");
        }
    }
}