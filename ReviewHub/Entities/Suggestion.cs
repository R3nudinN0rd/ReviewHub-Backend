using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"Suggestions")]
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
        public int Votes { get; set; }
        [Required(ErrorMessage = "User is required!")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
