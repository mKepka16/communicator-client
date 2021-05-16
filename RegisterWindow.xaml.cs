using communicator_client.dataTypes;
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

namespace communicator_client
{
    /// <summary>
    /// Logika interakcji dla klasy registerWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public static RegisterWindow registerWindow;

        public RegisterWindow()
        {
            InitializeComponent();
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            string nick = nickInput.Text;
            string password = passwordInput.Password;
            string repeatPassword = repeatPasswordInput.Password;
            string error = "";

            if (password != repeatPassword) error = "Hasła nie są identyczne.";
            if (password == "") error = "Hasło nie może być puste.";
            if (nick == "") error = "Nick nie może być pusty.";
            if(error != "")
            {
                DisplayError(error);
                return;
            }

            RegisterData registerData = new RegisterData(nick, password);
            Payload payload = new Payload("register", registerData.ToString());

            if (Connection.isConnected)
                Connection.Send(payload.ToString());
            else
            {
                MessageBox.Show("Błąd podczas łącznia z serwerem. Spróbuj ponownie później.");
                this.Close();
            }
        }

        public void RegisteredSuccessfully()
        {
            Dispatcher.Invoke(() =>
            {
                successText.Visibility = Visibility.Visible;
                registerButton.Visibility = Visibility.Collapsed;
                loginButton.Visibility = Visibility.Visible;
                errorText.Visibility = Visibility.Collapsed;
            });
        }

        public void DisplayError(string error)
        {
            Dispatcher.Invoke(() =>
            {
                errorText.Text = error;
                errorText.Visibility = Visibility.Visible;
            });
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void RegisterWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.loginWindow = new LoginWindow();
            this.Close();
            LoginWindow.loginWindow.Show();
        }
    }
}
