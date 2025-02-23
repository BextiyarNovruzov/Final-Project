using AutoMapper;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.Review;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetReviewsByProductIdAsync(int productId)
        {
            var reviews = await _reviewRepository.GetReviewsByProductIdAsync(productId);
            return reviews.Select(r => new ReviewViewModel
            {
                ProductId = r.ProductId,
                UserId = r.UserId,
                Comment = r.Comment,
                Rating = r.Rating,
                CreatedDate = r.CreatedAt,
                ReviewerName = r.ReviewerName
            });
        }

        public async Task AddReviewAsync(ReviewViewModel reviewViewModel)
        {
            var review = new Review
            {
                ProductId = reviewViewModel.ProductId,
                UserId = reviewViewModel.UserId,
                Comment = reviewViewModel.Comment,
                Rating = reviewViewModel.Rating,
                CreatedAt = reviewViewModel.CreatedDate,
                ReviewerName = reviewViewModel.ReviewerName
            };

            await _reviewRepository.AddReviewAsync(review);
        }
    }
}
