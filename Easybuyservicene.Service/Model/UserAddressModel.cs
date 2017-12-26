using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class UserAddressModel: BaseModel
    {
        public string AddressID { get; set; }

        public string UserID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerPostCode { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Town { get; set; }

        public string Village { get; set; }

        public string DetailedAddress { get; set; }

        public string Tags { get; set; }
    }
}
