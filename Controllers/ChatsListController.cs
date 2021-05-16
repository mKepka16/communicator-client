using communicator_client.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace communicator_client.Controllers
{
    class ChatsListController
    {
        ChatListData chatList;

        public ChatsListController(string data)
        {
            chatList = ChatListData.Deserialize(data);
            Application.Current.Dispatcher.Invoke(() =>
            {
                ChatWindow.listModel.SetList(chatList);
            });
        }
    }
}
