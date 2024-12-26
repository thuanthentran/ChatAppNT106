namespace ĐồÁn_Nhóm15
{
    partial class FormForgotPassword
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
            this.btnSendOtp = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtOtp = new System.Windows.Forms.TextBox();
            this.btnVerifyOtp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.showPLCbx2 = new System.Windows.Forms.CheckBox();
            this.showcbnp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSendOtp
            // 
            this.btnSendOtp.Location = new System.Drawing.Point(238, 106);
            this.btnSendOtp.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendOtp.Name = "btnSendOtp";
            this.btnSendOtp.Size = new System.Drawing.Size(64, 19);
            this.btnSendOtp.TabIndex = 0;
            this.btnSendOtp.Text = "Send OTP";
            this.btnSendOtp.UseVisualStyleBackColor = true;
            this.btnSendOtp.Click += new System.EventHandler(this.btnSendOtp_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(103, 66);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(103, 147);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 20);
            this.txtNewPassword.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(103, 189);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // txtOtp
            // 
            this.txtOtp.Location = new System.Drawing.Point(103, 107);
            this.txtOtp.Margin = new System.Windows.Forms.Padding(2);
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new System.Drawing.Size(132, 20);
            this.txtOtp.TabIndex = 4;
            // 
            // btnVerifyOtp
            // 
            this.btnVerifyOtp.Location = new System.Drawing.Point(134, 257);
            this.btnVerifyOtp.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerifyOtp.Name = "btnVerifyOtp";
            this.btnVerifyOtp.Size = new System.Drawing.Size(64, 28);
            this.btnVerifyOtp.TabIndex = 5;
            this.btnVerifyOtp.Text = "Verify";
            this.btnVerifyOtp.UseVisualStyleBackColor = true;
            this.btnVerifyOtp.Click += new System.EventHandler(this.btnVerifyOtp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(38, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(38, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "OTP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "New password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(9, 191);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Confirm  password";
            // 
            // showPLCbx2
            // 
            this.showPLCbx2.AutoSize = true;
            this.showPLCbx2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showPLCbx2.Location = new System.Drawing.Point(256, 221);
            this.showPLCbx2.Margin = new System.Windows.Forms.Padding(2);
            this.showPLCbx2.Name = "showPLCbx2";
            this.showPLCbx2.Size = new System.Drawing.Size(53, 17);
            this.showPLCbx2.TabIndex = 14;
            this.showPLCbx2.Text = "Show";
            this.showPLCbx2.UseVisualStyleBackColor = true;
            this.showPLCbx2.CheckedChanged += new System.EventHandler(this.showPLCbx_CheckedChanged);
            // 
            // showcbnp
            // 
            this.showcbnp.AutoSize = true;
            this.showcbnp.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showcbnp.Location = new System.Drawing.Point(256, 169);
            this.showcbnp.Margin = new System.Windows.Forms.Padding(2);
            this.showcbnp.Name = "showcbnp";
            this.showcbnp.Size = new System.Drawing.Size(53, 17);
            this.showcbnp.TabIndex = 15;
            this.showcbnp.Text = "Show";
            this.showcbnp.UseVisualStyleBackColor = true;
            this.showcbnp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(326, 312);
            this.Controls.Add(this.showcbnp);
            this.Controls.Add(this.showPLCbx2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerifyOtp);
            this.Controls.Add(this.txtOtp);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSendOtp);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormForgotPassword";
            this.Text = "FormForgotPassword";
            this.Load += new System.EventHandler(this.FormForgotPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendOtp;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtOtp;
        private System.Windows.Forms.Button btnVerifyOtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox showPLCbx2;
        private System.Windows.Forms.CheckBox showcbnp;
    }
}