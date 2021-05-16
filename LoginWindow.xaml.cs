using communicator_client.dataTypes;
using communicator_client.DataTypes;
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
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static LoginWindow loginWindow;
        
        public LoginWindow()
        {
            InitializeComponent();
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string nick = nickInput.Text;
            string password = passwordInput.Password;
            string error = "";

            if (password == "") error = "Hasło nie może być puste.";
            if (nick == "") error = "Nick nie może być pusty.";
            if (error != "")
            {
                DisplayError(error);
                return;
            }
            LoginData loginData = new LoginData(nick, password);
            Payload payload = new Payload("login", loginData.ToString());

            if (Connection.isConnected)
                Connection.Send(payload.ToString());
            else
            {
                MessageBox.Show("Błąd podczas łącznia z serwerem. Spróbuj ponownie później.");
                this.Close();
            }
        }

        public void LoginSuccessfully()
        {
            Dispatcher.Invoke(() =>
            {
                ChatWindow.chatWindow = new ChatWindow();
                this.Close();
                ChatWindow.chatWindow.Show();
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

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
        }
    }
}
