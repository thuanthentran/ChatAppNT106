using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ĐồÁn_Nhóm15
{
    public partial class FormChat : Form
    {
        private DatabaseHelper dbHelper;
        //private Timer updateTimer;
        public string Email;
        public string Name;
        private string currentUserEmail;
        private string otherUserEmail;
        private DateTime lastFetchedTime = DateTime.MinValue; // Khởi tạo với thời gian tối thiểu

        public FormChat()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper("NMM");
            textBoxEmail.TextChanged += new EventHandler(textBoxEmail_TextChanged);
            //updateTimer = new Timer();
            updateTimer.Interval = 5000; // Cập nhật mỗi 2 giây
            updateTimer.Tick += UpdateTimer_Tick;
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            currentUserEmail = Email;
            label1.Text = Name;
            label2.Text = Email;
            updateTimer.Start();
            LoadUserChats();
            //Console.WriteLine("FormChat loaded. CurrentUserEmail: " + currentUserEmail + ", Name: " + Name);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(otherUserEmail))
            {
                // Kiểm tra nếu lastFetchedTime có thay đổi, sau đó mới gọi DisplayChatHistory
                DisplayChatHistory(currentUserEmail, otherUserEmail);
            }
        }

        private void DisplayChatHistory(string user1, string user2)
        {
            // Xóa toàn bộ tin nhắn cũ trước khi hiển thị tin nhắn mới
            //flowLayoutPanelMessages.Controls.Clear();

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
            //Console.WriteLine("Searching for users with email: " + email);
            var users = dbHelper.SearchUsersByEmail(email);
            panelResult.Controls.Clear(); // Xóa kết quả cũ

            foreach (var user in users)
            {
                //Console.WriteLine("User found: " + user.email);
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

        private void SendMessage(string user1, string user2, string messageText)
        {
            var message = new ChatMessage
            {
                User1 = user1,
                User2 = user2,
                Message = messageText,
                Timestamp = DateTime.Now
            };
            dbHelper.InsertChatMessage(message);

            // Chỉ gọi lại DisplayChatHistory nếu user2 được gán đúng
            if (otherUserEmail == user2)
            {
                DisplayChatHistory(user1, user2);
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
            if (messageTextBox.Text == "")
            {
                sendButton.Enabled = false;
            }
            else if (messageTextBox.Text != "")
            {
                messageTextBox.Enabled = true;
            }
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
    }

    public class User
    {
        public ObjectId Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
}
