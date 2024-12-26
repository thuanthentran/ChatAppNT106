using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using SharpCompress.Crypto;
using Newtonsoft.Json;

namespace ĐồÁn_Nhóm15
{
    public partial class FormChat : Form
    {
        private DatabaseHelper dbHelper;
        public string Email;
        public string Name;
        private string currentUserEmail;
        private string otherUserEmail;
        private DateTime lastFetchedTime = DateTime.MinValue; // Khởi tạo với thời gian tối thiểu
        private TcpClient _client;
        private NetworkStream _stream;

        public FormChat()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper("NMM");
            textBoxEmail.TextChanged += new EventHandler(textBoxEmail_TextChanged);
            
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            currentUserEmail = Email;
            label1.Text = Name;
            label2.Text = Email;
            LoadUserChats();
            Connect();
        }
        public class TempMessage
        {
            public string User1 { get; set; }
            public string User2 { get; set; }
            public string Message { get; set; }
            public DateTime Timestamp { get; set; }
        }
        private async void Connect ()
        {
            _client = new TcpClient(IPAddress.Loopback.ToString(), 12345);
            _stream = _client.GetStream();
            var emailMessage = new { User1 = Email };  // Chỉ gửi email cho server
            var emailJson = JsonConvert.SerializeObject(emailMessage);
            var buffer = Encoding.UTF8.GetBytes(emailJson);

            try
            {
                await _stream.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            while (true)
            {
                try
                {
                    buffer = new byte[1024];
                    int received = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    var message_raw = Encoding.UTF8.GetString(buffer, 0, received);
                    Console.WriteLine($"Received message: {message_raw}");
                    var message = JsonConvert.DeserializeObject<TempMessage>(message_raw);
                    Console.WriteLine($"User1: {message.User1}");
                    Console.WriteLine($"User2: {message.User2}");
                    Console.WriteLine($"Message: {message.Message}");
                    Console.WriteLine($"Timestamp: {message.Timestamp}");
                    if (message.User1 == Email)
                    {
                        var outgoingBubble = new OutgoingMessageBubble();
                        outgoingBubble.SetMessage(message.Message, message.Timestamp);
                        flowLayoutPanelMessages.Controls.Add(outgoingBubble);
                        if (flowLayoutPanelMessages.Controls.Count > 0)
                        {
                            flowLayoutPanelMessages.ScrollControlIntoView(flowLayoutPanelMessages.Controls[flowLayoutPanelMessages.Controls.Count - 1]);
                        }
                    }
                    else
                    {
                        try
                        {
                            var incomingBubble = new IncomingMessageBubble();
                            incomingBubble.SetMessage(message.Message, message.Timestamp);
                            flowLayoutPanelMessages.Controls.Add(incomingBubble);
                            if (flowLayoutPanelMessages.Controls.Count > 0)
                            {
                                flowLayoutPanelMessages.ScrollControlIntoView(flowLayoutPanelMessages.Controls[flowLayoutPanelMessages.Controls.Count - 1]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(otherUserEmail))
            {
                DisplayChatHistory(currentUserEmail, otherUserEmail);
            }
        }

        private void DisplayChatHistory(string user1, string user2)
        {
            // Xóa toàn bộ tin nhắn cũ trước khi hiển thị tin nhắn mới

            // Lấy các tin nhắn giữa hai người dùng
            var messages = dbHelper.GetNewChatMessages(user1, user2, lastFetchedTime);

            foreach (var message in messages)
            {
                if (message.User1 == user1)
                {
                    var outgoingBubble = new OutgoingMessageBubble();
                    outgoingBubble.SetMessage(message.Message, message.Timestamp);
                    flowLayoutPanelMessages.Controls.Add(outgoingBubble);
                }
                else
                {
                    var incomingBubble = new IncomingMessageBubble();
                    incomingBubble.SetMessage(message.Message, message.Timestamp);
                    flowLayoutPanelMessages.Controls.Add(incomingBubble);
                }
            }

            // Cập nhật lastFetchedTime sau khi hiển thị tin nhắn
            if (messages.Count > 0)
            {
                lastFetchedTime = messages.LastOrDefault()?.Timestamp ?? DateTime.MinValue;
            }

            // Cuộn tới tin nhắn mới nhất
            if (flowLayoutPanelMessages.Controls.Count > 0)
            {
                flowLayoutPanelMessages.ScrollControlIntoView(flowLayoutPanelMessages.Controls[flowLayoutPanelMessages.Controls.Count - 1]);
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            var users = dbHelper.SearchUsersByEmail(email);
            panelResult.Controls.Clear(); // Xóa kết quả cũ

            foreach (var user in users)
            {
                var searchResult = new UserSearch(); // Tạo UserSearch mới
                searchResult.SetUserInfo(user.email, user.name);
                searchResult.UserClicked += new EventHandler(UserSearch_UserClicked); // Đăng ký sự kiện UserClicked
                panelResult.Controls.Add(searchResult); // Thêm UserSearch vào panelResult
            }
        }
        private void LoadUserChats()
        {
            var userChats = dbHelper.GetUserChats(currentUserEmail); // Lấy các cuộc trò chuyện của người dùng
            panelUsers.Controls.Clear();

            foreach (var chat in userChats)
            {
                var userChatPreview = new UserChatPreview();
                userChatPreview.SetChatPreview(chat.UserEmail, chat.UserName, chat.LastMessage);
                userChatPreview.UserChatClicked += new EventHandler(UserChatPreview_Clicked);
                userChatPreview.Dock = DockStyle.Top;
                panelUsers.Controls.Add(userChatPreview);
            }
        }

        private void UserChatPreview_Clicked(object sender, EventArgs e)
        {
            var chatPreview = (UserChatPreview)sender;
            string newOtherUserEmail = chatPreview.UserEmail; // Lấy email của người dùng đã chọn

            // Kiểm tra nếu email của user mới khác với email user cũ
            if (otherUserEmail != newOtherUserEmail)
            {
                otherUserEmail = newOtherUserEmail; // Cập nhật email của người dùng đã chọn
                lastFetchedTime = DateTime.MinValue;
                flowLayoutPanelMessages.Controls.Clear();
                DisplayChatHistory(currentUserEmail, otherUserEmail); // Hiển thị lịch sử chat mới
            }
        }


        private void UserSearch_UserClicked(object sender, EventArgs e)
        {
            var searchResult = (UserSearch)sender;
            string newOtherUserEmail = searchResult.getEmail(); // Lấy email của người dùng đã chọn

            // Kiểm tra nếu user mới được chọn khác với user trước đó
            if (otherUserEmail != newOtherUserEmail)
            {
                otherUserEmail = newOtherUserEmail; // Cập nhật email của người dùng được chọn
                lastFetchedTime = DateTime.MinValue;
                flowLayoutPanelMessages.Controls.Clear();
                DisplayChatHistory(currentUserEmail, otherUserEmail); // Hiển thị lịch sử chat mới
            }
        }

        private async void SendMessage(string user1, string user2, string messageText)
        {
            var message = new ChatMessage
            {
                User1 = user1,
                User2 = user2,
                Message = messageText,
                Timestamp = DateTime.Now
            };
            var messageJson = JsonConvert.SerializeObject(message);
            var buffer = Encoding.UTF8.GetBytes(messageJson);

            // Gửi tin nhắn tới server
            try
            {
                await _stream.WriteAsync(buffer, 0, buffer.Length);
                if (message.User1 == user1)
                {
                    var outgoingBubble = new OutgoingMessageBubble();
                    outgoingBubble.SetMessage(message.Message, message.Timestamp);
                    flowLayoutPanelMessages.Controls.Add(outgoingBubble);
                }
                else
                {
                    var incomingBubble = new IncomingMessageBubble();
                    incomingBubble.SetMessage(message.Message, message.Timestamp);
                    flowLayoutPanelMessages.Controls.Add(incomingBubble);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Tải lại danh sách người dùng để cập nhật
            LoadUserChats();
        }




        private void sendButton_Click(object sender, EventArgs e)
        {
            var user1 = Email;
            var user2 = otherUserEmail; // Sử dụng otherUserEmail thay vì textBoxEmail.Text
            var messageText = messageTextBox.Text;
            SendMessage(user1, user2, messageText);
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) {
        }

        private void panelResult_Paint(object sender, PaintEventArgs e) { }

        private void textBoxEmail_TextChanged_1(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void flowLayoutPanelMessages_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                panel2.Width += 30;
                if (panel2.Size == panel2.MaximumSize)
                {
                    timer1.Stop();
                    check = false;
                }
            }
            else
            {
                panel2.Width -= 30;
                if (panel2.Size == panel2.MinimumSize)
                {
                    timer1.Stop();
                    check = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCaroGameForm_Click(object sender, EventArgs e)
        {
            CaroGameForm caroGameForm = new CaroGameForm();
            caroGameForm.Show();
        }
    }

    public class User
    {
        public ObjectId Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
}
