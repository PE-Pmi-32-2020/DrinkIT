using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DrinkIt.enums;

namespace DrinkIt.models
{
    [Table("usersinfo")]
public class UserInfo
    {
        public UserInfo()
        {
        }

        public UserInfo(int age, double weight, double goal, DateTime dateOfBirth, Gender gender, User user)
        {
            this.Age = age;
            this.Weight = weight;
            this.Goal = goal;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.User = user;
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("age")]
        [Required]
        public int Age { get; set; }

        [Column("weight")]
        [Required]
        public double Weight { get; set; }

        [Column("goal")]
        [Required]
        public double Goal { get; set; }

        [Column("date_of_birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("gender_id")]
        public Gender Gender { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
    }
}