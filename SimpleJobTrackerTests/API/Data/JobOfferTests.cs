namespace SimpleJobTrackerTests.API.Data
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
            JobStatus status = JobStatus.Other;

            jobOffer.Status = status;

            Assert.Equal(status, jobOffer.Status);
        }

        // Company
        [Fact]
        public void CompanyProperty()
        {
            JobOffer jobOffer = new JobOffer();
            Company company = new Company();

            jobOffer.Company = company;

            Assert.Equal(company, jobOffer.Company);
        }

        // JobType
        [Fact]
        public void JobTypeProperty()
        {
            JobOffer jobOffer = new JobOffer();
            JobType jobType = JobType.Remote;

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

        // LastChangeDate
        [Fact]
        public void LastChangeDateProperty()
        {
            JobOffer jobOffer = new JobOffer();
            DateTime lastChangeDate = DateTime.Now;

            jobOffer.LastChange = lastChangeDate;

            Assert.Equal(lastChangeDate, jobOffer.LastChange);
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
