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
    public partial class UserChatPreview : UserControl
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        private Timer animationTimer;
        private Color targetColor;
        private Color originalColor;
        private int animationStep = 0;
        private const int totalSteps = 20;
        public event EventHandler UserChatClicked;

        public UserChatPreview()
        {
            InitializeComponent();
            this.Click += new EventHandler(UserChatPreview_Click); // Gán sự kiện nhấp chuột
            foreach (Control control in this.Controls)
            {
                control.Click += new EventHandler(UserChatPreview_Click); // Gán sự kiện cho các điều khiển con
            }
            this.BackColor = Color.Transparent; // Màu gốc
            originalColor = this.BackColor;

            this.MouseEnter += new EventHandler(UserControl_MouseEnter);
            this.MouseLeave += new EventHandler(UserControl_MouseLeave);

            animationTimer = new Timer();
            animationTimer.Interval = 1; // Thời gian mỗi bước chuyển màu
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
        }
        public void SetChatPreview(string email, string name, string lastMessage)
        {
            UserEmail = email;
            UserName = name;
            LastMessage = lastMessage;
            labelUserName.Text = name;
            labelLastMessage.Text = lastMessage;
        }
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent; // Màu gốc khi không di chuột
        }
        private void UserChatPreview_Load(object sender, EventArgs e)
        {

        }
        private void UserChatPreview_Click(object sender, EventArgs e)
        {
            UserChatClicked?.Invoke(this, e); // Kích hoạt sự kiện khi UserControl được nhấp
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
