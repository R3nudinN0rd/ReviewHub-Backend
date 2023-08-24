using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name: "Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Message is required!")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Review is required!")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
