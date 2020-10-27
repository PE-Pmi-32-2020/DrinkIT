using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.models
{
    [Table("drunkdrinks")]
    public class DrunkDrinks
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("volume")] public int Volume { get; set; }

        [Column("time")] public DateTime Time { get; set; }

        [ForeignKey("beverage_id")] public Beverage Beverage { get; set; }

        [ForeignKey("user_id")] public User User { get; set; }
    }
}