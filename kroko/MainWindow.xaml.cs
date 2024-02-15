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
        private readonly IGetUser getUser;

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

            getUser = new GetUser(
                new Database.Model.Context());
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            bool HasError = false;

            ResetErrorLabels();

            User user = new User
            {
                Name = regName.Text,
                Password = regPassword.Text,
                RegisterDate = DateTime.Now,
            };
            if (user.Name.Length > 20 || string.IsNullOrEmpty(user.Name))
            {
                ErrorMessageRegName.Content = "Error";
                HasError = true;
            }
            if (user.Password.Length > 20 || string.IsNullOrEmpty(user.Password))
            {
                ErrorMessageRegPassword.Content = "Error";
                HasError = true;
            }
            if (HasError) return;
            if (existsUser.Exists(user))
            {
                MessageErrorReg.Content = "пользователь уже существеут";
                return;
            }

            regUser.Execute(user);
            ResetTextBoxForReg();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool HasError = false;
            ResetErrorLabels();

            if (logName.Text.Length > 20 || string.IsNullOrEmpty(logName.Text))
            {
                ErrorMessageLogName.Content = "Error";
                HasError = true;
            }
            if (logPassword.Text.Length > 20 || string.IsNullOrEmpty(logPassword.Text))
            {
                ErrorMessageLogPassword.Content = "Error";
                HasError = true;
            }
            if (HasError) return;

            var user = getUser.Get(logName.Text, logPassword.Text);

            if (user == null)
            {
                MessageErrorLog.Content = "пользователь не найден";
                return;
            }

            UserName.Content = user.Name;
            UserPassword.Content = user.Password;
            UserDateReg.Content = user.RegisterDate;

            ResetTextBoxForLog();
        }

        private void ResetErrorLabels()
        {
            MessageErrorLog.Content = "";
            MessageErrorReg.Content = "";
            ErrorMessageLogName.Content = "";
            ErrorMessageLogPassword.Content = "";
            ErrorMessageRegName.Content = "";
            ErrorMessageRegPassword.Content = "";
        }

        private void ResetTextBoxForLog()
        {
            logName.Text = "";
            logPassword.Text = "";
        }

        private void ResetTextBoxForReg()
        {
            regName.Text = "";
            regPassword.Text = "";
        }
    }
}