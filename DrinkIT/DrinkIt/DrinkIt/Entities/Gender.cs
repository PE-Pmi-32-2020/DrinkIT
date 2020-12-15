using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.enums
{
    [Table("gender")]
public class Gender
    {
        public Gender(GenderId id)
        {
            this.Id = id;
            this.Name = id.ToString();
        }

        public enum GenderId
        {
            [Display(Name = "MALE")]
            Male = 1,
            [Display(Name = "FEMALE")]
            Female = 2,
            [Display(Name = "MIXED")]
            Mixed = 3,
        }

        [Key]
        [Column("id")]
        public GenderId Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}