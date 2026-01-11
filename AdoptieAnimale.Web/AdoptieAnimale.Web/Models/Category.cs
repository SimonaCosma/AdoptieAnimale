using System.ComponentModel.DataAnnotations;

namespace AdoptieAnimale.Web.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nume Categorie")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        [Display(Name = "Descriere")]
        public string? Description { get; set; }
    }
}