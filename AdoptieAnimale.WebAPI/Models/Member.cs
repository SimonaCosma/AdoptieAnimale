using System.ComponentModel.DataAnnotations;

namespace AdoptieAnimale.WebAPI.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(20)]
        public string Role { get; set; } = "User";

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }
}