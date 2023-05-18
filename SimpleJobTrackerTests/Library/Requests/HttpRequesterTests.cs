using FluentAssertions;
using SimpleJobTrackerLibrary.Requests;

namespace SimpleJobTrackerTests.Library.Requests
{
    public class HttpRequesterTests
    {
        [Fact]
        public void RequestData_ThrowsNotImplemented()
        {
            var requester = new HttpRequester();

            Assert.Throws<NotImplementedException>(requester.RequestData);
        }

        [Fact]
        public void OffersProperty_StartsAsNull()
        {
            var requester = new HttpRequester();

            requester.Offers.Should().BeNull();
        }


        [Fact]
        public async Task RequestDataAsync_SetsOffers()
        {
            var requester = new HttpRequester();

            await requester.RequestDataAsync();

            requester.Offers.Should().NotBeNull();
        }

        // TODO: fully test RequestDataAsync method
    }
}
