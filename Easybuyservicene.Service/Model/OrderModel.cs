using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class OrderModel:BaseModel
    {
        public string OrderID { get; set; }

        public int OrderState { get; set; }

        public string CostomerID { get; set; }

        public int OrderTotal { get; set; }

        public int Discount { get; set; }

        public string PayCostomerID { get; set; }

        public string Comment { get; set; }
    }
}
