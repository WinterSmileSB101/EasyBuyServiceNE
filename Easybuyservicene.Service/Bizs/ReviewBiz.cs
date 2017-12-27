using Easybuyservicene.Service.DataAccess;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Dtos.Review;
using Easybuyservicene.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Bizs
{
    public class ReviewBiz
    {
        #region fileds
        private const string VOTE = "VOTE";
        private const string PASS = "PASS";
        private const string REPLAY = "REPLAY";
        #endregion

        public static QueryResponseDTO<List<ReviewModel>> GetReviewInfo(ReviewDTO dto)
        {
            return ReviewDA.GetReviewInfo(dto);
        }

        public static QueryResponseDTO<bool> AlterReviewInfo(ReviewDTO dto)
        {
            if (string.IsNullOrEmpty(dto.ActionType))
            {
                switch (dto.ActionType.ToUpper())
                {
                    case VOTE:
                        return ReviewDA.AlterReviewVote(dto);
                    case PASS:
                        return ReviewDA.PassReviewInfo(dto);
                    case REPLAY:
                        return ReviewDA.AlterReviewReplay(dto);
                    default:
                        return null;
                }
            }
            return null;
        }

        public static QueryResponseDTO<bool> AddReviewInfo(ReviewDTO dto)
        {
            return ReviewDA.AddReviewInfo(dto);
        }

        public static QueryResponseDTO<bool> DeleteReviewInfo(ReviewDTO dto)
        {
            return ReviewDA.DeleteReviewInfo(dto);
        }
    }
}
