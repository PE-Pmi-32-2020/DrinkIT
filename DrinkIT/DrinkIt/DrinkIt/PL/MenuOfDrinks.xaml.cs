using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DrinkIt.bll;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для MenuOfDrinks.xaml
    /// </summary>
    public partial class MenuOfDrinks : Window
    {
        private Home home;
        private Calendar calendar;
        private Setting setting;
        private Statistic statistic;
        private DrinkService _drinkService;
        private bool _isR1Chacked = false;

        public MenuOfDrinks()
        {
            InitializeComponent();
            _drinkService = new DrinkService();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            home = new Home();
            this.Close();
            home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            calendar = new Calendar();
            this.Close();
            calendar.Show();
        }

        private void StatisticPageButton_Click(object sender, RoutedEventArgs e)
        {
            statistic = new Statistic();
            this.Close();
            statistic.Show();
        }

        private void NotificationPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            setting = new Setting();
            this.Close();
            setting.Show();
        }
        
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                 _isR1Chacked = true;
        }
        
        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }
        
        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }
        
        private void radioButton5_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }
        
        private void radioButton6_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }
        
        private void radioButton7_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }
        
        private void radioButton8_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                _isR1Chacked = true;
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {

            string bevarage = "";
            int volume = 100;

            _drinkService.AddDrink(bevarage, volume);

            Console.WriteLine(_isR1Chacked);

        }
    }
}
