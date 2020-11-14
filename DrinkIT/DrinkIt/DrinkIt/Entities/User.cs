using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("username")]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public String UserName { get; set; }

        [Column("password")] [Required] public string Password { get; set; }

        public UserData UserData { get; set; }

        public UserInfo UserInfo { get; set; }

        public IList<DrunkDrinks> DrunkDrinks { get; set; }

        public IList<UserAchievements> UserAchievements { get; set; }

        public User(String userName, String password)
        {
            UserName = userName;
            Password = password;
        }
    }
}