using Database;
using Domain;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace kroko
{
    public partial class MainWindow : Window
    {
        private readonly IRegUser regUser;
        private readonly IExistsUser existsUser;
        public MainWindow()
        {
            InitializeComponent();

            regUser = new 
                RegisterUserWithVerification(
                new AddUser(
                    new Database.Model.Context()),
                new DebugLog());

            existsUser = new
                CheckUserExistsDecorator(
                    new ExistsUser(
                        new Database.Model.Context()));
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (regName.Text.Length > 20)
            {
                //оповещение пользователя
                return;
            }
            if (regPassword.Text.Length > 20)
            {
                //оповещение пользователя
                return;
            }
            if (string.IsNullOrEmpty(regName.Text))
            {
                //оповещение пользователя
                return;
            }
            if (string.IsNullOrEmpty(regPassword.Text))
            {
                //оповещение пользователя
                return;
            }
            if (existsUser.Exists(regName.Text))
            {
                //оповещение пользователя
                return;
            }

            User user = new User
            {
                Name = regName.Text,
                Password = regPassword.Text,
                RegisterDate = DateTime.Now,
            };

            regUser.Execute(user);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}