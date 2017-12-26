using Easybuyservicene.Service.Bizs;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.User;
using Newegg.Oversea.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Services.User
{
    public class UserService : ModuleServiceBases<UserDTO>
    {
        public override object OnGet(UserDTO request)
        {
            request.PagingInfo = GetDefaultPagingInfo(request.PagingInfo);
            return UserBiz.GetUserInfo(request);
        }

        public override object OnPost(UserDTO request)
        {
            return base.OnPost(request);
        }

        private PagingInfoEntity GetDefaultPagingInfo(PagingInfoEntity pagingInfo) {
            if (pagingInfo == null)
            {
                pagingInfo = new PagingInfoEntity();
            }

            return pagingInfo;
        }
    }
}
