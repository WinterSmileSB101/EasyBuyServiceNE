using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class BaseModel
    {
        public DateTime? InDate { get; set; }

        public string InUser { get; set; }

        public DateTime? LastEditDate { get; set; }

        public string LastEditUser { get; set; }
    }
}
