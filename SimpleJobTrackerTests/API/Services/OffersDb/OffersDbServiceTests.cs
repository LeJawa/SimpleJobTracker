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

        private int AllOffersCount => _context.JobOffers.Count();
        private int DeletedOffersCount => _context.JobOffers.Where(x => x.IsDeleted).Count();
        private int JobOffersCount => _context.JobOffers.Where(x => !x.IsDeleted).Count();

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
        public async Task GetAllOffers_ReturnsCorrectCount()
        {
            // Arrange
            InitializeService();

            // Act
            var result = await _service.GetAllOffers();

            // Assert
            result.Should().HaveCount(AllOffersCount);
            result[0].Should().BeEquivalentTo(_mapper.Map<JobOfferDto>(_context.JobOffers.First()));
        }

        [Fact]
        public async Task GetJobOffers_ReturnsCorrectCount()
        {
            InitializeService();

            var result = await _service.GetJobOffers();

            result.Should().HaveCount(JobOffersCount);
        }

        [Fact]
        public async Task GetDeletedOffers_ReturnsCorrectCount()
        {
            InitializeService();

            var result = await _service.GetDeletedOffers();

            result.Should().HaveCount(DeletedOffersCount);
        }

        [Fact]
        public async Task GetSingleJobOffer_ReturnsOfferIfNonDeleted()
        {
            InitializeService();

            var result = await _service.GetSingleJobOffer(id: 1);
            var expected = _mapper.Map<JobOfferDto>(_context.JobOffers.SingleOrDefault(x => x.Id == 1));

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetSingleJobOffer_ReturnsNullIfDeleted()
        {
            InitializeService();

            var result = await _service.GetSingleJobOffer(id: 3);

            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteJobOffer_ReturnsTrue()
        {
            InitializeService();

            var initialJobOffersCount = JobOffersCount;
            var initialDeletedOffersCount = DeletedOffersCount;

            var result = await _service.DeleteJobOffer(id: 1);

            result.Should().BeTrue();
            JobOffersCount.Should().Be(initialJobOffersCount - 1);
            DeletedOffersCount.Should().Be(initialDeletedOffersCount + 1);
        }


        [Fact]
        public async Task DeleteJobOffer_ReturnsFalse()
        {
            InitializeService();

            var initialJobOffersCount = JobOffersCount;
            var initialDeletedOffersCount = DeletedOffersCount;

            var result = await _service.DeleteJobOffer(id: 3);

            result.Should().BeFalse();
            JobOffersCount.Should().Be(initialJobOffersCount);
            DeletedOffersCount.Should().Be(initialDeletedOffersCount);
        }

        [Fact]
        public async Task AddJobOffer_ReturnsNewId()
        {
            InitializeService();

            var initialJobOffersCount = JobOffersCount;
            var jobOffer = new JobOfferDto() { Position = "Test position" };

            var result = await _service.AddJobOffer(jobOffer);

            result.Id.Should().BePositive();
            result.Position.Should().Be(jobOffer.Position);
            JobOffersCount.Should().Be(initialJobOffersCount + 1);
        }

        [Fact]
        public async Task UpdateJobOffer_ReturnsTrue()
        {
            InitializeService();
            var jobOffer = new JobOfferDto() { Id = 1, Position = "Test position" };

            var result = await _service.UpdateJobOffer(jobOffer);

            result.Should().BeTrue();
            _context.JobOffers.Single(x => x.Id == 1).Position.Should().Be(jobOffer.Position);
        }

        [Fact]
        public async Task UpdateJobOffer_ReturnsFalse()
        {
            InitializeService();
            var jobOffer = new JobOfferDto() { Id = 3, Position = "Test position" };

            var result = await _service.UpdateJobOffer(jobOffer);

            result.Should().BeFalse();
            _context.JobOffers.Single(x => x.Id == 3).Position.Should().NotBe(jobOffer.Position);
        }

    }
}
