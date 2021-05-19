using communicator_client.dataTypes;
using communicator_client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace communicator_client.Controllers
{
    class UserExistenceController
    {
        public UserExistenceController(string status, string data = "")
        {
            if (status == "success")
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    NewChatView.newChatViewModel.AddUserToList();
                    NewChatView.newChatView.SetError("");
                    NewChatView.newChatViewModel.Nick = "";
                });
            }
            else
            {
                string error = "Taki użytkownik nie istnieje.";
                if (!string.IsNullOrEmpty(data))
                {
                    ErrorData errorData = ErrorData.Deserialize(data);
                    error = errorData.error;
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    NewChatView.newChatView.SetError(error);
                });
            }
        }
    }
}
