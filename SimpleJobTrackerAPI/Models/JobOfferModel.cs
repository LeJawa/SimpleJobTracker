﻿namespace SimpleJobTrackerAPI.Models
{
    public class JobOfferModel
    {
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public CompanyModel Company { get; set; } = new CompanyModel();
        public string Location { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public JobTypeModel JobType { get; set; } = new JobTypeModel();
        public StatusModel Status { get; set; } = new StatusModel();
        public decimal SalaryRangeTop { get; set; }
        public decimal SalaryRangeBottom { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastChange { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
