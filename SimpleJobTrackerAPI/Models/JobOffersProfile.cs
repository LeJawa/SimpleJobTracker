using AutoMapper;

namespace SimpleJobTrackerAPI.Models
{
    public class JobOffersProfile : Profile
    {
        public JobOffersProfile() 
        {
            CreateMap<JobOfferModel, JobOfferDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => src.Status.Description))
                .ForMember(dest => dest.JobTypeDescription, opt => opt.MapFrom(src => src.JobType.Description));
        }
    }
}
