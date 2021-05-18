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
        public UserExistenceController(string status)
        {
            if (status == "success")
            {

            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    NewChatView.newChatView.SetError("Taki użytkownik nie istnieje.");
                });
            }
        }
    }
}
