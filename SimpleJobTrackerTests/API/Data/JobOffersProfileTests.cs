using AutoMapper;
using FluentAssertions;

namespace SimpleJobTrackerTests.API.Data
{
    public class JobOffersProfileTests
    {
        [Fact]
        public void ProfileConfigurationIsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<JobOffersProfile>());
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void ConvertFromJobOfferDtoIsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<JobOffersProfile>());
            var mapper = config.CreateMapper();

            var offerDto = Helpers.CreateNewJobOfferDto();
            var offer = Helpers.CreateNewJobOffer(offerDto.Id);

            var newOffer = mapper.Map<JobOffer>(offerDto);

            newOffer.Should().BeEquivalentTo(offer);
        }



        [Fact]
        public void ConvertFromJobOfferIsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<JobOffersProfile>());
            var mapper = config.CreateMapper();

            var offer = Helpers.CreateNewJobOffer();
            var offerDto = Helpers.CreateNewJobOfferDto(offer.Id);

            var newOfferDto = mapper.Map<JobOfferDto>(offer);

            newOfferDto.Should().BeEquivalentTo(offerDto);
        }
    }
}
