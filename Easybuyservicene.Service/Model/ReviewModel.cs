using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model
{
    public class ReviewModel:BaseModel
    {
        public string ReviewID { get; set; }

        public string ProductOROrderID { get; set; }

        public string UserID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool CheckPassed { get; set; }

        public int Score { get; set; }

        public string Images { get; set; }

        public string Videos { get; set; }

        public int FavourCount { get; set; }

        public int OpposeCount { get; set; }

        public string VoteUsers { get; set; }

        public DateTime? ReviewDate { get; set; }

        public string EBReplay { get; set; }

        public string VendorReplay { get; set; }
    }
}
