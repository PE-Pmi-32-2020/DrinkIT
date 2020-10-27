using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class BeveragesContext : CommonDbContext
    {
        public DbSet<Beverage> Beverages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>().ToTable("beverage");
        }
    }
}