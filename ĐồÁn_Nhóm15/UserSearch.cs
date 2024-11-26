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
    public partial class UserSearch : UserControl
    {
        public event EventHandler UserClicked;
        private string userEmail;
        private string userName;
        public UserSearch()
        {
            InitializeComponent();
            this.Visible = false;
            this.Click += new EventHandler(SearchResultControl_Click); // Gán sự kiện nhấp chuột cho UserControl
                                                                       // Gán sự kiện cho các điều khiển con để đảm bảo sự kiện được kích hoạt khi nhấp vào bất kỳ đâu trong UserControl
            foreach (Control control in this.Controls)
            {
                control.Click += new EventHandler(SearchResultControl_Click);
            }

        }
        public void UpdateUser(string username, string email)
        {
            labelEmail.Text = email;
            labelUserName.Text = username;
            this.Visible = true;
        }
        public string getEmail()
        {
            return labelEmail.Text;
        }
        private void UserSearch_Load(object sender, EventArgs e)
        {

        }
        public void SetUserInfo(string email, string name)
        {
            userEmail = email;
            userName = name;
            labelUserName.Text = name;
            labelEmail.Text = email;
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void SearchResultControl_Click(object sender, EventArgs e)
        {
            UserClicked?.Invoke(this, e); // Gửi sự kiện khi UserControl được nhấp }
        }
    }
}
