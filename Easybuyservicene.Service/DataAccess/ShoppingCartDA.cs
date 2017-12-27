using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.ShoppingCart;
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
    public class ShoppingCartDA
    {
        public static QueryResponseDTO<List<ShoppingCartModel>> GetShoppingCartInfo(ShoppingCartDTO dto)
        {
            QueryResponseDTO<List<ShoppingCartModel>> responseDTO = new QueryResponseDTO<List<ShoppingCartModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetShoppingCartInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.UserID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "UserID", DbType.AnsiString, "@UserID", QueryConditionOperatorType.Equal, dto.UserID);
                    }

                    if (!string.IsNullOrEmpty(dto.SellerID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "SellerID", DbType.AnsiString, "@SellerID", QueryConditionOperatorType.Equal, dto.SellerID);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<ShoppingCartModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        public static QueryResponseDTO<bool> AddShoppingCartInfo(ShoppingCartDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddShoppingCartInfo");
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

        public static QueryResponseDTO<bool> AlterShoppingCartInfo(ShoppingCartDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterShoppingCartInfo");
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

        public static QueryResponseDTO<bool> DeleteShoppingCartInfo(ShoppingCartDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemoveShoppingCartInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.UserID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "UserID", DbType.AnsiString, "@UserID", QueryConditionOperatorType.Equal, dto.UserID);
                    }

                    if (!string.IsNullOrEmpty(dto.SellerID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "SellerID", DbType.AnsiString, "@SellerID", QueryConditionOperatorType.Equal, dto.SellerID);
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
