using System;
using DrinkIt.data;
using DrinkIt.models;

namespace DrinkIt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new UserDbContext()) {

                var user = new User()
                {
                    Id = 1,
                    Name = "Bill"
                };
                
                Console.WriteLine("is");
                

                context.Users.Add(user);
                context.SaveChanges();

                int id = user.Id;
                // context.Users.Find()
            }
        }
    }
}