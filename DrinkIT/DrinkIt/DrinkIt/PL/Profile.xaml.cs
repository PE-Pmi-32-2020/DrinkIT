namespace DrinkIt
{
using System;
using System.Windows;
using DrinkIt.bll;
using DrinkIt.models;
using Microsoft.EntityFrameworkCore.Storage;

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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            this.Close();
            this._home = new Home();
            this._home.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}