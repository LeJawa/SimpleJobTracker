using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimpleJobTrackerTests.API.Models
{
    public class JobOfferTests
    {
        [Fact]
        public void JobOfferExists()
        {
            JobOffer jobOffer = new JobOffer();

            Assert.NotNull(jobOffer);
        }

        [Fact]
        public void IdProperty()
        {
            JobOffer jobOffer = new JobOffer();

            int id = 1;

            jobOffer.Id = id;

            Assert.Equal(id, jobOffer.Id);
        }

        [Fact]
        public void PositionProperty()
        {
            JobOffer jobOffer = new JobOffer();
            string position = "Position";

            jobOffer.Position = position;

            Assert.Equal(position, jobOffer.Position);
        }

        // Location
        [Fact]
        public void LocationProperty() 
        {
            JobOffer jobOffer = new JobOffer();
            string location = "Location";

            jobOffer.Location = location;

            Assert.Equal(location, jobOffer.Location);
        }

        // SalaryRangeBottom
        [Fact]
        public void SalaryRangeBottomProperty()
        {
            JobOffer jobOffer = new JobOffer();
            decimal salaryRangeBottom = 10m;

            jobOffer.SalaryRangeBottom = salaryRangeBottom;

            Assert.Equal(salaryRangeBottom, jobOffer.SalaryRangeBottom);
        }

        // SalaryRangeTop
        [Fact]
        public void SalaryRangeTopProperty()
        {
            JobOffer jobOffer = new JobOffer();
            decimal salaryRangeTop = 10m;

            jobOffer.SalaryRangeTop = salaryRangeTop;

            Assert.Equal(salaryRangeTop, jobOffer.SalaryRangeTop);
        }

        // Status
        [Fact]
        public void StatusProperty()
        {
            JobOffer jobOffer = new JobOffer();
            StatusModel status = new StatusModel();

            jobOffer.Status = status;

            Assert.Equal(status, jobOffer.Status);
        }

        // Company
        [Fact]
        public void CompanyProperty()
        {
            JobOffer jobOffer = new JobOffer();
            CompanyModel company = new CompanyModel();

            jobOffer.Company = company;

            Assert.Equal(company, jobOffer.Company);
        }

        // JobType
        [Fact]
        public void JobTypeProperty()
        {
            JobOffer jobOffer = new JobOffer();
            JobTypeModel jobType = new JobTypeModel();

            jobOffer.JobType = jobType;

            Assert.Equal(jobType, jobOffer.JobType);
        }

        // Comments
        [Fact]
        public void CommentsProperty()
        {
            JobOffer jobOffer = new JobOffer();
            string comments = "Comments";

            jobOffer.Comments = comments;

            Assert.Equal(comments, jobOffer.Comments);
        }

        // CreationDate
        [Fact]
        public void CreationDateProperty()
        {
            JobOffer jobOffer = new JobOffer();
            DateTime creationDate = DateTime.Now;

            jobOffer.CreationDate = creationDate;

            Assert.Equal(creationDate, jobOffer.CreationDate);
        }

        // Url
        [Fact]
        public void UrlProperty()
        {
            JobOffer jobOffer = new JobOffer();
            string url = "Url";

            jobOffer.Url = url;

            Assert.Equal(url, jobOffer.Url);
        }

        // IsDeleted
        [Fact]
        public void IsDeletedProperty()
        {
            JobOffer jobOffer = new JobOffer();
            bool isDeleted = true;

            jobOffer.IsDeleted = isDeleted;

            Assert.Equal(isDeleted, jobOffer.IsDeleted);
        }

    }
}
