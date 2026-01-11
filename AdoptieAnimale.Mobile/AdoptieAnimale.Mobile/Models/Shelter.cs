namespace AdoptieAnimale.Mobile.Models
{
    public class Shelter
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int Capacity { get; set; }
    }
}