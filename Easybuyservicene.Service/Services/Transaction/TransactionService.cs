using Easybuyservicene.Service.Bizs;
using Easybuyservicene.Service.Dtos.User;
using Easybuyservicene.Service.Model.Static;
using Easybuyservicene.Service.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Services.Transaction
{
    public class TransactionService:ModuleServiceBases<TransactionDTO>
    {
        public override object OnDelete(TransactionDTO request)
        {
            try
            {
                if (null != request)
                {
                    return TransactionBiz.DeleteTransactionInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnGet(TransactionDTO request)
        {
            try
            {
                if (null != request)
                {
                    request.PagingInfo = ServiceUtils.GetDefaultPagingInfo(request.PagingInfo);
                    return TransactionBiz.GetTransactionInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPost(TransactionDTO request)
        {
            try
            {
                if (null != request)
                {
                    return TransactionBiz.AlterTransactionInfo(request);
                }
                return ResponseStaticModel.PARAM_ERROR_MODEL;
            }
            catch (Exception ex)
            {
                ResponseStaticModel.SERVER_ERROR_MODEL.ResultEntity = ex.Message;
                return ResponseStaticModel.SERVER_ERROR_MODEL;
            }
        }

        public override object OnPut(TransactionDTO request)
        {
            try
            {
                if (null != request)
                {
                    return TransactionBiz.AddTransactionInfo(request);
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
