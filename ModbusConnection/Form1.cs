using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusTCP;
using System.Timers;
using System.IO;

namespace ModbusConnection
{
    
    //public class MyTimer : System.Timers.Timer
    //{
    //    public MyTimer()
    //    {
    //    }
    //    public object Tag { get; set; }
    //}

    public partial class Trend : Form
    {
        private ModbusTCP.Master MBmaster;
        private byte[] data1, data2, data3;
        private static System.Timers.Timer myTimer = new System.Timers.Timer();
        string[,] param;
        string[] addresses = new string[20];
        System.Windows.Forms.Timer[] timers; 
        DateTime time;
        ushort Address;
        string str;
        System.Windows.Forms.Timer tm1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer tm2 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer tm3 = new System.Windows.Forms.Timer();

        public Trend()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as System.Windows.Forms.Timer).Tag);
            ushort ID = 4;
            byte unit = Convert.ToByte(0);
            if (param[index, 2] != null)
            {
                Address = Convert.ToUInt16(param[index, 2]);
                byte Length = Convert.ToByte(1);
                MBmaster.ReadInputRegister(ID, unit, Address, Length);
            }
            else
            {
                MessageBox.Show("Введите адресс переменной!!!");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as System.Windows.Forms.Timer).Tag);
            ushort ID = 4;
            byte unit = Convert.ToByte(0);
            if (param[index, 2] != null)
            {
                Address = Convert.ToUInt16(param[index, 2]);
                byte Length = Convert.ToByte(1);
                MBmaster.ReadInputRegister(ID, unit, Address, Length);
            }
            else
            {
                MessageBox.Show("Введите адресс переменной!!!");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as System.Windows.Forms.Timer).Tag);
            ushort ID = 4;
            byte unit = Convert.ToByte(0);
            if (param[index, 2] != null)
            {
                Address = Convert.ToUInt16(param[index, 2]);
                byte Length = Convert.ToByte(1);
                MBmaster.ReadInputRegister(ID, unit, Address, Length);
            }
            else
            {
                MessageBox.Show("Введите адресс переменной!!!");
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //Read settings file
                StreamReader sr = new StreamReader("Settings.txt", Encoding.Default);
                int count = System.IO.File.ReadAllLines("Settings.txt").Length;
                param = new string[count, 7];
                for (int x = 0; x < count; x++)
                {
                    str = sr.ReadLine();
                    if (str != null)
                    {
                        string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        param[x, 0] = words[0];
                        param[x, 1] = words[1];
                        param[x, 2] = words[2];
                        param[x, 3] = words[3];
                        if (param[x, 3] == "REAL") param[x, 4] = words[4];
                        if (param[x, 3] == "REAL") param[x, 5] = words[5]; else param[x, 5] = words[4];
                        if (param[x, 3] == "REAL") param[x, 6] = words[6]; else param[x, 6] = words[5];
                    }
                } 
                sr.Close();

                int j = 0;
                addresses[0] = param[0, 1]; 
                for (int x = 1; x < count; x++)
                {
                    j = 0;
                    for (;;)
                        if (param[x, 1] == addresses[j]) break;
                        else
                        {
                            j++;
                            if (addresses[j] == null)
                            {
                                addresses[j] = param[x, 1];
                                break;
                            }
                        }
                }

                //timers = new MyTimer[count];
                //for (int i = 0; i < count; i++)
                //{
                //    timers[i] = new System.Windows.Forms.Timer();
                //    timers[i].Tag = i;
                //    timers[i].Interval = Convert.ToInt32(param[i, 5]) * 1000;
                //    timers[i].Tick += timer1_Tick;
                //}
                
                tm1.Tag = 0;
                tm1.Interval = Convert.ToInt32(param[0, 5]) * 1000;
                tm1.Tick += timer1_Tick;

                tm2.Tag = 1;
                tm2.Interval = Convert.ToInt32(param[1, 5]) * 1000;
                tm2.Tick += timer2_Tick;

                tm3.Tag = 2;
                tm3.Interval = Convert.ToInt32(param[2, 5]) * 1000;
                tm3.Tick += timer3_Tick;

                if (MBmaster == null)
                {
                    //Create new modbus master and add event function
                    MBmaster = new Master(addresses[0], 502);
                    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponceData1);
                    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponceData2);
                    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponceData3);
                    //MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                    if (MBmaster.connected)
                    {
                        labelStatus.Text = "Connected";
                        buttonConnect.Text = "Disconnect";
                        tm1.Start();
                        tm2.Start();
                        tm3.Start();
                    }
                }
                else
                {
                    MBmaster.Dispose();
                    MBmaster = null;
                    labelStatus.Text = "Disconnected";
                    buttonConnect.Text = "Connect";
                    tm1.Stop();
                    tm2.Stop();
                    tm3.Stop();
                }
            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
            }
        }

        //Event for responce data
        private void MBmaster_OnResponceData1(ushort ID, byte unit, byte function, byte[] values)
        {
            //Separate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponceData1), new object[] { ID, unit, function, values });
                return;
            }
            data1 = values;
            ShowAs1(null, null);
        }

        private void MBmaster_OnResponceData2(ushort ID, byte unit, byte function, byte[] values)
        {
            //Separate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponceData2), new object[] { ID, unit, function, values });
                return;
            }
            data2 = values;
            ShowAs2(null, null);
        }

        private void MBmaster_OnResponceData3(ushort ID, byte unit, byte function, byte[] values)
        {
            //Separate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponceData3), new object[] { ID, unit, function, values });
                return;
            }
            data3 = values;
            ShowAs3(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data1 = new byte[0];
            data2 = new byte[0];
            data3 = new byte[0];
        }

        private void ShowAs1(object sender, System.EventArgs e)
        {
            bool[] bits = new bool[1];
            int[] word = new int[1];

            //Convert data
            if (data1.Length < 2) return;
            word = new int[data1.Length / 2];
            for (int x = 0; x < data1.Length; x = x + 2)
            {
                word[x / 2] = data1[x] * 256 + data1[x + 1];
            }
            time = DateTime.Now;
            textBox.Text += time.ToString() + " " + word[0].ToString() + "\r\n";
        }

        private void ShowAs2(object sender, System.EventArgs e)
        {
            bool[] bits = new bool[1];
            int[] word = new int[1];

            //Convert data
            if (data2.Length < 2) return;
            word = new int[data2.Length / 2];
            for (int x = 0; x < data2.Length; x = x + 2)
            {
                word[x / 2] = data2[x] * 256 + data2[x + 1];
            }
            time = DateTime.Now;
            textBox.Text += time.ToString() + " " + word[0].ToString() + "\r\n";
        }

        private void ShowAs3(object sender, System.EventArgs e)
        {
            bool[] bits = new bool[1];
            int[] word = new int[1];

            //Convert data
            if (data3.Length < 2) return;
            word = new int[data3.Length / 2];
            for (int x = 0; x < data3.Length; x = x + 2)
            {
                word[x / 2] = data3[x] * 256 + data3[x + 1];
            }
            time = DateTime.Now;
            textBox.Text += time.ToString() + " " + word[0].ToString() + "\r\n";
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Options_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();
        }

        private void Trend_Activated(object sender, EventArgs e)
        {

        }
    }
}
