using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Drawing.Text;
using WinFormAnimation;
using BCrypt.Net;
namespace ĐồÁn_Nhóm15
{
    public partial class FormLoginandRegister : Form
    {
        public static string hostEmail = "smtp.gmail.com";
        public static int portEmail = 587;
        public static string emailSender = "thuanthentran@gmail.com";
        public static string passwordSender = "tnhi lcdk npsp pych";
        private IMongoDatabase database;

        public FormLoginandRegister()
        {
            InitializeComponent();
            try
            {
                var client = new MongoClient("mongodb+srv://root:123@cluster0.o3wzx.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
                database = client.GetDatabase("NMM");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonLogin.PerformClick();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        Random rand = new Random();
        int otp;
        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            if (passTxb.Text == confirmTxb.Text)
            try
            {
                otp = rand.Next(10000, 100000);
                var fromAddress = new MailAddress(emailSender);
                var toAddress = new MailAddress(emailTxb.Text.ToString());
                var smtp = new SmtpClient()
                {
                    Host = hostEmail,
                    Port = portEmail,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, passwordSender),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "OTP code",
                    Body = otp.ToString()
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("OTP sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();



        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private async Task<bool> IsEmailUsed(string email)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("Login");
                var existingUser = await collection.Find(Builders<BsonDocument>.Filter.Eq("email", email)).FirstOrDefaultAsync();
                return existingUser != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking email: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> InsertNewUser(string name, string email, string password)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("Login");
                var newUser = new BsonDocument
        {
            { "name", name },
            { "email", email },
            { "password", password },
            
        };

                await collection.InsertOneAsync(newUser);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}");
                return false;
            }
        }
        private async  void guna2Button2_Click(object sender, EventArgs e)
        {
            if (otp.ToString().Equals(otpTxb.Text))
            {
                if (string.IsNullOrWhiteSpace(nameTxb.Text) ||
                    string.IsNullOrWhiteSpace(emailTxb.Text) ||
                    string.IsNullOrWhiteSpace(passTxb.Text) ||
                    string.IsNullOrWhiteSpace(confirmTxb.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (passTxb.Text != confirmTxb.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }

                bool isEmailUsed = await IsEmailUsed(emailTxb.Text);
                if (isEmailUsed)
                {
                    MessageBox.Show("This email has already been in use. Please use a different one.");
                    return;
                }

                // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passTxb.Text);

                bool isUserInserted = await InsertNewUser(nameTxb.Text, emailTxb.Text, hashedPassword);
                if (isUserInserted)
                {
                    MessageBox.Show("Registered successfully!");
                    nameTxb.Clear();
                    emailTxb.Clear();
                    passTxb.Clear();
                    confirmTxb.Clear();
                    otpTxb.Clear();
                    otp = 0;
                }
            }
            else
            {
                MessageBox.Show("Incorrect OTP");
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*if (guna2CircleProgressBar1.Value < 100)
            {
                guna2CircleProgressBar1.Value += 2;
            }
            else
            {*/
                //timer1.Stop();
                
            //}
        }

        private async void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("Login");
                var user = await collection.Find(Builders<BsonDocument>.Filter.Eq("email", emailLoginTxb.Text)).FirstOrDefaultAsync();

                if (user != null)
                {
                    // Kiểm tra mật khẩu
                    string storedHashedPassword = user["password"].AsString;
                    if (BCrypt.Net.BCrypt.Verify(passLoginTxb.Text, storedHashedPassword))
                    {
                        MessageBox.Show("Login successful!");
                        //panel3.BringToFront();
                        //timer1.Start();
                        FormProfile f2 = new FormProfile();
                        f2.emailname = emailLoginTxb.Text;
                        this.Hide();
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void showCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showCbx.Checked == true)
            {
                passTxb.PasswordChar = '\0'; // Hiển thị văn bản
            }
            else
            {
                passTxb.PasswordChar = '●'; // Hiển thị văn bản

            }
        }

        private void showPLCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showPLCbx.Checked == true)
            {
                passLoginTxb.PasswordChar = '\0';
            }
            else
            {
                passLoginTxb.PasswordChar = '●'; // Hiển thị văn bản

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}