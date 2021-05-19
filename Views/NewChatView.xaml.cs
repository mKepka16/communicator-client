using communicator_client.dataTypes;
using communicator_client.DataTypes;
using communicator_client.ViewModels;
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
        public static NewChatViewModel newChatViewModel = new NewChatViewModel();

        public NewChatView()
        {
            InitializeComponent();
            newChatView = this;
            DataContext = newChatViewModel;
        }

        private void CreateChat(object sender, RoutedEventArgs e)
        {
            NewChatData newChatData = newChatViewModel.GetChatData();
            if(newChatData.Nicks.Count == 0) {
                SetError("Najpierw dodaj użytkowników.");
                return;
            }
            if (newChatData.Nicks.Count > 1 && string.IsNullOrEmpty(newChatData.ChatName.Trim()))
            {
                SetError("Podaj nazwę grupy.");
                return;
            }
            Payload payload = new Payload("createChat", newChatData.ToString());
            Connection.Send(payload.ToString());
        }

        private void CheckIfUserExists()
        {
            string nick = newPersonInput.Text;
            if (string.IsNullOrEmpty(nick))
            {
                SetError("Podaj nazwę użytkownika.");
                return;
            }

            if(newChatViewModel.IsOnList(new NickData(nick)))
            {
                SetError("Użytkownik już istnieje na liście.");
                return;
            }

            NickData nickData = new NickData(nick);
            Payload payload = new Payload("isUserExist", nickData.ToString());
            Connection.Send(payload.ToString());
        }
        public void SetError(string error)
        {
            invalidUserError.Text = error;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            newChatViewModel.DeleteUserFromList(new NickData(tag));
        }

        private void addPersonToChat_Click(object sender, RoutedEventArgs e)
        {
            CheckIfUserExists();
        }

        private void newPersonInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            CheckIfUserExists();
        }
    }
}
