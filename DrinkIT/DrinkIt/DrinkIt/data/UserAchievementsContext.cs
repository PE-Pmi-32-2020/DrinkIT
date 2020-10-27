using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class UserAchievementsContext : CommonDbContext
    {
        public DbSet<UserAchievements> UserAchievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAchievements>().ToTable("user_achievements");
        }
    }
}