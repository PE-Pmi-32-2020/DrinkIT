using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class UserContext : CommonDbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }

    }
}