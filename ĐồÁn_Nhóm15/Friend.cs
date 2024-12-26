using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐồÁn_Nhóm15
{
    public partial class Friend : Form
    {
        private DatabaseHelper dbHelper;
        //private Timer updateTimer;
        public string Email;
        public string Name;
        private string currentUserEmail;
        private string otherUserEmail;
        public Friend()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper("NMM");
            textBoxEmail.TextChanged += new EventHandler(textBox2_1);
        }
        /*private void Friend_Load(object sender, EventArgs e)
        {

        }*/
        private void textBox2_1(object sender, EventArgs e)
        {
            string searchText = textBoxEmail.Text;
            var users = dbHelper.SearchUsersByEmail(searchText);
            panelResult.Controls.Clear();

            foreach (var user in users)
            {
                var searchResult = new UserSearch();
                searchResult.SetUserInfo(user.email, user.name);
                searchResult.UserClicked += UserSearch_UserClicked;

                // Check if current user and this user are friends
                string friendshipStatus = GetFriendRequestStatus(currentUserEmail, user.email);
                if (friendshipStatus == "Friend")
                {
                    var lblFriend = new Label
                    {
                        Text = "Bạn bè",
                        ForeColor = Color.Green,
                        AutoSize = true,
                        Top = 5,
                        Left = searchResult.Width - 60
                    };
                    searchResult.Controls.Add(lblFriend);
                }

                panelResult.Controls.Add(searchResult);
            }
        }
        private void UserSearch_UserClicked(object sender, EventArgs e)
        {
            var searchResult = (UserSearch)sender;
            string userEmail = searchResult.getEmail();
            string userName = searchResult.getName();

            OpenFriendInteractionPanel(userEmail, userName);
        }
        /*private void AddUserToPanelUsers(string email, string name)
        {
            foreach (Control control in panelUsers.Controls)
            {
                if (control is UserSearch existingUser && existingUser.getEmail() == email)
                    return;
            }

            var userDisplay = new UserSearch();
            userDisplay.SetUserInfo(email, name);
            userDisplay.Click += (s, e) => OpenFriendInteractionPanel(email, name);
            panelUsers.Controls.Add(userDisplay);
        }*/
        private void OpenFriendInteractionPanel(string userEmail, string userName)
        {
            flowLayoutPanelMessages.Controls.Clear();
            CreateFriendRequestPanel(userEmail, userName);
        }
        private bool IsRequestReceived(string userEmail)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("User1", userEmail),
                Builders<BsonDocument>.Filter.Eq("User2", currentUserEmail)
            );

            return collection.Find(filter).Any();
        }
        private void ShowSentRequestPanel(string userEmail, string userName)
        {
            var interactionPanel = CreateInteractionPanel(userEmail, userName);
            var lblInfo = new Label
            {
                Text = $"Bạn đã gửi lời mời kết bạn tới {userName}.",
                AutoSize = true,
                Top = 10,
                Left = 10
            };

            interactionPanel.Controls.Add(lblInfo);
            flowLayoutPanelMessages.Controls.Add(interactionPanel);
        }

        private string GetFriendRequestStatus(string senderEmail, string receiverEmail)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");

            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1", senderEmail),
                    Builders<BsonDocument>.Filter.Eq("User2", receiverEmail)
                ),
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1", receiverEmail),
                    Builders<BsonDocument>.Filter.Eq("User2", senderEmail)
                )
            );

            var request = collection.Find(filter).FirstOrDefault();
            return request == null ? "None" : request.GetValue("isFriend").AsBoolean ? "Friend" : "Pending";
        }


        private void ShowPendingRequestPanel(string userEmail, string userName)
        {
            var interactionPanel = CreateInteractionPanel(userEmail, userName);

            var lblInfo = new Label
            {
                Text = $"Lời mời kết bạn từ {userName} ({userEmail}).",
                AutoSize = true,
                Top = 10,
                Left = 10
            };

            var btnAccept = new Button { Text = "Chấp nhận", Width = 80, Left = 10, Top = 40 };
            var btnDelete = new Button { Text = "Xóa", Width = 80, Left = 100, Top = 40 };

            btnAccept.Click += (s, e) => AcceptFriendRequest(userEmail, userName, interactionPanel);
            btnDelete.Click += (s, e) => DeleteFriend(userEmail, userName, interactionPanel);

            interactionPanel.Controls.Add(lblInfo);
            interactionPanel.Controls.Add(btnAccept);
            interactionPanel.Controls.Add(btnDelete);
            flowLayoutPanelMessages.Controls.Add(interactionPanel);
        }



        private void CreateFriendRequestPanel(string userEmail, string userName)
        {
            var interactionPanel = CreateInteractionPanel(userEmail, userName);

            // Kiểm tra trạng thái kết bạn
            string friendshipStatus = GetFriendRequestStatus(currentUserEmail, userEmail);

            if (friendshipStatus == "Friend")
            {
                // Hiển thị nhãn "Bạn bè"
                var lblFriend = new Label
                {
                    Text = "Bạn bè",
                    ForeColor = Color.Green,
                    AutoSize = true,
                    Top = 10,
                    Left = 10
                };

                // Nút "Xóa bạn"
                var btnDeleteFriend = new Button
                {
                    Text = "Xóa bạn",
                    Width = 80,
                    Left = 10,
                    Top = 40
                };

                btnDeleteFriend.Click += (s, e) => DeleteFriend(userEmail, userName, interactionPanel);

                interactionPanel.Controls.Add(lblFriend);
                interactionPanel.Controls.Add(btnDeleteFriend);
            }
            else
            {
                // Nếu chưa kết bạn hoặc đã xóa bạn, hiển thị nút "Kết bạn"
                var btnAdd = new Button
                {
                    Text = "Kết bạn",
                    Width = 80,
                    Left = 10,
                    Top = 60
                };

                btnAdd.Click += (s, e) => AddFriend(userEmail, userName, interactionPanel);
                interactionPanel.Controls.Add(btnAdd);
            }

            flowLayoutPanelMessages.Controls.Add(interactionPanel);
        }



        private Panel CreateInteractionPanel(string userEmail, string userName)
        {
            return new Panel
            {
                Width = flowLayoutPanelMessages.Width - 20,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = userEmail
            };
        }

        private void AddFriend(string userEmail, string userName, Panel interactionPanel)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");

            // Check if the friend request already exists or they are friends
            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1", currentUserEmail),
                    Builders<BsonDocument>.Filter.Eq("User2", userEmail)
                ),
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1", userEmail),
                    Builders<BsonDocument>.Filter.Eq("User2", currentUserEmail)
                )
            );

            var existingRequest = collection.Find(filter).FirstOrDefault();

            if (existingRequest != null)
            {
                bool isFriend = existingRequest.GetValue("isFriend", false).AsBoolean;
                if (isFriend)
                {
                    MessageBox.Show("Bạn và người này đã là bạn bè.", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Lời mời kết bạn đã tồn tại.", "Thông báo", MessageBoxButtons.OK);
                }
                return;
            }

            // Send friend request if no existing request
            var friendRequest = new BsonDocument
    {
        { "User1", currentUserEmail },
        { "User2", userEmail },
        { "isFriend", false }
    };

            collection.InsertOne(friendRequest);
            MessageBox.Show($"Bạn đã gửi lời mời kết bạn tới {userName}!", "Thông báo", MessageBoxButtons.OK);
            flowLayoutPanelMessages.Controls.Remove(interactionPanel);
        }

        private void AcceptFriendRequest(string userEmail, string userName, Panel interactionPanel)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("User1", userEmail),
                Builders<BsonDocument>.Filter.Eq("User2", currentUserEmail)
            );

            var update = Builders<BsonDocument>.Update.Set("isFriend", true);
            collection.UpdateOne(filter, update);

            MessageBox.Show($"Bạn và {userName} đã trở thành bạn bè!", "Thông báo", MessageBoxButtons.OK);
            flowLayoutPanelMessages.Controls.Remove(interactionPanel);
        }

        private void DeleteFriend(string userEmail, string userName, Panel interactionPanel)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");

            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1", currentUserEmail),
                    Builders<BsonDocument>.Filter.Eq("User2", userEmail)
                ),
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("User1", userEmail),
                    Builders<BsonDocument>.Filter.Eq("User2", currentUserEmail)
                )
            );

            collection.DeleteOne(filter);

            MessageBox.Show($"Bạn đã hủy kết bạn với {userName}.", "Thông báo", MessageBoxButtons.OK);
            flowLayoutPanelMessages.Controls.Remove(interactionPanel);
        }



        private void panelResult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        public class User
        {
            public ObjectId Id { get; set; }
            public string email { get; set; }
            public string name { get; set; }
            public string password { get; set; }

            public List<string> FriendRequests { get; set; } = new List<string>();
            public List<string> Friends { get; set; } = new List<string>();
        }

        private void Friend_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            currentUserEmail = CurrentUser.currentUser?.Email;

            if (string.IsNullOrEmpty(currentUserEmail))
            {
                MessageBox.Show("Người dùng chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); // Đóng form nếu không có người dùng đăng nhập
                return;
            }

            label1.Text = CurrentUser.currentUser.Name;
            label2.Text = currentUserEmail;
            LoadFriendRequests();


        }

        private void LoadFriendRequests()
        {
            flowLayoutPanelMessages.Controls.Clear();

            var receivedRequests = GetReceivedFriendRequests(currentUserEmail);
            foreach (var request in receivedRequests)
            {
                string senderEmail = request["User1"].AsString;
                string senderName = dbHelper.GetUserNameByEmail(senderEmail);
                ShowPendingRequestPanel(senderEmail, senderName);
            }
        }

        private List<BsonDocument> GetReceivedFriendRequests(string email)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("User2", email),
                Builders<BsonDocument>.Filter.Eq("isFriend", false));
            return collection.Find(filter).ToList();
        }



        private List<BsonDocument> GetSentFriendRequests(string email)
        {
            var collection = dbHelper.GetCollection<BsonDocument>("FriendRequests");
            var filter = Builders<BsonDocument>.Filter.Eq("User1", email);
            return collection.Find(filter).ToList();
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelMessages_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
