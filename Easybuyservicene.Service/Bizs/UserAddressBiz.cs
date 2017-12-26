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
    public class UserAddressBiz
    {
        public static QueryResponseDTO<List<UserAddressModel>> GetUserAddressInfo(UserAddressDTO dto)
        {
            return UserAddressDA.GetUserAddressInfo(dto);
        }

        public static QueryResponseDTO<bool> AlterUserAddressInfo(UserAddressDTO dto)
        {
            return UserAddressDA.AlterUserAddressInfo(dto);
        }

        public static QueryResponseDTO<bool> AddUserAddressInfo(UserAddressDTO dto)
        {
            return UserAddressDA.AddUserAddressInfo(dto);
        }

        public static QueryResponseDTO<bool> DeleteUserAddressInfo(UserAddressDTO dto)
        {
            return UserAddressDA.DeleteUserAddressInfo(dto);
        }
    }
}
