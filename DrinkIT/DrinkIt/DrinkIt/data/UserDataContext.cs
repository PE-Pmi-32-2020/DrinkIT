using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class UserDataContext : CommonDbContext
    {
        public DbSet<UserData> UserData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().ToTable("usersdata");
        }
    }
}