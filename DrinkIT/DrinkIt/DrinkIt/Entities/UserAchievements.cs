using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.models
{
    [Table("user_achievements")]
    public class UserAchievements
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("user_id")]
        public User User { get; set; }
        
        [ForeignKey("achievement_id")]
        public Achievement Achievement { get; set; }
    }
}