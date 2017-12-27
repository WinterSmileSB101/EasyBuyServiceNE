using Easybuyservicene.Service.Bizs;
using Easybuyservicene.Service.Dtos.User;
using Easybuyservicene.Service.Model.Static;
using Easybuyservicene.Service.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Services.User
{
    public class UserWatchService : ModuleServiceBases<UserWatchDTO>
    {
        public override object OnDelete(UserWatchDTO request)
        {
            try
            {
                if (null != request)
                {
                    return UserWatchBiz.DeleteUserWatchInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnGet(UserWatchDTO request)
        {
            try
            {
                if (null != request)
                {
                    request.PagingInfo = ServiceUtils.GetDefaultPagingInfo(request.PagingInfo);
                    return UserWatchBiz.GetUserWatchInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPut(UserWatchDTO request)
        {
            try
            {
                if (null != request)
                {
                    return UserWatchBiz.AddUserWatchInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }
    }
}
