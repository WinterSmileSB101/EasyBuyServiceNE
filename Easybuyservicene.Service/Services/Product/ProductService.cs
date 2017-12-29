using Easybuyservicene.Service.Bizs;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Model.Static;
using Easybuyservicene.Service.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Services.Product
{
    public class ProductService:ModuleServiceBases<ProductDTO>
    {
        #region fileds
        private const string ALERTINFO = "ALERTINFO";
        private const string ALERTSTOCK = "ALERSTOCK";
        #endregion

        public override object OnDelete(ProductDTO request)
        {
            try
            {
                if (null != request)
                {
                    return ProductBiz.DeleteProductInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnGet(ProductDTO request)
        {
            try
            {
                if (null != request)
                {
                    request.PagingInfo = ServiceUtils.GetDefaultPagingInfo(request.PagingInfo);
                    return ProductBiz.GetProductInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPost(ProductDTO request)
        {
            try
            {
                if (null != request && null != request.ProductModel)
                {
                    switch (request.ActionType.ToUpper())
                    {
                        case ALERTINFO:
                            return ProductBiz.AlterProductInfo(request);
                        case ALERTSTOCK:
                            return ProductBiz.AlterProductStock(request);
                    }
                    
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPut(ProductDTO request)
        {
            try
            {
                if (null != request)
                {
                    return ProductBiz.AddProductInfo(request);
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
