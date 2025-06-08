using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Listener
{
    class Program
    {
        private static TcpClient clientSave;

        static void Main(string[] args)
        {
            //disconnection stuff
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            //tcp stuff
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            TcpClient client = new TcpClient();

            clientSave = client;

            client.Connect(ip, port);
            Console.WriteLine("client connected!!");
            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));

            thread.Start(client);

            string s;
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                ns.Write(buffer, 0, buffer.Length);
            }

            //client.Client.Shutdown(SocketShutdown.Send);
            thread.Join();
            ns.Close();
            //client.Close();
            //Console.WriteLine("disconnect from server!!");
            //Console.ReadKey();
            shutDown();
        }

        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
        }

        static void shutDown()
        {
            clientSave.Client.Shutdown(SocketShutdown.Send);
            clientSave.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
        }

        //when client closes own application stop the client's side connection
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            shutDown();
        }
    }
}