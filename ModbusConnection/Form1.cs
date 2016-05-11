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

namespace ModbusConnection
{
    public partial class Trend : Form
    {
        private ModbusTCP.Master MBmaster;
        private byte[] data;
        private static System.Timers.Timer myTimer = new System.Timers.Timer();
        DateTime time;
        ushort Address;

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
                if (MBmaster == null)
                {
                    //Create new modbus master and add event function
                    MBmaster = new Master(textboxIP.Text, 502);
                    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponceData);
                    //MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                    if (MBmaster.connected)
                    {
                        labelStatus.Text = "Connected";
                        buttonConnect.Text = "Disconnect";
                        timer1.Enabled = true;
                        //SetTimer();
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
                timer1.Stop();
                MBmaster.Dispose();
                MBmaster = null;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
                labelStatus.Text = "Disconnected";
                buttonConnect.Text = "Connect";
                timer1.Enabled = false;
            }
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

            // timer1.Tick += new EventHandler(timer1_Tick);


        }


        private void SendRequest(Object source, ElapsedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ushort ID = 4;
            byte unit = Convert.ToByte(0);
            if (TBRegAddress.Text != null)
            {
                Address = Convert.ToUInt16(TBRegAddress.Text);
            }
            else
            {
                MessageBox.Show("Введите адресс переменной!!!");
            }
            byte Length = Convert.ToByte(1);

            MBmaster.ReadInputRegister(ID, unit, Address, Length);
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
