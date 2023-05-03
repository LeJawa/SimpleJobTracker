namespace SimpleJobTrackerTests.API.Models
{
    public class JobTypeModelTests
    {
        [Fact]
        public void JobTypeModelExists()
        {
            JobTypeModel jobType = new JobTypeModel();

            Assert.NotNull(jobType);
        }

        [Fact]
        public void IdProperty()
        {
            JobTypeModel jobType = new JobTypeModel();
            int id = 1;

            jobType.Id = id;

            Assert.Equal(id, jobType.Id);
        }

        [Fact]
        public void DescriptionProperty()
        {
            JobTypeModel jobType = new JobTypeModel();
            string description = "Description";

            jobType.Description = description;

            Assert.Equal(description, jobType.Description);
        }
    }
}
