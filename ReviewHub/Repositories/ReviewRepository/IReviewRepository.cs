using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.ReviewRepository
{
    public interface IReviewRepository
    {
        public Task<ReviewModel> GetReviewByIdAsync(int reviewId);
        public Task<IEnumerable<ReviewModel>> GetAllReviewsAsync();
        public ReviewModel AddReview(ReviewModel review);
        public Task<IQueryable<ReviewAttachmentsModel>> GetReviewAttachementsAsync(int reviewId);
        public Task<IQueryable<CommentModel>> GetAllCommentsOfAReviewAsync(int reviewId);
        public void UpdateReview(ReviewModel review);
        public void DeleteReview(int reviewId);
        public bool ReviewExists(int reviewId);
    }
}
