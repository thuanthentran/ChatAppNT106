namespace ĐồÁn_Nhóm15
{
    partial class UserSearch
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
            this.labelEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.DarkGreen;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelUserName.Location = new System.Drawing.Point(32, 12);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(57, 20);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "label1";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Green;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelEmail.Location = new System.Drawing.Point(40, 34);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "label2";
            // 
            // UserSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ĐồÁn_Nhóm15.Properties.Resources.user2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelUserName);
            this.DoubleBuffered = true;
            this.Name = "UserSearch";
            this.Size = new System.Drawing.Size(351, 65);
            this.Load += new System.EventHandler(this.UserSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelEmail;
    }
}
