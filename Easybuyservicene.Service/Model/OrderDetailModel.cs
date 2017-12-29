using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class OrderDetailModel:BaseModel
    {
        public string OrderID { get; set; }

        public string ProductID { get; set; }

        public int PayState { get; set; }

        public int AddressID { get; set; }

        public string PostID { get; set; }
    }
}
