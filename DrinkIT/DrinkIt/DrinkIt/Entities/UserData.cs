namespace DrinkIt.models
{
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("usersdata")]
public class UserData
    {
        public UserData()
        {
        }

        public UserData( int waterNorm, TimeSpan sleep, TimeSpan wakeup, TimeSpan period, User user)
        {
            this.WaterNorm = waterNorm;
            this.SleepTime = sleep;
            this.WakeUpTime = wakeup;
            this.PeriodOfNotification = period;
            this.User = user;
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("water_norm")]
        public int WaterNorm { get; set; }

        [Column("wake_up_time")]
        public TimeSpan WakeUpTime { get; set; }

        [Column("sleep_time")]
        public TimeSpan SleepTime { get; set; }

        [Column("period_of_notification")]
        public TimeSpan PeriodOfNotification { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
    }
}