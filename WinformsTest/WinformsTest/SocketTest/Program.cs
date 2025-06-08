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

                try
                {
                    //check if still connected by sending a bit
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        //test connection
                        byte[] buff = new byte[1];
                        if (!client.Connected)
                        {
                            //client disconnected so remove it from list
                            list_clients.Remove(id);
                            Console.WriteLine("Client disconnected");
                            break;
                        }
                    }

                    //gets message and sends it to targets
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int byte_count = stream.Read(buffer, 0, buffer.Length);

                    if (byte_count == 0)
                    {
                        break;
                    }

                    string data = Encoding.ASCII.GetString(buffer, 0, byte_count);

                    //enventually filter message to see which audiance gets the message
                    string target = "All";

                    //filter audiance and send data to client(s)
                    if (target == "All")
                    {
                        broadcastToAll(data); //sends the message to all
                    }
                    else if (target == "AllButMe")
                    {
                        broadcast(client, data); //sends the message to all except the sender
                    }
                    else
                    {
                        //filter indexed from message
                        int indexed = -1;

                        if (indexed != -1)
                        {
                            TcpClient filteredClient = list_clients[indexed];
                            broadcastToSpecificMember(filteredClient, data);
                        }
                    }                    
                    
                    Console.WriteLine(data);
                }
                catch (Exception ex)
                {
                    //do nothing
                }
            }

            lock (_lock) list_clients.Remove(id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();

            //threads end
            //Console.WriteLine("thread has stopped since client disconnected");
        }

        /// <summary>
        /// Broadcasts to all but sender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public static void broadcast(TcpClient sender, string data)
        {
            list_messages.Add(data);
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);
            //byte[] buffer = Encoding.ASCII.GetBytes(data + " \r\n");

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

        /// <summary>
        /// Broadcasts to specific member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public static void broadcastToSpecificMember(TcpClient sender, string data)
        {
            //splits message
            //list_messages.Add(data);
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);

            //sends message
            NetworkStream stream = sender.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Send entire chat to specific client
        /// </summary>
        /// <param name="client"></param>
        public static void getEntireChat(TcpClient client)
        {
            foreach (string data in list_messages)
            {
                broadcastToSpecificMember(client, data);
            }
        }

        /// <summary>
        /// Broadcasts to all
        /// </summary>
        /// <param name="data"></param>
        public static void broadcastToAll(string data)
        {
            list_messages.Add(data);
            //byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);
            byte[] buffer = Encoding.ASCII.GetBytes(data + " \r\n");

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
