namespace ĐồÁn_Nhóm15
{
    partial class UserChatPreview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelLastMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.SeaGreen;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(14, 11);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(163, 26);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "labelUserName";
            // 
            // labelLastMessage
            // 
            this.labelLastMessage.AutoSize = true;
            this.labelLastMessage.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.labelLastMessage.Location = new System.Drawing.Point(17, 45);
            this.labelLastMessage.Name = "labelLastMessage";
            this.labelLastMessage.Size = new System.Drawing.Size(92, 13);
            this.labelLastMessage.TabIndex = 1;
            this.labelLastMessage.Text = "labelLastMessage";
            // 
            // UserChatPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ĐồÁn_Nhóm15.Properties.Resources.Userpreview2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.labelLastMessage);
            this.Controls.Add(this.labelUserName);
            this.DoubleBuffered = true;
            this.Name = "UserChatPreview";
            this.Size = new System.Drawing.Size(350, 69);
            this.Load += new System.EventHandler(this.UserChatPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelLastMessage;
    }
}
