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
    class GroupExistenceController
    {
        public GroupExistenceController(bool doesGroupExist, string data = "")
        {
            if (doesGroupExist)
            {
                ErrorData error = ErrorData.Deserialize(data);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    NewChatView.newChatView.SetError(error.error);
                });
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    NewChatView.newChatViewModel.ClearView();

                });
            }
        }
    }
}
