using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.User;
using Easybuyservicene.Service.Model;
using Easybuyservicene.Service.Model.Static;
using Newegg.Oversea.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.DataAccess
{
    public class TransactionDA
    {
        public static QueryResponseDTO<List<TransactionHistoryModel>> GetTransactionInfo(TransactionDTO dto)
        {
            QueryResponseDTO<List<TransactionHistoryModel>> responseDTO = new QueryResponseDTO<List<TransactionHistoryModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetTransactionInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.TransactionNumber))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "TransactionNumber", DbType.AnsiString, "@TransactionNumber", QueryConditionOperatorType.Equal, dto.TransactionNumber);
                    }

                    if (!string.IsNullOrEmpty(dto.FromUser))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "FromUser", DbType.AnsiString, "@FromUser", QueryConditionOperatorType.Equal, dto.FromUser);
                    }

                    if (!string.IsNullOrEmpty(dto.ToUser))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ToUser", DbType.AnsiString, "@ToUser", QueryConditionOperatorType.Equal, dto.ToUser);
                    }

                    if (dto.State > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "State", DbType.Int32, "@State", QueryConditionOperatorType.Equal, dto.State);
                    }

                    if (dto.Status > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32, "@Status", QueryConditionOperatorType.Equal, dto.Status);
                    }

                    if (dto.Number > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Number", DbType.Int32, "@Number", QueryConditionOperatorType.Equal, dto.Number);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<TransactionHistoryModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        public static QueryResponseDTO<bool> AddTransactionInfo(TransactionDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddTransactionItem");
            var updateRows = dataCommand.ExecuteNonQuery(dto);
            if (updateRows > 0)
            {
                response.ResultEntity = true;
                response.Code = ResponseStaticModel.Code.OK;
                response.Message = ResponseStaticModel.Message.OK;
            }
            else
            {
                response.ResultEntity = false;
                response.Code = ResponseStaticModel.Code.FAILED;
                response.Message = ResponseStaticModel.Message.FAILED;
            }
            return response;
        }

        public static QueryResponseDTO<bool> AlterTransactionInfo(TransactionDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterTransactionItem");
            var updateRows = dataCommand.ExecuteNonQuery(dto);
            if (updateRows > 0)
            {
                response.ResultEntity = true;
                response.Code = ResponseStaticModel.Code.OK;
                response.Message = ResponseStaticModel.Message.OK;
            }
            else
            {
                response.ResultEntity = false;
                response.Code = ResponseStaticModel.Code.FAILED;
                response.Message = ResponseStaticModel.Message.FAILED;
            }

            return response;
        }

        public static QueryResponseDTO<bool> DeleteTransactionInfo(TransactionDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemoveTransactionInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.TransactionNumber))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "TransactionNumber", DbType.AnsiString, "@TransactionNumber", QueryConditionOperatorType.Equal, dto.TransactionNumber);
                    }

                    if (!string.IsNullOrEmpty(dto.FromUser))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "FromUser", DbType.AnsiString, "@FromUser", QueryConditionOperatorType.Equal, dto.FromUser);
                    }

                    if (!string.IsNullOrEmpty(dto.ToUser))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ToUser", DbType.AnsiString, "@ToUser", QueryConditionOperatorType.Equal, dto.ToUser);
                    }

                    if (dto.State > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "State", DbType.Int32, "@State", QueryConditionOperatorType.Equal, dto.State);
                    }

                    if (dto.Status > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32, "@Status", QueryConditionOperatorType.Equal, dto.Status);
                    }

                    if (dto.Number > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Number", DbType.Int32, "@Number", QueryConditionOperatorType.Equal, dto.Number);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var updateRows = dataCommand.ExecuteNonQuery();
                if (updateRows > 0)
                {
                    response.ResultEntity = true;
                    response.Code = ResponseStaticModel.Code.OK;
                    response.Message = ResponseStaticModel.Message.OK;
                }
                else
                {
                    response.ResultEntity = false;
                    response.Code = ResponseStaticModel.Code.FAILED;
                    response.Message = ResponseStaticModel.Message.FAILED;
                }
            }
            return response;
        }
    }
}
