using Microsoft.AspNetCore.Mvc;
using SimpleJobTrackerAPI.Models;

namespace SimpleJobTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly OffersDbContext _context;

        public OffersController(OffersDbContext context)
        {
            _context = context;
        }

        public Task<ActionResult<List<JobOfferDto>>> GetAllDeletedOffers()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<JobOfferDto>>> GetAllNonDeletedOffers()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<List<JobOfferDto>>> GetAllOffers()
        {
            throw new NotImplementedException();
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
