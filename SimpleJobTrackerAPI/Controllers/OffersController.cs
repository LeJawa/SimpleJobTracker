using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Models;

namespace SimpleJobTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly OffersDbContext _context;
        private readonly IMapper _mapper;

        public OffersController(OffersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Queries the database for the list of all the deleted offers
        /// </summary>
        /// <returns>A list of deleted Job Offers</returns>
        public Task<ActionResult<List<JobOfferDto>>> GetAllDeletedOffers()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<JobOfferDto>>> GetAllNonDeletedOffers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<JobOfferDto>>> GetAllOffers()
        {
            return await _context.JobOffers.Include(x => x.Company).Include(x => x.Status).Include(x => x.JobType).Select(x => _mapper.Map<JobOfferDto>(x)).ToListAsync();
        }

        public object PatchDeleteJobOffer(int jobOfferToDeleteId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<JobOfferDto>> PostNewJobOffer(JobOfferDto newJobOffer)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutJobOffer(int id, JobOfferDto updatedJobOffer)
        {
            throw new NotImplementedException();
        }
    }
}
