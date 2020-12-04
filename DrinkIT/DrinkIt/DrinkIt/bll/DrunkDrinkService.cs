namespace DrinkIt.bll
{
using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.models;

class DrunkDrinkService
    {
        private readonly Context _context;

        public DrunkDrinkService()
        {
            this._context = new Context();
        }

        public bool AddDrink(string beverageName, int volume)
        {
            if (beverageName == null || volume == 0)
            {
                return false;
            }

            string username = (string)Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);

            Beverage beverage = this._context.Beverages.SingleOrDefault(g => g.Name == beverageName);

            DrunkDrinks drink = new DrunkDrinks(volume, DateTime.Now, beverage, user);
            this._context.DrunkDrinks.Add(drink);
            this._context.SaveChanges();

            this._context.Users.Update(user);
            this._context.SaveChanges();
            return true;
        }
    }
}