namespace ĐồÁn_Nhóm15
{
    partial class FormLoginandRegister
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showPLCbx = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.passLoginTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.emailLoginTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.showCbx = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.confirmTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.otpTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.emailTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.passTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.generateOtpBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.nameTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Azure;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(9, 10);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(192, 35);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.Azure;
            this.buttonRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.Location = new System.Drawing.Point(214, 10);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(192, 35);
            this.buttonRegister.TabIndex = 1;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showPLCbx);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.passLoginTxb);
            this.panel1.Controls.Add(this.emailLoginTxb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 166);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 315);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // showPLCbx
            // 
            this.showPLCbx.AutoSize = true;
            this.showPLCbx.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showPLCbx.Location = new System.Drawing.Point(286, 166);
            this.showPLCbx.Margin = new System.Windows.Forms.Padding(2);
            this.showPLCbx.Name = "showPLCbx";
            this.showPLCbx.Size = new System.Drawing.Size(53, 17);
            this.showPLCbx.TabIndex = 13;
            this.showPLCbx.Text = "Show";
            this.showPLCbx.UseVisualStyleBackColor = true;
            this.showPLCbx.CheckedChanged += new System.EventHandler(this.showPLCbx_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(19, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(19, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.DarkGreen;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(35, 197);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(310, 37);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Login";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // passLoginTxb
            // 
            this.passLoginTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passLoginTxb.DefaultText = "";
            this.passLoginTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passLoginTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passLoginTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passLoginTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passLoginTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.passLoginTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passLoginTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passLoginTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passLoginTxb.Location = new System.Drawing.Point(124, 136);
            this.passLoginTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.passLoginTxb.Name = "passLoginTxb";
            this.passLoginTxb.PasswordChar = '●';
            this.passLoginTxb.PlaceholderText = "Password";
            this.passLoginTxb.SelectedText = "";
            this.passLoginTxb.Size = new System.Drawing.Size(208, 24);
            this.passLoginTxb.TabIndex = 7;
            this.passLoginTxb.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // emailLoginTxb
            // 
            this.emailLoginTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailLoginTxb.DefaultText = "";
            this.emailLoginTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.emailLoginTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.emailLoginTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.emailLoginTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.emailLoginTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.emailLoginTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.emailLoginTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.emailLoginTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.emailLoginTxb.Location = new System.Drawing.Point(124, 93);
            this.emailLoginTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.emailLoginTxb.Name = "emailLoginTxb";
            this.emailLoginTxb.PasswordChar = '\0';
            this.emailLoginTxb.PlaceholderText = "Email";
            this.emailLoginTxb.SelectedText = "";
            this.emailLoginTxb.Size = new System.Drawing.Size(208, 24);
            this.emailLoginTxb.TabIndex = 6;
            this.emailLoginTxb.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(168, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.showCbx);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.confirmTxb);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.otpTxb);
            this.panel2.Controls.Add(this.emailTxb);
            this.panel2.Controls.Add(this.passTxb);
            this.panel2.Controls.Add(this.generateOtpBtn);
            this.panel2.Controls.Add(this.guna2Button2);
            this.panel2.Controls.Add(this.nameTxb);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(18, 166);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 318);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // showCbx
            // 
            this.showCbx.AutoSize = true;
            this.showCbx.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showCbx.Location = new System.Drawing.Point(286, 170);
            this.showCbx.Margin = new System.Windows.Forms.Padding(2);
            this.showCbx.Name = "showCbx";
            this.showCbx.Size = new System.Drawing.Size(53, 17);
            this.showCbx.TabIndex = 23;
            this.showCbx.Text = "Show";
            this.showCbx.UseVisualStyleBackColor = true;
            this.showCbx.CheckedChanged += new System.EventHandler(this.showCbx_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label9.Location = new System.Drawing.Point(19, 200);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Confirmpass:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // confirmTxb
            // 
            this.confirmTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.confirmTxb.DefaultText = "";
            this.confirmTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.confirmTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.confirmTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.confirmTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.confirmTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.confirmTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.confirmTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.confirmTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.confirmTxb.Location = new System.Drawing.Point(127, 192);
            this.confirmTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.confirmTxb.Name = "confirmTxb";
            this.confirmTxb.PasswordChar = '●';
            this.confirmTxb.PlaceholderText = "Confirmpass";
            this.confirmTxb.SelectedText = "";
            this.confirmTxb.Size = new System.Drawing.Size(208, 24);
            this.confirmTxb.TabIndex = 21;
            this.confirmTxb.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label8.Location = new System.Drawing.Point(19, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(19, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(19, 141);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(19, 238);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "OTP:";
            // 
            // otpTxb
            // 
            this.otpTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.otpTxb.DefaultText = "";
            this.otpTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.otpTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.otpTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.otpTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.otpTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.otpTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.otpTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.otpTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.otpTxb.Location = new System.Drawing.Point(124, 232);
            this.otpTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.otpTxb.Name = "otpTxb";
            this.otpTxb.PasswordChar = '\0';
            this.otpTxb.PlaceholderText = " OTP";
            this.otpTxb.SelectedText = "";
            this.otpTxb.Size = new System.Drawing.Size(112, 24);
            this.otpTxb.TabIndex = 16;
            this.otpTxb.TextChanged += new System.EventHandler(this.guna2TextBox6_TextChanged);
            // 
            // emailTxb
            // 
            this.emailTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailTxb.DefaultText = "";
            this.emailTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.emailTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.emailTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.emailTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.emailTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.emailTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.emailTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.emailTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.emailTxb.Location = new System.Drawing.Point(124, 96);
            this.emailTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.emailTxb.Name = "emailTxb";
            this.emailTxb.PasswordChar = '\0';
            this.emailTxb.PlaceholderText = "Email";
            this.emailTxb.SelectedText = "";
            this.emailTxb.Size = new System.Drawing.Size(208, 24);
            this.emailTxb.TabIndex = 15;
            this.emailTxb.TextChanged += new System.EventHandler(this.guna2TextBox5_TextChanged);
            // 
            // passTxb
            // 
            this.passTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passTxb.DefaultText = "";
            this.passTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.passTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passTxb.Location = new System.Drawing.Point(124, 136);
            this.passTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.passTxb.Name = "passTxb";
            this.passTxb.PasswordChar = '●';
            this.passTxb.PlaceholderText = "Password";
            this.passTxb.SelectedText = "";
            this.passTxb.Size = new System.Drawing.Size(208, 24);
            this.passTxb.TabIndex = 14;
            this.passTxb.TextChanged += new System.EventHandler(this.guna2TextBox4_TextChanged);
            // 
            // generateOtpBtn
            // 
            this.generateOtpBtn.DefaultAutoSize = true;
            this.generateOtpBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.generateOtpBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.generateOtpBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.generateOtpBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.generateOtpBtn.FillColor = System.Drawing.Color.DarkGreen;
            this.generateOtpBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.generateOtpBtn.ForeColor = System.Drawing.Color.White;
            this.generateOtpBtn.Location = new System.Drawing.Point(241, 232);
            this.generateOtpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.generateOtpBtn.Name = "generateOtpBtn";
            this.generateOtpBtn.Size = new System.Drawing.Size(105, 27);
            this.generateOtpBtn.TabIndex = 13;
            this.generateOtpBtn.Text = "Generate OTP";
            this.generateOtpBtn.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.DarkGreen;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(38, 262);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(310, 45);
            this.guna2Button2.TabIndex = 9;
            this.guna2Button2.Text = "Register";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // nameTxb
            // 
            this.nameTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameTxb.DefaultText = "";
            this.nameTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameTxb.FillColor = System.Drawing.Color.DarkGreen;
            this.nameTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameTxb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nameTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameTxb.Location = new System.Drawing.Point(124, 60);
            this.nameTxb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nameTxb.Name = "nameTxb";
            this.nameTxb.PasswordChar = '\0';
            this.nameTxb.PlaceholderText = "Name";
            this.nameTxb.SelectedText = "";
            this.nameTxb.Size = new System.Drawing.Size(208, 24);
            this.nameTxb.TabIndex = 1;
            this.nameTxb.TextChanged += new System.EventHandler(this.guna2TextBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(168, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Register";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.guna2CircleProgressBar1);
            this.panel3.Location = new System.Drawing.Point(18, 84);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 78);
            this.panel3.TabIndex = 9;
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(151, 2);
            this.guna2CircleProgressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(57, 57);
            this.guna2CircleProgressBar1.TabIndex = 0;
            this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ValueChanged += new System.EventHandler(this.guna2CircleProgressBar1_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormLoginandRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(454, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLoginandRegister";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2TextBox emailLoginTxb;
        private Guna.UI2.WinForms.Guna2TextBox passLoginTxb;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox nameTxb;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button generateOtpBtn;
        private Guna.UI2.WinForms.Guna2TextBox otpTxb;
        private Guna.UI2.WinForms.Guna2TextBox emailTxb;
        private Guna.UI2.WinForms.Guna2TextBox passTxb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox confirmTxb;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox showCbx;
        private System.Windows.Forms.CheckBox showPLCbx;
    }
}

