using Microsoft.AspNetCore.Mvc;
using SimpleJobTrackerAPI.Data;
using SimpleJobTrackerAPI.Services.OffersDbService;

namespace SimpleJobTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersDbService _service;

        public OffersController(IOffersDbService service)
        {
            _service = service;
        }

        /// <summary>
        /// Queries the database for the list of all the deleted offers
        /// </summary>
        /// <returns>A list of deleted Job Offers</returns>
        [HttpGet("deleted")]
        public async Task<ActionResult<List<JobOfferDto>>> GetAllDeletedOffers()
        {
            return Ok(await _service.GetDeletedOffers());
        }

        [HttpGet]
        public async Task<ActionResult<List<JobOfferDto>>> GetAllNonDeletedOffers()
        {
            return Ok(await _service.GetJobOffers());
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<JobOfferDto>>> GetAllOffers()
        {
            return Ok(await _service.GetAllOffers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobOfferDto>> GetSingleJobOffer(int id)
        {
            var jobOffer = await _service.GetSingleJobOffer(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return Ok(jobOffer);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobOffer(int jobOfferToDeleteId)
        {
            if (await _service.DeleteJobOffer(jobOfferToDeleteId))
                return NoContent();

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<JobOfferDto>> AddNewJobOffer(JobOfferDto newJobOffer)
        {
            var createdJobOffer = await _service.AddJobOffer(newJobOffer);

            return CreatedAtAction(nameof(GetSingleJobOffer), new { id = createdJobOffer.Id }, createdJobOffer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobOffer(JobOfferDto updatedJobOffer)
        {
            if (await _service.UpdateJobOffer(updatedJobOffer))
                return NoContent();

            return BadRequest();
        }
    }
}
