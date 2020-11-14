using System;
using System.Linq;
using DrinkIt.data;
using DrinkIt.models;
using WpfApp1.Utils;

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

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return false;
            }
            
            return true;
        }

    }
}