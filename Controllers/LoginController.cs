using communicator_client.dataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicator_client.Controllers
{
    class LoginController
    {
        public LoginController(string status, string data)
        {
            if(status == "success")
            {
                LoginWindow.loginWindow.LoginSuccessfully();
            }
            if(status == "fail")
            {
                ErrorData errorData = ErrorData.Deserialize(data);
                LoginWindow.loginWindow.DisplayError(errorData.error);
            }
        }
    }
}
