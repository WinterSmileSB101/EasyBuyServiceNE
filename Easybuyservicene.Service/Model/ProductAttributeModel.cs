using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class ProductAttributeModel:BaseModel
    {
        public string AttributeID { get; set; }

        public string ProductID { get; set; }

        public string AttributeValue { get; set; }
    }
}
