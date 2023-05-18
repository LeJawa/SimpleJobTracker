namespace SimpleJobTrackerLibrary.Requests
{
    public interface IDataRequester<T> where T : class
    {
        public List<T> RequestData();

        public Task<List<T>> RequestDataAsync();
    }
}
