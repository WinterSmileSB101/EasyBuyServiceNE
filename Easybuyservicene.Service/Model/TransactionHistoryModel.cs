using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class TransactionHistoryModel:BaseModel
    {
        public string TransactionNumber { get; set; }

        public string FromUser { get; set; }

        public string ToUser { get; set; }

        public string Title { get; set; }

        public int State { get; set; }

        public int Status { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public int Number { get; set; }
    }
}
