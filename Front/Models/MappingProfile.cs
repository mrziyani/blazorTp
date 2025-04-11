using AutoMapper;

namespace Front.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Comment, CreateComment>().ReverseMap();
            //CreateMap<Comment, CommentWithUser>()
   // .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

        }
    }
}
