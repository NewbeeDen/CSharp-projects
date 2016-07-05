using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EasyModbus;
//using ModbusTCP;
using System.Timers;
using System.IO;
using System.Runtime.InteropServices;

namespace ModbusConnection
{
    
    public partial class Trend : Form
    {

        //private ModbusTCP.Master MBmaster;
        private byte[] data1;
        bool SomeServerConnected;
        bool[] dataBool;
        int[,] values, states, statesTime;
        int[] dataInt, state, stateTime;
        private static System.Timers.Timer myTimer = new System.Timers.Timer();
        private ModbusClient[] modbusClient = new ModbusClient[20];
        string[,] param;
        int[] queue;
        string[] addresses = new string[20];
        int count, z;
        System.Windows.Forms.Timer[] timers; 
        DateTime time;
        ushort Address, ID;
        string str;

        private class NETRESOURCE
        {
            public ResourceScope dwScope = 0;
            public ResourceType dwType = 0;
            public ResourceDisplayType dwDisplayType = 0;
            public ResourceUsage dwUsage = 0;
            public string lpLocalName = null;
            public string lpRemoteName = null;
            public string lpComment = null;
            public string lpProvider = null;
        }

        public enum ResourceScope
        {
            RESOURCE_CONNECTED = 1,
            RESOURCE_GLOBALNET,
            RESOURCE_REMEMBERED,
            RESOURCE_RECENT,
            RESOURCE_CONTEXT
        }

        public enum ResourceType
        {
            RESOURCETYPE_ANY,
            RESOURCETYPE_DISK,
            RESOURCETYPE_PRINT,
            RESOURCETYPE_RESERVED
        }

        public enum ResourceUsage
        {
            RESOURCEUSAGE_CONNECTABLE = 0x00000001,
            RESOURCEUSAGE_CONTAINER = 0x00000002,
            RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
            RESOURCEUSAGE_SIBLING = 0x00000008,
            RESOURCEUSAGE_ATTACHED = 0x00000010,
            RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
        }

        public enum ResourceDisplayType
        {
            RESOURCEDISPLAYTYPE_GENERIC,
            RESOURCEDISPLAYTYPE_DOMAIN,
            RESOURCEDISPLAYTYPE_SERVER,
            RESOURCEDISPLAYTYPE_SHARE,
            RESOURCEDISPLAYTYPE_FILE,
            RESOURCEDISPLAYTYPE_GROUP,
            RESOURCEDISPLAYTYPE_NETWORK,
            RESOURCEDISPLAYTYPE_ROOT,
            RESOURCEDISPLAYTYPE_SHAREADMIN,
            RESOURCEDISPLAYTYPE_DIRECTORY,
            RESOURCEDISPLAYTYPE_TREE,
            RESOURCEDISPLAYTYPE_NDSCONTAINER
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NETRESOURCE lpNetResource, string lpPassword, string lpUsername, int dwFlags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string lpName, int dwFlags, int fForce);

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
            if (param[index, 2] != null && modbusClient != null)
            {
                Address = Convert.ToUInt16(param[index, 2]);
                byte Length = Convert.ToByte(1);
                for (int i = 0; i < 20; i++)
                {
                    if (param[index, 1] == addresses[i])
                    {
                        if (modbusClient[i] != null)
                        {
                            if (ID == 1)
                            {
                                dataBool = modbusClient[i].ReadCoils(Address, Length);
                                if (Convert.ToUInt16(param[index, 4]) != 0)
                                {
                                    state = modbusClient[i].ReadInputRegisters(Convert.ToUInt16(param[index, 4]), Convert.ToByte(1));
                                }
                                if (Convert.ToUInt16(param[index, 5]) != 0)
                                {
                                    stateTime = modbusClient[i].ReadInputRegisters(Convert.ToUInt16(param[index, 5]), Convert.ToByte(1));
                                }
                                if (z <= 0)
                                {
                                    textBox.Text += "\r\n";
                                    z = count;
                                }
                                values[index, 2] = Convert.ToInt16(dataBool[0]);
                                if (values[index, 0] == 0)
                                {
                                    values[index, 0] = Address;
                                    states[index, 0] = Convert.ToUInt16(param[index, 4]);
                                    statesTime[index, 0] = Convert.ToUInt16(param[index, 5]);
                                    values[index, 1] = Convert.ToInt16(dataBool[0]);
                                    states[index, 1] = state[0];
                                    statesTime[index, 1] = stateTime[0];
                                    values[index, 2] = Convert.ToInt16(dataBool[0]);
                                    states[index, 2] = state[0];
                                    statesTime[index, 2] = stateTime[0];
                                    string filename = @"\\10.0.4.243\exchange$\ASUTP\" + param[index, 6] + ".txt";
                                    StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                    string Time = DateTime.Now.ToString();
                                    string[] words = Time.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    sw.Write(words[0].ToString() + "\t" + words[1].ToString() + "\t" + values[index, 2] + "\t" + statesTime[index, 2]);
                                    sw.Close();
                                }
                                if (values[index, 1] != values[index, 2])
                                {
                                    string filename = @"\\10.0.4.243\exchange$\ASUTP\" + param[index, 6] + ".txt";
                                    StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                    string Time = DateTime.Now.ToString();
                                    string[] words = Time.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    sw.Write("\r\n");
                                    sw.Write(words[0].ToString() + "\t" + words[1].ToString() + "\t" + values[index, 2]);
                                    sw.Close();
                                    values[index, 1] = values[index, 2];
                                }
                                states[index, 2] = state[0];
                                if (states[index, 1] != states[index, 2])
                                {
                                    states[index, 1] = states[index, 2];
                                    string filename = @"\\10.0.4.243\exchange$\ASUTP\" + param[index, 6] + ".txt";
                                    StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                    sw.Write("\t" + states[index, 2]);
                                    sw.Close();
                                }
                                statesTime[index, 2] = stateTime[0];
                                if (statesTime[index, 1] != statesTime[index, 2])
                                {
                                    statesTime[index, 1] = statesTime[index, 2];
                                    string filename = @"\\10.0.4.243\exchange$\ASUTP\" + param[index, 6] + ".txt";
                                    StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                    sw.Write("\t" + statesTime[index, 2]);
                                    sw.Close();
                                }

                                textBox.Text += Address.ToString() + ":" + values[index, 2].ToString() + " " + statesTime[index, 2].ToString();
                                z--;
                                return;
                            }
                            else dataInt = modbusClient[i].ReadInputRegisters(Address, Length);
                            if (z <= 0)
                            {
                                textBox.Text += "\r\n";
                                z = count;
                            }
                            if (values[index, 0] == 0)
                            {
                                values[index, 0] = Address;
                                values[index, 1] = dataInt[0];
                                values[index, 2] = dataInt[0];
                            }
                            values[index, 2] = dataInt[0];
                            if (values[index, 1] != values[index, 2])
                            {
                                values[index, 1] = values[index, 2];
                                string filename = @"\\10.0.4.243\exchange$\ASUTP\" + param[index, 6] + ".txt";
                                StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                string Time = DateTime.Now.ToString();
                                string[] words = Time.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                sw.WriteLine(words[0].ToString() + "\t" + words[1].ToString() + "\t" + values[index, 2]);
                                sw.Close();
                            }
                            textBox.Text += Address.ToString() + ":" + dataInt[0].ToString() + " ";
                            z--;
                        }
                    }
                }
                time = DateTime.Now;
                int[] word = new int[1];
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SomeServerConnected)
                {
                    //Read settings file
                    StreamReader sr = new StreamReader("Settings.txt", Encoding.Default);
                    count = System.IO.File.ReadAllLines("Settings.txt").Length;
                    z = count;
                    values = new int[count, 3];
                    states = new int[count, 3];
                    param = new string[count, 8];
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
                            //if (param[x, 3] == "REAL")
                            param[x, 4] = words[4];
                            //if (param[x, 3] == "REAL")
                            param[x, 5] = words[5];
                            //else param[x, 5] = words[4];
                            //if (param[x, 3] == "REAL")
                            param[x, 6] = words[6];
                            //else param[x, 6] = words[5];
                            param[x, 7] = words[7];
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

                    for (int i = 0; i < 20; i++)
                    {
                        if (addresses[i] != null)
                        {
                            modbusClient[i] = new ModbusClient(addresses[i], 502);
                        }
                        else break;
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        if (modbusClient[i] != null)
                        {
                            do
                            {
                                modbusClient[i].Connect();
                            } while (!modbusClient[i].Connected);
                        }
                        else { break; }
                    }
                    
                    labelStatus.Text = "Connected";
                    buttonConnect.Text = "Disconnect";
                    SomeServerConnected = true;
                    for (int i = 0; i < count; i++)
                    {
                        timers[i].Start();
                    }
                    NETRESOURCE rc = new NETRESOURCE();
                    rc.dwType = 0x00000000;
                    rc.lpRemoteName = @"\\10.0.4.243\exchange$\ASUTP";
                    rc.lpLocalName = null;
                    rc.lpProvider = null;
                    int ret = WNetAddConnection2(rc, "kfp314", "LazarenkoD", 0);
                    time = DateTime.Now;
                    textBox.Text += time.ToString() + "\r\n";
               }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (modbusClient[i] != null)
                        {
                            modbusClient[i].Disconnect();
                            modbusClient[i] = null;
                        }
                    }
                    SomeServerConnected = false;
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
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    if (modbusClient[i] != null)
                    {
                        modbusClient[i].Disconnect();
                        modbusClient[i] = null;
                    }
                }
            }
            catch (SystemException er)
            {
                MessageBox.Show(er.Message);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data1 = new byte[0];
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
