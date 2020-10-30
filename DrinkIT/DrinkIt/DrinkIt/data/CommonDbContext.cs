using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class CommonDbContext : DbContext
    {

        private String connectionString = ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(connectionString);
    }
}