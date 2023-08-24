using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.ReviewAttachementsRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class ReviewAttachmentsController : ControllerBase
    {
        private readonly IReviewAttachementsRepository _reviewAttachementsRepository;
        public ReviewAttachmentsController(IReviewAttachementsRepository reviewAttachementsRepository)
        {
            _reviewAttachementsRepository = reviewAttachementsRepository ?? throw new ArgumentNullException(nameof(reviewAttachementsRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<ReviewAttachmentsModel>> GetAllReviewAttachments()
        {
            return Ok(_reviewAttachementsRepository.GetAllReviewAttachments().Result);
        }

        [HttpGet("{reviewAttachmentId}", Name = "GetReviewAttachmentById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"reviewAttachmentId"})]
        public ActionResult<ReviewAttachmentsModel> GetReviewAttachementById(int reviewAttachmentId)
        {
            return _reviewAttachementsRepository.ReviewAttachementExists(reviewAttachmentId) == false ?
                            NotFound("Review attachement not found!") :
                            Ok(_reviewAttachementsRepository.GetReviewAttachmentByIdAsync(reviewAttachmentId).Result);
        }

        [HttpPost]
        public ActionResult AddReviewAttachement(ReviewAttachmentsModel reviewAttachement)
        {
            _reviewAttachementsRepository.AddReviewAttachments(reviewAttachement);
            return CreatedAtRoute("GetReviewAttachementById",
                                  new { reviewAttachmentId = reviewAttachement.Id },
                                  reviewAttachement);
        }

        [HttpPut]
        public ActionResult UpdateReviewAttachement(ReviewAttachmentsModel reviewAttachment)
        {
            if(_reviewAttachementsRepository.ReviewAttachementExists(reviewAttachment.Id) == false)
            {
                return NotFound("Review attachment not found!");
            }

            _reviewAttachementsRepository.UpdateReviewAttachments(reviewAttachment);
            return Ok("Review attachment updated!");
        }

        [HttpDelete]
        public ActionResult DeleteReviewAttachment(int reviewAttachmentId)
        {
            if(_reviewAttachementsRepository.ReviewAttachementExists(reviewAttachmentId) == false)
            {
                return NotFound("Review attachment not found!");
            }

            _reviewAttachementsRepository.DeleteReviewAttachments(reviewAttachmentId);
            return Ok("Review attachment deleted!");
        }
    }
}
