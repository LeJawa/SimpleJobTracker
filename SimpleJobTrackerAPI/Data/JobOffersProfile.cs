using AutoMapper;
using SimpleJobTrackerAPI.Models;

namespace SimpleJobTrackerAPI.Data
{
    public class JobOffersProfile : Profile
    {
        public JobOffersProfile()
        {
            CreateMap<JobOffer, JobOfferDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.JobTypeDescription, opt => opt.MapFrom(src => src.JobType.ToString()))
                .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
