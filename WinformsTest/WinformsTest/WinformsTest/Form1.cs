using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsTest
{
    public partial class Form1 : Form
    {
        private static TcpClient clientSave;
        private static string sendedMessage = "";

        public Form1()
        {
            InitializeComponent();

            //disconnection stuff
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            //tcp setup stuff
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            TcpClient client = new TcpClient();

            clientSave = client;

            //connect to the server
            clientSave.Connect(ip, port);
            Console.WriteLine("client connected!!");

            //opens thread
            Thread thread = new Thread(checkBGWReceiver);
            thread.Start();

            BackgroundWorkerReceiver.RunWorkerAsync();
            BackgroundWorkerReceiver.WorkerReportsProgress = true;
            backgroundWorkerSender.WorkerSupportsCancellation = true;
        }

        private void checkBGWReceiver()
        {
            if(!BackgroundWorkerReceiver.IsBusy)
            {
                BackgroundWorkerReceiver.RunWorkerAsync();
            }
        }

        private void cancelReceiver()
        {
            if (BackgroundWorkerReceiver.WorkerSupportsCancellation == true)
            {
                BackgroundWorkerReceiver.CancelAsync();
            }
        }

        private void BackgroundWorkerReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                Thread.Sleep(1000);

                if (clientSave.Connected)
                {
                    //client connected

                    //
                    //ReceiveData(clientSave);

                    //
                    List<string> messages = ReceiveData(clientSave);
                    worker.ReportProgress(0, messages);
                }
                else
                {
                    //client not connected/failed
                }
            }
        }

        private void BackgroundWorkerReceiver_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<string> messages = (List<string>)e.UserState;

            for (int i = 0; i < messages.Count(); i++)
            {
                lbChat.Items.Add(messages[i]);
                Application.DoEvents();
            }
        }

        private void backgroundWorkerSender_DoWork(object sender, DoWorkEventArgs e)
        {
            if (clientSave.Connected)
            {
                if (sendedMessage != string.Empty || sendedMessage != "")
                {
                    NetworkStream ns = clientSave.GetStream();
                    byte[] buffer = Encoding.ASCII.GetBytes(sendedMessage);
                    ns.Write(buffer, 0, buffer.Length);
                }
            }
            else
            {

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendedMessage = txtMessage.Text;

            backgroundWorkerSender.RunWorkerAsync();

            txtMessage.Text = string.Empty;
            Application.DoEvents();
        }

        private List<string> ReceiveData(TcpClient client)
        {
            try
            {
                List<string> messages = new List<string>();

                if (client.Connected)
                {
                    NetworkStream ns = clientSave.GetStream();

                    //checks if there is data to read from the networkstream
                    if (ns.CanRead)
                    {
                        byte[] receivedBytes = new byte[1024];
                        int byte_count;

                        if ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                        {
                            messages.Add(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                        }

                        //while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                        //{
                        //    messages.Add(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                        //}
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        private void ReceiveDataShowListBox(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                lbChat.Items.Add(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
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
