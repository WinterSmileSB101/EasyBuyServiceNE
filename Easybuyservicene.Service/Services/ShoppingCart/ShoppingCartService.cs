using Easybuyservicene.Service.Bizs;
using Easybuyservicene.Service.Dtos.ShoppingCart;
using Easybuyservicene.Service.Model.Static;
using Easybuyservicene.Service.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Services.ShoppingCart
{
    public class ShoppingCartService:ModuleServiceBases<ShoppingCartDTO>
    {
        public override object OnDelete(ShoppingCartDTO request)
        {
            try
            {
                if (null != request)
                {
                    return ShoppingCartBiz.DeleteShoppingCartInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnGet(ShoppingCartDTO request)
        {
            try
            {
                if (null != request)
                {
                    request.PagingInfo = ServiceUtils.GetDefaultPagingInfo(request.PagingInfo);
                    return ShoppingCartBiz.GetShoppingCartInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPost(ShoppingCartDTO request)
        {
            try
            {
                if (null != request)
                {
                    return ShoppingCartBiz.AlterShoppingCartInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPut(ShoppingCartDTO request)
        {
            try
            {
                if (null != request)
                {
                    return ShoppingCartBiz.AddShoppingCartInfo(request);
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
