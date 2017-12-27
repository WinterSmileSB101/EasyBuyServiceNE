using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class ProductModel:BaseModel
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        public string ImageName { get; set; }

        public int ImagePosition { get; set; }

        public int Stock { get; set; }

        public int ItemType { get; set; }

        public string CategoryID { get; set; }

        public bool IsPublish { get; set; }

        public int HomePriority { get; set; }

        public int ProductPriority { get; set; }

        public string Description { get; set; }

        public string DetailDescription { get; set; }

        public int OriginalPrice { get; set; }

        public int Discount { get; set; }
    }
}
