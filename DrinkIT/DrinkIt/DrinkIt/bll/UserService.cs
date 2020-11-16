using System;
using System.Linq;
using DrinkIt.data;
using DrinkIt.models;
using DrinkIt.Utils;

namespace DrinkIt.bll
{
    public class UserService
    {
        private readonly Context _context;

        public UserService()
        {
            _context = new Context();
        }

        public User Register(String username, String password)
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
    }
}