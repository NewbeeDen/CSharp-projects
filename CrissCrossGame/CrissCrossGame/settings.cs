using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrissCrossGame.bin
{
    public partial class setting : Form
    {
        string ConfFile = "config.txt";
        UnicastIPAddressInformation[] netAdapters;

        public setting()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            int i = 0;
            netAdapters = new UnicastIPAddressInformation[10];
            foreach (NetworkInterface adapter in adapters)
            {
                cbInterfaces.Items.Add(adapter.Description);
                IPInterfaceProperties ni = adapter.GetIPProperties();
                try
                {
                    netAdapters[i] = ni.UnicastAddresses[1];
                }
                catch { }
                i++;
            }
            if (System.IO.File.Exists(ConfFile))
            {
                StreamReader sr = new StreamReader(ConfFile);
                tbClientIP.Text = sr.ReadLine();
                tbMyNick.Text = sr.ReadLine();
                sr.Close();
                Chat chat = new Chat();
                chat.oponentIP = tbClientIP.Text;
                chat.nick = tbMyNick.Text;
            }
        }

        private void setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void cbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbInterfaces.SelectedIndex;
            if (netAdapters[index] != null)
            {
                lMyIP.Text = netAdapters[index].Address.ToString();
            }
            else
            {
                lMyIP.Text = "";
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbClientIP.Text) && !String.IsNullOrWhiteSpace(tbMyNick.Text))
            {
                if (System.IO.File.Exists(ConfFile))
                {
                    File.Delete(ConfFile);
                }
                StreamWriter fs = new StreamWriter(ConfFile, true, Encoding.Default);
                Chat chat = new Chat();
                chat.oponentIP = tbClientIP.Text;
                chat.nick = tbMyNick.Text;
                fs.WriteLine(tbClientIP.Text);
                fs.WriteLine(tbMyNick.Text);
                fs.Close();
            }
        }

    }
}
