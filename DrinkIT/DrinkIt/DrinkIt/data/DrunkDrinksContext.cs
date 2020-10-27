using DrinkIt.enums;
using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class DrunkDrinksContext : CommonDbContext
    {
        public DbSet<DrunkDrinks> DrunkDrinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrunkDrinks>().ToTable("drunkdrinks");
        }
    }
}