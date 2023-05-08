using Microsoft.AspNetCore.Mvc;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerTests.API.Controllers
{
    public class OffersControllerTests
    {
        private List<JobOfferDto> _offers
        {
            get
            {
                var offers = new List<JobOfferDto>()
                {
                    new JobOfferDto() { Id = 1, Position = "Position 1" },
                    new JobOfferDto() { Id = 2, Position = "Position 2" },
                    new JobOfferDto() { Id = 3, Position = "Position 3" },
                    new JobOfferDto() { Id = 4, Position = "Position 4" },
                    new JobOfferDto() { Id = 5, Position = "Position 5" },
                };

                return offers;
            }
        }


        // GetAllOffers
        [Fact]
        public async Task GetAllOffersReturnsAllOffersAsync()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();
            mockOffersDbService.Setup(m => m.GetAllOffers()).Returns(Task.FromResult(_offers));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var actionResult = (await controller.GetAllOffers()).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(_offers.Count, jobOffers.Count());
        }

        // GetAllNonDeletedOffers
        [Fact]
        public async Task GetAllNonDeletedOffersReturnsNonDeletedOffersAsync()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();
            mockOffersDbService.Setup(m => m.GetJobOffers()).Returns(Task.FromResult(_offers));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var actionResult = (await controller.GetAllNonDeletedOffers()).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(_offers.Count, jobOffers.Count());
        }

        // GetAllDeletedOffers
        [Fact]
        public async Task GetAllDeletedOffersReturnsDeletedOffersAsync()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();
            mockOffersDbService.Setup(m => m.GetDeletedOffers()).Returns(Task.FromResult(_offers));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var actionResult = (await controller.GetAllDeletedOffers()).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(_offers.Count, jobOffers.Count());
        }

        // AddNewJobOffer
        [Fact]
        public async Task AddNewJobOfferCreatesNewJobOfferAsync()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();
            var newJobOffer = new JobOfferDto() { Position = "New Position" };
            var addedJobOffer = new JobOfferDto() { Id = 1, Position = newJobOffer.Position };

            mockOffersDbService.Setup(m => m.AddJobOffer(newJobOffer)).Returns(Task.FromResult(addedJobOffer));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var actionResult = (await controller.AddNewJobOffer(newJobOffer)).Result;

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            var createdJobOffer = Assert.IsType<JobOfferDto>(createdAtActionResult.Value);
            Assert.Equal(newJobOffer.Position, createdJobOffer.Position);
            Assert.True(createdJobOffer.Id == addedJobOffer.Id);
        }

        // UpdateJobOffer
        [Fact]
        public async Task UpdateJobOfferCorrecltySavesJobOfferAsync()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();

            int updatedJobOfferId = 1;
            var updatedJobOffer = new JobOfferDto() { Id = updatedJobOfferId, Position = "Updated Position" };

            mockOffersDbService.Setup(m => m.UpdateJobOffer(updatedJobOffer)).Returns(Task.FromResult(true));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var actionResult = await controller.UpdateJobOffer(updatedJobOffer);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task UpdateJobOfferCannotUpdateJobOffer()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();

            int updatedJobOfferId = 1;
            var updatedJobOffer = new JobOfferDto() { Id = updatedJobOfferId, Position = "Updated Position" };

            mockOffersDbService.Setup(m => m.UpdateJobOffer(updatedJobOffer)).Returns(Task.FromResult(false));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var actionResult = await controller.UpdateJobOffer(updatedJobOffer);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }


        // PatchDeleteJobOffer
        [Fact]
        public async Task PatchDeleteJobOfferReturnsNoContentResult()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();
            int jobOfferToDeleteId = 1;
            mockOffersDbService.Setup(m => m.DeleteJobOffer(jobOfferToDeleteId)).Returns(Task.FromResult(true));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var result = await controller.DeleteJobOffer(jobOfferToDeleteId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PatchDeleteJobOfferReturnsBadRequestIfOfferNotFound()
        {
            // Arrange
            var mockOffersDbService = new Mock<IOffersDbService>();
            int jobOfferToDeleteId = 1;
            mockOffersDbService.Setup(m => m.DeleteJobOffer(jobOfferToDeleteId)).Returns(Task.FromResult(false));

            var controller = new OffersController(mockOffersDbService.Object);

            // Act
            var result = await controller.DeleteJobOffer(jobOfferToDeleteId);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        // GetSingleJobOffer
        [Fact]
        public async Task GetSingleJobOfferReturnsCorrectOffer()
        {
            var mockOffersDbService = new Mock<IOffersDbService>();
            int id = 1;
            var gotJobOffer = new JobOfferDto() { Id = id, Position = "Position" };
            mockOffersDbService.Setup(m => m.GetSingleJobOffer(id)).Returns(Task.FromResult((JobOfferDto?)gotJobOffer));

            var controller = new OffersController(mockOffersDbService.Object);

            var result = (await controller.GetSingleJobOffer(id)).Result;

            var okResult = Assert.IsType<OkObjectResult>(result);
            var jobOffer = Assert.IsType<JobOfferDto>(okResult.Value);
            Assert.Equal(id, jobOffer.Id);
        }

        [Fact]
        public async Task GetSingleJobOfferReturnsNotFound()
        {
            var mockOffersDbService = new Mock<IOffersDbService>();
            int id = 1;
            mockOffersDbService.Setup(m => m.GetSingleJobOffer(id)).Returns(Task.FromResult(null as JobOfferDto));

            var controller = new OffersController(mockOffersDbService.Object);

            var result = (await controller.GetSingleJobOffer(id)).Result;

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
