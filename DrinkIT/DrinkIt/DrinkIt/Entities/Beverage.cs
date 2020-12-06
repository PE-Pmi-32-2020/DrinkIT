namespace DrinkIt.models
{
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("beverage")]
public class Beverage
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Beverage(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Beverage()
        {
        }

        [Column("name")]
        [Required]
        public string Name { get; set; }
    }
}