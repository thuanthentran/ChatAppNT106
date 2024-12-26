using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ĐồÁn_Nhóm15
{
    public partial class FormForgotPassword : Form
    {
        public static string hostEmail = "smtp.gmail.com";
        public static int portEmail = 587;
        public static string emailSender = "thuanthentran@gmail.com";
        public static string passwordSender = "tnhi lcdk npsp pych";
        private IMongoDatabase database;

        public FormForgotPassword()
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
        Random rand = new Random();
        int otp;
        private async void btnSendOtp_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;

            // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu không
            var collection = database.GetCollection<BsonDocument>("Login");
            var user = await collection.Find(Builders<BsonDocument>.Filter.Eq("email", email)).FirstOrDefaultAsync();
           

            if (user != null)
            {
                otp = rand.Next(10000, 100000); // Tạo mã OTP

                var fromAddress = new MailAddress(emailSender);
                var toAddress = new MailAddress(email);
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
                    Subject = "OTP Code for Password Reset",
                    Body = $"Your OTP code is: {otp}"
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("OTP sent successfully.");
            }
            else
            {
                MessageBox.Show("Email not found.");
            }
        }

        private async
            void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            if (otp.ToString() == txtOtp.Text)
            {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text);

                // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                var collection = database.GetCollection<BsonDocument>("Login");
                var filter = Builders<BsonDocument>.Filter.Eq("email", txtEmail.Text);
                var update = Builders<BsonDocument>.Update.Set("password", hashedPassword);

                var result = await collection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Password updated successfully.");
                    this.Close(); // Đóng form khi hoàn thành
                }
                else
                {
                    MessageBox.Show("Error updating password.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect OTP.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showcbnp.Checked == true)
            {
                txtNewPassword.PasswordChar = '\0'; // Hiển thị văn bản
            }
            else
            {
                txtNewPassword.PasswordChar = '●'; // Hiển thị văn bản

            }
        }

        private void showPLCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showPLCbx2.Checked == true)
            {
                txtConfirmPassword.PasswordChar = '\0'; // Hiển thị văn bản
            }
            else
            {
                txtConfirmPassword.PasswordChar = '●'; // Hiển thị văn bản

            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void FormForgotPassword_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
