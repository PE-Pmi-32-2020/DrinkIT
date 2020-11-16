using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DrinkIt.bll;
using DrinkIt.enums;

namespace DrinkIt.models
{
    [Table("usersinfo")]
    public class UserInfo
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        
        [Column("age")]
        [Required]
        public int Age { get; set; }
        
        [Column("weight")]
        [Required]
        public Double Weight { get; set; }
        
        [Column("date_of_birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [NotMapped]
        [ForeignKey("gender_id")]
        public Gender Gender { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
        
        public UserInfo(){}

        public UserInfo(int age, double weight, DateTime dateOfBirth, Gender gender, User user)
        {
            Age = age;
            Weight = weight;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            User = user;
        }
    }
}