using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.ReviewAttachementsRepository;
using ReviewHub.Repositories.ReviewRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<ReviewModel>> GetAllReviews()
        {
            return Ok(_reviewRepository.GetAllReviewsAsync().Result);
        }

        [HttpGet("{reviewId}", Name = "GetReviewById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"reviewId"})]
        public ActionResult<ReviewModel> GetReviewById(int reviewId) 
        {
            return _reviewRepository.ReviewExists(reviewId) == false ?
                            NotFound("Review not found!") :
                            Ok(_reviewRepository.GetReviewByIdAsync(reviewId).Result);
        }

        [HttpGet("attachments/{reviewId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"reviewId"})]
        public ActionResult<IEnumerable<ReviewAttachmentsModel>> GetReviewAttachements(int reviewId)
        {
            return _reviewRepository.ReviewExists(reviewId) == false ?
                            NotFound("Review not found!") :
                            Ok(_reviewRepository.GetReviewAttachementsAsync(reviewId).Result);
        }

        [HttpGet("comments/{reviewId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"reviewId"})]
        public ActionResult<IEnumerable<CommentModel>> GetReviewComments(int reviewId)
        {
            return _reviewRepository.ReviewExists(reviewId) == false ?
                                NotFound("Review not found!") :
                                Ok(_reviewRepository.GetAllCommentsOfAReviewAsync(reviewId).Result);
        }

        [HttpPost]
        public ActionResult AddReview(ReviewModel review)
        {
            _reviewRepository.AddReview(review);
            return CreatedAtRoute("GetReviewById",
                                  new { reviewId = review.Id },
                                  review);
        }

        [HttpPut]
        public ActionResult UpdateReview(ReviewModel review)
        {
            if(_reviewRepository.ReviewExists(review.Id) == false)
            {
                return NotFound("Review not found!");
            }
            _reviewRepository.UpdateReview(review);
            return Ok("Review updated!");
        }

        [HttpDelete]
        public ActionResult DeleteReview(int reviewId)
        {
            if(_reviewRepository.ReviewExists(reviewId) == false)
            {
                return NotFound("Review not found!");
            }
            _reviewRepository.DeleteReview(reviewId);
            return Ok("Review deleted!");
        }
    }
}
