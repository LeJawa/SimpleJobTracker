using Microsoft.EntityFrameworkCore;

namespace SimpleJobTrackerAPI.Data
{
    public class OffersDbContext : DbContext
    {
        public OffersDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<JobOffer> JobOffers { get; set; }
    }
}
