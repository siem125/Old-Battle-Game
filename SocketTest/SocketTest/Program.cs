using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketTest
{
    public class Program
    {
        static readonly object _lock = new object();
        static readonly Dictionary<int, TcpClient> list_clients = new Dictionary<int, TcpClient>();
        static List<string> list_messages = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Server started...");

            int count = 1;

            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
            ServerSocket.Start();

            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                lock (_lock) list_clients.Add(count, client);
                Console.WriteLine("Someone connected!!");
                getEntireChat(client);

                Thread t = new Thread(handle_clients);
                t.Start(count);
                count++;
            }
        }

        static void checkDisconnectionStates()
        {
            for (int i = 0; i <= list_clients.Count; i++)
            {
                TcpClient client = list_clients[i];
                
                //checks if has disconected
                if (client.Connected == false)
                {
                    client.GetStream().Close();
                    client.Close();
                }
            }
        }

        static bool checkDisconnectionState(TcpClient client)
        {
            //checks if has disconected
            //if (client.Connected == false)
            //{
            //    client.Client.Dispose();
            //    client.Close();
            //}

            if (client.Connected)
            {

                bool IsYouConnectionAlright =

                client.Client.Poll(01, SelectMode.SelectWrite) &&

                client.Client.Poll(01, SelectMode.SelectRead) && !client.Client.Poll(01, SelectMode.SelectError) ? true : false;

                return IsYouConnectionAlright;
            }

            return false;
        }

        public static void handle_clients(object o)
        {
            //try
            //{
                int id = (int)o;
                TcpClient client;

                lock (_lock) client = list_clients[id];

                while (true)
                {
                //checks if has disconected
                //bool isCon = checkDisconnectionState(client);

                //if (isCon == true)
                //{
                try
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int byte_count = stream.Read(buffer, 0, buffer.Length);

                    if (byte_count == 0)
                    {
                        break;
                    }

                    string data = Encoding.ASCII.GetString(buffer, 0, byte_count);
                    broadcast(client, data);
                    Console.WriteLine(data);
                }
                catch (Exception ex)
                {

                }
                //}
                }

                lock (_lock) list_clients.Remove(id);
                client.Client.Shutdown(SocketShutdown.Both);
                client.Close();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        public static void broadcast(TcpClient sender, string data)
        {
            list_messages.Add(data);
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);

            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    if (c != sender)
                    {
                        NetworkStream stream = c.GetStream();

                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        public static void broadcastToSpecificMember(TcpClient sender, string data)
        {
            //splits message
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);

            //sends message
            NetworkStream stream = sender.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void getEntireChat(TcpClient client)
        {
            foreach (string data in list_messages)
            {
                broadcastToSpecificMember(client, data);
            }
        }

        public static void broadcastToAll(string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);

            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    NetworkStream stream = c.GetStream();

                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
