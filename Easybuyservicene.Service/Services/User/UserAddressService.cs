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
    public class UserAddressService : ModuleServiceBases<UserAddressDTO>
    {
        public override object OnDelete(UserAddressDTO request)
        {
            try
            {
                if (null != request)
                {
                    return UserAddressBiz.DeleteUserAddressInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnGet(UserAddressDTO request)
        {
            try
            {
                if (null != request)
                {
                    request.PagingInfo = ServiceUtils.GetDefaultPagingInfo(request.PagingInfo);
                    return UserAddressBiz.GetUserAddressInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPost(UserAddressDTO request)
        {
            try
            {
                if (null != request)
                {
                    return UserAddressBiz.AlterUserAddressInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPut(UserAddressDTO request)
        {
            try
            {
                if (null != request)
                {
                    return UserAddressBiz.AddUserAddressInfo(request);
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
