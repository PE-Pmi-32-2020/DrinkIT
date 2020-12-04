// <copyright file="Context.cs" company="Com">

// </copyright>
namespace DrinkIt.data
{
using System.Configuration;
using DrinkIt.enums;
using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public Context()
        {
        }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<Beverage> Beverages { get; set; }

        public DbSet<DrunkDrinks> DrunkDrinks { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<UserAchievements> UserAchievements { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserData> UserData { get; set; }

        
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(this.connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>().ToTable("beverage");
            modelBuilder.Entity<DrunkDrinks>().ToTable("drunkdrinks");
            modelBuilder.Entity<Gender>().ToTable("gender");
            modelBuilder.Entity<UserAchievements>().ToTable("user_achievements");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserData>().ToTable("usersdata");
            modelBuilder.Entity<UserInfo>().ToTable("usersinfo");
        }
    }
}