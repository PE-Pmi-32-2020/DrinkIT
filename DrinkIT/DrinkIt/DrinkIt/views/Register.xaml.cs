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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    /// 
    public partial class Register : Window
    {
        private Profile profile;

        public Register()
        {
            InitializeComponent();
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            profile = new Profile();
            profile.Show();
            this.Close();
            
        }
    }
}
