using communicator_client.DataTypes;
using communicator_client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace communicator_client.Models
{
    public class ChatListModel : ObservableObject
    {
        public ObservableCollection<ChatListItemData> List { get; set; }

        public ChatListModel()
        {
            List = new ObservableCollection<ChatListItemData>();
        }

        public void SetList(ChatListData listData)
        {

            List<ChatListItemData> list = listData.ChatList;
            foreach (ChatListItemData item in list)
            {
                List.Add(item);
            }
        }
    }
}
