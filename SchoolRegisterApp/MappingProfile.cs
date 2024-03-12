﻿using AutoMapper;
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
               .ForMember(m => m.Username, cfg => cfg.MapFrom(src => src.Username))
               .ForMember(m => m.Phone, cfg => cfg.MapFrom(src => src.Phone));

            CreateMap<School, SchoolDto>()
               .ForMember(m => m.Id, cfg => cfg.MapFrom(src => src.Id))
               .ForMember(m => m.Name, cfg => cfg.MapFrom(src => src.Name))
               .ForMember(m => m.NameAlt, cfg => cfg.MapFrom(src => src.NameAlt))
               .ForMember(m => m.Type, cfg => cfg.MapFrom(src => src.Type))
               .ForMember(m => m.Settlement, cfg => cfg.MapFrom(src => src.Settlement.Name))
               .ForMember(m => m.IsActive, cfg => cfg.MapFrom(src => src.IsActive));

        }
    }
}
