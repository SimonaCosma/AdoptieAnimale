using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptieAnimale.WebAPI.Models
{
    public class Animal
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Species { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Breed { get; set; }

        public int Age { get; set; }

        public string? Description { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        public string? PhotoUrl { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Disponibil";

        public DateTime DateAdded { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int ShelterID { get; set; }

        // Navigation properties
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        [ForeignKey("ShelterID")]
        public Shelter? Shelter { get; set; }

        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }
}