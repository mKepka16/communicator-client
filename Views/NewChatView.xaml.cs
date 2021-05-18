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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace communicator_client.Views
{
    /// <summary>
    /// Logika interakcji dla klasy NewChatView.xaml
    /// </summary>
    public partial class NewChatView : UserControl
    {
        public static bool isOpened = false;
        public static NewChatView newChatView;
        public NewChatView()
        {
            InitializeComponent();
            newChatView = this;
        }

        private void CreateChat(object sender, RoutedEventArgs e)
        {

        }

        private void CheckIfUserExists(object sender, RoutedEventArgs e)
        {
            string nick = newPersonInput.Text;
            NickData nickData = new NickData(nick);
            Payload payload = new Payload("isUserExists", nickData.ToString());
            Connection.Send(payload.ToString());
        }
        public void SetError(string error)
        {
            invalidUserError.Text = error;
        }
    }
}
