namespace AdoptieAnimale.Mobile.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public string? Gender { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Status { get; set; }
        public DateTime DateAdded { get; set; }
        public int? CategoryID { get; set; }
        public int? ShelterID { get; set; }

        // Navigation properties (pentru afișare)
        public Category? Category { get; set; }
        public Shelter? Shelter { get; set; }
    }
}