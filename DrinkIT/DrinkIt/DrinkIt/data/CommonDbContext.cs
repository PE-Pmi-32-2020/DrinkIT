using System;
using System.Linq;
using DrinkIt.enums;
using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class CommonDbContext : DbContext
    {
        private String connectionString = "host=localhost;port=5432;database=postgres;user id=postgres;password=1111";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(connectionString);
    }
}