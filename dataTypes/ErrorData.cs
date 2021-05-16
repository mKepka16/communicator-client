using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicator_client.dataTypes
{
    class ErrorData
    {
        public string error;

        public ErrorData(string error)
        {
            this.error = error;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public static ErrorData Deserialize(string toDeserialize)
        {
            return JsonConvert.DeserializeObject<ErrorData>(toDeserialize);
        }
    }
}
