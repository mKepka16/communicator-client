using communicator_client.dataTypes;
using communicator_client.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace communicator_client.ViewModels
{
    public class NewChatViewModel : ObservableObject
    {
        
        private string _nick;
        public string Nick
        {
            get => _nick ?? "";
            set
            {
                _nick = value;
                OnPropertyChanged();
            }
        }

        private string _chatName;
        public string ChatName
        {
            get => _chatName ?? "";
            set
            {
                _chatName = value;
                OnPropertyChanged();
            }
        }

        private Visibility _chatNameInputVisibility = Visibility.Collapsed;
        public Visibility ChatNameInputVisibility
        {
            get => _chatNameInputVisibility;
            set
            {
                _chatNameInputVisibility = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NickData> UsersList { get; set; }

        public NewChatViewModel()
        {
            UsersList = new ObservableCollection<NickData>();
        }

        public NewChatData GetChatData()
        {
            List<NickData> usersList = new List<NickData>();
            foreach (NickData nickData in UsersList)
            {
                usersList.Add(nickData);
            }
            NewChatData newChatData = new NewChatData(
                ChatName,
                usersList
            );
            return newChatData;
        }

        public void ManageChatNameInputVisibility()
        {
            if (UsersList.Count > 1)
            {
                ChatNameInputVisibility = Visibility.Visible;
            }
            else
            {
                ChatNameInputVisibility = Visibility.Collapsed;
            }
        }

        public void AddUserToList(NickData nick)
        {
            UsersList.Add(nick);
            ManageChatNameInputVisibility();
        }

        public void AddUserToList()
        {
            UsersList.Add(new NickData(Nick));
            ManageChatNameInputVisibility();
            
        }

        public void DeleteUserFromList(NickData nick)
        {
            foreach (NickData nickData in UsersList)
            {
                if (nickData.Nick == nick.Nick)
                {
                    UsersList.Remove(nickData);
                    ManageChatNameInputVisibility();
                    return;
                }
            }
        }

        public void ClearView()
        {
            Nick = "";
            UsersList.Clear();
            ChatName = "";
            ChatNameInputVisibility = Visibility.Collapsed;
        }

        public bool IsOnList(NickData nick)
        {
            IEnumerable<NickData> sameNicks = UsersList.Where(nickData => nickData.Nick == nick.Nick);
            return sameNicks.Count() > 0;
        }
    }
}
