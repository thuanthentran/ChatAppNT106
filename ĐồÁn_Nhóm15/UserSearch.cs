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
        private Timer animationTimer;
        private Color targetColor;
        private Color originalColor;
        private int animationStep = 0;
        private const int totalSteps = 20;
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
            this.BackColor = Color.Transparent; // Màu gốc
            originalColor = this.BackColor;

            this.MouseEnter += new EventHandler(UserControl_MouseEnter);
            this.MouseLeave += new EventHandler(UserControl_MouseLeave);

            animationTimer = new Timer();
            animationTimer.Interval = 1; // Thời gian mỗi bước chuyển màu
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);

        }
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.White; // Màu khi di chuột vào
            //animationStep = 0;
            //animationTimer.Start();
        }

        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent; // Màu gốc khi không di chuột
            //animationStep = 0;
            //animationTimer.Start();
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
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (animationStep < totalSteps)
            {
                float ratio = (float)animationStep / totalSteps;
                this.BackColor = BlendColors(originalColor, targetColor, ratio);
                animationStep++;
            }
            else
            {
                animationTimer.Stop(); 
                this.BackColor = targetColor; 
                //if (targetColor == originalColor) targetColor = Color.Empty;// Đảm bảo màu trở về ban đầu { targetColor = Color.Empty;
            }
        }

        private Color BlendColors(Color color1, Color color2, float ratio)
        {
            int r = (int)(color1.R + (color2.R - color1.R) * ratio);
            int g = (int)(color1.G + (color2.G - color1.G) * ratio);
            int b = (int)(color1.B + (color2.B - color1.B) * ratio);
            return Color.FromArgb(r, g, b);
        }

    }
}
