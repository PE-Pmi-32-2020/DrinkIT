using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Npgsql;
using System.Diagnostics;

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
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

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
            
            
            if (IsValidEmail(email))
            {
                if (isValidPassword(password) && isValidPassword(confirmpassword))
                {
                    if (password == confirmpassword)
                    {
                        try
                        {
                            string conStr = "Host=localhost;Username=postgres;Password=1111;Database=postgres";
                        
                            NpgsqlConnection Connection = new NpgsqlConnection(conStr);
                            Connection.Open();
                            var query = "insert into users (username,password) values(@username,@password)";
                            var cmd = new NpgsqlCommand(query, Connection);
                            cmd.Parameters.Add(new NpgsqlParameter("username", email));
                            cmd.Parameters.Add(new NpgsqlParameter("password", password));
                            cmd.ExecuteNonQuery();
                            Connection.Close();
                        }
                        catch (Exception exception)
                        {
                            System.Windows.MessageBox.Show(exception.Message);
                            throw;
                        }
                       
                         //string query = "SELECT count(*) fromUser";
                          // NpgsqlCommand cmd = new NpgsqlCommand( );
                          // cmd.Connection = Connection;
                          // cmd.CommandText="insert into users (id,username,password) values(1,'mas@gmail.com','121212n')";
                          // cmd.ExecuteNonQuery();

                          //var  res =  cmd.ExecuteScalar().ToString();
                          //System.Windows.MessageBox.Show(res);
                          
              
                         // Connection.Close();
                          // using (var cmd = new NpgsqlCommand("INSERT INTO users(id,username,password)  VALUES (:u,:p)",Connection))
                        // {
                        //     cmd.Parameters.Add(new NpgsqlParameter("u", email));
                        //     cmd.Parameters.Add(new NpgsqlParameter("p", password));
                        //     cmd.ExecuteNonQuery();
                        // }
                       //  string query = "insert into Users (id,username,password) values(@username,@password)";
                       //  NpgsqlCommand cmd = new NpgsqlCommand(query, Connection);
                       //  cmd.Parameters.AddWithValue("username", email);
                       //  cmd.Parameters.AddWithValue("password", password);
                       //  
                       // // cmd.CommandType = CommandType.Text;  
                       // cmd.ExecuteNonQuery();
                       // Connection.Close();
                        
                       // string query =@"select * from insert_something('asas','asas')"; 
                       // var cmd = new NpgsqlCommand(query, Connection);
                       //cmd.CommandType = CommandType.Text;  
                       // cmd.Parameters.Add(new NpgsqlParameter("username", email));
                       // cmd.Parameters.Add(new NpgsqlParameter("password", password));
                             
                             
                       //
                       //NpgsqlCommand cmd = new NpgsqlCommand(@"select * from insert_something(:_val ,:_val2)",
                       //Connection);
                       // cmd.Parameters.AddWithValue("_val", "ass@gmail.com");
                       // cmd.Parameters.AddWithValue("_val2", "as122222");
                       // cmd.ExecuteNonQuery();
                       // if ((int) cmd.ExecuteScalar() == 22)
                       // {
                       //     System.Windows.MessageBox.Show("ok");
                       //     
                       // }
                       // else
                       // {
                       //     System.Windows.MessageBox.Show("not ok");
                       // }
                       // var sql2 = "select count(*) from users";
                       // var cmd2 = Connection.CreateCommand();
                       // cmd2.CommandText = sql2;
                       // var count = cmd2.ExecuteScalar().ToString();
                       // System.Windows.MessageBox.Show(count);
                       // // 
                       //cmd.ExecuteNonQuery();
                       //var count = cmd.ExecuteScalar().ToString();
                       //System.Windows.MessageBox.Show(count);
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

    internal class MassageBox
    {
    }
}