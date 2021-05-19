using communicator_client.dataTypes;
using communicator_client.DataTypes;
using communicator_client.Models;
using communicator_client.ViewModels;
using communicator_client.Views;
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
    /// Logika interakcji dla klasy ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public static ChatWindow chatWindow;
        public static ChatListModel listModel;
        public static ChatViewModel chatViewModel;

        public ChatWindow()
        {
            InitializeComponent();
            SendLoggedInInfo();

            chatViewModel = new ChatViewModel();
            DataContext = chatViewModel;
            listModel = new ChatListModel();
            ChatList.DataContext = listModel;
        }

        private void SendLoggedInInfo()
        {
            Connection.Send(new Payload("loggedIn", "").ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NewChatView.isOpened)
            {
                NewChatView.isOpened = false;
                DataContext = chatViewModel;
            }
            string content = ((Button)sender).Content.ToString();
            string tag = ((Button)sender).Tag.ToString();
            int id = int.Parse(tag);

            ChatRequestData requestData = new ChatRequestData(id, content);
            Payload payload = new Payload("chatRequest", requestData.ToString());
            Connection.Send(payload.ToString());
            ChatView.chatViewModel.ChatId = id;
        }

        private void ChangeToNewChatView(object sender, RoutedEventArgs e)
        {
            DataContext = new NewChatViewModel();
            NewChatView.isOpened = true;
            NewChatView.newChatViewModel.ClearView();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
        }

        public void SetStartingView()
        {
            if(listModel.List.Count > 0)
            {
                int id = listModel.List[0].Id;
                string content = listModel.List[0].Name;
                ChatRequestData requestData = new ChatRequestData(id, content);
                Payload payload = new Payload("chatRequest", requestData.ToString());
                Connection.Send(payload.ToString());
                ChatView.chatViewModel.ChatId = id;
                return;
            }

            DataContext = new NewChatViewModel();
            NewChatView.isOpened = true;
        }
    }
}
