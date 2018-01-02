using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class PostHistoryModel:BaseModel
    {
        public int ID { get; set; }

        public string PostID { get; set; }

        public string PostName { get; set; }

        public int PostCost { get; set; }

        public int PostSpeed { get; set; }

        public string PostDescription { get; set; }

        public int PostStart { get; set; }
    }
}
