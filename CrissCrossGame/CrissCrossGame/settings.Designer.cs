namespace CrissCrossGame.bin
{
    partial class setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lIP = new System.Windows.Forms.Label();
            this.lNick = new System.Windows.Forms.Label();
            this.tbClientIP = new System.Windows.Forms.TextBox();
            this.tbMyNick = new System.Windows.Forms.TextBox();
            this.cbInterfaces = new System.Windows.Forms.ComboBox();
            this.ltextMyIP = new System.Windows.Forms.Label();
            this.lMyIP = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lIP
            // 
            this.lIP.AutoSize = true;
            this.lIP.Location = new System.Drawing.Point(35, 23);
            this.lIP.Name = "lIP";
            this.lIP.Size = new System.Drawing.Size(119, 13);
            this.lIP.TabIndex = 0;
            this.lIP.Text = "IP адрес собеседника";
            // 
            // lNick
            // 
            this.lNick.AutoSize = true;
            this.lNick.Location = new System.Drawing.Point(226, 25);
            this.lNick.Name = "lNick";
            this.lNick.Size = new System.Drawing.Size(49, 13);
            this.lNick.TabIndex = 1;
            this.lNick.Text = "Ваш ник";
            // 
            // tbClientIP
            // 
            this.tbClientIP.Location = new System.Drawing.Point(13, 50);
            this.tbClientIP.Name = "tbClientIP";
            this.tbClientIP.Size = new System.Drawing.Size(185, 20);
            this.tbClientIP.TabIndex = 2;
            // 
            // tbMyNick
            // 
            this.tbMyNick.Location = new System.Drawing.Point(213, 50);
            this.tbMyNick.Name = "tbMyNick";
            this.tbMyNick.Size = new System.Drawing.Size(86, 20);
            this.tbMyNick.TabIndex = 3;
            // 
            // cbInterfaces
            // 
            this.cbInterfaces.FormattingEnabled = true;
            this.cbInterfaces.Location = new System.Drawing.Point(12, 83);
            this.cbInterfaces.Name = "cbInterfaces";
            this.cbInterfaces.Size = new System.Drawing.Size(286, 21);
            this.cbInterfaces.TabIndex = 4;
            this.cbInterfaces.SelectedIndexChanged += new System.EventHandler(this.cbInterfaces_SelectedIndexChanged);
            // 
            // ltextMyIP
            // 
            this.ltextMyIP.AutoSize = true;
            this.ltextMyIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ltextMyIP.Location = new System.Drawing.Point(56, 135);
            this.ltextMyIP.Name = "ltextMyIP";
            this.ltextMyIP.Size = new System.Drawing.Size(83, 20);
            this.ltextMyIP.TabIndex = 5;
            this.ltextMyIP.Text = "Ваш ІР - ";
            // 
            // lMyIP
            // 
            this.lMyIP.AutoSize = true;
            this.lMyIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMyIP.Location = new System.Drawing.Point(145, 135);
            this.lMyIP.Name = "lMyIP";
            this.lMyIP.Size = new System.Drawing.Size(84, 20);
            this.lMyIP.TabIndex = 6;
            this.lMyIP.Text = "               ";
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(93, 179);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(104, 23);
            this.bSave.TabIndex = 7;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 220);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lMyIP);
            this.Controls.Add(this.ltextMyIP);
            this.Controls.Add(this.cbInterfaces);
            this.Controls.Add(this.tbMyNick);
            this.Controls.Add(this.tbClientIP);
            this.Controls.Add(this.lNick);
            this.Controls.Add(this.lIP);
            this.Name = "setting";
            this.Text = "Настройка сети";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.setting_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lIP;
        private System.Windows.Forms.Label lNick;
        private System.Windows.Forms.TextBox tbClientIP;
        private System.Windows.Forms.TextBox tbMyNick;
        private System.Windows.Forms.ComboBox cbInterfaces;
        private System.Windows.Forms.Label ltextMyIP;
        private System.Windows.Forms.Label lMyIP;
        private System.Windows.Forms.Button bSave;

    }
}