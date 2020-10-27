using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class UserInfoContext:CommonDbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().ToTable("usersinfo");
        }

    }
}