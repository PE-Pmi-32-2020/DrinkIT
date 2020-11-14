using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private Home home;
        public Profile()
        {
            InitializeComponent();
            home = new Home();
        }

        bool IsGenderValid(object gender_)
        {
            string gender = "";
            try
            {
                gender = Convert.ToString(gender_);
            }
            catch (Exception ex)
            {
                ProfileInvalidMessageBox.Text = "Please select your gender";
            }

            return !(String.IsNullOrEmpty(gender));
        }

        bool IsWeightValid(object weight_)
        {
            int weight = 0;
            try
            {
                weight = Convert.ToInt32(weight_);
            }
            catch(Exception ex)
            {
                ProfileInvalidMessageBox.Text = "Weight is not number";
            }
            return weight > 10 && weight< 200;
        }

        bool IsGoalValid(object goal_)
        {
            int goal = 0;
            try
            {
                goal = Convert.ToInt32(goal_);
            }
            catch (Exception ex)
            {
                ProfileInvalidMessageBox.Text = "Goal is not number";
            }
            return goal > 0;
        }



        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {

            var gender = SexBox.SelectedValue;
            var date = DateBirthBox.SelectedDate.Value;
            var weight = WeightBox.Text;
            var goal = GoalBox.Text;


            if (!IsGenderValid(gender))
            {
                ProfileInvalidMessageBox.Text = "Select your gender";
                return;
            }

            if (!IsWeightValid(weight))
            {
                ProfileInvalidMessageBox.Text = "Weight should be more 10 and less 200";
                return;
            }

            if (!IsGoalValid(goal))
            {
                ProfileInvalidMessageBox.Text = "Goal should be more 0";
                return;
            }

            this.Close();
            home.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
