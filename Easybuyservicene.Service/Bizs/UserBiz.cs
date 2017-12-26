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
    public class UserBiz
    {
        public static QueryResponseDTO<List<UserModel>> GetUserInfo(UserDTO dto)
        {
            return UserDA.GetUserInfo(dto);
        }
    }
}
