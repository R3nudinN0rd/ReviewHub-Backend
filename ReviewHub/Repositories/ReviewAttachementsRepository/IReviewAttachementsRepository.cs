using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.ReviewAttachementsRepository
{
    public interface IReviewAttachementsRepository
    {
        public Task<ReviewAttachmentsModel> GetReviewAttachmentByIdAsync(int reviewAttachementId);
        public Task<IEnumerable<ReviewAttachmentsModel>> GetAllReviewAttachments();
        public ReviewAttachmentsModel AddReviewAttachments(ReviewAttachmentsModel reviewAttachements);
        public void UpdateReviewAttachments(ReviewAttachmentsModel reviewAttachments);
        public void DeleteReviewAttachments(int reviewAttachementId);
        public bool ReviewAttachementExists(int reviewAttachementId);
    }
}
