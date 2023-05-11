using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Data;
using SimpleJobTrackerAPI.Enums;

namespace SimpleJobTrackerAPI.Services.OffersDb
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
                var jobOfferToBeRemoved = await _context.JobOffers.Include(x => x.Company).SingleAsync(x => x.Id == id);

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
            var deletedOffers = await _context.JobOffers.Include(x => x.Company).Where(x => x.IsDeleted).Select(x => _mapper.Map<JobOfferDto>(x)).ToListAsync();
            return deletedOffers;
        }

        public async Task<List<JobOfferDto>> GetJobOffers()
        {
            var offers = await _context.JobOffers.Include(x => x.Company).Where(x => !x.IsDeleted).Select(x => _mapper.Map<JobOfferDto>(x)).ToListAsync();
            return offers;
        }

        public async Task<JobOfferDto?> GetSingleJobOffer(int id)
        {
            try
            {
                var jobOffer = await _context.JobOffers.Include(x => x.Company).SingleAsync(x => x.Id == id);

                if (jobOffer.IsDeleted) { throw new KeyNotFoundException(); }

                return _mapper.Map<JobOfferDto>(jobOffer);
            }
            catch (Exception)
            {
                // TODO: Log exception
                return null;
            }
        }

        public async Task<bool> UpdateJobOffer(JobOfferDto jobOffer)
        {
            try
            {
                var existingJobOffer = await _context.JobOffers.Include(x => x.Company).SingleAsync(x => x.Id == jobOffer.Id);

                if (existingJobOffer.IsDeleted) { throw new KeyNotFoundException(); }

                existingJobOffer.Position = jobOffer.Position;

                // TODO: Update company instead of adding new one
                existingJobOffer.Company = new Company() { Name = jobOffer.CompanyName };

                existingJobOffer.Location = jobOffer.Location;
                existingJobOffer.Url = jobOffer.Url;

                existingJobOffer.JobType = Enum.Parse<JobType>(jobOffer.JobTypeDescription);
                existingJobOffer.Status = Enum.Parse<JobStatus>(jobOffer.StatusDescription);

                existingJobOffer.SalaryRangeBottom = jobOffer.SalaryRangeBottom;
                existingJobOffer.SalaryRangeTop = jobOffer.SalaryRangeTop;

                existingJobOffer.Comments = jobOffer.Comments;

                existingJobOffer.LastChange = DateTime.Now;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // TODO: Log exception
                return false;
            }
        }
    }
}
