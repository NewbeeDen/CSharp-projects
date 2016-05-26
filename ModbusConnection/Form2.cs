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
        TextBox[,] tb = new TextBox[300, 6];
        ComboBox[] cb = new ComboBox[300];
        string settingsstring;
        int NumberOfStrings;
        Button[] btDelete = new Button[300];
              
        public Form2()
        {
            InitializeComponent();
            NumberOfStrings = ReadSettings();
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private int ReadSettings()
        {
            int x = 0;
            string str;
            if (System.IO.File.Exists(Application.StartupPath + "\\Settings.txt"))
            {
                StreamReader sr = new StreamReader("Settings.txt", Encoding.Default);
                do { 
                    str = sr.ReadLine();
                    if (str != null)
                    {
                        string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        tb[x, 0] = new System.Windows.Forms.TextBox();
                        tb[x, 0].Location = new System.Drawing.Point(13, 70 + x * 22);
                        tb[x, 0].Size = new System.Drawing.Size(256, 23);
                        tb[x, 0].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 0]);
                        tb[x, 0].Text = words[0];

                        tb[x, 1] = new System.Windows.Forms.TextBox();
                        tb[x, 1].Location = new System.Drawing.Point(271, 70 + x * 22);
                        tb[x, 1].Size = new System.Drawing.Size(122, 23);
                        tb[x, 1].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 1]);
                        tb[x, 1].Text = words[1];

                        tb[x, 2] = new System.Windows.Forms.TextBox();
                        tb[x, 2].Location = new System.Drawing.Point(395, 70 + x * 22);
                        tb[x, 2].Size = new System.Drawing.Size(122, 23);
                        tb[x, 2].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 2]);
                        tb[x, 2].Text = words[2];

                        cb[x] = new System.Windows.Forms.ComboBox();
                        cb[x].Location = new System.Drawing.Point(519, 70 + x * 22);
                        cb[x].Size = new System.Drawing.Size(122, 23);
                        cb[x].Text = "BOOL";
                        cb[x].Items.AddRange(new string[] { "BOOL", "INT", "REAL" });
                        Controls.Add(cb[x]);
                        if (words[3] == "BOOL")
                        {
                            cb[x].SelectedIndex = 0;
                        }
                        else if (words[3] == "INT")
                        {
                            cb[x].SelectedIndex = 1;
                        }
                        else if (words[3] == "REAL")
                        {
                            cb[x].SelectedIndex = 2;
                        }
                        
                        tb[x, 3] = new System.Windows.Forms.TextBox();
                        tb[x, 3].Location = new System.Drawing.Point(643, 70 + x * 22);
                        tb[x, 3].Size = new System.Drawing.Size(122, 23);
                        tb[x, 3].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 3]);
                        //if (cb[x].SelectedIndex == 2)
                        //{
                            tb[x, 3].Text = words[4];
                        //}
                        
                        tb[x, 4] = new System.Windows.Forms.TextBox();
                        tb[x, 4].Location = new System.Drawing.Point(767, 70 + x * 22);
                        tb[x, 4].Size = new System.Drawing.Size(122, 23);
                        tb[x, 4].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 4]);
                        //if (cb[x].SelectedIndex == 2)
                        //{
                            tb[x, 4].Text = words[5];
                        //}
                        //else
                        //{
                        //    tb[x, 4].Text = words[4];
                        //}

                        tb[x, 5] = new System.Windows.Forms.TextBox();
                        tb[x, 5].Location = new System.Drawing.Point(891, 70 + x * 22);
                        tb[x, 5].Size = new System.Drawing.Size(122, 23);
                        tb[x, 5].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 5]);
                        //if (cb[x].SelectedIndex == 2)
                        //{
                            tb[x, 5].Text = words[6];
                        //}
                        //else
                        //{
                        //    tb[x, 5].Text = words[5];
                        //}

                        btDelete[x] = new System.Windows.Forms.Button();
                        btDelete[x].Location = new System.Drawing.Point(1015, 69 + x * 22);
                        btDelete[x].Size = new System.Drawing.Size(23, 23);
                        btDelete[x].BackgroundImage = ModbusConnection.Properties.Resources.Buttons_accept_and_delete;
                        btDelete[x].BackgroundImageLayout = ImageLayout.Stretch;
                        btDelete[x].Tag = x.ToString();
                        Controls.Add(btDelete[x]);
                        btDelete[x].Click += new EventHandler(DelPosition);

                        x++;
                    } 
                } while (str != null);
                sr.Close();
            }
            
            return x;
        }

        private void DelPosition(object sender, EventArgs e)
        {
            //Получаем номер удаляемой строки и удаляем элементы
            int x = Convert.ToInt32((sender as Button).Tag);
            for (int i = 0; i < 6; i++)
            {
                Controls.Remove(tb[x, i]);
                if (tb[x, i] != null) tb[x, i] = null;
            }
            Controls.Remove(cb[x]);
            if (cb[x] != null) cb[x] = null;
            Controls.Remove(btDelete[x]);
            if (btDelete[x] != null) btDelete[x] = null;
            
            //Смещаем номера оставшихся строк
            for (int i = x + 1; i < NumberOfStrings; i++)
            {
                btDelete[i].Tag = i - 1;
            }

            //Смещение расположения оставшихся элементов
            for (int i = x; i < NumberOfStrings - 1; i++)
            {
                tb[i, 0] = tb[i + 1, 0];
                tb[i, 0].Location = new System.Drawing.Point(13, 70 + i * 22);
                tb[i, 1] = tb[i + 1, 1];
                tb[i, 1].Location = new System.Drawing.Point(271, 70 + i * 22);
                tb[i, 2] = tb[i + 1, 2];
                tb[i, 2].Location = new System.Drawing.Point(395, 70 + i * 22);
                tb[i, 3] = tb[i + 1, 3];
                tb[i, 3].Location = new System.Drawing.Point(643, 70 + i * 22);
                tb[i, 4] = tb[i + 1, 4];
                tb[i, 4].Location = new System.Drawing.Point(767, 70 + i * 22);
                tb[i, 5] = tb[i + 1, 5];
                tb[i, 5].Location = new System.Drawing.Point(891, 70 + i * 22);
                cb[i] = cb[i + 1];
                cb[i].Location = new System.Drawing.Point(519, 70 + i * 22);
                btDelete[i] = btDelete[i + 1];
                btDelete[i].Location = new System.Drawing.Point(1015, 70 + i * 22);
            }

            NumberOfStrings--;
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; ; x++)
                {
                    if (tb[x,0] == null)
                    {

                        tb[x, 0] = new System.Windows.Forms.TextBox();
                        tb[x, 0].Location = new System.Drawing.Point(13, 70 + NumberOfStrings * 22);
                        tb[x, 0].Size = new System.Drawing.Size(256, 23);
                        tb[x, 0].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 0]);

                        tb[x, 1] = new System.Windows.Forms.TextBox();
                        tb[x, 1].Location = new System.Drawing.Point(271, 70 + NumberOfStrings * 22);
                        tb[x, 1].Size = new System.Drawing.Size(122, 23);
                        tb[x, 1].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 1]);

                        tb[x, 2] = new System.Windows.Forms.TextBox();
                        tb[x, 2].Location = new System.Drawing.Point(395, 70 + NumberOfStrings * 22);
                        tb[x, 2].Size = new System.Drawing.Size(122, 23);
                        tb[x, 2].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 2]);

                        cb[x] = new System.Windows.Forms.ComboBox();
                        cb[x].Location = new System.Drawing.Point(519, 70 + NumberOfStrings * 22);
                        cb[x].Size = new System.Drawing.Size(122, 23);
                        cb[x].Text = "BOOL";
                        cb[x].Items.AddRange(new string[] { "BOOL", "INT", "REAL" });
                        Controls.Add(cb[x]);

                        tb[x, 3] = new System.Windows.Forms.TextBox();
                        tb[x, 3].Location = new System.Drawing.Point(643, 70 + NumberOfStrings * 22);
                        tb[x, 3].Size = new System.Drawing.Size(122, 23);
                        tb[x, 3].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 3]);

                        tb[x, 4] = new System.Windows.Forms.TextBox();
                        tb[x, 4].Location = new System.Drawing.Point(767, 70 + NumberOfStrings * 22);
                        tb[x, 4].Size = new System.Drawing.Size(122, 23);
                        tb[x, 4].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 4]);

                        tb[x, 5] = new System.Windows.Forms.TextBox();
                        tb[x, 5].Location = new System.Drawing.Point(891, 70 + NumberOfStrings * 22);
                        tb[x, 5].Size = new System.Drawing.Size(122, 23);
                        tb[x, 5].BorderStyle = BorderStyle.FixedSingle;
                        Controls.Add(tb[x, 5]);

                        NumberOfStrings++;
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
            DialogResult dg = MessageBox.Show("Save changes?", "Attention", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                StreamWriter sw = new StreamWriter("Settings.txt", false, Encoding.Default);
                for (int i = 0; i < NumberOfStrings; i++)
                {
                    if (tb[i, 0] != null)
                    {
                        settingsstring = tb[i, 0].Text.ToString().Replace(' ', '_');
                        //if (cb[i].Text == "REAL")
                        //{
                            sw.WriteLine(settingsstring + " " + tb[i, 1].Text.ToString().Trim() + " " + tb[i, 2].Text.ToString().Trim() + " " + cb[i].Text.ToString().Trim() + " " + tb[i, 3].Text.ToString().Trim() + " " + tb[i, 4].Text.ToString().Trim() + " " + tb[i, 5].Text.ToString().Trim());
                        //}
                        //else
                        //{
                        //    sw.WriteLine(settingsstring + " " + tb[i, 1].Text.ToString().Trim() + " " + tb[i, 2].Text.ToString().Trim() + " " + cb[i].Text.ToString().Trim() + " " + tb[i, 4].Text.ToString().Trim() + " " + tb[i, 5].Text.ToString().Trim());
                        //}
                    }
                }
                sw.Close();
            }               
        }

        private void buttonDellete_Click(object sender, EventArgs e)
        {

        }
    }
}
