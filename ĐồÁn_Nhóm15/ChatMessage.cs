using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐồÁn_Nhóm15
{
    public class ChatMessage
    {
        public ObjectId Id { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now; // Default to current time }
    }
}
