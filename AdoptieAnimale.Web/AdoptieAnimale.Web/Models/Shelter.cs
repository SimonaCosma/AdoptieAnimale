using System.ComponentModel.DataAnnotations;

namespace AdoptieAnimale.Web.Models
{
    public class Shelter
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele adăpostului este obligatoriu")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Nume Adăpost")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adresa este obligatorie")]
        [StringLength(200)]
        [Display(Name = "Adresă")]
        public string Address { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Oraș")]
        public string? City { get; set; }

        [Phone]
        [StringLength(20)]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Capacitate")]
        public int Capacity { get; set; }
    }
}