using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers;
public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetReviews(int productId)
    //{
    //    var reviews = await _reviewService.GetReviewsByProductIdAsync(productId);
    //    return PartialView("_ReviewsPartial", reviews); // Assuming you have a partial view to display reviews
    //}

    //[HttpPost]
    //public async Task<IActionResult> AddReview(ReviewViewModel reviewViewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        await _reviewService.AddReviewAsync(reviewViewModel);
    //        return RedirectToAction("GetReviews", new { productId = reviewViewModel.ProductId });
    //    }
    //    return View(reviewViewModel); // Return the view with validation errors
    //}
}

