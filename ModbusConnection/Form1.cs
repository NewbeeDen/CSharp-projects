using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ModbusTCP;
using System.Timers;
using System.IO;

namespace ModbusConnection
{
    
    public partial class Trend : Form
    {
        private ModbusTCP.Master MBmaster;
        private byte[] data1;
        private static System.Timers.Timer myTimer = new System.Timers.Timer();
        string[,] param;
        int[] queue;
        string[] addresses = new string[20];
        int currentAddress, count, z;
        System.Windows.Forms.Timer[] timers; 
        DateTime time;
        ushort Address, ID;
        string str;
        
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
            if (param[index, 3] == "BOOL") ID = 1;
            else ID = 4;
            byte unit = Convert.ToByte(0);
            if (param[index, 2] != null && MBmaster != null)
            {
                Address = Convert.ToUInt16(param[index, 2]);
                byte Length = Convert.ToByte(1);
                if (ID == 1) MBmaster.ReadCoils(ID, unit, Address, Length);
                else MBmaster.ReadInputRegister(ID, unit, Address, Length);
                queue[index] = Address;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //Read settings file
                StreamReader sr = new StreamReader("Settings.txt", Encoding.Default);
                count = System.IO.File.ReadAllLines("Settings.txt").Length;
                z = count - 1;
                param = new string[count, 7];
                timers = new System.Windows.Forms.Timer[count];
                queue = new int[count];
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

                for (int i = 0; i < count; i++)
                {
                    timers[i] = new System.Windows.Forms.Timer();
                    timers[i].Tag = i;
                    timers[i].Interval = Convert.ToInt32(param[i, 5]) * 1000;
                    timers[i].Tick += timer1_Tick;
                }

                if (MBmaster == null)
                {
                    //Create new modbus master and add event function
                    MBmaster = new Master(addresses[0], 502);
                    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponceData1);
                    //MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                    if (MBmaster.connected)
                    {
                        labelStatus.Text = "Connected";
                        buttonConnect.Text = "Disconnect";
                        for (int i = 0; i < count; i++)
                        {
                            timers[i].Start();
                        }
                    }
                }
                else
                {
                    MBmaster.Dispose();
                    MBmaster = null;
                    labelStatus.Text = "Disconnected";
                    buttonConnect.Text = "Connect";
                    for (int i = 0; i < count; i++)
                    {
                        timers[i].Stop();
                    }
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
                while (true)
                {
                    currentAddress = queue[z];
                    queue[z] = 0;
                    if (z > 0) z--;
                    else z = count - 1;
                    break;
                }
                //currentAddress = queue[z];
                //queue[z] = 0;
                //if (z < count - 1) z++;
                //else z = 0;
                return;
            }
            data1 = values;
            ShowAs(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data1 = new byte[0];
        }

        private void ShowAs(object sender, System.EventArgs e)
        {
            bool[] bits = new bool[1];
            int[] word = new int[1];
            time = DateTime.Now;

            //Convert data
            if (data1.Length < 2)
            {
                textBox.Text += time.ToString() + " " + currentAddress.ToString() + " " + data1[0].ToString() + "\r\n";
                return;
            }
            word = new int[data1.Length / 2];
            for (int x = 0; x < data1.Length; x = x + 2)
            {
                word[x / 2] = data1[x] * 256 + data1[x + 1];
            }
            
            textBox.Text += time.ToString() + " " + currentAddress.ToString() + " " + word[0].ToString() + "\r\n";
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
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
