using System.Windows;
using FluentScheduler;

namespace DrinkIt.BLL
{
    public class NotificationService
    {
        public NotificationService()
        {
            JobManager.AddJob(
                this.DoNotification,
                notification => notification.ToRunNow().AndEvery(10).Seconds());
        }

        private void DoNotification()
        {
            MessageBox.Show("TIME TO DRINK!");
        }
    }
}