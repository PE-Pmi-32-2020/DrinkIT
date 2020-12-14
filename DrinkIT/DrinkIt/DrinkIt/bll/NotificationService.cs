namespace DrinkIt.BLL
{
    using System;
    using FluentScheduler;
    using DrinkIt.PL;
    using System.Windows.Threading;

    public class NotificationService
    {
        private Notification _notification;
        public NotificationService()
        {
            JobManager.AddJob(
                this.DoNotification,
                notification => notification.ToRunNow().AndEvery(1).Seconds());
        }

        private void DoNotification()
        {
            DoPrimaryWorkOffUIThread();
            Dispatcher.CurrentDispatcher.Invoke(new Action(this.ShowResultsOnUIThread));
        }

        private DateTime currentResult;

        private void DoPrimaryWorkOffUIThread()
        {
            this.currentResult = DateTime.Now;
        }

        private void ShowResultsOnUIThread()
        {
            _notification = new Notification();
            _notification.ShowWindow();
        }
    }
}
