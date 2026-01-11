using System.ComponentModel.DataAnnotations;

namespace AdoptieAnimale.Web.Models
{
    public class Animal
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Nume")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Specia este obligatorie")]
        [StringLength(50)]
        [Display(Name = "Specie")]
        public string Species { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Rasă")]
        public string? Breed { get; set; }

        [Range(0, 30, ErrorMessage = "Vârsta trebuie să fie între 0 și 30 ani")]
        [Display(Name = "Vârstă")]
        public int Age { get; set; }

        [StringLength(1000)]
        [Display(Name = "Descriere")]
        public string? Description { get; set; }

        [StringLength(10)]
        [Display(Name = "Gen")]
        public string? Gender { get; set; }

        [Url]
        [Display(Name = "URL Fotografie")]
        public string? PhotoUrl { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Disponibil";

        [Display(Name = "Data Adăugării")]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Categorie")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Adăpost")]
        public int ShelterID { get; set; }

        // Pentru afișare
        public Category? Category { get; set; }
        public Shelter? Shelter { get; set; }
    }
}