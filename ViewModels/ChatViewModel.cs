using communicator_client.DataTypes;
using communicator_client.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace communicator_client.ViewModels
{
    public class ChatViewModel : ObservableObject
    {
        private string _title;
        public string Title
        {
            get => _title ?? "";
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public int ChatId { get; set; }

        public ObservableCollection<MessageData> Messages { get; set; }

        public ChatViewModel()
        {
            Title = "Unknown";
            ChatId = 0;
            Messages = new ObservableCollection<MessageData>();
        }

        public void Update(ChatHistoryData chatHistory)
        {
            Title = chatHistory.Name;
            Messages.Clear();
            string lastNick = "";
            foreach (ChatMessageData message in chatHistory.ChatHistory)
            {
                MessageData UiMessage = new MessageData(message.Content, message.SenderNick, message.IsMyMessage, lastNick);
                Messages.Add(UiMessage);
                lastNick = message.SenderNick;
            }
            ChatView.chatView.ScrollDown();
        }

        public void AddMessage(MessageReceiveData message)
        {
            string lastNick = "";
            if(Messages.Count > 0)
                lastNick = Messages[Messages.Count - 1].Author;
            Messages.Add(new MessageData(message.Content, message.Author, false, lastNick));
            ChatView.chatView.ScrollDown();
        }

        public void AddMessage(string message)
        {
            Messages.Add(new MessageData(message, "", true, ""));
            ChatView.chatView.ScrollDown();
        }
    }

    public class MessageData
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public string Alignment { get; set; }
        public Visibility AuthorVisibility { get; set; }

        public MessageData(string Content, string Author, bool IsOwnMessage, string lastAuthor)
        {
            this.Content = Content;
            this.Author = Author;
            Alignment = IsOwnMessage ? "Right" : "Left";
            AuthorVisibility = IsOwnMessage ? Visibility.Collapsed : Visibility.Visible;
            if (!IsOwnMessage && lastAuthor == Author)
                AuthorVisibility = Visibility.Collapsed;
        }
    }
}
