using System;
using System.Linq;
using DrinkIt.enums;
using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class Model : DbContext
    {
        private String connectionString = "host=localhost;port=5432;database=postgres;user id=postgres;password=1111";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(connectionString);

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserData>().ToTable("usersdata");
            modelBuilder.Entity<UserInfo>().ToTable("usersinfo");
            modelBuilder.Entity<Gender>().ToTable("gender");
            modelBuilder.Entity<Beverage>().ToTable("beverage");
        }
    }
}