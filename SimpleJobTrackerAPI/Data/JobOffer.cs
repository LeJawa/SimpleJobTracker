using SimpleJobTrackerAPI.Enums;

namespace SimpleJobTrackerAPI.Data
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public Company Company { get; set; } = new Company();
        public string Location { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public JobType JobType { get; set; } = JobType.Undefined;
        public JobStatus Status { get; set; } = JobStatus.Undefined;
        public decimal SalaryRangeTop { get; set; }
        public decimal SalaryRangeBottom { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastChange { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
