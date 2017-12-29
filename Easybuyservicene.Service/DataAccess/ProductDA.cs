using Easybuyservicene.Service.Dtos;
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
    public class ProductDA
    {
        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<List<ProductModel>> GetProductInfo(ProductDTO dto)
        {
            QueryResponseDTO<List<ProductModel>> responseDTO = new QueryResponseDTO<List<ProductModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetProductInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.ProductID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ProductID", DbType.AnsiString, "@ProductID", QueryConditionOperatorType.Equal, dto.ProductID);
                    }

                    if (dto.Stock > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Stock", DbType.Int32, "@Stock", QueryConditionOperatorType.MoreThanOrEqual, dto.Stock);
                    }

                    if (!string.IsNullOrEmpty(dto.CategoryID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "CategoryID", DbType.AnsiString, "@CategoryID", QueryConditionOperatorType.Equal, dto.CategoryID);
                    }

                    sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "IsPublish", DbType.Boolean, "@IsPublish", QueryConditionOperatorType.Equal, dto.IsPublish);

                    if (dto.OriginalPrice > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "OriginalPrice", DbType.AnsiString, "@OriginalPrice", QueryConditionOperatorType.MoreThanOrEqual, dto.OriginalPrice);
                    }

                    if (dto.LastEditDate != null)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "LastEditDate", DbType.DateTime, "@LastEditDate", QueryConditionOperatorType.MoreThanOrEqual, dto.LastEditDate);
                    }

                    if (dto.Discount > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Discount", DbType.Int32, "@Discount", QueryConditionOperatorType.MoreThanOrEqual, dto.Discount);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<ProductModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        /// <summary>
        /// insert ProductInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<bool> AddProductInfo(ProductDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddProductInfo");
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

        public static QueryResponseDTO<bool> AlterProductInfo(List<ProductModel> model)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterProductInfo");
            var updateRows = dataCommand.ExecuteNonQuery(model);
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

        public static QueryResponseDTO<bool> AlterProductStock(List<ProductModel> model)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterProductStock");
            var updateRows = dataCommand.ExecuteNonQuery(model);
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

        public static QueryResponseDTO<bool> DeleteProductInfo(ProductDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemoveProductInfo");

            foreach (var model in dto.ProductModel)
            {
                using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
                {
                    if (null != dto)
                    {
                        if (!string.IsNullOrEmpty(model.ProductID))
                        {
                            sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "ProductID", DbType.AnsiString, "@ProductID", QueryConditionOperatorType.Equal, model.ProductID);
                        }

                        if (model.Stock > 0)
                        {
                            sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "Stock", DbType.Int32, "@Stock", QueryConditionOperatorType.MoreThanOrEqual, model.Stock);
                        }

                        if (!string.IsNullOrEmpty(model.CategoryID))
                        {
                            sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "CategoryID", DbType.AnsiString, "@CategoryID", QueryConditionOperatorType.Equal, model.CategoryID);
                        }

                        sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "IsPublish", DbType.Boolean, "@IsPublish", QueryConditionOperatorType.Equal, model.IsPublish);

                        if (model.OriginalPrice > 0)
                        {
                            sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "OriginalPrice", DbType.AnsiString, "@OriginalPrice", QueryConditionOperatorType.MoreThanOrEqual, model.OriginalPrice);
                        }

                        if (dto.LastEditDate != null)
                        {
                            sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "LastEditDate", DbType.DateTime, "@LastEditDate", QueryConditionOperatorType.MoreThanOrEqual, model.LastEditDate);
                        }

                        if (model.Discount > 0)
                        {
                            sqlBuilder.ConditionConstructor
                                .AddCondition(QueryConditionRelationType.AND, "Discount", DbType.Int32, "@Discount", QueryConditionOperatorType.MoreThanOrEqual, model.Discount);
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
            }
            return response;
        }
    }
}
