using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos.User
{
    [RestService("api/user")]
    [RestService("api/user/{UserID}")]
    public class UserDTO:BaseDTO
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? LastChangeUserNameDate { get; set; }
        public string Role { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
