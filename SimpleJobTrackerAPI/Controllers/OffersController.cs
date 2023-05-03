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

        public Task<ActionResult<List<JobOfferDTO>>> GetAllDeletedOffers()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<JobOfferDTO>>> GetAllNonDeletedOffers()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<List<JobOfferDTO>>> GetAllOffers()
        {
            throw new NotImplementedException();
        }

        public object PatchDeleteJobOffer(int jobOfferToDeleteId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<JobOfferDTO>> PostNewJobOffer(JobOfferDTO newJobOffer)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutJobOffer(int id, JobOfferDTO updatedJobOffer)
        {
            throw new NotImplementedException();
        }
    }
}
