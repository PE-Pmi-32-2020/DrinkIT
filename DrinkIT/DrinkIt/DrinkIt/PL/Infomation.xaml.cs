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

namespace DrinkIt
{
    /// <summary>
    /// Логика взаимодействия для Infomation.xaml
    /// </summary>
    public partial class Infomation : Window
    {
        
        private MenuOfDrinks _menuOfDrinks;
        private Home _home;
        private Statistic _statistic;
        private Setting _setting;
        public Infomation()
        {
            
            InitializeComponent();
            _menuOfDrinks = new MenuOfDrinks();
            _home=new Home();
            _statistic=new Statistic();
            _setting=new Setting();
            
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _home.Show();

        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            _menuOfDrinks.Show();

        }


        private void StatisticPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _statistic.Show();
        }

        private void NotificationPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _setting.Show();

        }
    }
}
