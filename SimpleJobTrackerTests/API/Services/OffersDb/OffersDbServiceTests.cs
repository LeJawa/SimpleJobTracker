using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerTests.API.Services.OffersDb
{
    // TODO Test suite for OffersDbService
    public class OffersDbServiceTests
    {
        private const string _connectionString = "Server=VULCANO\\SQLEXPRESS;Database=TestOffersDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";

        private IOffersDbService _service = null!;
        private IMapper _mapper = null!;
        private OffersDbContext _context = null!;

        private void InitializeService()
        {
            InitializeContext();
            InitializeMapper();

            _service = new OffersDbService(_context, _mapper);
        }

        private void InitializeMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new JobOffersProfile()));
            _mapper = new Mapper(configuration);
        }

        private void InitializeContext()
        {
            var options = new DbContextOptionsBuilder<OffersDbContext>()
                            .UseSqlServer(_connectionString)
                            .Options;
            _context = new OffersDbContext(options);

            _context.Database.ExecuteSql($"dbo.spInitializeTestEnvironment");
        }

        [Fact]
        public async Task GetAllOffersReturnsAllOffers()
        {
            // Arrange
            InitializeService();

            // Act
            var result = await _service.GetAllOffers();

            // Assert
            result.Should().HaveCount(_context.JobOffers.Count());
            result[0].Should().BeEquivalentTo(_mapper.Map<JobOfferDto>(_context.JobOffers.First()));
        }


    }
}
