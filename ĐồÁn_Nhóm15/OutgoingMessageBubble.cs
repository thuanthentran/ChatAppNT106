using Amazon.Runtime.Internal.Util;
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
    public partial class OutgoingMessageBubble : UserControl
    {
        public OutgoingMessageBubble()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue; // Màu nền cho tin nhắn gửi
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(10);
            this.Margin = new Padding(5);
            this.Dock = DockStyle.Right;
        }

        private void OutgoingMessageBubble_Load(object sender, EventArgs e)
        {

        }
        public void SetMessage(string message, DateTime timestamp)
        {
            lblMessage.Text = message;
            lblTimestamp.Text = timestamp.ToString("HH:mm");
        }
    }
}
