using System.ComponentModel.DataAnnotations;

namespace AdoptieAnimale.WebAPI.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation property
        public ICollection<Animal>? Animals { get; set; }
    }
}