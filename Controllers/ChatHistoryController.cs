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
    class ChatHistoryController
    {
        public ChatHistoryController(string data)
        {
            ChatHistoryData chatHistory = ChatHistoryData.Deserialize(data);
            Application.Current.Dispatcher.Invoke(() =>
            {
                ChatView.chatViewModel.Update(chatHistory);
            });
        }
    }
}
