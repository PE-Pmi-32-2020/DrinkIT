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
            this.Close();
        }
    }
}
