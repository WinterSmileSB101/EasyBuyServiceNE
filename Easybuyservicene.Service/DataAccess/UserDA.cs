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
    public class UserDA
    {
        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<List<UserModel>> GetUserInfo(UserDTO dto)
        {
            QueryResponseDTO<List<UserModel>> responseDTO = new QueryResponseDTO<List<UserModel>>();
            CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("GetUserInfo");

            using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
                dataCommand.CommandText,dataCommand,dto.PagingInfo, "UserID ASC"))
            {
                if (null != dto)
                {
                    if (!string.IsNullOrEmpty(dto.UserID))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "UserID", DbType.AnsiString, "@UserID", QueryConditionOperatorType.Equal, dto.UserID);
                    }

                    if (!string.IsNullOrEmpty(dto.UserName))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "UserName", DbType.AnsiString, "@UserName", QueryConditionOperatorType.Equal, dto.UserName);
                    }

                    if (!string.IsNullOrEmpty(dto.Email))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Email", DbType.AnsiString, "@Email", QueryConditionOperatorType.Equal, dto.Email);
                    }

                    if (!string.IsNullOrEmpty(dto.Phone))
                    {
                        sqlBuilder.ConditionConstructor
                            .AddCondition(QueryConditionRelationType.AND, "Phone", DbType.AnsiString, "@Phone", QueryConditionOperatorType.Equal, dto.Phone);
                    }
                }
                //QueryData
                dataCommand.CommandText = sqlBuilder.BuildQuerySql();
                var result = dataCommand.ExecuteEntityList<UserModel>();

                responseDTO.ResultEntity = result;
                
            }
            responseDTO.TotalCount = dto.PagingInfo.TotalCount;
            responseDTO.Code = ResponseStaticModel.Code.OK;
            responseDTO.Message = ResponseStaticModel.Message.OK;
            return responseDTO;
        }

        /// <summary>
        /// insert UserInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<bool> AddUserInfo(UserDTO dto)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand("AddUserInfo");
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

        /// <summary>
        /// modify UserInfo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static QueryResponseDTO<bool> AlterUserInfo(UserDTO dto) {
            var commandName = "AlterUserName";
            if (!string.IsNullOrEmpty(dto.UserName))
            {
                commandName = "AlterUserName";
            }
            else if (!string.IsNullOrEmpty(dto.UserPassWord))
            {
                commandName = "AlterUserPassWord";
            }
            else if (!string.IsNullOrEmpty(dto.Email))
            {
                commandName = "AlterUserEmail";
            }
            else if (!string.IsNullOrEmpty(dto.Phone))
            {
                commandName = "AlterUserPhone";
            }
            else if (!string.IsNullOrEmpty(dto.Role))
            {
                commandName = "AlterUserRole";
            }
            else if (!string.IsNullOrEmpty(dto.DefaultAddressID))
            {
                commandName = "AlterUserRole";
            }

            return AlterUserInfo(dto, commandName);
        }

        private static QueryResponseDTO<bool> AlterUserInfo(UserDTO dto,string commandName)
        {
            QueryResponseDTO<bool> response = new QueryResponseDTO<bool>();
            response.ResultEntity = false;

            var dataCommand = DataCommandManager.GetDataCommand(commandName);
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


    }
}
