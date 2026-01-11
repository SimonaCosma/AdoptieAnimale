namespace AdoptieAnimale.Mobile.Models
{
    public class AdoptionRequest
    {
        public int ID { get; set; }
        public int AnimalID { get; set; }
        public int MemberID { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public string? ApplicantName { get; set; }
        public string? ApplicantEmail { get; set; }
        public string? ApplicantPhone { get; set; }
        public string? ApplicantAddress { get; set; }
        public string? Reason { get; set; }

        // Navigation properties
        public Animal? Animal { get; set; }
    }
}