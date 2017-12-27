using Easybuyservicene.Service.DataAccess;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.User;
using Easybuyservicene.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Bizs
{
    public class TransactionBiz
    {
        public static QueryResponseDTO<List<TransactionHistoryModel>> GetTransactionInfo(TransactionDTO dto)
        {
            return TransactionDA.GetTransactionInfo(dto);
        }

        public static QueryResponseDTO<bool> AlterTransactionInfo(TransactionDTO dto)
        {
            return TransactionDA.AlterTransactionInfo(dto);
        }

        public static QueryResponseDTO<bool> AddTransactionInfo(TransactionDTO dto)
        {
            return TransactionDA.AddTransactionInfo(dto);
        }

        public static QueryResponseDTO<bool> DeleteTransactionInfo(TransactionDTO dto)
        {
            return TransactionDA.DeleteTransactionInfo(dto);
        }
    }
}
