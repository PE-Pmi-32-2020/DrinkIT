﻿using System;
using System.Data.SqlClient;
using System.Linq;
using DrinkIt.enums;
using DrinkIt.models;
using DrinkIt.data;

namespace DrinkIt.bll
{
    public class DataGenerator
    {
        private static Random random = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GenerateRandomString(int length)
        {
            return new string(Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GenerateRandomInt(int floor, int ceil)
        {
            return random.Next(floor, ceil);
        }

        public static Double GenerateRandomDouble(Double floor, Double ceil)
        {
            return random.NextDouble() * (ceil - floor) + floor;
        }

        public static DateTime GenerateRandomDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public static TimeSpan GenerateRandomTimeSpan()
        {
            return new TimeSpan(0, 0, 0, new Random().Next(86400));
        }

        public static User GenerateUser()
        {
            return new User()
            {
                UserName = GenerateRandomString(8),
                Password = GenerateRandomString(20),
            };
        }

        public static UserInfo GenerateUserInfo(User user, Gender gender)
        {
            return new UserInfo()
            {
                Name = GenerateRandomString(8),
                Age = GenerateRandomInt(4, 70),
                Weight = GenerateRandomDouble(10, 90),
                DateOfBirth = GenerateRandomDateTime(),
                Gender = gender,
                User = user,
            };
        }

        public static UserData GenerateUserData(User user)
        {
            return new UserData()
            {
                WaterNorm = GenerateRandomInt(100, 1000),
                PeriodOfNotification = GenerateRandomTimeSpan(),
                SleepTime = GenerateRandomTimeSpan(),
                WakeUpTime = GenerateRandomTimeSpan(),
                User = user
            };
        }

        public static DrunkDrinks GenerateDrunkDrink(User user, Beverage beverage)
        {
            return new DrunkDrinks()
            {
                Volume = GenerateRandomInt(10, 100),
                Time = GenerateRandomDateTime(),
                User = user,
                Beverage = beverage,
            };
        }

        public static UserAchievements GenerateUserAchievements(User user, Achievement achievement)
        {
            return new UserAchievements()
            {
                User = user,
                Achievement = achievement
            };
        }

        public static void Generate(int n)
        {
            var context = new Context();


            Console.WriteLine("---start---");

            for (int i = 1; i < n; i++)
            {
                User user = GenerateUser();
                int genderNum = context.Genders.Count();
                Gender gender = context.Genders.Find((Gender.GenderId) random.Next(1, genderNum));
                UserInfo userInfo = GenerateUserInfo(user, gender);
                UserData userData = GenerateUserData(user);

                context.Users.Add(user);
                context.UserData.Add(userData);
                context.UserInfos.Add(userInfo);

                int num = random.Next(0, 3);
                for (int j = 0; j < num; j++)
                {
                    int beverageNum = context.Beverages.Count();
                    Beverage beverage = context.Beverages.Find(random.Next(1, beverageNum));

                    DrunkDrinks drink = GenerateDrunkDrink(user, beverage);

                    context.DrunkDrinks.Add(drink);
                }

                for (int j = 0; j < num; j++)
                {
                    int aCount = context.Achievements.Count();
                    Achievement achievement = context.Achievements.Find(random.Next(1, aCount));

                    UserAchievements userAchievement = GenerateUserAchievements(user, achievement);

                    context.UserAchievements.Add(userAchievement);
                }
            }

            try
            {
                context.SaveChanges();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Cannot generate data");
                throw e;
            }
        }
    }
}