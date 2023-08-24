using ReviewHub.Models;

namespace ReviewHub.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }
        public int EntityReviewedId { get; set; }
    }
}
