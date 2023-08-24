using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"EntitiesReviewed")]
    public class EntityReviewed
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Details is required!")]
        public string Details { get; set; }
        public byte[]? Image { get; set; }
        [Required(ErrorMessage = "Entity type is required!")]
        public int EntityTypeId { get; set; }
        public EntityType EntityType { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
