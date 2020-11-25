﻿using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.enums;
using DrinkIt.models;
using DrinkIt.Utils;

namespace DrinkIt.bll
{
    class DrunkDrinkService
    {
        private readonly Context _context;

        public DrunkDrinkService()
        {
            _context = new Context();
        }
        public bool AddDrink(string beverageName, int volume)
        {
            if (beverageName == null || volume == 0)
                return false;

            string username = (string) Application.Current.Properties["username"];
            
            User user = _context.Users.SingleOrDefault(x => x.UserName == username);
            
            Beverage beverage = _context.Beverages.SingleOrDefault(g => g.Name == beverageName);
            
            DrunkDrinks drink = new DrunkDrinks(volume,DateTime.Now,beverage,user);
            _context.DrunkDrinks.Add(drink);
            _context.SaveChanges();
            
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}