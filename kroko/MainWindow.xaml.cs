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

            var context = new Database.Model.Context();

            regUser = new 
                RegisterUserWithVerification(
                new AddUser(
                    context),
                new DebugLog());

            existsUser = new
                CheckUserExistsDecorator(
                    new ExistsUser(
                        context));
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Name = regName.Text,
                Password = regPassword.Text,
                RegisterDate = DateTime.Now,
            };
            if (user.Name.Length > 20)
            {
                //оповещение пользователя
                return;
            }
            if (user.Password.Length > 20)
            {
                //оповещение пользователя
                return;
            }
            if (string.IsNullOrEmpty(user.Name))
            {
                //оповещение пользователя
                return;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                //оповещение пользователя
                return;
            }
            if (existsUser.Exists(user))
            {
                //оповещение пользователя
                return;
            }

            regUser.Execute(user);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}