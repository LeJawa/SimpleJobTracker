using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace SimpleJobTrackerTests.API.Controllers
{
    public class OffersControllerTests
    {
        private static int _mockedDbContextCount;
        private static int _mockedDbContextNonDeletedCount;
        private static int _mockedDbContextDeletedCount;

        /// <summary>
        /// Tests if the OffersController class has a Dependency Injection of the OfferDbContext
        /// </summary>
        [Fact]
        public void OffersControllerHasDbContextDI()
        {
            var mockDbContext = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(mockDbContext.Object, mapperMock.Object);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Creates a mock DbContext to make the tests. The mocked database contains 3 JobOffers.
        /// </summary>
        /// <returns>The mocked OffersDbContext</returns>
        private static Mock<OffersDbContext> GetMockDbContext()
        {
            var mockOptions = new DbContextOptionsBuilder<OffersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;


            var offersDbContextMock = new Mock<OffersDbContext>(mockOptions);
            var data = new List<JobOfferModel>
            {
                new JobOfferModel() { Id = 1, Position = "Entity 1" },
                new JobOfferModel() { Id = 2, Position = "Entity 2" },
                new JobOfferModel() { Id = 3, Position = "Entity 3", IsDeleted = true },
                new JobOfferModel() { Id = 4, Position = "Entity 4" },
                new JobOfferModel() { Id = 5, Position = "Entity 5", IsDeleted = true },
            };

            _mockedDbContextCount = data.Count;
            _mockedDbContextNonDeletedCount = data.Select(x => !x.IsDeleted).ToList().Count;
            _mockedDbContextDeletedCount = data.Select(x => x.IsDeleted).ToList().Count;

            var mockSet = new Mock<DbSet<JobOfferModel>>();
            mockSet.As<IQueryable<JobOfferModel>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<JobOfferModel>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<JobOfferModel>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<JobOfferModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // alternative to the previous line
            //mockSet.As<IQueryable<JobOffer>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());

            // Assigns the mockSet object to be returned when the context DbSet is queried.
            offersDbContextMock.Setup(c => c.Set<JobOfferModel>()).Returns(mockSet.Object);
            return offersDbContextMock;
        }

        private static Mock<IMapper> GetMockMapper()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<JobOfferModel>(It.IsAny<JobOfferDto>())).Returns(It.IsAny<JobOfferModel>());
            return mapperMock;
        }

        // GetAllOffers
        [Fact]
        public void GetAllOffersReturnsAllOffers()
        {
            // Arrange
            Mock<OffersDbContext> offersDbContextMock = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(offersDbContextMock.Object, mapperMock.Object);

            // Act
            var result = controller.GetAllOffers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(_mockedDbContextCount, jobOffers.Count());
        }

        // GetAllNonDeletedOffers
        [Fact]
        public void GetAllNonDeletedOffersReturnsNonDeletedOffers()
        {
            // Arrange
            Mock<OffersDbContext> offersDbContextMock = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(offersDbContextMock.Object, mapperMock.Object);

            // Act
            var result = controller.GetAllNonDeletedOffers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(_mockedDbContextNonDeletedCount, jobOffers.Count());
        }

        // GetAllDeletedOffers
        [Fact]
        public void GetAllDeletedOffersReturnsDeletedOffers()
        {
            // Arrange
            Mock<OffersDbContext> offersDbContextMock = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(offersDbContextMock.Object, mapperMock.Object);

            // Act
            var result = controller.GetAllDeletedOffers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(_mockedDbContextDeletedCount, jobOffers.Count());
        }

        // PostNewJobOffer
        [Fact]
        public void PostNewJobOfferCreatesNewJobOffer()
        {
            // Arrange
            Mock<OffersDbContext> offersDbContextMock = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(offersDbContextMock.Object, mapperMock.Object);

            var newJobOffer = new JobOfferDto() { Position = "New Position" };

            // Act
            var result = controller.PostNewJobOffer(newJobOffer);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdJobOffer = Assert.IsType<JobOfferDto>(createdAtActionResult.Value);
            Assert.Equal(newJobOffer.Position, createdJobOffer.Position);
            offersDbContextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

        // PutJobOffer
        [Fact]
        public void PutJobOfferSavesJobOffer()
        {
            // Arrange
            Mock<OffersDbContext> offersDbContextMock = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(offersDbContextMock.Object, mapperMock.Object);

            int updatedJobOfferId = 1;
            var updatedJobOffer = new JobOfferDto() { Id = updatedJobOfferId, Position = "Updated Position" };

            // Act
            var result = controller.PutJobOffer(updatedJobOffer.Id, updatedJobOffer);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Equal(updatedJobOffer.Position, offersDbContextMock.Object.JobOffers.First(x => x.Id == updatedJobOfferId).Position);
            offersDbContextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }


        // PatchDeleteJobOffer
        [Fact]
        public void PatchDeleteJobOfferDeletesJobOffer()
        {
            // Arrange
            Mock<OffersDbContext> offersDbContextMock = GetMockDbContext();
            var mapperMock = GetMockMapper();

            var controller = new OffersController(offersDbContextMock.Object, mapperMock.Object);

            int jobOfferToDeleteId = 1;

            // Act
            var result = controller.PatchDeleteJobOffer(jobOfferToDeleteId);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.True(offersDbContextMock.Object.JobOffers.First(x => x.Id == jobOfferToDeleteId).IsDeleted);
            offersDbContextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
