using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Models;

namespace SimpleJobTrackerAPI.Controllers
{
    public class OffersDbContext : DbContext
    {
        public OffersDbContext(DbContextOptions options) : base(options) { }

        public DbSet<JobOffer> JobOffers { get; set; }
    }
}
