using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.Post;
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
    public class PostDA
    {
        #region PostHistory
        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<List<PostHistoryModel>> GetPostHistoryInfo(PostDTO dto)
        {
            QueryResponseDTO<List<PostHistoryModel>> responseDTO = new QueryResponseDTO<List<PostHistoryModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetPostHistoryInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.PostID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostID", DbType.AnsiString, "@PostID", QueryConditionOperatorType.Equal, dto.PostID);
                    }

                    if (dto.PostCost > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostCost", DbType.Int32, "@PostCost", QueryConditionOperatorType.LessThanOrEqual, dto.PostCost);
                    }

                    if (dto.PostSpeed > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostSpeed", DbType.Int32, "@PostSpeed", QueryConditionOperatorType.MoreThanOrEqual, dto.PostSpeed);
                    }

                    if (dto.PostStart > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostStart", DbType.Int32, "@PostStart", QueryConditionOperatorType.LessThanOrEqual, dto.PostStart);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<PostHistoryModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        /// <summary>
        /// insert PostHistoryInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<bool> AddPostHistoryInfo(PostDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddPostHistoryInfo");
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

        public static QueryResponseDTO<bool> AlterPostHistoryInfo(PostDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterPostHistoryInfo");
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

        public static QueryResponseDTO<bool> DeletePostHistoryInfo(PostDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemovePostHistoryInfo");
            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
            dataCommand.CommandText, dataCommand, dto.PagingInfo, "ID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.PostID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostID", DbType.AnsiString, "@PostID", QueryConditionOperatorType.Equal, dto.PostID);
                    }

                    if (dto.PostCost > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostCost", DbType.Int32, "@PostCost", QueryConditionOperatorType.LessThanOrEqual, dto.PostCost);
                    }

                    if (dto.PostSpeed > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostSpeed", DbType.Int32, "@PostSpeed", QueryConditionOperatorType.MoreThanOrEqual, dto.PostSpeed);
                    }

                    if (dto.PostStart > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "PostStart", DbType.Int32, "@PostStart", QueryConditionOperatorType.LessThanOrEqual, dto.PostStart);
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
        #endregion

        #region Post

        #endregion
    }
}
