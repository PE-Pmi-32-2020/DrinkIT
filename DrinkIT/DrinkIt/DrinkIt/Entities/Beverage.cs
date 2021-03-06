﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.models
{
    [Table("beverage")]
public class Beverage
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }
    }
}