using System;
using System.Windows;
using DrinkIt.bll;
using DrinkIt.BLL;
using DrinkIt.Utils;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
public partial class Profile
    {
        private Home _home;
        private UserService _userService;

        public Profile()
        {
            this.InitializeComponent();
            this._userService = new UserService();
            Logger.InitLogger();
        }

        private bool IsGenderValid(string gender_)
        {
            string gender = string.Empty;
            try
            {
                if (gender_ != "Please Select")
                {
                    gender = Convert.ToString(gender_);
                }
                else
                {
                    this.ProfileInvalidMessageBox.Text = "Please select your gender";
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                this.ProfileInvalidMessageBox.Text = "Please select your gender";
            }

            return !string.IsNullOrEmpty(gender);
        }

        private bool IsWeightValid(object weight_)
        {
            int weight = 0;
            try
            {
                weight = Convert.ToInt32(weight_);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                this.ProfileInvalidMessageBox.Text = "Weight is not number";
            }

            return weight > 10 && weight < 200;
        }

        private bool IsGoalValid(object goal_)
        {
            int goal = 0;
            try
            {
                goal = Convert.ToInt32(goal_);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                this.ProfileInvalidMessageBox.Text = "Goal is not number";
            }

            return goal > 0;
        }

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var gender = this.SexBox.Text;
            var date = this.DateBirthBox.SelectedDate.Value;
            var weight = this.WeightBox.Text;
            var goal = this.GoalBox.Text;
            TimeSpan wakeUp = new TimeSpan(8,0, 0);
            TimeSpan sleep = new TimeSpan(22,0, 0);
            TimeSpan period = new TimeSpan(0,20,0);
            if (!this.IsGenderValid(gender))
            {
                this.ProfileInvalidMessageBox.Text = "Select your gender";
                return;
            }

            if (!this.IsWeightValid(weight))
            {
                this.ProfileInvalidMessageBox.Text = "Weight should be more 10 and less 200";
                return;
            }

            if (!this.IsGoalValid(goal))
            {
                this.ProfileInvalidMessageBox.Text = "Goal should be more 0";
                return;
            }

            this._userService.AddUserInfo(gender, int.Parse(weight), int.Parse(goal), date);
            this._userService.AddUserData(int.Parse(weight) * 30, sleep, wakeUp, period);
            this.Close();
            this._home = new Home();
            this._home.Show();
            NotificationService.StartNotification();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}