namespace ĐồÁn_Nhóm15
{
    partial class FormChat
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
            this.components = new System.ComponentModel.Container();
            this.panelSearching = new System.Windows.Forms.Panel();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.panelResult = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearching.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelUsers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearching
            // 
            this.panelSearching.Controls.Add(this.textBoxEmail);
            this.panelSearching.Location = new System.Drawing.Point(4, 3);
            this.panelSearching.Name = "panelSearching";
            this.panelSearching.Size = new System.Drawing.Size(288, 81);
            this.panelSearching.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxEmail.Location = new System.Drawing.Point(8, 26);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(224, 29);
            this.textBoxEmail.TabIndex = 1;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged_1);
            // 
            // panelResult
            // 
            this.panelResult.Location = new System.Drawing.Point(4, 90);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(288, 539);
            this.panelResult.TabIndex = 3;
            this.panelResult.Paint += new System.Windows.Forms.PaintEventHandler(this.panelResult_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelSearching);
            this.panel2.Controls.Add(this.panelResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 641);
            this.panel2.TabIndex = 4;
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this.label2);
            this.panelUsers.Controls.Add(this.label1);
            this.panelUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelUsers.Location = new System.Drawing.Point(297, 0);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(301, 641);
            this.panelUsers.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMessages);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.messageTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(598, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 641);
            this.panel1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 597);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(755, 597);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "button2";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(290, 597);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(438, 20);
            this.messageTextBox.TabIndex = 1;
            this.messageTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // flowLayoutPanelMessages
            // 
            this.flowLayoutPanelMessages.AutoScroll = true;
            this.flowLayoutPanelMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMessages.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMessages.Name = "flowLayoutPanelMessages";
            this.flowLayoutPanelMessages.Size = new System.Drawing.Size(869, 574);
            this.flowLayoutPanelMessages.TabIndex = 4;
            this.flowLayoutPanelMessages.WrapContents = false;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUsers);
            this.Controls.Add(this.panel2);
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.panelSearching.ResumeLayout(false);
            this.panelSearching.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        /* void FormChat_Load(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }*/

        #endregion
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Panel panelSearching;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMessages;
    }
}