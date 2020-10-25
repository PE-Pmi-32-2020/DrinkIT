using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DrinkIt.models
{
    public class User : DbContext
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}