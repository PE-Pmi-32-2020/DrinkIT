using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.models
{
    [Table("usersdata")]
    public class UserData
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("water_norm")] public int WaterNorm { get; set; }

        [Column("wake_up_time")] public DateTime WakeUpTime { get; set; }

        [Column("sleep_time")] public DateTime SleepTime { get; set; }

        [Column("period_of_notification")] public TimeSpan PeriodOfNotification { get; set; }

        [ForeignKey("user_id")] public User User { get; set; }
    }
}