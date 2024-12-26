using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ĐồÁn_Nhóm15
{
    public class CurrentUser
    {
        public static CurrentUser currentUser { get; private set; }
        public string Email { get; set; }
        public string Name { get; set; }
        // Các thuộc tính khác
        public string Password { get; set; }
        public static void SetCurrentUser (string email, string name, string password)
        {
            currentUser = new CurrentUser
            {
                Email = email,
                Name = name,
                Password = password,   
            };
        }
        public string GetEmail()
        {
            return currentUser.Email;
        }
        public string GetName()
        {
            return currentUser.Name;
        }
        public static void Clear()
        {
            currentUser = null;
        }
    }
}
