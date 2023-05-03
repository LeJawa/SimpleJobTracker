namespace SimpleJobTrackerAPI.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
