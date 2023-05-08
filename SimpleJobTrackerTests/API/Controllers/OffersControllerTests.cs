using Microsoft.AspNetCore.Mvc;
using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerTests.API.Controllers
{
    public class OffersControllerTests
    {
        private class TestOffersDbService : IOffersDbService
        {
            List<JobOfferDto> _orders;

            public TestOffersDbService()
            {
                _orders = new List<JobOfferDto>()
                {
                    new JobOfferDto() { Id = 1, Position = "Position 1" },
                    new JobOfferDto() { Id = 2, Position = "Position 2" },
                    new JobOfferDto() { Id = 3, Position = "Position 3" },
                    new JobOfferDto() { Id = 4, Position = "Position 4" },
                    new JobOfferDto() { Id = 5, Position = "Position 5" },
                };
            }

            public static int GetAllOffersCount { get; private set; }
            public Task<List<JobOfferDto>> GetAllOffers()
            {
                GetAllOffersCount = _orders.Count;

                return Task.FromResult(_orders);
            }

            public Task<JobOfferDto?> GetSingleJobOffer(int id)
            {
                try
                {
                    return Task.FromResult(_orders?.Single(x => x.Id == id));
                }
                catch
                {
                    return Task.FromResult(null as JobOfferDto);
                }
            }

            public static int GetJobOffersCount { get; private set; }
            public Task<List<JobOfferDto>> GetJobOffers()
            {
                GetJobOffersCount = _orders.Count;

                return Task.FromResult(_orders);
            }

            public static int GetDeletedOffersCount { get; private set; }
            public Task<List<JobOfferDto>> GetDeletedOffers()
            {
                GetDeletedOffersCount = _orders.Count;

                return Task.FromResult(_orders);
            }

            public Task<bool> DeleteJobOffer(int id)
            {
                try
                {
                    _orders.RemoveAt(_orders.FindIndex(x => x.Id == id));
                }
                catch
                {
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);
            }

            public Task<JobOfferDto> AddJobOffer(JobOfferDto jobOffer)
            {
                jobOffer.Id = _orders.Count + 1;
                _orders.Add(jobOffer);

                return Task.FromResult(jobOffer);
            }

            public Task<bool> UpdateJobOffer(JobOfferDto jobOffer)
            {
                try
                {
                    _orders.Single(x => x.Id == jobOffer.Id).Position = jobOffer.Position;
                }
                catch
                {
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);
            }

            public Task<JobOfferDto> UpsertJobOffer(JobOfferDto newJobOffer)
            {
                throw new NotImplementedException();
            }
        }

        // GetAllOffers
        [Fact]
        public async Task GetAllOffersReturnsAllOffersAsync()
        {
            var controller = new OffersController(new TestOffersDbService());

            // Act
            var actionResult = (await controller.GetAllOffers()).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(TestOffersDbService.GetAllOffersCount, jobOffers.Count());
        }

        // GetAllNonDeletedOffers
        [Fact]
        public async Task GetAllNonDeletedOffersReturnsNonDeletedOffersAsync()
        {
            // Arrange
            var controller = new OffersController(new TestOffersDbService());

            // Act
            var actionResult = (await controller.GetAllNonDeletedOffers()).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(TestOffersDbService.GetJobOffersCount, jobOffers.Count());
        }

        // GetAllDeletedOffers
        [Fact]
        public async Task GetAllDeletedOffersReturnsDeletedOffersAsync()
        {
            // Arrange
            var controller = new OffersController(new TestOffersDbService());

            // Act
            var actionResult = (await controller.GetAllDeletedOffers()).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var jobOffers = Assert.IsAssignableFrom<IEnumerable<JobOfferDto>>(okResult.Value);
            Assert.Equal(TestOffersDbService.GetDeletedOffersCount, jobOffers.Count());
        }

        // PostNewJobOffer
        [Fact]
        public async Task PostNewJobOfferCreatesNewJobOfferAsync()
        {
            // Arrange
            var controller = new OffersController(new TestOffersDbService());

            var newJobOffer = new JobOfferDto() { Position = "New Position" };

            // Act
            var actionResult = (await controller.AddNewJobOffer(newJobOffer)).Result;

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            var createdJobOffer = Assert.IsType<JobOfferDto>(createdAtActionResult.Value);
            Assert.Equal(newJobOffer.Position, createdJobOffer.Position);
            Assert.True(createdJobOffer.Id != 0);
        }

        // PutJobOffer
        [Fact]
        public async Task PutJobOfferSavesJobOfferAsync()
        {
            // Arrange
            var service = new TestOffersDbService();
            var controller = new OffersController(service);

            int updatedJobOfferId = 1;
            var updatedJobOffer = new JobOfferDto() { Id = updatedJobOfferId, Position = "Updated Position" };

            // Act
            var actionResult = await controller.UpdateJobOffer(updatedJobOffer);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
            Assert.Equal(updatedJobOffer.Position, service.GetSingleJobOffer(updatedJobOfferId).Result.Position);
        }


        // PatchDeleteJobOffer
        [Fact]
        public async Task PatchDeleteJobOfferReturnsNoContentResult()
        {
            // Arrange
            var controller = new OffersController(new TestOffersDbService());

            int jobOfferToDeleteId = 1;

            // Act
            var result = await controller.DeleteJobOffer(jobOfferToDeleteId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PatchDeleteJobOfferReturnsBadRequestIfOfferNotFound()
        {
            // Arrange
            var controller = new OffersController(new TestOffersDbService());

            int jobOfferToDeleteId = -1;

            // Act
            var result = await controller.DeleteJobOffer(jobOfferToDeleteId);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        // GetSingleOffer
        [Fact]
        public async Task GetSingleOfferReturnsCorrectOffer()
        {
            var controller = new OffersController(new TestOffersDbService());
            int id = 1;

            var result = (await controller.GetSingleOffer(id)).Result;

            var okResult = Assert.IsType<OkObjectResult>(result);
            var jobOffer = Assert.IsType<JobOfferDto>(okResult.Value);
            Assert.Equal(id, jobOffer.Id);
        }

        [Fact]
        public async Task GetSingleOfferReturnsNotFound()
        {
            var controller = new OffersController(new TestOffersDbService());
            int id = -1;

            var result = (await controller.GetSingleOffer(id)).Result;

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
