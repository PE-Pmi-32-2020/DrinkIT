using System;
using System.Windows;
using System.Windows.Controls;
using DrinkIt.bll;
using DrinkIt.Utils;

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для MenuOfDrinks.xaml
    /// </summary>
public partial class MenuOfDrinks
    {
        private Home _home;
        private Setting _setting;
        private Statistic _statistic;
        private DrunkDrinkService _drunkDrinkService;

        private string _bevarage;
        private int _volume;

        public MenuOfDrinks()
        {
            this.InitializeComponent();

            this._bevarage = null;
            this._volume = 0;
            
            this._drunkDrinkService = new DrunkDrinkService();
            
            Logger.InitLogger();

        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this._home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void StatisticPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._statistic = new Statistic();
            this.Close();
            this._statistic.Show();
        }

        private void NotificationPageButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._setting = new Setting();
            this.Close();
            this._setting.Show();
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                this._bevarage = this.RadioButton1.Content.ToString();
            }
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                this._bevarage = this.RadioButton2.Content.ToString();
            }
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                this._bevarage = this.RadioButton3.Content.ToString();
            }
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                this._bevarage = this.RadioButton4.Content.ToString();
            }
        }

        private void RadioButton5_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                this._bevarage = this.RadioButton5.Content.ToString();
            }
        }

        private void RadioButton6_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                this._bevarage = this.RadioButton6.Content.ToString();
            }
        }

        private void RadioButton7_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = this.RadioButton7.Content.ToString();
                this._volume = int.Parse(vol.Substring(0, vol.Length - 3));
            }
        }

        private void RadioButton8_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = this.RadioButton8.Content.ToString();
                this._volume = int.Parse(vol.Substring(0, vol.Length - 3));
            }
        }

        private void RadioButton9_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = this.RadioButton9.Content.ToString();
                this._volume = int.Parse(vol.Substring(0, vol.Length - 3));
            }
        }

        private void RadioButton10_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = this.RadioButton10.Content.ToString();
                this._volume = int.Parse(vol.Substring(0, vol.Length - 3));
            }
        }

        private void RadioButton11_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
            {
                string vol = this.RadioButton11.Content.ToString();
                this._volume = int.Parse(vol.Substring(0, vol.Length - 3));
            }
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this._drunkDrinkService.AddDrink(this._bevarage, this._volume))
                {
                    this.MenuInvalidMessageBox.Text = "Check your _volume or beverage";
                    return;
                }

                this.Close();
                
                this._home = new Home();
                this._home.Show();
            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception);
                throw;
            }
        }
    }
}
