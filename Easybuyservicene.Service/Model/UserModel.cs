using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class UserModel: BaseModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? LastChangeUserNameDate { get; set; }
        public string Role { get; set; }
        public string DefaultAddressID { get; set; }
    }
}
