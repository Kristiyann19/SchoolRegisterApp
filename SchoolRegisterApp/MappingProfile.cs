using AutoMapper;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Entities;

namespace SchoolRegisterApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserDto>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.School, cfg => cfg.MapFrom(src => src.School.Name))
               .ForMember(m => m.UserName, cfg => cfg.MapFrom(src => src.Username))
               .ForMember(m => m.Phone, cfg => cfg.MapFrom(src => src.Phone));

        }
    }
}
