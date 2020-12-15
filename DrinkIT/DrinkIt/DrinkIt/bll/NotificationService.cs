using System;
using System.Linq;
using System.Windows;
using DrinkIt.data;
using DrinkIt.models;
using FluentScheduler;

namespace DrinkIt.BLL
    {
        public class NotificationService
        {

            public static void StartNotification()
            {
                Context _context = new Context();
                string username = (string) Application.Current.Properties["username"];
                User user = _context.Users.SingleOrDefault(x => x.UserName == username);
                string period = _context.UserData.Where(d => d.User.Id == (int) user.Id)
                    .Select(x => x.PeriodOfNotification).SingleOrDefault().ToString();
                decimal dec = Convert.ToDecimal(TimeSpan.Parse(period).TotalHours);
                int seconds = (int) (Convert.ToDouble(dec.ToString()) * 100);
                JobManager.AddJob(
                    DoNotification,
                    notification => notification.WithName("DrinkNotification").ToRunNow().AndEvery(seconds).Seconds());
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
