using DrinkIt.data;
using DrinkIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Utils;

namespace DrinkIt.bll
{
    class Drink
    {
        private readonly Context _context;

        public Drink()
        {
            _context = new Context();
        }
        public DrunkDrinks AddDrink(Beverage beverage, int volume, User username)
        {
            if (beverage == null || volume == null)
                throw new AppException("Chek your volume or beverage");

            DrunkDrinks drink = new DrunkDrinks(volume,DateTime.Now,beverage,username);
            _context.DrunkDrinks.Add(drink);
            _context.SaveChanges();
            return drink;
        }
    }
}
