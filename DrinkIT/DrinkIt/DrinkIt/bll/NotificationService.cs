using System;
using System.Linq;
using DrinkIt.data;
using DrinkIt.models;

namespace DrinkIt.BLL
{
    using FluentScheduler;
    using System.Windows;


    public class NotificationService
    {
        private Context _context;
        public NotificationService()
        {
            this._context = new Context();
            string username = (string)Application.Current.Properties["username"];
            User user = this._context.Users.SingleOrDefault(x => x.UserName == username);
            string period = this._context.UserData.Where(d => d.User.Id == (int)user.Id).Select(x => x.PeriodOfNotification).SingleOrDefault().ToString();
            decimal dec = Convert.ToDecimal(TimeSpan.Parse(period).TotalHours);
            int seconds = (int)(Convert.ToDouble(dec.ToString()) * 100);
            JobManager.AddJob(
                this.DoNotification,
                notification => notification.ToRunNow().AndEvery(seconds).Seconds());
        }

        private void DoNotification()
        {
            MessageBox.Show("TIME TO DRINK!");
        }
    }
}