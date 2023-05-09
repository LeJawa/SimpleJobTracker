using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerTests.API.Services.OffersDbService
{
    // TODO Test suite for OffersDbService
    public class OffersDbServiceTests
    {
        [Fact]
        public async Task GetAllOffersReturnsAllOffers()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<OffersDbContext>()
                .UseSqlServer("Server=VULCANO\\SQLEXPRESS;Database=TestOffersDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True")
                .Options;
            var dbContext = new OffersDbContext(options);

            //await dbContext.JobOffers.ExecuteDeleteAsync();
            await dbContext.Database.ExecuteSqlAsync($"spDropAndCreateTables");

            await dbContext.Database.ExecuteSqlAsync($"spInsertNumberedCompany @CompanyNumber={1}");
            await dbContext.Database.ExecuteSqlAsync($"spInsertNumberedCompany @CompanyNumber={2}");
            await dbContext.Database.ExecuteSqlAsync($"spInsertNumberedCompany @CompanyNumber={3}");

            await dbContext.Database.ExecuteSqlAsync($"spInsertNumberedJobOffer @JobOfferNumber={1}");
            await dbContext.Database.ExecuteSqlAsync($"spInsertNumberedJobOffer @JobOfferNumber={2}");
            await dbContext.Database.ExecuteSqlAsync($"spInsertNumberedJobOffer @JobOfferNumber={3}");

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new JobOffersProfile()));
            IMapper mapper = new Mapper(configuration);

            IOffersDbService service = new SimpleJobTrackerAPI.Services.OffersDbService.OffersDbService(dbContext, mapper);

            // Act
            var result = await service.GetAllOffers();

            // Assert
            result.Should().HaveCount(dbContext.JobOffers.Count());
            result[0].Should().BeEquivalentTo(mapper.Map<JobOfferDto>(dbContext.JobOffers.First()));
        }


    }
}
