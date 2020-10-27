using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.enums
{
    [Table("gender")]
    public class Gender
    {
        public enum GenderId
        {
            [Display(Name = "MALE")] Male = 1,
            [Display(Name = "FEMALE")] Female = 2,
            [Display(Name = "MIXED")] Mixed = 3,
        }

        public Gender(GenderId id)
        {
            Id = id;
            Name = id.ToString();
        }

        [Key] [Column("id")] public GenderId Id { get; set; }

        [Column("name")] public string Name { get; set; }
    }
}