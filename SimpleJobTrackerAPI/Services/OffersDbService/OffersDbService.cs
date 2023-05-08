using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Controllers;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerAPI.Services.OffersDbService
{
    public class OffersDbService : IOffersDbService
    {
        private readonly OffersDbContext _context;
        private readonly IMapper _mapper;

        public OffersDbService(OffersDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }


        public Task<JobOfferDto> AddJobOffer(JobOfferDto jobOffer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJobOffer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobOfferDto>> GetAllOffers()
        {
            var dbset = _context.JobOffers;

            var mappedDbset = dbset.Select(x => _mapper.Map<JobOfferDto>(x));

            var list = await mappedDbset.ToListAsync();

            return list;
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
