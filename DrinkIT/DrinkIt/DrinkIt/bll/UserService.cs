using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.enums;
using DrinkIt.models;
using WpfApp1.Utils;

namespace DrinkIt.bll
{
    public class UserService
    {
        private readonly Context _context;

        public UserService()
        {
            _context = new Context();
        }

        public User Register(string username, String password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.UserName == username))
                throw new AppException("Username \"" + username + "\" is already taken");

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User(username, passwordHash);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void AddUserInfo(string genderName, int weight, int goal, DateTime dateOfBirth)
        {
            Gender gender = _context.Genders.SingleOrDefault(g => g.Name == genderName);
            string username = (string) Application.Current.Properties["username"];
            User user = _context.Users.SingleOrDefault(x => x.UserName == username);

            int age = (DateTime.Now.Year - dateOfBirth.Year); 
            UserInfo userInfo = new UserInfo(age, weight, dateOfBirth, gender,user);

            if (user != null)
            {
                user.UserInfo = userInfo;

                _context.UserInfos.Add(userInfo);
                _context.Users.Update(user);
            }

            _context.SaveChanges();
        }
    }
}