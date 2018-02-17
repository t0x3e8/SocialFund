using AutoMapper;
using SF.App.Models.Data;
using SF.App.Models.ViewModels;

namespace SF.App.Models {
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Employee, HomeIndexViewModel>()
                .ForMember(dest => dest.DirectManager, opt => opt.MapFrom(src => src.Manager))
                .ForMember(dest => dest.HiredDate, opt => opt.MapFrom(src => src.HiredDate.ToShortDateString()))
                .ForMember(dest => dest.IsModelEmpty, opt => opt.Ignore());
            
            // CreateMap<HomeIndexViewModel, Employee>()
            //     .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.DirectManager))
            //     .ForMember(dest => dest.RoleName, opt => opt.Ignore());
            
            CreateMap<Report, ReportIndexViewModel>()
                .ForMember(dest => dest.ReportName, opt =>  opt.ResolveUsing<ReportTypeResolver>())// opt.ResolveUsing<ReportTypeResolver, ReportType>(src => src.Type)),
                .ForMember(dest => dest.SubmissionDate, opt => opt.MapFrom(src => src.SubmissionDate.ToShortDateString()));
        }
    }
}