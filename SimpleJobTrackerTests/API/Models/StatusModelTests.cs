namespace SimpleJobTrackerTests.API.Models
{
    public class StatusModelTests
    {
        [Fact]
        public void StatusModelExists()
        {
            StatusModel status = new StatusModel();

            Assert.NotNull(status);
        }

        [Fact]
        public void IdProperty()
        {
            StatusModel status = new StatusModel();
            int id = 1;

            status.Id = id;

            Assert.Equal(id, status.Id);
        }

        [Fact]
        public void DescriptionProperty()
        {
            StatusModel status = new StatusModel();
            string description = "Description";

            status.Description = description;

            Assert.Equal(description, status.Description);
        }
    }
}
