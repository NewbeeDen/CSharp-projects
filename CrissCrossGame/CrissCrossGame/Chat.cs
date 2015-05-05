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
        public Chat()
        {
            InitializeComponent();
            //Создаем поток для приема сообщений
            new Thread(new ThreadStart(Receiver)).Start();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            new Thread(new ParameterizedThreadStart(ThreadSend)).Start(mymessage.Text);
        }

        //Метод потока
        protected void Receiver()
        {
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(7000);
            //Начинаем прослушку
            Listen.Start();
            //и заведем заранее сокет
            Socket ReceiveSocket;
            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[256];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        do
                        {//Собственно читаем
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //и записываем в поток
                            MessageR.Write(Receive, 0, ReceivedBytes);
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceiveSocket.Available > 0);
                        //Добавляем изменения в ChatBox
                        messages.BeginInvoke(AcceptDelegate, new object[] { Encoding.Default.GetString(MessageR.ToArray()), messages });
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        //Делегат доступа к контролам формы
        delegate void SendMsg(String Text, RichTextBox Rtb);

        SendMsg AcceptDelegate = (String Text, RichTextBox Rtb) =>
        {
            Rtb.Text += Text + "\n";
        };

        /// <summary>
        /// Отправляет сообщение в потоке на IP, заданный в контроле IP
        /// </summary>
        /// <param name="Message">Передаваемое сообщение</param>
        void ThreadSend(object Message)
        {
            try
            {
                //Проверяем входной объект на соответствие строке
                String MessageText = "";
                if (Message is String)
                    MessageText = Message as String;
                else
                    throw new Exception("На вход необходимо подавать строку");
                Game frm = new Game();
                //Создаем сокет, коннектимся
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(frm.oponentIP), 7000);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                //Отправляем сообщение
                Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                Connector.Send(SendBytes);
                Connector.Close();
                //Изменяем поле сообщений (уведомляем, что отправили сообщение)
                messages.BeginInvoke(AcceptDelegate, new object[] { frm.mynickname + MessageText, messages });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
