using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"Categories")]
    public class EntityType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public ICollection<EntityReviewed> EntityRevieweds { get; set; }
    }
}
