using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModbusConnection
{
    public partial class Form2 : Form
    {
        TextBox[,] tb = new TextBox[100, 6];
        ComboBox[] cb = new ComboBox[100];  

        public Form2()
        {
            InitializeComponent();


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < 100; x++)
                {
                    if (tb[x,0] == null)
                    {

                        tb[x, 0] = new System.Windows.Forms.TextBox();
                        tb[x, 0].Location = new System.Drawing.Point(13, 70 + x * 22);
                        tb[x, 0].Size = new System.Drawing.Size(256, 23);
                        tb[x, 0].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 0]);

                        tb[x, 1] = new System.Windows.Forms.TextBox();
                        tb[x, 1].Location = new System.Drawing.Point(271, 70 + x * 22);
                        tb[x, 1].Size = new System.Drawing.Size(122, 23);
                        tb[x, 1].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 1]);

                        tb[x, 2] = new System.Windows.Forms.TextBox();
                        tb[x, 2].Location = new System.Drawing.Point(395, 70 + x * 22);
                        tb[x, 2].Size = new System.Drawing.Size(122, 23);
                        tb[x, 2].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 2]);

                        cb[x] = new System.Windows.Forms.ComboBox();
                        cb[x].Location = new System.Drawing.Point(519, 70 + x * 22);
                        cb[x].Size = new System.Drawing.Size(122, 23);
                        cb[x].Text = "BOOL";
                        cb[x].Items.AddRange(new string[] { "BOOL", "INT", "REAL" });
                        Controls.Add(cb[x]);

                        tb[x, 3] = new System.Windows.Forms.TextBox();
                        tb[x, 3].Location = new System.Drawing.Point(643, 70 + x * 22);
                        tb[x, 3].Size = new System.Drawing.Size(122, 23);
                        tb[x, 3].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 3]);

                        tb[x, 4] = new System.Windows.Forms.TextBox();
                        tb[x, 4].Location = new System.Drawing.Point(767, 70 + x * 22);
                        tb[x, 4].Size = new System.Drawing.Size(122, 23);
                        tb[x, 4].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 4]);

                        tb[x, 5] = new System.Windows.Forms.TextBox();
                        tb[x, 5].Location = new System.Drawing.Point(891, 70 + x * 22);
                        tb[x, 5].Size = new System.Drawing.Size(122, 23);
                        tb[x, 5].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 5]);

                        break;

                    }
                }
                

            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream("Settings.txt", FileMode.Create, FileAccess.Write);
            for(int i=0; i<100; i++)
            {
                if (tb[i,0] != null)
                {

                }
            }
        }
    }
}
