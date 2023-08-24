using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"ReviewsAttachments")]
    public class ReviewAttachments
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Attachment is required!")]
        public byte[]? Attachment { get; set; }
        [Required(ErrorMessage = "Review is required!")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
