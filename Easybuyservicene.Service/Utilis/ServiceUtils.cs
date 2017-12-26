using Newegg.Oversea.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Utilis
{
    public class ServiceUtils
    {
        public static PagingInfoEntity GetDefaultPagingInfo(PagingInfoEntity pagingInfo)
        {
            if (pagingInfo == null)
            {
                pagingInfo = new PagingInfoEntity();
            }

            return pagingInfo;
        }
    }
}
