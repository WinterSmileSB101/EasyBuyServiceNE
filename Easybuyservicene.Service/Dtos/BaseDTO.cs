using Newegg.Oversea.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos
{
    public class BaseDTO
    {
        public DateTime? InDate { get; set; }

        public string InUser { get; set; }

        public DateTime? LastEditDate { get; set; }

        public string LastEditUser { get; set; }

        public string ActionType { get; set; }

        public PagingInfoEntity PagingInfo { get; set; }
    }
}
