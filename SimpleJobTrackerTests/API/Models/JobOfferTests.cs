namespace SimpleJobTrackerTests.API.Models
{
    public class JobOfferTests
    {
        [Fact]
        public void JobOfferExists()
        {
            JobOfferModel jobOffer = new JobOfferModel();

            Assert.NotNull(jobOffer);
        }

        [Fact]
        public void IdProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();

            int id = 1;

            jobOffer.Id = id;

            Assert.Equal(id, jobOffer.Id);
        }

        [Fact]
        public void PositionProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            string position = "Position";

            jobOffer.Position = position;

            Assert.Equal(position, jobOffer.Position);
        }

        // Location
        [Fact]
        public void LocationProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            string location = "Location";

            jobOffer.Location = location;

            Assert.Equal(location, jobOffer.Location);
        }

        // SalaryRangeBottom
        [Fact]
        public void SalaryRangeBottomProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            decimal salaryRangeBottom = 10m;

            jobOffer.SalaryRangeBottom = salaryRangeBottom;

            Assert.Equal(salaryRangeBottom, jobOffer.SalaryRangeBottom);
        }

        // SalaryRangeTop
        [Fact]
        public void SalaryRangeTopProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            decimal salaryRangeTop = 10m;

            jobOffer.SalaryRangeTop = salaryRangeTop;

            Assert.Equal(salaryRangeTop, jobOffer.SalaryRangeTop);
        }

        // Status
        [Fact]
        public void StatusProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            StatusModel status = new StatusModel();

            jobOffer.Status = status;

            Assert.Equal(status, jobOffer.Status);
        }

        // Company
        [Fact]
        public void CompanyProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            CompanyModel company = new CompanyModel();

            jobOffer.Company = company;

            Assert.Equal(company, jobOffer.Company);
        }

        // JobType
        [Fact]
        public void JobTypeProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            JobTypeModel jobType = new JobTypeModel();

            jobOffer.JobType = jobType;

            Assert.Equal(jobType, jobOffer.JobType);
        }

        // Comments
        [Fact]
        public void CommentsProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            string comments = "Comments";

            jobOffer.Comments = comments;

            Assert.Equal(comments, jobOffer.Comments);
        }

        // CreationDate
        [Fact]
        public void CreationDateProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            DateTime creationDate = DateTime.Now;

            jobOffer.CreationDate = creationDate;

            Assert.Equal(creationDate, jobOffer.CreationDate);
        }

        // Url
        [Fact]
        public void UrlProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            string url = "Url";

            jobOffer.Url = url;

            Assert.Equal(url, jobOffer.Url);
        }

        // IsDeleted
        [Fact]
        public void IsDeletedProperty()
        {
            JobOfferModel jobOffer = new JobOfferModel();
            bool isDeleted = true;

            jobOffer.IsDeleted = isDeleted;

            Assert.Equal(isDeleted, jobOffer.IsDeleted);
        }

    }
}
