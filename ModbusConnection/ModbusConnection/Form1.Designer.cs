namespace ModbusConnection
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textboxIP = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.TBRegAddress = new System.Windows.Forms.TextBox();
            this.buttonReadReg = new System.Windows.Forms.Button();
            this.TBValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textboxIP
            // 
            this.textboxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxIP.Location = new System.Drawing.Point(31, 47);
            this.textboxIP.Name = "textboxIP";
            this.textboxIP.Size = new System.Drawing.Size(177, 22);
            this.textboxIP.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(233, 47);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(133, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(74, 85);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(93, 18);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Disconnected";
            this.labelStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(233, 82);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(133, 23);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // TBRegAddress
            // 
            this.TBRegAddress.Location = new System.Drawing.Point(386, 121);
            this.TBRegAddress.Name = "TBRegAddress";
            this.TBRegAddress.Size = new System.Drawing.Size(100, 20);
            this.TBRegAddress.TabIndex = 3;
            // 
            // buttonReadReg
            // 
            this.buttonReadReg.Location = new System.Drawing.Point(233, 118);
            this.buttonReadReg.Name = "buttonReadReg";
            this.buttonReadReg.Size = new System.Drawing.Size(133, 23);
            this.buttonReadReg.TabIndex = 4;
            this.buttonReadReg.Text = "ReadRegister";
            this.buttonReadReg.UseVisualStyleBackColor = true;
            this.buttonReadReg.Click += new System.EventHandler(this.buttonReadReg_Click);
            // 
            // TBValue
            // 
            this.TBValue.Location = new System.Drawing.Point(233, 187);
            this.TBValue.Name = "TBValue";
            this.TBValue.Size = new System.Drawing.Size(100, 20);
            this.TBValue.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 285);
            this.Controls.Add(this.TBValue);
            this.Controls.Add(this.buttonReadReg);
            this.Controls.Add(this.TBRegAddress);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textboxIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxIP;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox TBRegAddress;
        private System.Windows.Forms.Button buttonReadReg;
        private System.Windows.Forms.TextBox TBValue;
    }
}

