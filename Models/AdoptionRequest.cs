using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptieAnimale.WebAPI.Models
{
    public class AdoptionRequest
    {
        public int ID { get; set; }

        [Required]
        public int AnimalID { get; set; }

        [Required]
        public int MemberID { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "În așteptare";

        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("AnimalID")]
        public Animal? Animal { get; set; }

        [ForeignKey("MemberID")]
        public Member? Member { get; set; }
    }
}