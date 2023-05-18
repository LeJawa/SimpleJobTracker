using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerLibrary.Requests
{
    public class HttpRequester : IDataRequester<JobOfferDto>
    {
        public List<JobOfferDto> Offers { get; private set; } = null!;


        public List<JobOfferDto> RequestData()
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobOfferDto>> RequestDataAsync()
        {
            // Create a New HttpClient object.
            HttpClient client = new HttpClient();

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/offers");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();

            // TODO: parse json response

            return Offers;
        }
    }
}
