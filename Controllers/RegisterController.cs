using communicator_client.dataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicator_client.Controllers
{
    class RegisterController
    {
        public RegisterController(string status, string data)
        {
            if(status == "success")
            {
                RegisterWindow.registerWindow.RegisteredSuccessfully();
            }
            if(status == "fail")
            {
                ErrorData errorData = ErrorData.Deserialize(data);
                RegisterWindow.registerWindow.DisplayError(errorData.error);
            }
        }
    }
}
