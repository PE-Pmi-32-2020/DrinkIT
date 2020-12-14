namespace DrinkIt.BLL
{
    using FluentScheduler;
    using System.Windows;


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