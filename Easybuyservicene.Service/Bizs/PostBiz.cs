using Easybuyservicene.Service.DataAccess;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.Post;
using Easybuyservicene.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Bizs
{
    public class PostBiz
    {
        #region PostHistory
        public static QueryResponseDTO<List<PostHistoryModel>> GetPostHistoryInfo(PostDTO dto)
        {
            return PostDA.GetPostHistoryInfo(dto);
        }

        public static QueryResponseDTO<bool> AlterPostHistoryInfo(PostDTO dto)
        {
            return PostDA.AlterPostHistoryInfo(dto);
        }

        public static QueryResponseDTO<bool> AddPostHistoryInfo(PostDTO dto)
        {
            return PostDA.AddPostHistoryInfo(dto);
        }

        public static QueryResponseDTO<bool> DeletePostHistoryInfo(PostDTO dto)
        {
            return PostDA.DeletePostHistoryInfo(dto);
        }
        #endregion

        #region Post

        #endregion
    }
}
