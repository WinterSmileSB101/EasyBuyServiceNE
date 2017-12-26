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
    public class UserAddressDA
    {
        public static QueryResponseDTO<List<UserAddressModel>> GetUserAddressInfo(UserAddressDTO dto)
        {
            QueryResponseDTO<List<UserAddressModel>> responseDTO = new QueryResponseDTO<List<UserAddressModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetUserAddressInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "AddressID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.AddressID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "AddressID", DbType.Int32, "@AddressID", QueryConditionOperatorType.Equal, dto.AddressID);
                    }

                    if (!string.IsNullOrEmpty(dto.UserID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "UserID", DbType.AnsiString, "@UserID", QueryConditionOperatorType.Equal, dto.UserID);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<UserAddressModel>();

                responseDTO.ResultEntity = result;

            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        public static QueryResponseDTO<bool> AddUserAddressInfo(UserAddressDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddUserAddressInfo");
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

        public static QueryResponseDTO<bool> AlterUserAddressInfo(UserAddressDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AlterUserAddressInfo");
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

        public static QueryResponseDTO<bool> DeleteUserAddressInfo(UserAddressDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;


            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("RemoveUserAddressInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText, dataCommand, dto.PagingInfo, "UserID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.AddressID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "AddressID", DbType.Int32, "@AddressID", QueryConditionOperatorType.Equal, dto.AddressID);
                    }

                    if (!string.IsNullOrEmpty(dto.UserID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "UserID", DbType.AnsiString, "@UserID", QueryConditionOperatorType.Equal, dto.UserID);
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
