using Microsoft.EntityFrameworkCore;

namespace SimpleJobTrackerTests.API.Controllers
{
    public class OffersDbContextTests
    {
        [Fact]
        public void OffersDbContextExists()
        {
            var mockOptions = new DbContextOptionsBuilder<OffersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var offersDbContext = new OffersDbContext(mockOptions);

            Assert.NotNull(offersDbContext);
        }

        [Fact]
        public void JobOffersProperty()
        {
            var mockOptions = new DbContextOptionsBuilder<OffersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var offersDbContext = new OffersDbContext(mockOptions);
            int id = 1;
            var jobOffer = new JobOffer() { Id = id };

            offersDbContext.JobOffers.Add(jobOffer);
            offersDbContext.SaveChanges();

            Assert.Equal(jobOffer, offersDbContext.JobOffers.First());

            offersDbContext.JobOffers.Remove(jobOffer);
            offersDbContext.SaveChanges();

            Assert.Equal(0, offersDbContext.JobOffers.Count());
        }
    }
}
