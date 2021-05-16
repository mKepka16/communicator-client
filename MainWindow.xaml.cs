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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace communicator_client
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            Connection.Start();
        }

        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow.registerWindow = new RegisterWindow();
            RegisterWindow.registerWindow.Show();
            this.Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.loginWindow = new LoginWindow();
            LoginWindow.loginWindow.Show();
            this.Close();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
        }
    }
}
