using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.enums;
using DrinkIt.models;

namespace DrinkIt.bll
{
    public class SettingService
    {
        private readonly Context _context;

        public SettingService()
        {
            this._context = new Context();
        }

        public void UpdateInfo( DateTime dateOfBirth,int weight,TimeSpan sleep, TimeSpan wakeup, TimeSpan period, int goal, string genderName)
        {
            string username = (string)Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            UserInfo userInfo = this._context.UserInfos.Single(u => u.User.UserName == user.UserName);
            UserData userData = this._context.UserData.Single(u => u.User.UserName == user.UserName);
            Gender gender = this._context.Genders.SingleOrDefault(g => g.Name == genderName);
            userInfo.DateOfBirth = dateOfBirth;
            userInfo.Weight = weight;
            userInfo.Goal = goal;
            userInfo.Gender = gender;
            userData.SleepTime = sleep;
            userData.WakeUpTime = wakeup;
            userData.PeriodOfNotification = period;
            this._context.UserData.Update(userData);
            this._context.UserInfos.Update(userInfo);
            this._context.SaveChanges();

            this._context.Users.Update(user);
            this._context.SaveChanges();
        }
    }
}