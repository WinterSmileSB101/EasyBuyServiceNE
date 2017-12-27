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
    public class UserWatchDA
    {
        public static QueryResponseDTO<List<UserWatchModel>> GetUserWatchInfo(UserWatchDTO dto)
        {
            QueryResponseDTO<List<UserWatchModel>> responseDTO = new QueryResponseDTO<List<UserWatchModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetUserWatchInfo");

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

                    if (!string.IsNullOrEmpty(dto.WatchID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "WatchID", DbType.AnsiString, "@WatchID", QueryConditionOperatorType.Equal, dto.WatchID);
                    }

                    if (dto.WatchType > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "WatchType", DbType.Int32, "@WatchType", QueryConditionOperatorType.Equal, dto.WatchType);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<UserWatchModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        public static QueryResponseDTO<bool> AddUserWatchInfo(UserWatchDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddUserWatchInfo");
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

        public static QueryResponseDTO<bool> DeleteUserWatchInfo(UserWatchDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemoveUserWatchInfo");

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

                    if (!string.IsNullOrEmpty(dto.WatchID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "WatchID", DbType.AnsiString, "@WatchID", QueryConditionOperatorType.Equal, dto.WatchID);
                    }

                    if (dto.WatchType > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "WatchType", DbType.Int32, "@WatchType", QueryConditionOperatorType.Equal, dto.WatchType);
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
