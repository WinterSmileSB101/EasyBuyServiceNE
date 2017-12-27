using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos.User
{
    [RestService("api/userwatch")]
    public class UserWatchDTO:BaseDTO
    {
        public string UserID { get; set; }

        public string WatchID { get; set; }

        public int WatchType { get; set; }
    }
}
