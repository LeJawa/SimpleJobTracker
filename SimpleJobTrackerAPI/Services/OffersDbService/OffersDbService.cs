using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Controllers;
using SimpleJobTrackerAPI.Data;
using SimpleJobTrackerAPI.Models;

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


        public async Task<JobOfferDto> AddJobOffer(JobOfferDto jobOfferDto)
        {
            // Convert JobOfferDto into JobOffer
            var jobOffer = _mapper.Map<JobOffer>(jobOfferDto);


            // TODO: check if company already exists

            await _context.JobOffers.AddAsync(jobOffer);
            await _context.SaveChangesAsync();

            return _mapper.Map<JobOfferDto>(jobOffer);
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
