using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.Review;
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
    public class ReviewDA
    {
        public static QueryResponseDTO<List<ReviewModel>> GetReviewInfo(ReviewDTO dto)
        {
            QueryResponseDTO<List<ReviewModel>> responseDTO = new QueryResponseDTO<List<ReviewModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetReviewInfo");

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

                    if (!string.IsNullOrEmpty(dto.ReviewID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ReviewID", DbType.AnsiString, "@ReviewID", QueryConditionOperatorType.Equal, dto.ReviewID);
                    }

                    if (!string.IsNullOrEmpty(dto.ProductOROrderID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ProductOROrderID", DbType.AnsiString, "@ProductOROrderID", QueryConditionOperatorType.Equal, dto.ProductOROrderID);
                    }

                    if (null != dto.ReviewDate)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ReviewDate", DbType.DateTime, "@ReviewDate", QueryConditionOperatorType.Equal, dto.ReviewDate);
                    }

                    if (dto.Score > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Score", DbType.Int32, "@Score", QueryConditionOperatorType.Equal, dto.Score);
                    }

                    if (dto.FavourCount > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "FavourCount", DbType.Int32, "@FavourCount", QueryConditionOperatorType.Equal, dto.FavourCount);
                    }

                    if (dto.OpposeCount > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "OpposeCount", DbType.Int32, "@OpposeCount", QueryConditionOperatorType.Equal, dto.OpposeCount);
                    }

                    sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "CheckPassed", DbType.Boolean, "@CheckPassed", QueryConditionOperatorType.Equal, dto.CheckPassed);
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<ReviewModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        public static QueryResponseDTO<bool> AddReviewInfo(ReviewDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddReviewInfo");
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

        public static QueryResponseDTO<bool> PassReviewInfo(ReviewDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("PassReview");
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

        public static QueryResponseDTO<bool> AlterReviewReplay(ReviewDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterReviewReplay");
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

        public static QueryResponseDTO<bool> AlterReviewVote(ReviewDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;
            DataCommand dataCommand = null;
            if (dto.VoteFaour)
            {
                //vote favour
                dataCommand = DataCommandManager.GetDataCommand("FavourReview");
            }
            else {
                //vote oppose
                dataCommand = DataCommandManager.GetDataCommand("OpposeReview");
            }
            
            var updateRows = 0;
            updateRows = dataCommand.ExecuteNonQuery(dto);
            if (updateRows <= 0)
            {
                response.ResultEntity = false;
                response.Code = ResponseStaticModel.Code.FAILED;
                response.Message = ResponseStaticModel.Message.FAILED;
            }
            dataCommand = DataCommandManager.GetDataCommand("UpdateVoteReviewUser");
            updateRows = dataCommand.ExecuteNonQuery(dto);
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

        public static QueryResponseDTO<bool> DeleteReviewInfo(ReviewDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemoveReviewInfo");

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

                    if (!string.IsNullOrEmpty(dto.ReviewID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ReviewID", DbType.AnsiString, "@ReviewID", QueryConditionOperatorType.Equal, dto.ReviewID);
                    }

                    if (!string.IsNullOrEmpty(dto.ProductOROrderID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ProductOROrderID", DbType.AnsiString, "@ProductOROrderID", QueryConditionOperatorType.Equal, dto.ProductOROrderID);
                    }

                    if (null != dto.ReviewDate)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "ReviewDate", DbType.DateTime, "@ReviewDate", QueryConditionOperatorType.Equal, dto.ReviewDate);
                    }

                    if (dto.Score > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Score", DbType.Int32, "@Score", QueryConditionOperatorType.Equal, dto.Score);
                    }

                    if (dto.FavourCount > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "FavourCount", DbType.Int32, "@FavourCount", QueryConditionOperatorType.Equal, dto.FavourCount);
                    }

                    if (dto.OpposeCount > 0)
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "OpposeCount", DbType.Int32, "@OpposeCount", QueryConditionOperatorType.Equal, dto.OpposeCount);
                    }

                    sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "CheckPassed", DbType.Boolean, "@CheckPassed", QueryConditionOperatorType.Equal, dto.CheckPassed);
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
