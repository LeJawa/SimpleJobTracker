﻿namespace SimpleJobTrackerAPI.Models
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string JobTypeDescription { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public decimal SalaryRangeTop { get; set; }
        public decimal SalaryRangeBottom { get; set; }
        public DateTime LastChange { get; set; }
    }
}
