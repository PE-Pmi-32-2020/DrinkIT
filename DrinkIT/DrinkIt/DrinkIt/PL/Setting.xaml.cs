using System;
using System.Windows;
using DrinkIt.bll;
using DrinkIt.data;
using DrinkIt.enums;
using DrinkIt.models;
using DrinkIt.Utils;
using Npgsql;


namespace DrinkIt
{
    /// <summary>
    /// Логіка взаємодії для Setting.xaml
    /// </summary>
public partial class Setting
    {
        private Home _home;
        private MenuOfDrinks _menu;
        private Statistic _statistic;
        private UserService _userService;
        private SettingService _settingService;
        private Context _context;

        public Setting()
        {
            this.InitializeComponent();
            this._context = new Context();
            Logger.InitLogger();

            this._userService = new UserService();
            this._settingService=new SettingService();
            
            string username = (string) Application.Current.Properties["username"];
            NpgsqlConnection conn = new NpgsqlConnection(_context.connectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT (SELECT name FROM gender WHERE id = gender_id) FROM usersinfo WHERE user_id = (SELECT id FROM users WHERE username = @param1)",conn);
            command.Parameters.Add(new NpgsqlParameter("@param1", username));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (Application.Current.Properties["userId"] != null)
            {
                int id = (int)Application.Current.Properties["userId"];
                try
                {
                    this.IntakeGoal.Text = this._userService.GetUserInfo(id).Goal.ToString();
                    this.Weight.Text = this._userService.GetUserInfo(id).Weight.ToString();
                    this.DateBirthBox.SelectedDate = this._userService.GetUserInfo(id).DateOfBirth;
                    this.Reminder.Text = this._userService.GetUserData(id).PeriodOfNotification.ToString();
                    this.WakeUpTime.Text = this._userService.GetUserData(id).WakeUpTime.ToString();
                    this.SleepTime.Text = this._userService.GetUserData(id).SleepTime.ToString();
                    dataReader.Read();
                    string a = dataReader[0].ToString();
                    this.IntakeSex.Text = dataReader[0].ToString();
                }
                catch (Exception e)
                {
                    Logger.Log.Error(e.Message);
                    Console.WriteLine(e);
                    this.IntakeGoal.Text = "2000";
                    this.Reminder.Text = "30";
                    this.WakeUpTime.Text = "8:30";
                    this.SleepTime.Text = "22:00";
                }
            }
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this._home = new Home();
            this.Close();
            this._home.Show();
        }

        private void MenuDrinkPageButton_Click(object sender, RoutedEventArgs e)
        {
            this._menu = new MenuOfDrinks();
            this.Close();
            this._menu.Show();
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
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateOfBirth = this.DateBirthBox.SelectedDate.Value;
            int weight = int.Parse(this.Weight.Text);
            TimeSpan sleep = TimeSpan.Parse(this.SleepTime.Text);
            TimeSpan wakeUp = TimeSpan.Parse(this.WakeUpTime.Text);
            TimeSpan period = TimeSpan.Parse(this.Reminder.Text);
            int goal = int.Parse(this.IntakeGoal.Text);
            string gender = this.IntakeSex.Text;
            this._settingService.UpdateInfo(dateOfBirth, weight, sleep, wakeUp, period, goal, gender);
            
            this._home = new Home();
            this.Close();
            _home.Show();

        }
    }
}
