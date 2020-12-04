namespace DrinkIt.bll
{
using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.enums;
using DrinkIt.models;
using DrinkIt.Utils;


public class UserService
    {
        private readonly Context _context;
        private AuthService _authService;

        public UserService()
        {
            this._context = new Context();
            this._authService = new AuthService();
        }

        public User Register(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }

            if (this._context.Users.Any(x => x.UserName == username))
            {
                throw new AppException("Username \"" + username + "\" is already taken");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User(username, passwordHash);
            this._context.Users.Add(user);
            this._context.SaveChanges();

            this._authService.Login(username, password);

            return user;
        }

        public void AddUserInfo(string genderName, int weight, int goal, DateTime dateOfBirth)
        {
            Gender gender = this._context.Genders.SingleOrDefault(g => g.Name == genderName);
            string username = (string)Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);

            int age = DateTime.Now.Year - dateOfBirth.Year;
            UserInfo userInfo = new UserInfo(age, weight, goal, dateOfBirth, gender, user);

            if (user != null)
            {
                user.UserInfo = userInfo;

                this._context.UserInfos.Add(userInfo);
                this._context.SaveChanges();

                this._context.Users.Update(user);
                this._context.SaveChanges();
            }
        }

        public UserInfo GetUserInfo(int userId)
        {
            return this._context.UserInfos.Single(u => u.User.Id == userId);
        }
    }
}