using AutoMapper;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Models.Dtos.PersonHistoryDtos;
using SchoolRegisterApp.Models.Dtos.PersonSchoolDtos;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Models.Entities;

namespace SchoolRegisterApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<PersonDetailsDto, Person>()
            //    .ForMember(m => m.BirthPlace.Name, cfg => cfg.MapFrom(src => src.BirthPlace))
            //    .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
            //    .ForMember(m => m.MiddleName, cfg => cfg.MapFrom(src => src.MiddleName))
            //    .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
            //    .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic))
            //    .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
            //    .ForMember(m => m.Gender, cfg => cfg.MapFrom(src => src.Gender));



            CreateMap<Users, UserDto>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.School, cfg => cfg.MapFrom(src => src.School))
               .ForMember(m => m.Username, cfg => cfg.MapFrom(src => src.Username))
               .ForMember(m => m.Phone, cfg => cfg.MapFrom(src => src.Phone));


            CreateMap<School, SchoolDto>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name))
               .ForMember(m => m.NameAlt, cfg => cfg.MapFrom(src => src.NameAlt))
               .ForMember(m => m.Type, cfg => cfg.MapFrom(src => src.Type))
               .ForMember(m => m.Settlement, cfg => cfg.MapFrom(src => src.Settlement))
               .ForMember(m => m.IsActive, cfg => cfg.MapFrom(src => src.IsActive));

            CreateMap<AddSchoolDto, School>()
               .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name))
               .ForMember(m => m.NameAlt, cfg => cfg.MapFrom(src => src.NameAlt))
               .ForMember(m => m.Type, cfg => cfg.MapFrom(src => src.Type))
               .ForMember(m => m.SettlementId, cfg => cfg.MapFrom(src => src.SettlementId))
               .ForMember(m => m.Settlement, cfg => cfg.MapFrom(src => src.Settlement))
               .ForMember(m => m.IsActive, cfg => cfg.MapFrom(src => src.IsActive));

            //CreateMap<School, SchoolIdAndNameDto>()
            //    .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
            //    .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name));

            CreateMap<Person, PersonDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
                .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
                .ForMember(m => m.BirthPlace, cfg => cfg.MapFrom(src => src.BirthPlace))
                .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic));

            CreateMap<Person, PersonDetailsDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(m => m.MiddleName, cfg => cfg.MapFrom(src => src.MiddleName))
                .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
                .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
                .ForMember(m => m.SchoolId, cfg => cfg.MapFrom(src => src.SchoolId))
                .ForMember(m => m.School, cfg => cfg.MapFrom(src => src.School))
                .ForMember(m => m.BirthPlaceId, cfg => cfg.MapFrom(src => src.BirthPlaceId))
                .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic))
                .ForMember(m => m.Gender, cfg => cfg.MapFrom(src => src.Gender));

            CreateMap<PersonHistory, PersonHistoryDto>()
                .ForMember(m => m.UserId, cfg => cfg.MapFrom(src => src.UserId))
                .ForMember(m => m.PersonId, cfg => cfg.MapFrom(src => src.PersonId))
                .ForMember(m => m.DataModified, cfg => cfg.MapFrom(src => src.DataModified))
                .ForMember(m => m.ActionDate, cfg => cfg.MapFrom(src => src.ActionDate))
                .ForMember(m => m.ModificationType, cfg => cfg.MapFrom(src => src.ModificationType))
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id));

            CreateMap<PersonSchool, PersonSchoolDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.PersonId, cfg => cfg.MapFrom(src => src.PersonId))
                .ForMember(m => m.SchoolId, cfg => cfg.MapFrom(src => src.SchoolId))
                .ForMember(m => m.Position, cfg => cfg.MapFrom(src => src.Position))
                .ForMember(m => m.StartDate, cfg => cfg.MapFrom(src => src.StartDate))
                .ForMember(m => m.EndDate, cfg => cfg.MapFrom(src => src.EndDate));

            //CreateMap<PersonSchoolAddDto, PersonSchool>()
            //    .ForMember(m => m.PersonId, cfg => cfg.MapFrom(src => src.PersonId))
            //    .ForMember(m => m.SchoolId, cfg => cfg.MapFrom(src => src.SchoolId))
            //    .ForMember(m => m.Position, cfg => cfg.MapFrom(src => src.Position))
            //    .ForMember(m => m.StartDate, cfg => cfg.MapFrom(src => src.StartDate))
            //    .ForMember(m => m.EndDate, cfg => cfg.MapFrom(src => src.EndDate));

            CreateMap<PersonDetailsDto, Person>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.FirstName, cfg => cfg.MapFrom(src => src.FirstName))
               .ForMember(m => m.MiddleName, cfg => cfg.MapFrom(src => src.MiddleName))
               .ForMember(m => m.LastName, cfg => cfg.MapFrom(src => src.LastName))
               .ForMember(m => m.BirthDate, cfg => cfg.MapFrom(src => src.BirthDate))
               .ForMember(m => m.BirthPlaceId, cfg => cfg.MapFrom(src => src.BirthPlaceId))
               .ForMember(m => m.Uic, cfg => cfg.MapFrom(src => src.Uic))
               .ForMember(m => m.Gender, cfg => cfg.MapFrom(src => src.Gender));

            CreateMap<Settlement, SettlementDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name));
        }
    }
}
