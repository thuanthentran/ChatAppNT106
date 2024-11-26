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
    public partial class IncomingMessageBubble : UserControl
    {
        public IncomingMessageBubble()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray; // Màu nền cho tin nhắn nhận
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(10);
            this.Margin = new Padding(5);
        }

        public void SetMessage(string message, DateTime timestamp)
        {
            lblMessage.Text = message;
            lblTimestamp.Text = timestamp.ToString("HH:mm");
        }

        private void IncomingMessageBubble_Load(object sender, EventArgs e)
        {

        }
    }

}
