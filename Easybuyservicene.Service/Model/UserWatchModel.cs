using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class UserWatchModel:BaseModel
    {
        public string UserID { get; set; }

        public string WatchID { get; set; }

        public int WatchType { get; set; }
    }
}
