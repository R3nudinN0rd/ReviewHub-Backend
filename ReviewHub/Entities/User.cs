using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewHub.Entities
{
    [Table(name:"Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }
        public string? Username { get; set;}

        [Required(ErrorMessage = "Email is required!"), EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }
        [Required]
        public bool VerifiedEmail { get; set; }//false for unverified, true for verified
        [Required(ErrorMessage = "Password is required!"), MinLength(8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Date of birth is required!")]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        [Required, DefaultValue(0)]
        public int EarnedPoints { get; set; }
        [Required]
        public byte[]? Image { get; set; }
        [Required]
        public int RankId { get; set; }
        public Rank? Rank { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Suggestion> Suggestions { get; set; }
    }
}
