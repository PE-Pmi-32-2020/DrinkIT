using System;
using System.Windows;

namespace DrinkIt
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

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            int YearOfBirth = int.Parse(YearOfBirthBox.Text);
            double weight = Convert.ToDouble(WeightBox.Text);
            int goal = int.Parse(GoalBox.Text);


            this.Close();
            home.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
