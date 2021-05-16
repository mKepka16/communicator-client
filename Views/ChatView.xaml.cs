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
    /// Logika interakcji dla klasy ChatView.xaml
    /// </summary>
    public partial class ChatView : UserControl
    {
        public static ChatViewModel chatViewModel = new ChatViewModel();
        public static ChatView chatView;

        public ChatView()
        {
            InitializeComponent();
            DataContext = chatViewModel;
            chatView = this;
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        public void ScrollDown()
        {
            ChatScrollViewer.ScrollToBottom();
        }

        private void SendMessage()
        {
            string inputValue = messageInput.Text;
            if (string.IsNullOrEmpty(inputValue)) return;

            inputValue = inputValue.Trim();
            int chatId = chatViewModel.ChatId;
            MessageSendData message = new MessageSendData(inputValue, chatId);
            Payload payload = new Payload("messageSend", message.ToString());
            Connection.Send(payload.ToString());
            chatViewModel.AddMessage(inputValue);
            messageInput.Text = "";
        }

        private void messageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            SendMessage();
        }
    }
}
