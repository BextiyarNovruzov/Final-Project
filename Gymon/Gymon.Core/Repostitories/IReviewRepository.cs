using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
        Task AddReviewAsync(Review review);
    }
}
