namespace SimpleJobTrackerTests.API.Data
{
    public class CompanyTests
    {
        [Fact]
        public void CompanyModelExists()
        {
            Company company = new Company();

            Assert.NotNull(company);
        }

        [Fact]
        public void IdProperty()
        {
            Company company = new Company();
            int id = 1;

            company.Id = id;

            Assert.Equal(id, company.Id);
        }

        [Fact]
        public void NameProperty()
        {
            Company company = new Company();
            string name = "Name";

            company.Name = name;

            Assert.Equal(name, company.Name);
        }
    }
}
