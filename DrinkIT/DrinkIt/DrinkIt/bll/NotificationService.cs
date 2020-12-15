using System;
using System.Windows;
using FluentScheduler;

namespace DrinkIt.BLL
{
    public class NotificationService
    {

        public static void StartNotification()
        {
            JobManager.AddJob(
                DoNotification,
                notification => notification.WithName("DrinkNotification").ToRunNow().AndEvery(5).Seconds());
        }

        public static void StopNotification()
        {
            JobManager.RemoveJob("DrinkNotification");
        }

        private static void DoNotification()
        {
            MessageBox.Show("TIME TO DRINK!");
        }
    }
}