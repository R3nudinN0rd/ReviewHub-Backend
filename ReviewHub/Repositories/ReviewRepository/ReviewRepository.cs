using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public ReviewRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public ReviewModel AddReview(ReviewModel review)
        {
            try
            {
                _reviewHubContext.Reviewes.Add(
                    _mapper.Map<Review>(review)
                    );
                return review;
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public void DeleteReview(int reviewId)
        {
            var reviewToDelete = _reviewHubContext.Reviewes.FirstOrDefault(review => review.Id == reviewId);
            try
            {
                _reviewHubContext.Reviewes.Remove(reviewToDelete);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }


        public async Task<IQueryable<CommentModel>> GetAllCommentsOfAReviewAsync(int reviewId)
        {
            return _mapper.Map<IQueryable<CommentModel>>(
                    await _reviewHubContext.Comments.Where(comment => comment.ReviewId == reviewId).ToListAsync()
                );
        }
        public async Task<IEnumerable<ReviewModel>> GetAllReviewsAsync()
        {
            return _mapper.Map<IEnumerable<ReviewModel>>(
                await _reviewHubContext.Reviewes.ToListAsync()
                );
        }

        public async Task<IQueryable<ReviewAttachmentsModel>> GetReviewAttachementsAsync(int reviewId)
        {
            return _mapper.Map<IQueryable<ReviewAttachmentsModel>>(
                    await _reviewHubContext.ReviewesAttachments.Where(reviewAttachments => reviewAttachments.ReviewId == reviewId).ToListAsync()
                    );
        }

        public async Task<ReviewModel> GetReviewByIdAsync(int reviewId)
        {
            return _mapper.Map<ReviewModel>(
                await _reviewHubContext.Reviewes.FirstOrDefaultAsync(review => review.Id == reviewId)
                );
        }

        public bool ReviewExists(int reviewId)
        {
            var review = _reviewHubContext.Reviewes.FirstOrDefault(r => r.Id == reviewId);
            return review != null;
        }

        public void UpdateReview(ReviewModel review)
        {
            try
            {
                var existingReview = _reviewHubContext.Reviewes.FirstOrDefault(r => r.Id == review.Id);
                _reviewHubContext.Reviewes.Update(
                     _mapper.Map(review, existingReview)
                     );
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }
    }
}
