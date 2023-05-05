using Microsoft.AspNetCore.Mvc;
using SimpleJobTrackerAPI.Models;

namespace SimpleJobTrackerAPI.Services.OffersDbService
{
    public class OffersDbService : IOffersDbService
    {
        public Task<JobOfferDto> AddJobOffer(JobOfferDto jobOffer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJobOffer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobOfferDto>> GetAllOffers()
        {
            throw new NotImplementedException();
        }

        public Task<List<JobOfferDto>> GetDeletedOffers()
        {
            throw new NotImplementedException();
        }

        public Task<List<JobOfferDto>> GetJobOffers()
        {
            throw new NotImplementedException();
        }

        public Task<JobOfferDto?> GetSingleJobOffer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateJobOffer(JobOfferDto jobOffer)
        {
            throw new NotImplementedException();
        }
    }
}
