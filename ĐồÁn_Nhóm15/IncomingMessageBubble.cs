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
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.Padding = new Padding(10);
            //this.Margin = new Padding(5);
            this.Dock = DockStyle.Right;
        }

        public void SetMessage(string message, DateTime timestamp)
        {
            lblMessage.Text = message;
            DateTime dateTime = DateTime.Parse(timestamp.ToString());
            lblTimestamp.Text = dateTime.ToString("dd/MM/yyyy HH:mm");
        }
        /*public void SetMessage(string message)
        {
            lblMessage.Text = message;

        }*/
        private void IncomingMessageBubble_Load(object sender, EventArgs e)
        {

        }
    }

}
