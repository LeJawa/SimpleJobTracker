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

        public async Task<bool> DeleteJobOffer(int id)
        {
            try
            {
                var jobOfferToBeRemoved = await _context.JobOffers.SingleAsync(x => x.Id == id);

                if (jobOfferToBeRemoved.IsDeleted) { throw new KeyNotFoundException(); } // Offer already deleted

                jobOfferToBeRemoved.IsDeleted = true;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // TODO: Log exception
                return false;
            }
        }

        public async Task<List<JobOfferDto>> GetAllOffers()
        {
            var dbset = _context.JobOffers;

            var mappedDbset = dbset.Select(x => _mapper.Map<JobOfferDto>(x));

            var list = await mappedDbset.ToListAsync();

            return list;
        }

        public async Task<List<JobOfferDto>> GetDeletedOffers()
        {
            var deletedOffers = await _context.JobOffers.Where(x => x.IsDeleted).Select(x => _mapper.Map<JobOfferDto>(x)).ToListAsync();
            return deletedOffers;
        }

        public async Task<List<JobOfferDto>> GetJobOffers()
        {
            var offers = await _context.JobOffers.Where(x => !x.IsDeleted).Select(x => _mapper.Map<JobOfferDto>(x)).ToListAsync();
            return offers;
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
