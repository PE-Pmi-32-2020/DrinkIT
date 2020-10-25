using DrinkIt.models;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.data
{
    public class UserDbContext : CommonDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}