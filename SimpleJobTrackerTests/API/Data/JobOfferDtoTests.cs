using SimpleJobTrackerAPI.Data;

namespace SimpleJobTrackerTests.API.Data
{
    public class JobOfferDtoTests
    {
        [Fact]
        public void JobOfferDtoExists()
        {
            JobOfferDto jobOffer = new JobOfferDto();

            Assert.NotNull(jobOffer);
        }

        [Fact]
        public void IdProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();

            int id = 1;

            jobOffer.Id = id;

            Assert.Equal(id, jobOffer.Id);
        }

        [Fact]
        public void PositionProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string position = "Position";

            jobOffer.Position = position;

            Assert.Equal(position, jobOffer.Position);
        }

        // Location
        [Fact]
        public void LocationProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string location = "Location";

            jobOffer.Location = location;

            Assert.Equal(location, jobOffer.Location);
        }

        // SalaryRangeBottom
        [Fact]
        public void SalaryRangeBottomProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            decimal salaryRangeBottom = 10m;

            jobOffer.SalaryRangeBottom = salaryRangeBottom;

            Assert.Equal(salaryRangeBottom, jobOffer.SalaryRangeBottom);
        }

        // SalaryRangeTop
        [Fact]
        public void SalaryRangeTopProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            decimal salaryRangeTop = 10m;

            jobOffer.SalaryRangeTop = salaryRangeTop;

            Assert.Equal(salaryRangeTop, jobOffer.SalaryRangeTop);
        }

        // StatusDescription
        [Fact]
        public void StatusDescriptionProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string statusDescription = "Status description";

            jobOffer.StatusDescription = statusDescription;

            Assert.Equal(statusDescription, jobOffer.StatusDescription);
        }

        // CompanyName
        [Fact]
        public void CompanyProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string companyName = "Company";

            jobOffer.CompanyName = companyName;

            Assert.Equal(companyName, jobOffer.CompanyName);
        }

        // JobTypeDescription
        [Fact]
        public void JobTypeProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string jobTypeDescription = "Job type description";

            jobOffer.JobTypeDescription = jobTypeDescription;

            Assert.Equal(jobTypeDescription, jobOffer.JobTypeDescription);
        }

        // Comments
        [Fact]
        public void CommentsProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string comments = "Comments";

            jobOffer.Comments = comments;

            Assert.Equal(comments, jobOffer.Comments);
        }

        // LastChangeDate
        [Fact]
        public void LastChangeDateProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            DateTime lastChangeDate = DateTime.Now;

            jobOffer.LastChange = lastChangeDate;

            Assert.Equal(lastChangeDate, jobOffer.LastChange);
        }

        // Url
        [Fact]
        public void UrlProperty()
        {
            JobOfferDto jobOffer = new JobOfferDto();
            string url = "Url";

            jobOffer.Url = url;

            Assert.Equal(url, jobOffer.Url);
        }
    }
}
