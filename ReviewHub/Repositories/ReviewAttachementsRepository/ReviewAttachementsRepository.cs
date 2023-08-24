using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.ReviewAttachementsRepository
{
    public class ReviewAttachementsRepository : IReviewAttachementsRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public ReviewAttachementsRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ReviewAttachmentsModel AddReviewAttachments(ReviewAttachmentsModel reviewAttachements)
        {
            try
            {
                _reviewHubContext.ReviewesAttachments.Add(
                    _mapper.Map<ReviewAttachments>(reviewAttachements)
                    );
                return reviewAttachements;
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

        public void DeleteReviewAttachments(int reviewAttachementId)
        {
            var reviewAttachementToDelete = _reviewHubContext.ReviewesAttachments.FirstOrDefault(reviewAttachement => reviewAttachement.Id == reviewAttachementId);
            try
            {
                _reviewHubContext.ReviewesAttachments.Remove(reviewAttachementToDelete);
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

        public async Task<IEnumerable<ReviewAttachmentsModel>> GetAllReviewAttachments()
        {
            return _mapper.Map<IEnumerable<ReviewAttachmentsModel>>(
                    await _reviewHubContext.ReviewesAttachments.ToListAsync()
                );
        }

        public async Task<ReviewAttachmentsModel> GetReviewAttachmentByIdAsync(int reviewAttachementId)
        {
            return _mapper.Map<ReviewAttachmentsModel>(
                    await _reviewHubContext.ReviewesAttachments.FirstOrDefaultAsync(reviewAttachement => reviewAttachement.Id == reviewAttachementId)
                    );
        }

        public bool ReviewAttachementExists(int reviewAttachementId)
        {
            var reviewAttachement = _reviewHubContext.ReviewesAttachments.FirstOrDefault(reviewAttachement => reviewAttachement.Id == reviewAttachementId);
            return reviewAttachement != null;
        }

        public void UpdateReviewAttachments(ReviewAttachmentsModel reviewAttachments)
        {
            try
            {
                var existingReviewAttachment = _reviewHubContext.ReviewesAttachments.FirstOrDefault(ra => ra.Id == reviewAttachments.Id);
                _reviewHubContext.ReviewesAttachments.Update(
                      _mapper.Map(reviewAttachments, existingReviewAttachment)
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
