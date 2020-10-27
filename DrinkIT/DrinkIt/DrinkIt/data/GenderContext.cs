using DrinkIt.enums;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class GenderContext : CommonDbContext
    {
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().ToTable("gender");
        }
    }
}