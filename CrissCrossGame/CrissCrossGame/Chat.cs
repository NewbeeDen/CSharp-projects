using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrissCrossGame
{
    public partial class Chat : Form
    {

        string localIP = "0.0.0.0";
        public string oponentIP = "";
        public string nick = "";

        public Chat()
        {
            InitializeComponent();
            //Create thread for receiving messages 
            new Thread(new ThreadStart(Receiver)).Start();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            new Thread(new ParameterizedThreadStart(ThreadSend)).Start(mymessage.Text);
        }

        //Thread method 
        protected void Receiver()
        {
            //Create Listener on localhost and port 7000
            TcpListener Listen = new TcpListener(IPAddress.Parse(localIP), 7000);
            Thread.Sleep(1000);
            //Start listen
            Listen.Start();
            //and create socket
            Socket ReceiveSocket;
            while (true)
            {
                try
                {
                    //Message came
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[256];
                    //Read message will be in thread
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Number of readed bytes
                        Int32 ReceivedBytes;
                        do
                        {//Reading
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //and write in thread
                            MessageR.Write(Receive, 0, ReceivedBytes);
                            //Reading, while in queue is data
                        } while (ReceiveSocket.Available > 0);
                        //Add changes in ChatBox
                        messages.BeginInvoke(AcceptDelegate, new object[] { Encoding.Default.GetString(MessageR.ToArray()), messages });
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Access delegate to form control
        delegate void SendMsg(String Text, RichTextBox Rtb);

        SendMsg AcceptDelegate = (String Text, RichTextBox Rtb) =>
        {
            Rtb.Text += Text + "\n";
        };

        /// <summary>
        /// Send message in thread on IP from settings
        /// </summary>
        /// <param name="Message">Message which sending</param>
        void ThreadSend(object Message)
        {
            try
            {
                //Check that inputed object match to string
                String MessageText = "";
                if (Message is String)
                    MessageText = Message as String;
                else
                    throw new Exception("На вход необходимо подавать строку");
                //Create socket and connecting
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(oponentIP), 7000);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                if (Connector.Connected)
                {
                    //Send message
                    Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                    Connector.Send(SendBytes);
                    Connector.Close();
                    //Change message field
                    messages.BeginInvoke(AcceptDelegate, new object[] { nick + MessageText, messages });
                }
                else
                {
                    MessageBox.Show("Не удалось установить соединение! Проверьте настройки!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            
        }




    }
}
