using Microsoft.AspNetCore.Mvc;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerAPI.Services.OffersDbService
{
    public interface IOffersDbService
    {
        /// <summary>
        /// Gets all job offers, including deleted ones.
        /// </summary>
        /// <returns>A list of offers.</returns>
        public Task<List<JobOfferDto>> GetAllOffers();
        public Task<List<JobOfferDto>> GetJobOffers();
        public Task<List<JobOfferDto>> GetDeletedOffers();

        public Task<JobOfferDto?> GetSingleJobOffer(int id);

        public Task<bool> DeleteJobOffer(int id);

        public Task<JobOfferDto> AddJobOffer(JobOfferDto jobOffer);

        public Task<bool> UpdateJobOffer(JobOfferDto jobOffer);
        public Task<JobOfferDto> UpsertJobOffer(JobOfferDto newJobOffer);
    }
}
