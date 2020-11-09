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
using System.Text.RegularExpressions;
using System.Globalization;

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
            profile = new Profile();
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private bool isValidPassword(string password)
        {
            bool validation = false;

            if (password.Length > 5 && password.Length < 20)
                validation = true;


            return validation;
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {

            string email = EmailBox.Text;
            string password = PasswordBox.Password;
            string confirmpassword = ConfirmPasswordBox.Password;

            if(IsValidEmail(email))
            {
                if(isValidPassword(password) && isValidPassword(confirmpassword))
                {
                    if(password == confirmpassword)
                    {
                        this.Close();
                        profile.Show();
                    }
                    else
                    {
                        InvalidMessageBox.Text = "Passwords must match";
                        PasswordBox.BorderBrush = Brushes.Red;
                        ConfirmPasswordBox.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    InvalidMessageBox.Text = "Password length should be from 5 to 20 symbols";
                    PasswordBox.BorderBrush = Brushes.Red;
                    ConfirmPasswordBox.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                InvalidMessageBox.Text = "Email should be like example@example.com";
                EmailBox.BorderBrush = Brushes.Red;
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
