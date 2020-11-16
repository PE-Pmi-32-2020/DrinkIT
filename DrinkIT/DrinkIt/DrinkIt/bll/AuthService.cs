using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.models;
using DrinkIt.Utils;

namespace DrinkIt.bll
{
    public class AuthService
    {
        private readonly Context _context;

        public AuthService()
        {
            _context = new Context();
        }

        public bool Login(String username, String password)
        {
            User user = _context.Users.SingleOrDefault(x => x.UserName == username);

            if (user == null && !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return false;
            }
            
            Application.Current.Properties["userId"] = user.Id;
            Application.Current.Properties["username"] = user.UserName;
            
            return true;
        }

    }
}