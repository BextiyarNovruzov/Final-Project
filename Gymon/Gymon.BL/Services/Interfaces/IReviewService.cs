using Gymon.BL.ViewModels.Review;
using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface IReviewService
    {

        Task<IEnumerable<ReviewViewModel>> GetReviewsByProductIdAsync(int productId);
        Task AddReviewAsync(ReviewViewModel reviewViewModel);
    }

}
