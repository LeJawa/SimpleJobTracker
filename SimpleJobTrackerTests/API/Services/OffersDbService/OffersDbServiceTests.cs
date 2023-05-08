using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerTests.API.Services.OffersDbService
{
    // TODO Test suite for OffersDbService
    public class OffersDbServiceTests
    {
        //[Fact]
        //public async Task GetAllOffersReturnsAllOffers()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<OffersDbContext>()
        //        .UseInMemoryDatabase(databaseName: "TestDatabase")
        //        .Options;
        //    var dbContextMock = new Mock<OffersDbContext>(options);
        //    var data = new List<JobOffer> { new JobOffer { Id = 1, Position = "Position 1", IsDeleted = false } };
        //    var dbSetMock = new Mock<DbSet<JobOffer>>();

        //    dbSetMock.As<IQueryable<JobOffer>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
        //    dbSetMock.As<IQueryable<JobOffer>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
        //    dbSetMock.As<IQueryable<JobOffer>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
        //    dbSetMock.As<IQueryable<JobOffer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


        //    dbContextMock.Setup(m => m.JobOffers).Returns(dbSetMock.Object);

        //    var jobOffer = new JobOffer { Id = 1, Position = "Position 1", IsDeleted = false };
        //    var jobOfferDto = new JobOfferDto { Id = 1, Position = "Position 1" };

        //    var mapperMock = new Mock<IMapper>();
        //    mapperMock.Setup(m => m.Map<JobOfferDto>(jobOffer)).Returns(jobOfferDto);


        //    var service = new SimpleJobTrackerAPI.Services.OffersDbService.OffersDbService(dbContextMock.Object, mapperMock.Object);

        //    // Act
        //    var result = await service.GetAllOffers();

        //    // Assert
        //    Assert.Single(result);
        //    Assert.Equal(1, result[0].Id);
        //    Assert.Equal("Position 1", result[0].Position);
        //}


    }
}
