using System;
using System.Linq;
using DrinkIt.data;
using DrinkIt.enums;
using DrinkIt.models;

namespace DrinkIt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new Model())
            {
                var user = new User()
                {
                    UserName = "ferf",
                    Password = "fsdfsdf"
                };
                var userData = new UserData()
                {
                    Id = 1,
                    WaterNorm = 10,
                    WakeUpTime = DateTime.Now,
                    SleepTime = DateTime.Now,
                    PeriodOfNotification = TimeSpan.Zero,
                    User = user,
                };
                var userInfo = new UserInfo()
                {
                    Id = 1,
                    Name = "Andriy",
                    Age = 20,
                    Weight = 77,
                    DateOfBirth = DateTime.Now,
                    Gender = context.Genders.Find(Gender.GenderId.Male)
                };
                
                Console.WriteLine("---start---");

                context.Users.Add(user);
                context.UserInfos.Add(userInfo);
                context.UserDatas.Add(userData);
                context.SaveChanges();
                
                // context.Users.Find()
            }
        }
    }
}