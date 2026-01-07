using AutoMapper;
using Entity.DTOs;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RegistrationDto, Student>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.StudentNumber));

            CreateMap<RegistrationDto, Admin>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<RegistrationDto, LaundryMan>()
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));


        }

        
    }
}
