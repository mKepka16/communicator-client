using communicator_client.DataTypes;
using communicator_client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace communicator_client.Controllers
{
    class MessageReceiveController
    {
        public MessageReceiveController(string data)
        {
            MessageReceiveData message = MessageReceiveData.Deserialize(data);
            int currentChatId = ChatView.chatViewModel.ChatId;
            if (message.ChatId != currentChatId) return;

            Application.Current.Dispatcher.Invoke(() =>
            {
                ChatView.chatViewModel.AddMessage(message);
            });
        }
    }
}
