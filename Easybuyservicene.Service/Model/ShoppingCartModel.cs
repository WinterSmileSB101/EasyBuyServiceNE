using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class ShoppingCartModel:BaseModel
    {
        public string AttributeID { get; set; }

        public string ProductID { get; set; }

        public string AttributeValue { get; set; }

        public string UserID { get; set; }

        public int ProductCount { get; set; }

        public string SellerID { get; set; }
    }
}
