using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"Reviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Score is required!"), Range(0,5)]
        public double Score { get; set; }
        public string? Comment { get; set; }
        [Required(ErrorMessage = "Reviewer is required!")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage ="Entity reviewed is required!")]
        public int EntityReviewedId { get; set; }
        public EntityReviewed EntityReviewed { get; set; }
        public ICollection<Comment> Comments { get; set;}
        public ICollection<ReviewAttachments> Attachments { get; set; }
    }
}
