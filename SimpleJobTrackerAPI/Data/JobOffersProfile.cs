using AutoMapper;
using SimpleJobTrackerAPI.Enums;
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


            CreateMap<JobOfferDto, JobOffer>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => new Company() { Name = src.CompanyName }))
                .ForMember(dest => dest.JobType, opt => opt.MapFrom(src => Enum.Parse<JobType>(src.JobTypeDescription)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<JobStatus>(src.StatusDescription)))
                .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                .ForMember(x => x.CreationDate, opt => opt.Ignore());
        }
    }
}
