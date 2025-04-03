using System;
using System.Collections.Generic;
using DAL.Models;
namespace Service
{
    using AutoMapper;
    using Service.DTO;
    

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}
