using AutoFixture;
using System.Net.Sockets;

namespace SimpleJobTrackerAPI.Data
{
    public static class Seeder
    {
        public static void Seed(this OffersDbContext offersContext)
        {
            if (!offersContext.JobOffers.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<JobOffer>(product => product.Without(p => p.Id));
                fixture.Customize<Company>(product => product.Without(c => c.Id));
                //--- The next two lines add 25 rows to your database
                List<JobOffer> offers = fixture.CreateMany<JobOffer>(25).ToList();
                offersContext.AddRange(offers);
                offersContext.SaveChanges();
            }
        }
    }
}

