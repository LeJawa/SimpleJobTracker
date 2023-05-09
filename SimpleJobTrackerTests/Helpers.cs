using SimpleJobTrackerAPI.Data;
using SimpleJobTrackerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJobTrackerTests
{
    internal class Helpers
    {
        private static int nextId = 1;

        public static JobOffer CreateNewJobOffer(int id = 0)
        {
            var actualId = id;

            if (actualId == 0)
                actualId = nextId++;

            JobOffer offer = new JobOffer()
            {
                Id = actualId,
                Position = "Position " + actualId,
                Company = new Company() { Name = "Company " + actualId },
                Location = "Location",
                Url = "Url",
                JobType = JobType.Hybrid,
                Status = JobStatus.NotYetApplied,
                CreationDate = new DateTime(),
                LastChange = new DateTime(),
                IsDeleted = false
            };

            return offer;
        }
        public static JobOfferDto CreateNewJobOfferDto(int id = 0)
        {
            var actualId = id;

            if (actualId == 0)
                actualId = nextId++;

            JobOfferDto offer = new JobOfferDto()
            {
                Id = actualId,
                Position = "Position " + actualId,
                CompanyName = "Company " + actualId,
                Location = "Location",
                Url = "Url",
                JobTypeDescription = JobType.Hybrid.ToString(),
                StatusDescription = JobStatus.NotYetApplied.ToString(),
                LastChange = new DateTime()
            };

            return offer;
        }

    }
}
