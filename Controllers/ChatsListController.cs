using communicator_client.dataTypes;
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
    class ChatsListController
    {
        ChatListData chatList;
        static bool isStartingViewSet = false;

        public ChatsListController(string data)
        {
            chatList = ChatListData.Deserialize(data);
            Application.Current.Dispatcher.Invoke(() =>
            {
                ChatWindow.listModel.SetList(chatList);

                if(NewChatView.isOpened)
                {
                    if (NewChatView.isOpened)
                    {
                        NewChatView.isOpened = false;
                        ChatWindow.chatWindow.DataContext = ChatWindow.chatViewModel;
                    }
                    
                    int lastIndex = ChatWindow.listModel.List.Count - 1;
                    int id = ChatWindow.listModel.List[lastIndex].Id;
                    string content = ChatWindow.listModel.List[lastIndex].Name;
                    ChatRequestData requestData = new ChatRequestData(id, content);
                    Payload payload = new Payload("chatRequest", requestData.ToString());
                    Connection.Send(payload.ToString());
                    ChatView.chatViewModel.ChatId = id;
                }

                if(!isStartingViewSet)
                {
                    ChatWindow.chatWindow.SetStartingView();
                    isStartingViewSet = true;
                }
            });
        }
    }
}
