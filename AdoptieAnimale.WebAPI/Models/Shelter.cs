using System.ComponentModel.DataAnnotations;

namespace AdoptieAnimale.WebAPI.Models
{
    public class Shelter
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public int Capacity { get; set; }

        // Navigation property
        public ICollection<Animal>? Animals { get; set; }
    }
}