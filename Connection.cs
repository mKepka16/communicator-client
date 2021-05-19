using communicator_client.Controllers;
using communicator_client.dataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace communicator_client
{
    class Connection
    {
        private static TcpClient client;
        private static BinaryReader reader;
        private static BinaryWriter writer;
        private static string host = "127.0.0.1";
        private static int port = 200;
        public static bool isConnected = false;

        public static void Start()
        {
            try
            {
                client = new TcpClient(host, port);
                NetworkStream networkStream = client.GetStream();
                reader = new BinaryReader(networkStream);
                writer = new BinaryWriter(networkStream);
                isConnected = true;
                Task.Run(() => Read());
            }
            catch
            {
                isConnected = false;
            }
        }

        public static void Send(string data)
        {
            writer.Write(data);
            writer.Flush();
        }

        public static void Read()
        {
            string readData;
            try
            {
                while (true)
                {
                    readData = reader.ReadString();
                    Payload payload = Payload.Deserialize(readData);
                    PayloadDistributor.Distribute(payload);
                }
            }
            catch
            {
                MessageBox.Show("Server is not available");
                Environment.Exit(0);
            }
        }
    }
}
