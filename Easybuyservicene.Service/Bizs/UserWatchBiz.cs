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
    public class UserWatchBiz
    {
        public static QueryResponseDTO<List<UserWatchModel>> GetUserWatchInfo(UserWatchDTO dto)
        {
            return UserWatchDA.GetUserWatchInfo(dto);
        }
        public static QueryResponseDTO<bool> AddUserWatchInfo(UserWatchDTO dto)
        {
            return UserWatchDA.AddUserWatchInfo(dto);
        }

        public static QueryResponseDTO<bool> DeleteUserWatchInfo(UserWatchDTO dto)
        {
            return UserWatchDA.DeleteUserWatchInfo(dto);
        }
    }
}
