using ReviewHub.Entities;
using ReviewHub.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ReviewHub.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Username { get; set; }
        public string Email { get; set; }
        public bool VerifiedEmail { get; set; }//false for unverified, true for verified
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public int EarnedPoints { get; set; }
        public byte[]? Image { get; set; }
        public int RankId { get; set; }
        public int RoleId { get; set; }
    }
}
