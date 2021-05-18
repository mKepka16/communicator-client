using communicator_client.dataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicator_client.Controllers
{
    class PayloadDistributor
    {
        public static void Distribute(Payload payload)
        {

            switch (payload.action)
            {
                case "registerFail":
                    new RegisterController("fail", payload.data);
                    break;
                case "registerSuccess":
                    new RegisterController("success", payload.data);
                    break;
                case "loginFail":
                    new LoginController("fail", payload.data);
                    break;
                case "loginSuccess":
                    new LoginController("success", payload.data);
                    break;
                case "chatsList":
                    new ChatsListController(payload.data);
                    break;
                case "chatHistory":
                    new ChatHistoryController(payload.data);
                    break;
                case "messageReceive":
                    new MessageReceiveController(payload.data);
                    break;
                case "userExists":
                    new UserExistenceController("success");
                    break;
                case "userDoesNotExist":
                    new UserExistenceController("fail");
                    break;
            }
        }
    }
}
