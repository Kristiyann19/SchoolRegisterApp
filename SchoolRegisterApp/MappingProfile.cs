using AutoMapper;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDetailsDto, Person>()
                .ForPath(m => m.BirthPlace.Name, cfg => cfg.MapFrom(src => src.BirthPlace))
                .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(m => m.MiddleName, cfg => cfg.MapFrom(src => src.MiddleName))
                .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
                .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic))
                .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
                .ForMember(m => m.Gender, cfg => cfg.MapFrom(src => src.Gender));



            CreateMap<Users, UserDto>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.School, cfg => cfg.MapFrom(src => src.School.Name))
               .ForMember(m => m.Username, cfg => cfg.MapFrom(src => src.Username))
               .ForMember(m => m.Phone, cfg => cfg.MapFrom(src => src.Phone));


            CreateMap<School, SchoolDto>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name))
               .ForMember(m => m.NameAlt, cfg => cfg.MapFrom(src => src.NameAlt))
               .ForMember(m => m.Type, cfg => cfg.MapFrom(src => src.Type))
               .ForMember(m => m.Settlement, cfg => cfg.MapFrom(src => src.Settlement.Name))
               .ForMember(m => m.IsActive, cfg => cfg.MapFrom(src => src.IsActive));


            CreateMap<Person, PersonDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
                .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
                .ForMember(m => m.BirthPlace, cfg => cfg.MapFrom(src => src.BirthPlace.Name))
                .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic));
<<<<<<< HEAD

            CreateMap<Person, PersonDetailsDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(m => m.MiddleName, cfg => cfg.MapFrom(src => src.MiddleName))
                .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
                .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
                .ForMember(m => m.BirthPlace, cfg => cfg.MapFrom(src => src.BirthPlace.Name))
                .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic))
                .ForMember(m => m.Gender, cfg => cfg.MapFrom(src => src.Gender));
=======
>>>>>>> 4ede17321f1a302f9e3a1a52a445dcf64322833c

            CreateMap<PersonAddDto, Person>()
                .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(m => m.MiddleName, cfg => cfg.MapFrom(src => src.MiddleName))
                .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
                .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
                .ForMember(m => m.BirthPlaceId, cfg => cfg.MapFrom(src => src.BirthPlaceId))
                .ForMember(m => m.Gender, cfg => cfg.MapFrom(src => src.Gender))
                .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic));

        CreateMap<Settlement, SettlementDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name));
        }
    }
}
