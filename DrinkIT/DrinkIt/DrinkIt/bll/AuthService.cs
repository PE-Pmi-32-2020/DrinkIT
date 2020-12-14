﻿using log4net;

namespace DrinkIt.bll
{
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.models;
using DrinkIt.Utils;

public class AuthService
    {
        private readonly Context _context;


        public AuthService()
        {
            Logger.InitLogger();//инициализация - требуется один раз в начале

            Logger.Log.Info("hello ingo!");
            Logger.Log.Error("hello error!");
            
            this._context = new Context();
        }

        public User Login(string username, string password)
        {
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new AppException("Invalid username or password");
            }

            Application.Current.Properties["userId"] = user.Id;
            Application.Current.Properties["username"] = user.UserName;

            return user;
        }
    }
}