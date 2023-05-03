using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJobTrackerTests.API.Models
{
    public class CompanyModelTests
    {
        [Fact]
        public void CompanyModelExists()
        {
            CompanyModel company = new CompanyModel();

            Assert.NotNull(company);
        }

        [Fact]
        public void IdProperty()
        {
            CompanyModel company = new CompanyModel();
            int id = 1;

            company.Id = id;

            Assert.Equal(id, company.Id);
        }

        [Fact]
        public void NameProperty()
        {
            CompanyModel company = new CompanyModel();
            string name = "Name";

            company.Name = name;

            Assert.Equal(name, company.Name);
        }
    }
}
