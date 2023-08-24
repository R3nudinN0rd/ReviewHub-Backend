using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"Ranks")]
    public class Rank
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Rank title is required!")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int MinimumAmountOfPoints { get; set; }
        [Required]
        public int MaximumAmountOfPoints { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
