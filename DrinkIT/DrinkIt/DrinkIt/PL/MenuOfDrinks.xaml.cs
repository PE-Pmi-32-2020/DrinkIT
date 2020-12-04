using System;
using System.Collections.Generic;
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
        private Setting setting;
        private Statistic statistic;
        private DrunkDrinkService _drunkDrinkService;
        
        private string bevarage;
        private int volume;

        public MenuOfDrinks()
        {
            InitializeComponent();

            bevarage = null;
            volume = 0;
            
            home = new Home();
            _drunkDrinkService = new DrunkDrinkService();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            
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
            {
                bevarage = RadioButton1.Content.ToString();
            }
        }
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                bevarage = RadioButton2.Content.ToString();
        }
        
        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                bevarage = RadioButton3.Content.ToString();
        }
        
        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                bevarage = RadioButton4.Content.ToString();
        }
        
        private void radioButton5_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                bevarage = RadioButton5.Content.ToString();
        }
        
        private void radioButton6_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                bevarage = RadioButton6.Content.ToString();
        }
        
        private void radioButton7_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = RadioButton7.Content.ToString();
                volume = int.Parse(vol.Substring(0, vol.Length-3));
            }
        }
        
        private void radioButton8_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = RadioButton8.Content.ToString();
                volume = int.Parse(vol.Substring(0, vol.Length-3));
            }
        }
        
        private void radioButton9_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = RadioButton9.Content.ToString();
                volume = int.Parse(vol.Substring(0, vol.Length-3));
            }
        }
        
        private void radioButton10_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = RadioButton10.Content.ToString();
                volume = int.Parse(vol.Substring(0, vol.Length-3));
            }
        }
        private void radioButton11_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = RadioButton11.Content.ToString();
                volume = int.Parse(vol.Substring(0, vol.Length-3));
            }
            
        }
        
        

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_drunkDrinkService.AddDrink(bevarage, volume))
                {
                    MenuInvalidMessageBox.Text = "Check your volume or beverage";
                    return;
                }
                Close();
                home.Show();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
