namespace CrissCrossGame
{
    partial class Chat
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
            this.messages = new System.Windows.Forms.TextBox();
            this.mymessage = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messages
            // 
            this.messages.Enabled = false;
            this.messages.Location = new System.Drawing.Point(16, 13);
            this.messages.Multiline = true;
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(244, 120);
            this.messages.TabIndex = 0;
            // 
            // mymessage
            // 
            this.mymessage.Location = new System.Drawing.Point(16, 146);
            this.mymessage.Multiline = true;
            this.mymessage.Name = "mymessage";
            this.mymessage.Size = new System.Drawing.Size(180, 49);
            this.mymessage.TabIndex = 1;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(206, 160);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(74, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Отправить";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.mymessage);
            this.Controls.Add(this.messages);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messages;
        private System.Windows.Forms.TextBox mymessage;
        private System.Windows.Forms.Button Send;
    }
}