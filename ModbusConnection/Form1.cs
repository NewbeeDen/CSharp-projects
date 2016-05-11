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
    public partial class Trend : Form
    {
        private ModbusTCP.Master MBmaster;
        private byte[] data;
        private static System.Timers.Timer myTimer = new System.Timers.Timer();
        string[,] param;
        string[] addresses = new string[20]; 
        DateTime time;
        ushort Address;
        string str;

        public Trend()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

                int z = 1, j = 0;
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

                for (int i = 0; i < 4; i++) textBox.Text += addresses[i] + "\r\n";

                //if (MBmaster == null)
                //{
                //    //Create new modbus master and add event function
                //    MBmaster = new Master(param[0,1], 502);
                //    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponceData);
                //    //MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                //    if (MBmaster.connected)
                //    {
                //        labelStatus.Text = "Connected";
                //        buttonConnect.Text = "Disconnect";
                //        timer1.Enabled = true;
                //    }
                //}
                //else
                //{
                //    MBmaster.Dispose();
                //    MBmaster = null;
                //    labelStatus.Text = "Disconnected";
                //    buttonConnect.Text = "Connect";
                //    timer1.Enabled = false;
                //}
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
                timer1.Stop();
                MBmaster.Dispose();
                MBmaster = null;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            
        }

        //Read input register
        private void buttonReadReg_Click(object sender, EventArgs e)
        {

        }

        //Event for responce data
        private void MBmaster_OnResponceData(ushort ID, byte unit, byte function, byte[] values)
        {
            //Separate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponceData), new object[] { ID, unit, function, values });
                return;
            }
            data = values;
            ShowAs(null, null);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data = new byte[0];
        }

        private void ShowAs(object sender, System.EventArgs e)
        {
            bool[] bits = new bool[1];
            int[] word = new int[1];

            //Convert data
            if (data.Length < 2) return;
            word = new int[data.Length / 2];
            for (int x = 0; x < data.Length; x = x + 2)
            {
                word[x / 2] = data[x] * 256 + data[x + 1];
            }
            time = DateTime.Now;
            textBox.Text += time.ToString() + " " + word[0].ToString() + "\r\n";
        }

        private void SetTimer()
        {


        }


        private void SendRequest(Object source, ElapsedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ushort ID = 4;
            byte unit = Convert.ToByte(0);
            if (param[0,2] != null)
            {
                Address = Convert.ToUInt16(param[0, 2]);
                byte Length = Convert.ToByte(1);
                MBmaster.ReadInputRegister(ID, unit, Address, Length);
            }
            else
            {
                MessageBox.Show("Введите адресс переменной!!!");
            }
            
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Options_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();
        }
    }
}
