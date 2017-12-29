using Easybuyservicene.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos
{
    public class ProductDTO:BaseDTO
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public int Stock { get; set; }

        public int ItemType { get; set; }

        public string CategoryID { get; set; }

        public bool IsPublish { get; set; }

        public int Discount { get; set; }

        public int OriginalPrice { get; set; }

        public List<ProductModel> ProductModel { get; set; }
    }
}
