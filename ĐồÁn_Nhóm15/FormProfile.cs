using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
 
    public partial class FormProfile : Form
    {
        public static string hostEmail = "smtp.gmail.com";
        public static int portEmail = 587;
        public static string emailSender = "thuanthentran@gmail.com";
        public static string passwordSender = "tnhi lcdk npsp pych";
        public string emailname { set; get; }
        private readonly IMongoDatabase database;
        public CurrentUser CurrentUser { set; get; }
        public FormProfile()
        {
            InitializeComponent();
            var client = new MongoClient("mongodb+srv://root:123@cluster0.o3wzx.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
             database = client.GetDatabase("NMM");
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = emailname;
            try
            {
              
                var collection = database.GetCollection<BsonDocument>("Login");

             
                var filter = Builders<BsonDocument>.Filter.Eq("email", label2.Text.Trim());
                var user = collection.Find(filter).FirstOrDefault();

                if (user != null)
                {
                    textBoxUsername.Text = user.GetValue("name").AsString;
                    label3.Text = user.GetValue("email").AsString;
                    textBoxPassword.Text = user.GetValue("password").AsString;
                    CurrentUser.SetCurrentUser(user.GetValue("email").AsString, user.GetValue("name").AsString, user.GetValue("password").AsString);
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                StartWatchingFriendRequests();
                LoadFriends();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            FormLoginandRegister f1 = new FormLoginandRegister();
            this.Hide();
            f1.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                guna2CustomGradientPanel1.Width += 30;
                if (guna2CustomGradientPanel1.Size == guna2CustomGradientPanel1.MaximumSize)
                {
                    timer1.Stop();
                    check = false;
                }
            }
            else
            {
                guna2CustomGradientPanel1.Width -= 30;
                if (guna2CustomGradientPanel1.Size == guna2CustomGradientPanel1.MinimumSize)
                {
                    timer1.Stop();
                    check = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }
        private string OTP;
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text != textBoxConfirmNewPassword.Text)
            {
                MessageBox.Show("The password in the 'New password' and 'Confirm new password' must match!");
                return;
            }
            //add some more conditional clause to this
            else {
                try
                {
                    Random rand = new Random();
                    int otp = rand.Next(10000, 100000);
                    OTP = otp.ToString();   
                    var fromAddress = new MailAddress(emailSender);
                    var toAddress = new MailAddress(textBoxYourEmail.Text.ToString());
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
        }
        
        private void panelSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPanel(panelHome);
        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowPanel(panelSetting);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ShowPanel(panelHome);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowPanel(panelSetting);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormChat formchat = new FormChat();
            formchat.Email = label2.Text;
            formchat.Name = textBoxUsername.Text;
            formchat.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            friend.ShowDialog();
        }

        private void textBoxOldPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var collection = database.GetCollection<BsonDocument>("Login");
            var filter = Builders<BsonDocument>.Filter.Eq("email", textBoxYourEmail.Text.Trim());
            var user = collection.Find(filter).FirstOrDefault();
            //textBoxYourEmail.Text = user.GetValue("email").AsString;
            bool isMatch = BCrypt.Net.BCrypt.Verify(textBoxOldPassword.Text, user.GetValue("password").AsString);
            if (!isMatch)
            {
                MessageBox.Show("The current password entered is not correct!");
                return;
            }
            else if (textBoxAuthOTP.Text != OTP)
            {
                MessageBox.Show("Authentication OTP is not correct!");
                return;
            }
            else
            {
                try
                {
                    user.Set("password", BCrypt.Net.BCrypt.HashPassword(textBoxNewPassword.Text));
                    var update = Builders<BsonDocument>.Update.Set("password", user.GetValue("password").AsString); // Thay đổi nội dung cần update
                    MessageBox.Show("Password changed successfully!");
                    var result = collection.UpdateOne(filter, update);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);    
                }

            }

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormChat formchat = new FormChat();
            formchat.Email = label2.Text;
            formchat.Name = textBoxUsername.Text;
            formchat.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var collection = database.GetCollection<BsonDocument>("Login");
            var filter = Builders<BsonDocument>.Filter.Eq("email", label2.Text.ToString());
            var user = collection.Find(filter).FirstOrDefault();
            try
            {
                user.Set("name", textBoxNewUsername.Text.ToString());
                var update = Builders<BsonDocument>.Update.Set("name", user.GetValue("name").AsString); // Thay đổi nội dung cần update
                MessageBox.Show("Username changed successfully!");
                var result = collection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowPanel(Panel panel)
        {
            // Ẩn tất cả các panel trước.
            panelHome.Visible = false;
            panelSetting.Visible = false;

            // Hiển thị panel được chọn.
            panel.Visible = true;
            panel.BringToFront();
        }
        private void LoadFriends()
        {
            try
            {
                var friendRequestsCollection = database.GetCollection<BsonDocument>("FriendRequests");
                var loginCollection = database.GetCollection<BsonDocument>("Login");

                // Lọc những người đã là bạn (IsFriend = true) với user hiện tại
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("isFriend", true),
                    Builders<BsonDocument>.Filter.Or(
                        Builders<BsonDocument>.Filter.Eq("User1", emailname),
                        Builders<BsonDocument>.Filter.Eq("User2", emailname)
                    )
                );

                var friends = friendRequestsCollection.Find(filter).ToList();

                List<BsonDocument> friendDetails = new List<BsonDocument>();

                foreach (var friend in friends)
                {
                    string friendEmail;

                    // Xác định email của bạn bè (không phải email của user hiện tại)
                    if (friend.GetValue("User1").AsString == emailname)
                    {
                        friendEmail = friend.GetValue("User2").AsString;
                    }
                    else
                    {
                        friendEmail = friend.GetValue("User1").AsString;
                    }

                    // Tìm thông tin tên của bạn bè trong collection Login
                    var userFilter = Builders<BsonDocument>.Filter.Eq("email", friendEmail);
                    var user = loginCollection.Find(userFilter).FirstOrDefault();

                    if (user != null)
                    {
                        friendDetails.Add(new BsonDocument
                {
                    { "email", friendEmail },
                    { "name", user.GetValue("name").AsString }
                });
                    }
                }

                if (friendDetails.Count > 0)
                {
                    DisplayFriends(friendDetails); // Hiển thị danh sách bạn bè kèm tên và email
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading friends: {ex.Message}");
            }
        }
        private void StartWatchingFriendRequests()
        {
            Task.Run(() => WatchFriendRequests());
        }
        private void WatchFriendRequests()
        {
            try
            {
                var friendRequestsCollection = database.GetCollection<BsonDocument>("FriendRequests");

                var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>()
                    .Match("{ operationType: { $in: ['insert', 'update', 'replace'] } }");

                var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

                using (var changeStream = friendRequestsCollection.Watch(pipeline, options))
                {
                    foreach (var change in changeStream.ToEnumerable())
                    {
                        UpdateUI(() => LoadFriends()); // Gọi LoadFriends từ thread chính
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error watching friend requests: {ex.Message}");
            }
        }
        private void UpdateUI(Action updateAction)
        {
            if (InvokeRequired) // Kiểm tra nếu không phải thread chính
            {
                Invoke(updateAction); // Thực hiện trên thread chính
            }
            else
            {
                updateAction(); // Thực hiện trực tiếp nếu đã trên thread chính
            }
        }
        private void DisplayFriends(List<BsonDocument> friends)
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa nội dung cũ trong flowLayoutPanel1
            UpdateUI(() =>
            {
                foreach (var friend in friends)
                {
                    string friendName = friend.GetValue("name").AsString;
                    string friendEmail = friend.GetValue("email").AsString;

                    // Tạo một Panel nhỏ chứa thông tin bạn bè
                    Panel friendPanel = new Panel
                    {
                        AutoSize = true,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(10),
                        Margin = new Padding(5),
                        Width = flowLayoutPanel1.Width - 10 // Giới hạn chiều rộng
                    };

                    // Tạo Label hiển thị tên (xuống hàng)
                    Label lblName = new Label
                    {
                        Text = $"Name:\n{friendName}", // Xuống hàng bằng \n
                        AutoSize = true,
                        Font = new Font("Times New Roman", 10, FontStyle.Regular),
                        ForeColor = Color.White
                    };

                    // Tạo Label hiển thị email (xuống hàng sau tên)
                    Label lblEmail = new Label
                    {
                        Text = $"Email:\n{friendEmail}", // Xuống hàng bằng \n
                        AutoSize = true,
                        Font = new Font("Times New Roman", 10, FontStyle.Regular),
                        ForeColor = Color.White,
                        Margin = new Padding(0, 10, 0, 0) // Tạo khoảng cách giữa các label
                    };

                    // Sử dụng FlowLayoutPanel nhỏ để chứa các Label (xuống hàng)
                    FlowLayoutPanel innerPanel = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.TopDown, // Hiển thị từ trên xuống
                        AutoSize = true,
                        WrapContents = false,
                        Dock = DockStyle.Fill
                    };

                    // Thêm các Label vào FlowLayoutPanel nhỏ
                    innerPanel.Controls.Add(lblName);
                    innerPanel.Controls.Add(lblEmail);

                    // Thêm FlowLayoutPanel nhỏ vào Panel chính
                    friendPanel.Controls.Add(innerPanel);

                    // Thêm Panel chính vào flowLayoutPanel1
                    flowLayoutPanel1.Controls.Add(friendPanel);
                }
            });
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            friend.ShowDialog();
        }
    }
}
