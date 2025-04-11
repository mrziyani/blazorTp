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
            CreateMap<Comment, CommentWithUserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
            CreateMap<Post, PostDto>().ReverseMap();

        }
    }

}
